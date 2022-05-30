using MySqlX.XDevAPI.Relational;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Media_Bazaar
{
    public class ScheduleManagement
    {
        private DBConnection DBConnection;

        public ScheduleManagement()
        {
            DBConnection = new DBConnection();
        }

        public DataTable ShowAllSchedule()
        {
            return DBConnection.SelectAllSchedules();
        }

        public DataTable ShowShift(int employeeId, int workWeek)
        {
            return DBConnection.SelectShift(employeeId, workWeek);
        }
        public int ShowWorkingHoursPerWeek(int employeeId, int workWeek)
        {
            return DBConnection.SelectWorkingHoursPerWeek(employeeId, workWeek);
        }
        public DataTable ShowAllShifts(int workWeek)
        {
            return DBConnection.SelectAllShifts(workWeek);
        }
        public DataTable ShowShifts(int selectedScheduleId)
        {
            return DBConnection.SelectShifts(selectedScheduleId);
        }
        public bool AddSchedule(int department, int shiftType, int jobPosition, int employeesPerShift, int day)
        {
            string query = $"INSERT INTO `schedule` (`day_id` ,`department_id`, `shift_type_id`, `position_id`, `number_per_shift`) VALUES ({day},{department}, {shiftType}, {jobPosition}, '{employeesPerShift}'); ";

            var isAdded = DBConnection.InsertOrUpdateOrDel(query);
            return isAdded;
        }

        public bool UpdateSchedule(int department, int shiftType, int jobPosition, int employeesPerShift, int day, int scheduleId)
        {
            string query = $"UPDATE `schedule` SET `day_id`={day} ,`department_id`={department}, `shift_type_id`={shiftType}, `position_id`={jobPosition}, `number_per_shift` = {employeesPerShift} WHERE ID = {scheduleId}; ";

            var isUpdated = DBConnection.InsertOrUpdateOrDel(query);
            return isUpdated;
        }
        public bool DeleteShiftsPerSchedule(int scheduleId)
        {
            string query = $"DELETE FROM shift WHERE schedule_id = {scheduleId}";

            var isDeleted = DBConnection.InsertOrUpdateOrDel(query);
            return isDeleted;
        }
        public bool AddWorkWeek(int year, int workWeek)
        {
            string query = $"INSERT INTO `work_week` (`ID` ,`year`, `week`) VALUES (null,{year}, {workWeek}); ";

            var isAdded = DBConnection.InsertOrUpdateOrDel(query);
            return isAdded;
        }
        public bool AddWorkDay(int weekWork, int dayOfWeek, int month, int dayOfMonth)
        {
            string query = $"INSERT INTO `work_day` (`ID` ,`work_week_id`, `day_of_week_id`, `month_id`, `day_of_month`) VALUES (null,{weekWork}, {dayOfWeek}, {month}, {dayOfMonth}); ";

            var isAdded = DBConnection.InsertOrUpdateOrDel(query);
            return isAdded;
        }
        public List<ShiftType> PopulateComboDepotShiftType()
        {
            return DBConnection.SelectAllShiftTypesDepot();
        }

        public bool CreateSchedule(DateTime firstDay, DateTime lastDay, Department department, int numberPerShiftMorning, int numberPerShiftAfternoon, int numberPerShiftNight, int positionId, Dictionary<int, int> shiftTypesPerDepartment)
        {

            TimeSpan difference = lastDay - firstDay;
            int interval = difference.Days;
            
            for (int i = 0; i <= interval; i++)
            {
                DateTime currentDay = firstDay.AddDays(i);

                int year = currentDay.Year;
                int month = currentDay.Month;
                int workWeek = WeekOneFromNewYear(currentDay);
                int dayOfWeek = ((int)currentDay.DayOfWeek == 0) ? 7 : (int)currentDay.DayOfWeek;
                int day = currentDay.Day;




                if (!IsWorkWeeKExists(year, workWeek))
                {
                    bool result = AddWorkWeek(year, workWeek);
                    if (!result)
                    {
                        return false;
                    }
                }
                if (!IsWorkDayExists(workWeek, dayOfWeek, month, day))
                {
                    bool result = AddWorkDay(workWeek, dayOfWeek, month, day);
                    if (!result)
                    {
                        return false;
                    }
                }
                int workDayId = GetWorkDayId(workWeek, dayOfWeek, month, day);


                if (!IsScheduleExists(department.id, workDayId))
                {
                    foreach (KeyValuePair<int, int> entry in shiftTypesPerDepartment)
                    {
                        bool result = AddSchedule(department.id, entry.Key, positionId, entry.Value, workDayId);
                        if (!result)
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    foreach (KeyValuePair<int, int> entry in shiftTypesPerDepartment)
                    {

                        int scheduleId = GetScheduleId(department.id, workDayId, entry.Key);
                        bool isDeleted = DeleteShiftsPerSchedule(scheduleId);
                        if (!isDeleted)
                        {
                            return false;
                        }
                        bool result = UpdateSchedule(department.id, entry.Key, positionId, entry.Value, workDayId, scheduleId);
                        if (!result)
                        {
                            return false;
                        }
                    }

                }
            }
            return true;
        }



        public bool AutomaticallyAssignEmployeesToShifts(Department department, int workWeekid)
        {

            DataTable schedulesDt = ShowSchedulesForAssignemntPerWeek(department.id, workWeekid);
            int previousWorkday = -1;
            int neededShiftsPerDay = 0;
            bool lessEmployeesThanNeeded = false;
            List<int> allEmployees = SelectEmployeesPerDepartment(department.id);


            Dictionary<int, List<int>> previousDayEmployees = new Dictionary<int, List<int>>(); // key: shiftTypeId , value: list of employeeId
            Dictionary<int, List<int>> currentDayEmployees = new Dictionary<int, List<int>>(); // key: shiftTypeId , value: list of employeeId


            int scheduleIdForCalculation = -1;
            Dictionary<int, int> employeeHours = new Dictionary<int, int>(); // key: employeeId , value: hours per week
            Dictionary<int, int> employeeShifts = new Dictionary<int, int>(); // key: employeeId , value: shifts per day 

            int currentDayFirstShiftPeople = 0;
            int currentDaySecondShiftPeople = 0;

            int employesForFirstShift = 0;
            int employesForSecondShift = 0;
            int employesForThirdShift = 0;

            // initialize employees 
            foreach (int employeeId in allEmployees)
            {
                employeeHours.Add(employeeId, 0);
                employeeShifts.Add(employeeId, 0);

            }

            //logic
            List<int> firstShiftEmployees = new List<int>();
            List<int> secondShiftEmployees = new List<int>();

            foreach (DataRow schedule in schedulesDt.Rows)
            {


                List<int> employeesPerShift = new List<int>();
                int currentDateYear = Convert.ToInt32(schedule["Year"]);
                int currentDateMonth = Convert.ToInt32(schedule["Month"]);
                int currentDateDay = Convert.ToInt32(schedule["Day"]);
                int currentWorkDay = Convert.ToInt32(schedule["WorkDay"]);
                int currentShift = Convert.ToInt32(schedule["Shift"]);
                int currentPeople = Convert.ToInt32(schedule["People"]);
                int scheduleId = Convert.ToInt32(schedule["ID"]);
                DeleteShiftsPerSchedule(scheduleId); // clear shifts


                if (previousWorkday != currentWorkDay)
                {
                    foreach (int employeeId in allEmployees)
                    {

                        employeeShifts[employeeId] = 0;
                    }

                    currentDayFirstShiftPeople = 0;
                    currentDaySecondShiftPeople = 0;
                    previousWorkday = currentWorkDay;
                    firstShiftEmployees = new List<int>();
                    secondShiftEmployees = new List<int>();

                }

                if (scheduleIdForCalculation == -1)
                {
                    int neededPeopleFirstShift = 0;
                    int neededPeopleSecondShift = 0;
                    int neededPeopleThirdShift = 0;
                    DataTable dataSchedule = ShowSchedulePerDay(currentWorkDay);
                    int i = 1;
                    foreach (DataRow dtRow in dataSchedule.Rows)
                    {
                        int numberOfPeople = Convert.ToInt32(dtRow["Employees per shift"]);
                        neededShiftsPerDay += numberOfPeople;
                        switch (i)
                        {
                            case 1:
                                {
                                    neededPeopleFirstShift = numberOfPeople;
                                    break;
                                }
                            case 2:
                                {
                                    neededPeopleSecondShift = numberOfPeople;
                                    break;
                                }
                            case 3:
                                {
                                    neededPeopleThirdShift = numberOfPeople;
                                    break;
                                }

                        }
                        i++;

                    }
                    scheduleIdForCalculation = neededShiftsPerDay * 7;
                    if (scheduleIdForCalculation > allEmployees.Count * 10)
                    {
                        lessEmployeesThanNeeded = true;
                        int availableShiftsPerDay = allEmployees.Count * 10 / 7; // 14.2
                        int availableEmployeesPerShift1 = availableShiftsPerDay / 3; // 4.34
                        int availableEmployeesPerShift2 = availableShiftsPerDay / 3; // 4.34
                        int availableEmployeesPerShift3 = availableShiftsPerDay / 3; // 4.34
                        int fraction = availableShiftsPerDay % 3;
                        int tmp = 0;
                        bool shift1 = false;
                        bool shift2 = false;
                        bool shift3 = false;
                        if (neededPeopleFirstShift <= availableEmployeesPerShift1)
                        {
                            shift1 = true;
                            tmp = availableEmployeesPerShift1 - neededPeopleFirstShift; // 2
                            availableEmployeesPerShift2 += tmp;
                            availableEmployeesPerShift1 = neededPeopleFirstShift; // 2
                        }
                        tmp = 0;
                        if (neededPeopleSecondShift <= availableEmployeesPerShift2)
                        {
                            shift2 = true;
                            tmp = availableEmployeesPerShift2 - neededPeopleSecondShift;
                            availableEmployeesPerShift3 += tmp;
                            availableEmployeesPerShift2 = neededPeopleSecondShift;
                        }
                        if (neededPeopleThirdShift <= availableEmployeesPerShift3)
                        {
                            shift3 = true;
                            availableEmployeesPerShift3 = neededPeopleThirdShift;
                        }
                        switch (fraction)
                        {
                            case 0:
                                {
                                    employesForFirstShift = availableEmployeesPerShift1;
                                    employesForSecondShift = availableEmployeesPerShift2;
                                    employesForThirdShift = availableEmployeesPerShift3;
                                }
                                break;
                            case 1:
                                {
                                    if (!shift1)
                                    {
                                        employesForFirstShift = availableEmployeesPerShift1 + 1;
                                    }
                                    else
                                    {
                                        employesForFirstShift = availableEmployeesPerShift1;
                                    }

                                    employesForSecondShift = availableEmployeesPerShift2;
                                    employesForThirdShift = availableEmployeesPerShift3;
                                }
                                break;
                            case 2:
                                {
                                    if (!shift1)
                                    {
                                        employesForFirstShift = availableEmployeesPerShift1 + 1;
                                    }
                                    else
                                    {
                                        employesForFirstShift = availableEmployeesPerShift1;
                                    }
                                    if (!shift2)
                                    {
                                        employesForSecondShift = availableEmployeesPerShift2 + 1;
                                    }
                                    else
                                    {
                                        employesForSecondShift = availableEmployeesPerShift2;
                                    }

                                    if (!shift3)
                                    {
                                        employesForThirdShift = availableEmployeesPerShift3 + 1;
                                    }
                                    else
                                    {
                                        employesForThirdShift = availableEmployeesPerShift3;
                                    }

                                }
                                break;

                        }
                    }
                }





                Dictionary<int, int> availableEmployeesHours = new Dictionary<int, int>(); // key: employeeId , value: hours per day 
                foreach (KeyValuePair<int, int> entry in employeeHours)
                {
                    if (entry.Value < 40 && employeeShifts[entry.Key] < 2)
                    {
                        availableEmployeesHours.Add(entry.Key, entry.Value);
                    }
                }

                foreach (KeyValuePair<int, int> item in availableEmployeesHours.OrderBy(key => key.Value))
                {

                    if (currentDayFirstShiftPeople == 0)
                    {
                        employeesPerShift.Add(item.Key);
                        employeeHours[item.Key] += 4;
                        employeeShifts[item.Key]++;
                        firstShiftEmployees.Add(item.Key);


                    }
                    if (currentDaySecondShiftPeople == 0 && currentDayFirstShiftPeople > 0)
                    {

                        employeesPerShift.Add(item.Key);
                        employeeHours[item.Key] += 4;
                        employeeShifts[item.Key]++;

                        secondShiftEmployees.Add(item.Key);

                    }
                    if (currentDaySecondShiftPeople > 0)
                    {
                        int availableEmployeesForThirdShift = availableEmployeesHours.Count - firstShiftEmployees.Count;

                        if (!firstShiftEmployees.Contains(item.Key))
                        {

                            employeesPerShift.Add(item.Key);
                            employeeHours[item.Key] += 4;
                            employeeShifts[item.Key]++;


                        }
                    }
                    if (lessEmployeesThanNeeded)
                    {

                        if (currentDaySecondShiftPeople == 0 && currentDayFirstShiftPeople > 0)
                        {
                            if (employeesPerShift.Count == employesForSecondShift)
                            {

                                break;

                            }
                        }
                        if (currentDayFirstShiftPeople == 0)
                        {
                            if (employeesPerShift.Count == employesForFirstShift)
                            {

                                break;

                            }
                        }
                        if (currentDayFirstShiftPeople > 0 && currentDaySecondShiftPeople > 0)
                        {
                            if (employeesPerShift.Count == employesForThirdShift)
                            {

                                break;

                            }
                        }

                    }
                    else
                    {
                        if (employeesPerShift.Count == currentPeople)
                        {

                            break;

                        }
                    }

                } // foreach availalableEmployeesHours

                if (currentDaySecondShiftPeople == 0 && currentDayFirstShiftPeople > 0)
                {
                    currentDaySecondShiftPeople = currentPeople;
                }

                if (currentDayFirstShiftPeople == 0)
                {
                    currentDayFirstShiftPeople = currentPeople;
                }


                //insert data for assignment of employee to schedule
                bool success = false;
                foreach (int employeeId in employeesPerShift)
                {
                    success = AddEmployeeToSchedule(employeeId, scheduleId);
                    if (!success)
                    {
                        return false;
                    }
                }
                //   previousShift = currentShift;

            }
            return true;
        }



        // This presumes that weeks start with Monday.
        // Week 1 is the 1st week of the year with a Thursday in it.
        public int WeekOneFromNewYear(DateTime time)
        {

            DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(time);
            if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
            {
                time = time.AddDays(3);
            }

            // Return the week of our adjusted day
            return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(time, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }



        public List<Position> LoadShiftPositions()
        {
            return DBConnection.GetShiftPositions();
        }

        public bool AddEmployeeToSchedule(int employeeId, int scheduleId)
        {
            string query = $"INSERT INTO `shift` (`employee_id`, `schedule_id`) VALUES ({employeeId}, {scheduleId}); ";

            var isAdded = DBConnection.InsertOrUpdateOrDel(query);
            return isAdded;
        }
        public bool RemoveShift( int scheduleId , int employeeId)
        {
            string query = $"DELETE FROM shift WHERE schedule_id = {scheduleId} AND employee_id = {employeeId} ";

            var isRemoved = DBConnection.InsertOrUpdateOrDel(query);
            return isRemoved;
        }

        public List<Position> PopulateComboboxRole()
        {
            return DBConnection.SelectAllRoles();
        }
        public List<Department> PopulateComboboxDepartment()
        {
            return DBConnection.SelectAllDepartments();
        }
        public List<ShiftType> PopulateComboboxShiftType()
        {
            return DBConnection.SelectAllShiftTypes();
        }

        public List<ShiftType> PopulateComboSalesShiftType()
        {
            return DBConnection.SelectAllShiftTypesSales();
        }

        public List<WorkWeek> PopulateComboboxWorkWeeks()
        {
            return DBConnection.SelectAllWorkWeeks();
        }

        public List<int> SelectShiftsPerDepartment(int departmentId)
        {
            return DBConnection.SelectShiftsPerDepartment(departmentId);
        }
        public DataTable ShowWorkDays(int weekWork)
        {
            return DBConnection.SelectWorkDays(weekWork);

        }
        public DataTable ShowSchedulesPerPeriod(int departmentId, int startDay, int startMonth, int startYear, int endDay, int endMonth, int endYear)
        {
            return DBConnection.SelectSchedulesPerPeriod(departmentId, startDay, startMonth, startYear, endDay, endMonth, endYear);

        }
        public DataTable ShowSchedulesFourWeeks(int departmentId, int workWeek)
        {
            return DBConnection.SelectSchedulesPerFourWeeks(departmentId, workWeek);

        }
        public DataTable ShowSchedulesForAssignemnt(int departmentId, int startDay, int startMonth, int startYear)
        {
            return DBConnection.SelectSchedulesForAssignment(departmentId, startDay, startMonth, startYear);

        }
        public DataTable ShowSchedulesForAssignemntPerWeek(int departmentId, int workWeekId)
        {
            return DBConnection.SelectSchedulesForAssignmentPerWeek(departmentId, workWeekId);

        }
        public bool IsWorkWeeKExists(int year, int workWeek)
        {
            return DBConnection.SelectIsWeekExists(year, workWeek) == 1;

        }
        public bool IsWorkDayExists(int weekWork, int dayOfWeek, int month, int dayOfMonth)
        {
            return DBConnection.SelectIsDayExists(weekWork, dayOfWeek, month, dayOfMonth) == 1;

        }
        public int GetWorkDayId(int weekWork, int dayOfWeek, int month, int dayOfMonth)
        {
            return DBConnection.SelectWorkDayId(weekWork, dayOfWeek, month, dayOfMonth);

        }
        public int GetScheduleId(int departmentId, int dayId, int shiftTypeId)
        {
            return DBConnection.SelectScheduleId(departmentId, dayId, shiftTypeId);

        }
        public int GetEmployeesPerShift(int scheduleId)
        {
            return DBConnection.SelectEmployeesPerShift(scheduleId);

        }
        public int GetOneScheduleId(int departmentId, int workWeek, int shiftTypeId, int dayOfWeek)
        {
            return DBConnection.SelectOneScheduleId(departmentId,workWeek,shiftTypeId,dayOfWeek);

        }
        public string GetMondayFromWeek(int workWeekId)
        {
            return DBConnection.SelectMondayFromWeek(workWeekId);

        }
        public string GetSundayFromWeek(int workWeekId)
        {
            return DBConnection.SelectSundayFromWeek(workWeekId);

        }
        public bool IsScheduleExists(int departmentId, int dayId)
        {
            return !(DBConnection.SelectIsScheduleExists(departmentId, dayId) == 0);

        }
        public bool IsSchiftExists(int employeeId, int scheduleId)
        {
            return !(DBConnection.SelectIsShiftExists(employeeId, scheduleId) == 0);

        }
        public DataTable ShowSchedulePerDay(int workDay)
        {
            return DBConnection.SelectSchedulesPerDay(workDay);

        }
        public DataTable SelectNumberOfPeoplePerShift(int deparmentId, int workWeekId)
        {
            return DBConnection.SelectNumberOfPeoplePerShift(deparmentId, workWeekId);

        }
        public List<int> SelectEmployeesPerDepartment(int departmentId)
        {
            return DBConnection.SelectEmployeesPerDepartment(departmentId);
        }
        public DataTable SelectPeoplePerShift(int deparmentId, int workWeekId)
        {
            return DBConnection.SelectPeoplePerShift(deparmentId, workWeekId);
        }
       
    }
}
