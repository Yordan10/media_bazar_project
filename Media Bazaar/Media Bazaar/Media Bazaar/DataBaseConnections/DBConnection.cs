using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Media_Bazaar
{
    public class DBConnection
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        //Constructor
        public DBConnection()
        {
            Initialize();
        }

        //Initialize values
        private void Initialize()
        {
            server = "studmysql01.fhict.local";
            database = "dbi450024";
            uid = "dbi450024";
            password = ",marwa004";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }

        //open connection to database
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        //Close connection
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        //Insert statement
        public bool InsertOrUpdateOrDel(string query)
        {
            try
            {
                if (this.OpenConnection() == true)
                {
                    //create command and assign the query and connection from the constructor
                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    //Execute command
                    cmd.ExecuteNonQuery();

                    //close connection
                    return true;
                }
                else
                {
                    return false;
                }
            }        
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                {
                    MessageBox.Show("You are trying to enter duplicate values.");
                    return false;
                }
                else
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
            finally
            {
                this.CloseConnection();

            }
        }
        public DataTable SelectAllStock()
        {
            try
            {
                DataTable dt = new DataTable();
                var sql = $"Select p.ID,p.Name,p.Model,p.Brand,p.Weight,p.Height,p.Depth,p.Barcode,p.Cost,pt.Name As Type, p.Price,p.Quantity from product p INNER JOIN product_type pt ON p.type_id=pt.ID";
                if (this.OpenConnection() == true)
                {
                    //Create Command
                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    dt.Load(dataReader);
                }
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                this.CloseConnection();

            }

        }
        public DataTable SelectAllProductsDataTable()
        {
            try
            {
                DataTable dt = new DataTable();
                var sql = $"Select p.ID,p.Name,p.Model,p.Brand,p.Weight,p.Height,p.Depth,p.Barcode,p.Cost,pt.Name As Type from product p INNER JOIN product_type pt ON p.type_id=pt.ID";
                if (this.OpenConnection() == true)
                {
                    //Create Command
                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    dt.Load(dataReader);
                }
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                this.CloseConnection();

            }
        }
        public DataTable SelectAllProductTyes()
        {
            try
            {
                DataTable dt = new DataTable();
                var sql = $"Select * from product_type";
                if (this.OpenConnection() == true)
                {
                    //Create Command
                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    dt.Load(dataReader);
                }
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                this.CloseConnection();

            }
        }
        public List<ProductType> SelectAllProductTyesList()
        {
            try
            {
                var pTypes = new List<ProductType>();
                var sql = $"Select * from product_type";
                if (this.OpenConnection() == true)
                {
                    //Create Command
                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        int id = Convert.ToInt32(dataReader["ID"]);
                        string name = dataReader["Name"].ToString();
                        pTypes.Add(new ProductType(id, name));
                    }
                    //close Data Reader
                    dataReader.Close();

                }
                return pTypes;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                this.CloseConnection();

            }
        }
        //Select statement
        public List<string> SelectStockTypes()
        {
            try
            {
                var stockTypes = new List<string>();
                var sql = $"SELECT name FROM dbi450024.product_type;";
                if (this.OpenConnection() == true)
                {
                    //Create Command
                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    //Read the data and store them in the list
                    while (dataReader.Read())
                    {
                        stockTypes.Add(Convert.ToString(dataReader["name"]));
                    }

                    //close Data Reader
                    dataReader.Close();
                    //return list to be displayed                  
                }
                return stockTypes;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                this.CloseConnection();

            }
        }
        public List<string> SelectStockNames()
        {
            try
            {
                var stockTypes = new List<string>();
                var sql = $"SELECT Distinct Name FROM dbi450024.stock;";
                if (this.OpenConnection() == true)
                {
                    //Create Command
                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    //Read the data and store them in the list
                    while (dataReader.Read())
                    {
                        stockTypes.Add(Convert.ToString(dataReader["Name"]));
                    }

                    //close Data Reader
                    dataReader.Close();
                    //return list to be displayed                  
                }
                return stockTypes;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                this.CloseConnection();

            }
        }
        public List<int> SelectEmployeesPerDepartment(int departmentId)
        {
            try
            {
                var employees = new List<int>();
                var sql = $"SELECT ID FROM employee WHERE department_id={departmentId} and IsFulltime = 1";
                if (this.OpenConnection() == true)
                {
                    //Create Command
                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    //Read the data and store them in the list
                    while (dataReader.Read())
                    {
                        employees.Add(Convert.ToInt32(dataReader["ID"]));
                    }

                    //close Data Reader
                    dataReader.Close();
                    //return list to be displayed                  
                }
                return employees;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                this.CloseConnection();

            }
        }
        public List<int> SelectShiftsPerDepartment(int departmentId)
        {
            try
            {
                var shifts = new List<int>();
                var sql = $"Select distinct shift_type_id AS ShiftId from schedule a where department_id ={departmentId} order by shift_type_id";
                if (this.OpenConnection() == true)
                {
                    //Create Command
                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    //Read the data and store them in the list
                    while (dataReader.Read())
                    {
                        shifts.Add(Convert.ToInt32(dataReader["ShiftId"]));
                    }

                    //close Data Reader
                    dataReader.Close();
                    //return list to be displayed                  
                }
                return shifts;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                this.CloseConnection();

            }
        }
        public DataTable SearchStockByTypes(int type)
        {
            try
            {
                DataTable dt = new DataTable();
                var sql = $"Select p.ID,p.Name,pt.Name As Type,p.Price,p.Quantity from product p INNER JOIN product_type pt ON p.type_id=pt.ID WHERE p.type_id={type}";
                if (this.OpenConnection() == true)
                {
                    //Create Command
                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    dt.Load(dataReader);
                }
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                this.CloseConnection();

            }
        }
        public DataTable SearchProductByTypes(int typeID)
        {
            try
            {
                DataTable dt = new DataTable();
                var sql = $"Select p.ID,p.Name,pt.Name As Type from product p INNER JOIN product_type pt ON p.type_id=pt.ID WHERE p.type_id={typeID}";
                if (this.OpenConnection() == true)
                {
                    //Create Command
                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    dt.Load(dataReader);
                }
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                this.CloseConnection();

            }
        }

        //Count statement
        public int Count()
        {
            return 0;
        }
        public DataTable SelectAllEmployees()
        {
            try
            {
                DataTable dt = new DataTable();
                var sql = $"Select * from employee ";
                if (this.OpenConnection() == true)
                {
                    //Create Command
                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    dt.Load(dataReader);
                }
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                this.CloseConnection();

            }
        }
      
        public DataTable SelectEmployeesInfo()
        {
            try
            {
                DataTable dt = new DataTable();
                var sql = $"SELECT a.ID, a.FirstName,a.Surname,a.Email,a.PhoneNumber,b.Name Position FROM employee a, employee_position b WHERE a.PositionID = b.ID";
                if (this.OpenConnection() == true)
                {
                    //Create Command
                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    dt.Load(dataReader);
                }
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                this.CloseConnection();

            }
        }
        public List<Position> GetShiftPositions()
        {
            try
            {
                var positions = new List<Position>();
                var sql = $"SELECT  id,name  FROM dbi450024.employee_position ;";
                if (this.OpenConnection() == true)
                {
                    //Create Command
                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    //Read the data and store them in the list
                    while (dataReader.Read())
                    {
                        int id = Convert.ToInt32(dataReader["ID"]);
                        string name = dataReader["name"].ToString();
                        Position p = new Position(id, name);
                        positions.Add(p);
                    }

                    //close Data Reader
                    dataReader.Close();
                    //return list to be displayed                  
                }
                return positions;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                this.CloseConnection();

            }
        }

        public DataTable SelectAllSchedules()
        {
            try
            {
                DataTable dt = new DataTable();
                var sql = $"SELECT a.ID, 'Date',a.number_per_shift 'People per shift',b.name Position , a.position_id 'Position id' FROM schedule a , employee_position b WHERE a.position_id = b.id ORDER BY a.position_id ";
                if (this.OpenConnection() == true)
                {
                    //Create Command
                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    dt.Load(dataReader);
                }
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                this.CloseConnection();

            }
        }
        public List<EmployeeDataObject> SelectEmployeesPerPosition(int selectedPosition)
        {

            try
            {
                var result = new List<EmployeeDataObject>();
                var sql = $"SELECT ID ,CONCAT(FirstName, \" \", Surname) AS Name FROM employee WHERE PositionId = {selectedPosition} ";
                if (this.OpenConnection() == true)
                {
                    //Create Command
                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    //Read the data and store them in the list
                    while (dataReader.Read())
                    {
                        int id = Convert.ToInt32(dataReader["ID"]);
                        string name = dataReader["Name"].ToString();
                        EmployeeDataObject e = new EmployeeDataObject(id, name);
                        result.Add(e);
                    }

                    //close Data Reader
                    dataReader.Close();
                    //return list to be displayed                  
                }
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                this.CloseConnection();

            }
        }
        public List<EmployeeDataObject> SelectPartTimeEmployeesPerDepartment(int departmentId)
        {

            try
            {
                var result = new List<EmployeeDataObject>();
                var sql = $"SELECT ID ,CONCAT(FirstName, \" \", Surname) AS Name FROM employee WHERE department_id = {departmentId} and IsFulltime = 0";
                if (this.OpenConnection() == true)
                {
                    //Create Command
                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    //Read the data and store them in the list
                    while (dataReader.Read())
                    {
                        int id = Convert.ToInt32(dataReader["ID"]);
                        string name = dataReader["Name"].ToString();
                        EmployeeDataObject e = new EmployeeDataObject(id, name);
                        result.Add(e);
                    }

                    //close Data Reader
                    dataReader.Close();
                    //return list to be displayed                  
                }
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                this.CloseConnection();

            }
        }
        public DataTable SelectShifts(int selectedSheduleId)
        {
            try
            {
                DataTable dt = new DataTable();
                var sql = $"SELECT CONCAT(FirstName, \" \", Surname) AS Name from employee a , shift b , schedule c where b.schedule_id = c.ID and b.employee_id = a.ID and b.schedule_id = {selectedSheduleId};";
                if (this.OpenConnection() == true)
                {
                    //Create Command
                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    dt.Load(dataReader);
                }
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                this.CloseConnection();

            }
        }
        public DataTable SelectShift(int employeeId, int workWeek)
        {
            
            try
            {
                string sql ="";
                if (workWeek ==-1)
                {
                    sql = $"SELECT f.name AS Day,e.day_of_month as Date,g.name as Month, d.name  AS Department, h.name as 'Shift type' FROM employee a, shift b, schedule c , department d , work_day e, day_of_week f , month g , shift_type h WHERE a.ID = b.employee_id AND b.schedule_id = c.ID and d.ID=c.department_id and c.day_id = e.ID and f.id=e.day_of_week_id and g.ID=e.month_id and h.id=c.shift_type_id AND employee_id = {employeeId} order by e.month_id , e.day_of_Month asc";
                }
                else
                {
                    sql = $"SELECT f.name AS Day,e.day_of_month as Date,g.name as Month, d.name  AS Department, h.name as 'Shift type' FROM employee a, shift b, schedule c , department d , work_day e, day_of_week f , month g , shift_type h WHERE a.ID = b.employee_id AND b.schedule_id = c.ID and d.ID=c.department_id and c.day_id = e.ID and f.id=e.day_of_week_id and g.ID=e.month_id and h.id=c.shift_type_id AND employee_id = {employeeId} AND e.work_week_id = {workWeek} order by e.month_id , e.day_of_Month asc";
                }
                DataTable dt = new DataTable();
                if (this.OpenConnection() == true)
                {
                    //Create Command
                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    dt.Load(dataReader);
                }
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                this.CloseConnection();

            }
        }
        public int SelectWorkingHoursPerWeek(int employeeId, int workWeek)
        {
            int result = 0;
            try
            {
                string sql = "";
                if (workWeek == -1)
                {
                    return result;
                }
                else
                {
                    sql = $"SELECT COUNT(*) * 4 AS Hours  FROM employee a, shift b, schedule c , department d , work_day e, day_of_week f , month g , shift_type h WHERE a.ID = b.employee_id AND b.schedule_id = c.ID and d.ID=c.department_id and c.day_id = e.ID and f.id=e.day_of_week_id and g.ID=e.month_id and h.id=c.shift_type_id AND employee_id = {employeeId} AND e.work_week_id = {workWeek}";
                }
               
                if (this.OpenConnection() == true)
                {
                    //Create Command
                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        result = Convert.ToInt32(dataReader["Hours"]);
                    }
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                
            }
            finally
            {
                this.CloseConnection();

            }
            return result;
        }

        public int SelectIsWeekExists(int year, int workWeek)
        {
            int result = 0;
            try
            {
                string sql = $"SELECT COUNT(*) AS IsWeekExists FROM work_week WHERE year={year} AND week = {workWeek}";
              
                if (this.OpenConnection() == true)
                {
                    //Create Command
                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        result = Convert.ToInt32(dataReader["IsWeekExists"]);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                this.CloseConnection();

            }
            return result;
        }
        public int SelectIsDayExists(int weekWork, int dayOfWeek, int month, int dayOfMonth)
        {
            int result = 0;
            try
            {
                string sql = $"SELECT COUNT(*) AS IsDayExists FROM work_day WHERE work_week_id={weekWork} AND day_of_week_id = {dayOfWeek} AND month_id = {month} AND day_of_month = {dayOfMonth}";

                if (this.OpenConnection() == true)
                {
                    //Create Command
                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        result = Convert.ToInt32(dataReader["IsDayExists"]);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                this.CloseConnection();

            }
            return result;
        }
        public int SelectWorkDayId(int weekWork, int dayOfWeek, int month, int dayOfMonth)
        {
            int result = 0;
            try
            {
                string sql = $"SELECT ID  FROM work_day WHERE work_week_id={weekWork} AND day_of_week_id = {dayOfWeek} AND month_id = {month} AND day_of_month = {dayOfMonth}";

                if (this.OpenConnection() == true)
                {
                    //Create Command
                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        result = Convert.ToInt32(dataReader["ID"]);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                this.CloseConnection();

            }
            return result;
        }
        public int SelectIsScheduleExists(int departmentId, int dayId)
        {
            int result = 0;
            try
            {
                string sql = $"SELECT COUNT(*) AS IsScheduleExists FROM schedule where department_id = {departmentId} AND day_id = {dayId}";

                if (this.OpenConnection() == true)
                {
                    //Create Command
                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        result = Convert.ToInt32(dataReader["IsScheduleExists"]);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                this.CloseConnection();

            }
            return result;
        }
        public int SelectIsShiftExists(int employeeid, int scheduleId)
        {
            int result = 0;
            try
            {
                string sql = $"SELECT COUNT(*) AS IsShiftExists FROM shift where schedule_id = {scheduleId} AND employee_id = {employeeid}";

                if (this.OpenConnection() == true)
                {
                    //Create Command
                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        result = Convert.ToInt32(dataReader["IsShiftExists"]);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                this.CloseConnection();

            }
            return result;
        }

        public int SelectEmployeesPerShift(int scheduleId)
        {
            int result = 0;
            try
            {
                string sql = $"SELECT COUNT(*) AS NumberOfEmployees FROM shift where schedule_id = {scheduleId}";

                if (this.OpenConnection() == true)
                {
                    //Create Command
                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        result = Convert.ToInt32(dataReader["NumberOfEmployees"]);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                this.CloseConnection();

            }
            return result;
        }
        public int SelectScheduleId(int departmentId, int dayId, int shiftTypeId)
        {
            int result = 0;
            try
            {
                string sql = $"SELECT ID FROM schedule where department_id = {departmentId} AND day_id = {dayId} AND shift_type_id = {shiftTypeId} ";

                if (this.OpenConnection() == true)
                {
                    //Create Command
                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        result = Convert.ToInt32(dataReader["ID"]);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                this.CloseConnection();

            }
            return result;
        }

        public int SelectOneScheduleId(int departmentId, int workWeek, int shiftTypeId, int dayOfWeek)
        {
            int result = 0;
            try
            {
                string sql = $" SELECT c.ID AS ID FROM   schedule c, department d , work_day e, day_of_week f , shift_type h WHERE d.ID = c.department_id and c.day_id = e.ID and f.id = e.day_of_week_id  and h.id = c.shift_type_id and h.ID = {shiftTypeId} and c.department_id = {departmentId} and f.ID = {dayOfWeek} and e.work_week_id = {workWeek} ";

                if (this.OpenConnection() == true)
                {
                    //Create Command
                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        result = Convert.ToInt32(dataReader["ID"]);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                this.CloseConnection();

            }
            return result;
        }
        public string SelectSundayFromWeek(int workWeekID)
        {
            string result = "";
            try
            {
                string sql = $"SELECT concat( a.day_of_month , '-' , a.month_id , '-' ,b.year) as Date  from work_day a, work_week b where a.work_week_id=b.ID and a.work_week_id= {workWeekID} and a.day_of_week_id =  (select  max(day_of_week_id) from work_day where work_week_id={workWeekID}) ";

                if (this.OpenConnection() == true)
                {
                    //Create Command
                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        result = dataReader["Date"].ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                this.CloseConnection();

            }
            return result;
        }
        public string SelectMondayFromWeek(int workWeekID)
        {
            string result = "";
            try
            {
                string sql = $"SELECT concat( a.day_of_month , '-' , a.month_id , '-' ,b.year) as Date  from work_day a, work_week b where a.work_week_id=b.ID and a.work_week_id= {workWeekID} and a.day_of_week_id =  (select  min(day_of_week_id) from work_day where work_week_id={workWeekID}) ";

                if (this.OpenConnection() == true)
                {
                    //Create Command
                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        result = dataReader["Date"].ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                this.CloseConnection();

            }
            return result;
        }
        public DataTable SelectAllShifts(int workWeek)
        {
            try
            {
                string sql = "";
                if (workWeek==-1)
                {
                    sql = $" SELECT a.UserName,f.name AS Day,e.day_of_month as Date,g.name as Month, d.name  AS Department, h.name as 'Shift type' FROM employee a, shift b, schedule c , department d , work_day e, day_of_week f , month g , shift_type h WHERE a.ID = b.employee_id AND b.schedule_id = c.ID and d.ID=c.department_id and c.day_id = e.ID and f.id=e.day_of_week_id and g.ID=e.month_id and h.id=c.shift_type_id order by e.month_id , e.day_of_Month asc";
                }
                else
                {
                    sql = $" SELECT a.UserName,f.name AS Day,e.day_of_month as Date,g.name as Month, d.name  AS Department, h.name as 'Shift type' FROM employee a, shift b, schedule c , department d , work_day e, day_of_week f , month g , shift_type h WHERE a.ID = b.employee_id AND b.schedule_id = c.ID and d.ID=c.department_id and c.day_id = e.ID and f.id=e.day_of_week_id and g.ID=e.month_id and h.id=c.shift_type_id AND e.work_week_id = {workWeek} order by e.month_id , e.day_of_Month asc";
                }
                DataTable dt = new DataTable();
                if (this.OpenConnection() == true)
                {
                    //Create Command
                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    dt.Load(dataReader);
                }
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                this.CloseConnection();

            }
        }

        public DataTable SelectWorkDays(int weekWork)
        {
            try
            {
                DataTable dt = new DataTable();
                var sql = $" SELECT a.ID as 'Day_id' , b.name AS 'Day of week', a.day_of_Month AS 'Date', c.name AS 'Month'  FROM work_day a,day_of_week b, month c WHERE a.day_of_week_id = b.ID AND a.month_id = c.ID AND a.work_week_id = {weekWork} ORDER BY b.ID";
                if (this.OpenConnection() == true)
                {
                    //Create Command
                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    dt.Load(dataReader);
                }
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                this.CloseConnection();

            }
        }

        public DataTable SelectSchedulesPerDay(int workDay)
        {
            try
            {
                DataTable dt = new DataTable();
                var sql = $" SELECT a.ID as 'Schedule_id',d.name as 'Department', c.name as 'Shift type',b.name 'Position', a.number_per_shift 'Employees per shift',b.ID AS 'position_id' FROM schedule a , employee_position b , shift_type c, department d WHERE a.position_id = b.id and a.shift_type_id = c.ID and a.department_id = d.ID and a.day_id = {workDay}  ORDER BY d.ID , c.ID, a.position_id  ";
                if (this.OpenConnection() == true)
                {
                    //Create Command
                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    dt.Load(dataReader);
                }
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                this.CloseConnection();

            }
        }


        public DataTable SelectNumberOfPeoplePerShift(int deparmentId, int workWeekId)
        {
            try
            {
                DataTable dt = new DataTable();
                var sql = $"select a.ID as ID, a.number_per_shift AS People ,a.shift_type_id AS Shift, b.day_of_week_id AS Day from schedule a, work_day b  where a.department_id = {deparmentId} and a.day_id = b.ID  and b.work_week_id = {workWeekId} order by day_of_week_id, shift_type_id ";
                if (this.OpenConnection() == true)
                {
                    //Create Command
                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    dt.Load(dataReader);
                }
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                this.CloseConnection();

            }
        }

        public DataTable SelectPeoplePerShift(int deparmentId, int workWeekId)
        {
            try
            {
                DataTable dt = new DataTable();
                var sql = $"select d.ID AS ID , CONCAT(d.FirstName,' ',d.Surname) AS Name ,a.shift_type_id AS Shift, b.day_of_week_id AS Day , a.number_per_shift AS People, (Select count(*) from shift z  where a.ID=z.schedule_id ) AS Assigned from schedule a, work_day b , shift c, employee d where a.department_id = {deparmentId} and a.day_id = b.ID and d.ID = c.employee_id and a.id = c.schedule_id and b.work_week_id = {workWeekId} order by day_of_week_id, shift_type_id ";
                if (this.OpenConnection() == true)
                {
                    //Create Command
                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    dt.Load(dataReader);
                }
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                this.CloseConnection();

            }
        }

        public DataTable SelectSchedulesForAssignmentPerWeek(int departmentId, int workWeekId)
        {
            try
            {
                DataTable dt = new DataTable();
                var sql = $"select a.ID as ID, a.day_id as WorkDay, c.year AS Year, b.month_id AS Month, b.day_of_month AS Day, a.number_per_shift AS People, a.shift_type_id as Shift from schedule a, work_day b, work_week c where a.day_id = b.ID and b.work_week_id = c.ID  and a.department_id= {departmentId}  and c.ID = {workWeekId} order by c.year, b.month_id,b.day_of_month, a.shift_type_id ";
                if (this.OpenConnection() == true)
                {
                    //Create Command
                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    dt.Load(dataReader);
                }
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                this.CloseConnection();

            }
        }
        public DataTable SelectSchedulesForAssignment(int departmentId, int startDay, int startMonth, int startYear)
        {
            try
            {
                DataTable dt = new DataTable();
                var sql = $" select a.ID as ID, c.year AS Year, b.month_id AS Month, b.day_of_month AS Day, a.number_per_shift AS People, a.shift_type_id as Shift from schedule a, work_day b, work_week c where a.day_id = b.ID and b.work_week_id = c.ID and a.department_id= {departmentId} and STR_TO_DATE(CONCAT(c.year,'-',LPAD(b.month_id,2,'00'),'-',LPAD(b.day_of_Month,2,'00')),'%Y-%m-%d')  between  STR_TO_DATE(CONCAT({startYear},'-',LPAD({startMonth},2,'00'),'-',LPAD({startDay},2,'00')),'%Y-%m-%d') and STR_TO_DATE(CONCAT(9999,'-',LPAD(6,2,'00'),'-',LPAD(6,2,'00')),'%Y-%m-%d')  order by c.year, b.month_id,b.day_of_month, a.shift_type_id ";
                if (this.OpenConnection() == true)
                {
                    //Create Command
                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    dt.Load(dataReader);
                }
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                this.CloseConnection();

            }
        }

        public DataTable SelectSchedulesPerPeriod(int departmentId, int startDay, int startMonth, int startYear, int endDay, int endMonth, int endYear)
        {
            try
            {
                DataTable dt = new DataTable();
                var sql = $" SELECT a.ID as Schedule_id, e.day_of_Month as Day, e.month_id as Month, f.year,d.name as 'Department', c.name as 'Shift type', a.number_per_shift 'Employees per shift' FROM schedule a , employee_position b , shift_type c, department d, work_day e , work_week f WHERE a.position_id = b.id and a.shift_type_id = c.ID and a.department_id = d.ID and a.day_id = e.ID and e.work_week_id = f.week and a.department_id = {departmentId} and  STR_TO_DATE(CONCAT(f.year,'-',LPAD(e.month_id,2,'00'),'-',LPAD(e.day_of_Month,2,'00')),'%Y-%m-%d')  between  STR_TO_DATE(CONCAT({startYear},'-',LPAD({startMonth},2,'00'),'-',LPAD({startDay},2,'00')),'%Y-%m-%d') and STR_TO_DATE(CONCAT({endYear},'-',LPAD({endMonth},2,'00'),'-',LPAD({endDay},2,'00')),'%Y-%m-%d')  ORDER BY  f.year, e.month_id, e.day_of_Month,  c.ID, a.position_id  ";
                if (this.OpenConnection() == true)
                {
                    //Create Command
                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    dt.Load(dataReader);
                }
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                this.CloseConnection();

            }
        }
        public DataTable SelectSchedulesPerFourWeeks(int departmentId, int workWeek)
        {
            try
            {
                DataTable dt = new DataTable();
                var sql = $" SELECT a.ID as Schedule_id, CONCAT(e.day_of_Month, '.' , e.month_id) AS Date,e.day_of_week_id as Day, c.ID as 'Shift_type', a.number_per_shift 'People' FROM schedule a , employee_position b , shift_type c, department d, work_day e , work_week f WHERE a.position_id = b.id and a.shift_type_id = c.ID and a.department_id = d.ID and a.day_id = e.ID and e.work_week_id = f.week and a.department_id = {departmentId} and  e.work_week_id >= {workWeek} and  e.work_week_id < {workWeek + 4}  ORDER BY  f.year, e.month_id, e.day_of_Month,  c.ID ";
                if (this.OpenConnection() == true)
                {
                    //Create Command
                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    dt.Load(dataReader);
                }
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                this.CloseConnection();

            }
        }
        public List<Product> SelectAllProducts()
        {

            try
            {
                var result = new List<Product>();
                


                    var sql = $"SELECT ID ,name AS Name FROM product  ";
                    if (this.OpenConnection() == true)
                    {
                        //Create Command
                        MySqlCommand cmd = new MySqlCommand(sql, connection);
                        //Create a data reader and Execute the command
                        MySqlDataReader dataReader = cmd.ExecuteReader();

                        //Read the data and store them in the list
                        while (dataReader.Read())
                        {
                            int id = Convert.ToInt32(dataReader["ID"]);
                            string name = dataReader["Name"].ToString();
                            Product e = new Product(id, name);
                            result.Add(e);
                        }

                        //close Data Reader
                        dataReader.Close();
                        //return list to be displayed                  
                    }

                
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                this.CloseConnection();

            }
        }
        public List<Product> SelectAllProductsPerType(int selectedType)
        {

            try
            {
                var result = new List<Product>();
                if (selectedType != -1)
                {


                    var sql = $"SELECT ID ,name AS Name FROM product WHERE type_id = {selectedType} ";
                    if (this.OpenConnection() == true)
                    {
                        //Create Command
                        MySqlCommand cmd = new MySqlCommand(sql, connection);
                        //Create a data reader and Execute the command
                        MySqlDataReader dataReader = cmd.ExecuteReader();

                        //Read the data and store them in the list
                        while (dataReader.Read())
                        {
                            int id = Convert.ToInt32(dataReader["ID"]);
                            string name = dataReader["Name"].ToString();
                            Product e = new Product(id, name);
                            result.Add(e);
                        }

                        //close Data Reader
                        dataReader.Close();
                        //return list to be displayed                  
                    }
                    
                }
                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                this.CloseConnection();

            }
        }
        public List<Position> SelectAllRoles()
        {

            try
            {
                var result = new List<Position>();
                


                    var sql = $"SELECT ID ,name AS Name FROM employee_position ";
                    if (this.OpenConnection() == true)
                    {
                        //Create Command
                        MySqlCommand cmd = new MySqlCommand(sql, connection);
                        //Create a data reader and Execute the command
                        MySqlDataReader dataReader = cmd.ExecuteReader();

                        //Read the data and store them in the list
                        while (dataReader.Read())
                        {
                            int id = Convert.ToInt32(dataReader["ID"]);
                            string name = dataReader["Name"].ToString();
                            Position e = new Position(id, name);
                            result.Add(e);
                        }

                        //close Data Reader
                        dataReader.Close();
                        //return list to be displayed                  
                    }

                
                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                this.CloseConnection();

            }
        }

        public List<Department> SelectAllDepartments()
        {

            try
            {
                var result = new List<Department>();



                var sql = $"SELECT ID ,name AS Name FROM department ";
                if (this.OpenConnection() == true)
                {
                    //Create Command
                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    //Read the data and store them in the list
                    while (dataReader.Read())
                    {
                        int id = Convert.ToInt32(dataReader["ID"]);
                        string name = dataReader["Name"].ToString();
                        Department e = new Department(id, name);
                        result.Add(e);
                    }

                    //close Data Reader
                    dataReader.Close();
                    //return list to be displayed                  
                }


                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                this.CloseConnection();

            }
        }

        public List<ShiftType> SelectAllShiftTypes()
        {

            try
            {
                var result = new List<ShiftType>();



                var sql = $"SELECT ID ,name AS Name FROM shift_type ";
                if (this.OpenConnection() == true)
                {
                    //Create Command
                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    //Read the data and store them in the list
                    while (dataReader.Read())
                    {
                        int id = Convert.ToInt32(dataReader["ID"]);
                        string name = dataReader["Name"].ToString();
                        ShiftType e = new ShiftType(id, name);
                        result.Add(e);
                    }

                    //close Data Reader
                    dataReader.Close();
                    //return list to be displayed                  
                }


                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                this.CloseConnection();

            }
        }


        public List<ShiftType> SelectAllShiftTypesDepot()
        {

            try
            {
                var result = new List<ShiftType>();



                var sql = $"SELECT ID ,name AS Name FROM shift_type where id <= 3  ORDER BY id";
                if (this.OpenConnection() == true)
                {
                    //Create Command
                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    //Read the data and store them in the list
                    while (dataReader.Read())
                    {
                        int id = Convert.ToInt32(dataReader["ID"]);
                        string name = dataReader["Name"].ToString();
                        ShiftType e = new ShiftType(id, name);
                        result.Add(e);
                    }

                    //close Data Reader
                    dataReader.Close();
                    //return list to be displayed                  
                }


                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                this.CloseConnection();

            }
        }

        public List<ShiftType> SelectAllShiftTypesSales()
        {

            try
            {
                var result = new List<ShiftType>();



                var sql = $"SELECT ID ,name AS Name FROM shift_type where id > 3 ORDER BY id";
                if (this.OpenConnection() == true)
                {
                    //Create Command
                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    //Read the data and store them in the list
                    while (dataReader.Read())
                    {
                        int id = Convert.ToInt32(dataReader["ID"]);
                        string name = dataReader["Name"].ToString();
                        ShiftType e = new ShiftType(id, name);
                        result.Add(e);
                    }

                    //close Data Reader
                    dataReader.Close();
                    //return list to be displayed                  
                }


                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                this.CloseConnection();

            }
        }

        public List<WorkWeek> SelectAllWorkWeeks()
        {
            try
            {
                var result = new List<WorkWeek>();


                var sql = $"SELECT ID ,year AS Year, week AS Week FROM work_week ORDER BY year, week ";
                if (this.OpenConnection() == true)
            
                {
                    //Create Command
                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    //Read the data and store them in the list
                    while (dataReader.Read())
                    {
                        int id = Convert.ToInt32(dataReader["ID"]);
                        int year = Convert.ToInt32( dataReader["Year"]);
                        int week = Convert.ToInt32( dataReader["Week"]);
                        WorkWeek e = new WorkWeek(id, year,week);
                        result.Add(e);
                    }

                    //close Data Reader
                    dataReader.Close();
                    //return list to be displayed                  
                }


                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                this.CloseConnection();

            }
        }



        public List<ProductType> SelectAllProductTypes()
        {

            try
            {
                var result = new List<ProductType>();
                var sql = $"SELECT ID ,name AS Name FROM product_type";
                if (this.OpenConnection() == true)
                {
                    //Create Command
                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    //Read the data and store them in the list
                    while (dataReader.Read())
                    {
                        int id = Convert.ToInt32(dataReader["ID"]);
                        string name = dataReader["Name"].ToString();
                        ProductType p = new ProductType(id, name);
                        result.Add(p);
                    }

                    //close Data Reader
                    dataReader.Close();
                    //return list to be displayed                  
                }
                return result ;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                this.CloseConnection();

            }
        }

        public DataTable SelectAllRequests()
        {
            try
            {
                DataTable dt = new DataTable();
                var sql = $"SELECT r.ID,p.Name,pt.name As Type,r.Quantity,s.Name As Status FROM request r INNER JOIN product p On r.product_id=p.ID INNER JOIN product_type pt ON p.type_id=pt.ID INNER JOIN status s ON s.ID=r.status_id;";
                if (this.OpenConnection() == true)
                {
                    //Create Command
                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    dt.Load(dataReader);
                }
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                this.CloseConnection();

            }
        }

        public LoginDataObject Login(string username, string password)
        {
            try
            {
                int employeeId = -1;
                int employeePositionid = -1;
                var sql = $"SELECT ID, positionID FROM employee WHERE UserName = '{username}' AND password = '{password}';";
                if (this.OpenConnection() == true)
                {
                    //Create Command
                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    //Read the data and store them in the list

                    while (dataReader.Read())
                    {

                        employeeId = Convert.ToInt32(dataReader["ID"]);
                        employeePositionid = Convert.ToInt32(dataReader["positionId"]);


                    }
                    if (employeeId == -1)
                    {
                        MessageBox.Show("Invalid credentials");
                        return null;
                    }
                    //close Data Reader
                    dataReader.Close();
                    //return list to be displayed                  
                }
                return new LoginDataObject(employeeId, employeePositionid);
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                this.CloseConnection();

            }
        }

        public SaleRepresentative SelectSaleRepresentative(int employeeId)
        {
            try
            {

                var sql = $"SELECT * FROM employee WHERE ID = {employeeId} ";
                if (this.OpenConnection() == true)
                {
                    //Create Command
                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    //Read the data and store them in the list
                    dataReader.Read();

                    int id = Convert.ToInt32(dataReader["ID"]);
                    string fName = dataReader["FirstName"].ToString();
                    string username = dataReader["UserName"].ToString();
                    string password = dataReader["Password"].ToString();
                    string surname = dataReader["Surname"].ToString();
                    int position = Convert.ToInt32( dataReader["PositionID"]);
                    int phoneNumber = Convert.ToInt32(dataReader["PhoneNumber"]);
                    string address = dataReader["Address"].ToString();
                    DateTime birthDate = (DateTime)dataReader["BirthDate"];
                    string email = dataReader["Email"].ToString();
                    int isMarried = Convert.ToInt32(dataReader["IsMarried"]);
                    int bsn = Convert.ToInt32(dataReader["BSN"]);
                    string functions = dataReader["Functions"].ToString();
                    decimal salary = Convert.ToDecimal(dataReader["Salary"]);
                    int gender = Convert.ToInt32(dataReader["Gender"]);
                    DateTime startDate = (DateTime)dataReader["StartDate"];
                    string certificates = dataReader["Certificates"].ToString();
                    string languagesSpoken = dataReader["SpokenLanguages"].ToString();
                    //I a = dataReader["department_id"]
                    int? department =null;
                    bool isDepNotNull = !dataReader.IsDBNull(dataReader.GetOrdinal("department_id"));
                    int contract = Convert.ToInt32(dataReader["IsFulltime"]);
                    if (isDepNotNull)
                    {
                        department = Convert.ToInt32(dataReader["department_id"]);
                    }
                    

                    SaleRepresentative s = new SaleRepresentative(username,password,fName,surname,phoneNumber,address,birthDate,email,isMarried,bsn,functions,startDate,certificates,languagesSpoken,id,salary,gender,position,department,contract);
                    return s;

                    //close Data Reader
                    dataReader.Close();
                    //return list to be displayed                  
                }
                return null; 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                this.CloseConnection();

            }
        }
        public DataTable SelectAllEmployeesPerAge(int startage, int endage,string Department)
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = "";
                var sqlWithOutDep = $"Select TIMESTAMPDIFF(YEAR,`BirthDate`,NOW()) As Age, Count(*) As NoOfEmployees from employee where TIMESTAMPDIFF(YEAR,`BirthDate`,NOW()) BETWEEN {startage} AND {endage} Group By Age";
                var sqlWithDep = $"Select TIMESTAMPDIFF(YEAR,`BirthDate`,NOW()) As Age, Count(*) As NoOfEmployees from employee E INNER JOIN employee_position EP ON E.PositionID=EP.ID WHERE EP.Name='{Department}' AND TIMESTAMPDIFF(YEAR,`BirthDate`,NOW()) BETWEEN {startage} AND {endage} Group By Age";

                if (String.IsNullOrEmpty(Department))
                {
                    sql = sqlWithOutDep;
                }
                else
                {
                    sql = sqlWithDep;
                }
                if (this.OpenConnection() == true)
                {
                    //Create Command
                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    dt.Load(dataReader);
                }
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public DataTable SelectAllEmployeesByGender(string Department)
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = "";
                var sqlWithOutDep = $"Select IF(Gender=1,'M','F') As Gen,count(*) As NoOfEmployees from employee group by Gen";
                var sqlWithDep = $"SELECT IF(E.Gender=1,'M','F') As Gen,count(*) As NoOfEmployees from employee E INNER JOIN employee_position EP ON E.PositionID=EP.ID Where EP.Name = '{Department}' group by Gen";

                if (String.IsNullOrEmpty(Department))
                {
                    sql = sqlWithOutDep;
                }
                else
                {
                    sql = sqlWithDep;
                }
                if (this.OpenConnection() == true)
                {
                    //Create Command
                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    dt.Load(dataReader);
                }
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                this.CloseConnection();

            }
        }


        public DataTable MostsoldProduct()
        {
            try
            {
                DataTable dt = new DataTable();
                
                var sql = $"SELECT product_type.Name as type,SUM(request.quantity)as Quantity FROM request inner join product on request.product_id=product.ID inner join product_type  on product_type.ID= product.type_id group by product_type.Name; ";

                if (this.OpenConnection() == true)
                {
                    //Create Command
                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    dt.Load(dataReader);
                }
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                this.CloseConnection();

            }

           
        }



        public DataTable Quntity_Of_Product()
        {
            try
            {
                DataTable dt = new DataTable();

                var sql = $"select product_type.Name as type,count(*) as products from product_type inner join product on product_type.ID=product.type_id group by product_type.ID;";

                if (this.OpenConnection() == true)
                {
                    //Create Command
                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    dt.Load(dataReader);
                }
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                this.CloseConnection();

            }


        }


        public DataTable Profit_for_PCateogory()
        {
            try
            {
                DataTable dt = new DataTable();

                var sql = $"SELECT product_id,product_type.Name as type,SUM(request.quantity)as Quantity ,SUM(product.price*request.quantity) as Profit FROM request inner join product on request.product_id=product.ID inner join product_type  on product_type.ID= product.type_id group by product_type.Name; ";

                if (this.OpenConnection() == true)
                {
                    //Create Command
                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    dt.Load(dataReader);
                }
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                this.CloseConnection();

            }


        }

        public DataTable EmployeesOnTime(string date)
        {
            try
            {
                DataTable dt = new DataTable();

                var sql = $"SELECT Count(ID) As No_of_emp,attendstatus  FROM dbi450024.checkinout where attendstatus <> ' ' AND  Date ='{date}'  group by attendstatus;";

                if (this.OpenConnection() == true)
                {
                    //Create Command
                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    dt.Load(dataReader);
                }
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                this.CloseConnection();

            }


        }


        public DataTable Delayhours(string date)
        {
            try
            {
                DataTable dt = new DataTable();

                var sql = $"SELECT Count(ID) As NumberOfEmployees, delaytime  FROM dbi450024.checkinout where delaytime <> ' '  AND  Date ='{date}' group by delaytime;";

                if (this.OpenConnection() == true)
                {
                    //Create Command
                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    dt.Load(dataReader);
                }
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                this.CloseConnection();

            }


        }
















        public int SelectProductQuantity(int req)
        {
            var amount = 0;
            try
            {
                var stockTypes = new List<string>();
                var sql = $"SELECT ifnull(p.Quantity,0) As Quantity From product p INNER JOIN request req on req.product_id=p.ID Where req.ID={req} And p.ID = req.product_id LIMIT 1";
                if (this.OpenConnection() == true)
                {
                    //Create Command
                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    //Read the data and store them in the list
                    while (dataReader.Read())
                    {
                       amount= Convert.ToInt32(dataReader["Quantity"]);
                    }

                    //close Data Reader
                    dataReader.Close();
                    //return list to be displayed                  
                }
                return amount;
            }
            catch (Exception ex)
            {
                return -1;
            }
            finally
            {
                this.CloseConnection();

            }
        }

        public DataTable GetAllEmp()
        {
            try
            {
                DataTable dt = new DataTable();
                var sql = $"SELECT ID, FirstName FROM dbi450024.employee;";
                if (this.OpenConnection() == true)
                {
                    //Create Command
                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    dt.Load(dataReader);
                }
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                this.CloseConnection();

            }
        }


        public DataTable Statbyemp(int id,string date)
        {
            try
            {
                DataTable dt = new DataTable();
                var sql = $"SELECT delaytime,Date FROM dbi450024.checkinout where EmpID={id} And Date ='{date}' And attendstatus is not null And attendstatus <> ' ';";
                if (this.OpenConnection() == true)
                {
                    //Create Command
                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    dt.Load(dataReader);
                }
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                this.CloseConnection();

            }
        }
      
  
    }

}

