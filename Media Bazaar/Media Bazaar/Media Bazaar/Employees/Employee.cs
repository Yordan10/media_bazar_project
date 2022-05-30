using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Media_Bazaar
{
    [Serializable]
    public abstract class Employee 
    {
        protected string username;
        protected string password;
        protected string firstName;
        protected string surname;
        protected int phoneNumber;
        protected string address;
        protected DateTime birthDate;
        protected string email;
        protected int isMarried;
        protected int bsn;
        protected string functions;
        protected int id;
        protected decimal salary;
        protected int gender;
        protected int position;
        protected int? department;
        protected int contract;

        public Employee(string username,string password ,string fName, string surname, int pNumber, string address, DateTime birthDate, string email, int isMarried, int bsn, string functions, int id,decimal salary,int gender,int position,int? department, int contract)
        {
            this.username = username;
            this.password = password;
            this.firstName = fName;
            this.surname = surname;
            this.phoneNumber = pNumber;
            this.address = address;
            this.birthDate = birthDate;
            this.email = email;
            this.isMarried = isMarried;
            this.bsn = bsn;
            this.functions = functions;
            this.id = id;
            this.salary = salary;
            this.gender = gender;
            this.position = position;
            this.department = department;
            this.contract = contract;
        }
        public string GetName()
        {
            return firstName;
        }
      public int  GetPosition()
        {
            return position;
        }
       public int GetId() { return id; }

        public string GetFirstName()
        {
            return firstName;
        }
        public string GetSurname() { return surname; }
        public int GetPhoneNumber() { return phoneNumber; }
        public string GetAddress() { return address; }
        public DateTime GetBirth() { return birthDate; }
        public string GetEmail() { return email; }
        public int GetIsMarried() { return isMarried; }
        public int GetBsn() { return bsn;}
        public string GetFunctions() { return functions; }
       public decimal GetSalary() { return salary; }
        public int GetGender() { return gender; }
        public string GetUsername() { return username; }
        public string GetPassword() { return password; }
        public int? GetDepartment() { return department; }
        public int GetContract() { return contract; }
    }
}
