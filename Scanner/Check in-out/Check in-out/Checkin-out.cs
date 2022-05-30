using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Check_in_out
{
    class Checkin_out
    {

        
        public DateTime ScanTime { get; set; }
        public int EmpID { get; }
        public String Time
        {
            get { return ScanTime.ToString("HH:mm"); }
        }
        public String Date
        {
            get { return ScanTime.ToString("dd/MM/yyyy"); }
        }
        public int Status { get; private set; }
        int ID;

        public Checkin_out(int empId, int status)
        {
            this.EmpID = empId;
            this.Status = status;
        }

        public int DoCheckInOrOut()
        {
                if (this.Status == 1) //if checked in 
                {
                    Status = 0; //check him out
                }
                else if (this.Status == 0) //if check out
                {
                    Status = 1; //chech him in
                }
                return Status;      
        }

        public string ShowMessage()
        {
            if (this.Status == 1)
            {
                return $"Employee{EmpID} : Check IN Successfully";
                
                
            }
            else if (this.Status == 0) 
            {
                return $"Employee{EmpID} : Check OUT Successfully";
            }
            return null;
        }
        

       
    }
}
