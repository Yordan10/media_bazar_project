using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Media_Bazaar
{
   
    public class SaleRepresentative: Employee
    {
        
        private DateTime startDate;
        private string certificates;
        private string languagesSpoken;
       
        
        public SaleRepresentative(string username, string password,string fName, string surname, int pNumber, string address, DateTime birthDate, string email, int isMarried, int bsn, string functions, DateTime startDate, string certificates, string languagesSpoken,int id, decimal salary,int gender,int position,int? department, int contract) : base( username,password,fName, surname, pNumber, address, birthDate, email, isMarried, bsn, functions,id,salary,gender,position,department,contract)
        {
            this.startDate = startDate;
            this.certificates = certificates;
            this.languagesSpoken = languagesSpoken;
          
        }
        public DateTime GetStartDate() { return startDate; }
        public string GetCertificates() { return certificates; }
        public string GetLanguagesSpoken() { return languagesSpoken; }
       
    }
}
