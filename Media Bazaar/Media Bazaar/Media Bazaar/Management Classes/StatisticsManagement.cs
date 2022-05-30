using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media_Bazaar
{
    public class StatisticsManagement
    {
        private DBConnection DBConnection;

        public StatisticsManagement()
        {
            DBConnection = new DBConnection();
        }

        public DataTable ShowEmployeesByAge(int sAge, int eAge,string department)
        {
            return DBConnection.SelectAllEmployeesPerAge(sAge,eAge,department);
        }
        public DataTable ShowEmployeesByGender(string department)
        {
           return DBConnection.SelectAllEmployeesByGender(department);
        }
        public List<string> GetAllRoles()
        {
            var postNames = new List<string>() { "All" };
            var positions = DBConnection.GetShiftPositions();
            foreach(Position p in positions)
            {
                postNames.Add(p.name);
            }
            return postNames;
        }

        public DataTable stockst()
        {
            return DBConnection.MostsoldProduct();
        }

        public DataTable Product_Quan()
        {
            return DBConnection.Quntity_Of_Product();
        }
        public DataTable Profit_cat()
        {
            return DBConnection.Profit_for_PCateogory();
        }

        public DataTable ProductOverView()
        {
            return DBConnection.SelectAllStock();
        }

        public DataTable EmpOnTime(string date)
        {
            return DBConnection.EmployeesOnTime(date);
        }

        public DataTable delh(string date)
        {
            return DBConnection.Delayhours(date);
        }

        public DataTable allemp()
        {
            return DBConnection.GetAllEmp();
        }

        public DataTable attendemp(int id,string date)
        {
            return DBConnection.Statbyemp(id,date);
        }
       
    }
}
