using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Check_in_out
{
    class DB
    {
       
        

        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;


        //Constructor
        public DB()
        {
            Initialize();
        }

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

        public Checkin_out GetCheckInOrCheckOut(int employeeId)
        {
            Checkin_out checkIn_out = null; 
            try
       // We are selecting max(ID) in oder to get latest status of employee either he is check in or out at this moment.
            {
                string sql = "";
                sql = $"SELECT ch.EmpID,ch.status " +
                            "FROM dbi450024.checkinout As ch "+
                            $"Where  ch.ID = (Select Max(ID) "+
                                                         "FROM dbi450024.checkinout "+
                                                         $"Where EmpID ={employeeId})";
                if (this.OpenConnection() == true)
                {
                    //Create Command
                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        var status = Convert.ToInt32(dataReader["Status"]);
                        checkIn_out = new Checkin_out(employeeId, status);
                    }
                }

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
            return checkIn_out;
        }

        public bool ChangeStatus(Checkin_out checkin_Out)
        {
            try
            {
                if (this.OpenConnection() == true)
                {
                    checkin_Out.DoCheckInOrOut();
                    checkin_Out.ScanTime = DateTime.Now;
                    var startTime= TimeSpan.Parse("9:00");
                    var attendanceStatus = "";
                    var delay = "";
                    //TimeSpan  del = null;
                    TimeSpan ts = TimeSpan.Parse(checkin_Out.Time);
                  
                  
                        if (checkin_Out.Status == 1 && ts == startTime)


                        {
                            attendanceStatus = "On time";
                        }

                        else if (checkin_Out.Status == 1 && ts > startTime)
                        {

                            attendanceStatus = "Not On time";

                            TimeSpan del = ts - startTime;
                            delay = del.Hours.ToString();

                        }
                    

                    

                    string query = $"INSERT INTO `checkinout` (`ID`, `Time`, `Status`, `EmpID`,`Date`,`attendstatus`,`delaytime`) VALUES (null, '{checkin_Out.Time}', {checkin_Out.Status}, {checkin_Out.EmpID},'{checkin_Out.Date}','{attendanceStatus}','{delay}'); ";
                    //create command and assign the query and connection from the constructor
                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    //Execute command
                    return cmd.ExecuteNonQuery()==1;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException ex) when (ex.Number == 547)
            {
                MessageBox.Show("You are trying to Check In non existing employees.");
                return false;
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

    }
}
