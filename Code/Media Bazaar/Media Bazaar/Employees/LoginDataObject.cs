using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media_Bazaar
{
   public  class LoginDataObject
    {
        private int employeeId;
        private int employeePositionId;

        public LoginDataObject(int id, int employeePositionid)
        {
            this.employeeId = id;
            this.employeePositionId = employeePositionid;
        }

        public int GetEmployeeId()
        {
            return employeeId;
        }
        public int GetEmployeePositionid()
        {
            return employeePositionId;
        }
       
    }
}
