using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Media_Bazaar
{
    public partial class ManualScheduler : Form
    {
        AdministrationManagement administrationManagement = null;
        ScheduleManagement scheduleManagement = null;
        int department = 0;
        int workWeek = 0;
        int day = 0;
        int shift = 0;
        int scheduleId = 0;
        int numberOfPeopleNeeded = 0;
        public ManualScheduler(int department, int workWeek, int day, int shift)
        {
            InitializeComponent();
           
            administrationManagement = new AdministrationManagement();
            scheduleManagement = new ScheduleManagement();
            this.department = department;
            this.workWeek = workWeek;
            this.day = day;
            this.shift = shift;
            ShowEmployees();
            ShowComboBoxEmployees();
        }

        public void ShowEmployees()
        {
            lbEmployees.Items.Clear();
            DataTable numberOfPeopleDataTable = scheduleManagement.SelectNumberOfPeoplePerShift(department, workWeek);
            foreach (DataRow row in numberOfPeopleDataTable.Rows)
            {
                numberOfPeopleNeeded = Convert.ToInt32(row["People"]);
                int shiftSchedule = Convert.ToInt32(row["Shift"]);
                int daySchedule = Convert.ToInt32(row["Day"]);
                this.scheduleId = Convert.ToInt32(row["ID"]);
                if (day == daySchedule && shift == shiftSchedule)
                {
                    lbEmployees.Items.Add("Nr of people needed: " + numberOfPeopleNeeded);
                    lbEmployees.Items.Add("-------------------------------");
                    break;
                }


            }
            DataTable peopleDataTable = scheduleManagement.SelectPeoplePerShift(department, workWeek);
            foreach (DataRow row in peopleDataTable.Rows)
            {
                string name = row["Name"].ToString();
                int id = Convert.ToInt32(row["ID"]);
                EmployeeDataObject person = new EmployeeDataObject(id, name);
                int shiftSchedule = Convert.ToInt32(row["Shift"]);
                int daySchedule = Convert.ToInt32(row["Day"]);
                if (day == daySchedule && shift == shiftSchedule)
                {
                    lbEmployees.Items.Add(person);
                }
            }
        }

        public void ShowComboBoxEmployees()
        {
            var employees = administrationManagement.PopulateComboboxPartTimeEmployee(department);

            cmbEmployees.DisplayMember = "name";
            cmbEmployees.ValueMember = "id";
            cmbEmployees.DataSource = employees;
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                EmployeeDataObject employee = (EmployeeDataObject)cmbEmployees.SelectedItem;
                if (scheduleManagement.ShowWorkingHoursPerWeek(employee.GetId(), workWeek) >= 20)
                {
                    MessageBox.Show("This employee can't work more than 20 hours this week");
                    return;
                }
                if (scheduleManagement.IsSchiftExists(employee.id,scheduleId))
                {
                    
                    MessageBox.Show("Employee is already in this shift");
                    return;

                }
                else if (scheduleManagement.GetEmployeesPerShift(scheduleId)>=numberOfPeopleNeeded)
                {
                    MessageBox.Show($"Employees can not exceed {numberOfPeopleNeeded}");
                    return;
                }
                else
                {
                    scheduleManagement.AddEmployeeToSchedule(employee.id, scheduleId);
                    ShowEmployees();
                }
                
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                EmployeeDataObject selectedEmployee = (EmployeeDataObject)lbEmployees.SelectedItem;
                scheduleId = scheduleManagement.GetOneScheduleId(department, workWeek, shift, day);
                bool success= scheduleManagement.RemoveShift(scheduleId, selectedEmployee.id);
                ShowEmployees();
                if (success)
                {
                    MessageBox.Show("Employee's shift removed successfully");
                }
                else
                {
                    MessageBox.Show("Coudn't remove employee's shift");
                }
               

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
          
        }
    }
}