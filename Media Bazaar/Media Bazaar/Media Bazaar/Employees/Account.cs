using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Media_Bazaar
{
    [Serializable]
   public class Account
    {
        private string username;
        private string password;

        public Account(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
    }
}
