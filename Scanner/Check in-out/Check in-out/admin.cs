using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//namespace Check_in_out
//{
//    class admin
//    {
//        private DB dB;

//        public void add_info(int id, DateTime timein, DateTime timeout)
//        {
//            var checkin = new Checkin_out(id,timein,timeout);

//            string query = $"INSERT INTO `checkinout` (`ID`, `checkinout`,`checkinout`) VALUES (null, '{id}',{timein},'{timeout}');";
//            var isAdded = dB.InsertOrUpdateOrDel(query);
//            if (!isAdded)
//            {
//                MessageBox.Show("Info Added:Failed");
//            }
//            else
//                MessageBox.Show("Info Added:successully");
//        }
//    }
//}
