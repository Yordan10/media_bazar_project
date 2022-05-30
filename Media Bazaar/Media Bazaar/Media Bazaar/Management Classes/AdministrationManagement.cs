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
    public class AdministrationManagement
    {
        private DBConnection DBConnection;

        public AdministrationManagement()
        {
            DBConnection = new DBConnection();
        }

        public void AddEmployee(string username, string password, string fName, string surname, int pNumber, string address, string birthDate, string email, int isMarried, int bsn, string functions, int id, string startDate, string spokenLanguages, string certificates, int positionId, decimal salary, int gender, string spouse, int department, int contract)
        {

            string query = $"INSERT INTO `employee` (`ID`, `FirstName`, `Surname`, `PhoneNumber`, `Address`, `BirthDate`, `Email`, `IsMarried`, `BSN`, `Functions`,`UserName`, `Password`,`StartDate`, `SpokenLanguages`,`Certificates`,`PositionID`, `Salary`, `Gender`, `Spouse`, `department_id`,`IsFulltime`) VALUES (null, '{fName}', '{surname}', {pNumber},'{address}', '{birthDate}','{email}', {isMarried}, {bsn},'{functions}','{username}','{password}','{startDate}','{spokenLanguages}','{certificates}',{positionId},{salary}, {gender} , '{spouse}', {department}, {contract});";

            var isAdded = DBConnection.InsertOrUpdateOrDel(query);
            if (!isAdded)
            {
                MessageBox.Show("Employee added:Failed");
            }
            else
            {
                MessageBox.Show("Added successfully");
            }
        }
        public void EditEmployee(string username, string password, string fName, string surname, int pNumber, string address, string birthDate, string email, int isMarried, int bsn, string functions, int id, string startDate, string spokenLanguages, string certificates, int positionId, decimal salary, int gender, string spouse, int? dpId, int contract)
        {
            string query = $"UPDATE `employee` Set `ID`={id},`FirstName`='{fName}',`Surname`='{surname}', `PhoneNumber`={pNumber},`Address`='{address}' , `BirthDate`='{birthDate}', `Email`='{email}', `IsMarried`={isMarried}, `BSN`={bsn}, `Functions`='{functions}',`UserName`='{username}', `Password`='{password}',`StartDate`='{startDate}', `SpokenLanguages`='{spokenLanguages}',`Certificates`='{certificates}',`PositionID`={positionId}, `Salary` = {salary}, `Gender` = {gender}, `Spouse`='{spouse}', `department_id`={dpId}, `IsFulltime`={contract} WHERE `ID` = {id};";

            var isUpdate = DBConnection.InsertOrUpdateOrDel(query);
            if (!isUpdate)
            {
                MessageBox.Show("Employee update:Failed");
            }
            else
            {
                MessageBox.Show("Changed successfully");
            }
        }
        public void FireEmployee(int id)
        {
            string query = $"DELETE FROM `employee` WHERE `ID` ={id}";
            var isDel = DBConnection.InsertOrUpdateOrDel(query);
            if (!isDel)
            {
                MessageBox.Show("The employee wasn't deleted");
            }
            else
            {
                MessageBox.Show("Deleted successfully");
            }
        }
        public DataTable ShowEmployees()
        {
            return DBConnection.SelectEmployeesInfo();
        }
        public List<EmployeeDataObject> PopulateComboboxEmployee(int employeePosition)
        {
            return DBConnection.SelectEmployeesPerPosition(employeePosition);
        }
        public List<EmployeeDataObject> PopulateComboboxPartTimeEmployee(int departmentId)
        {
            return DBConnection.SelectPartTimeEmployeesPerDepartment(departmentId);
        }
       
       
    }
}
