using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media_Bazaar
{
    public class WorkWeek
    {
        public int id;
        public int year;
        public int week;

        public WorkWeek(int id, int year, int week)
        {
            this.id = id;
            this.year = year;
            this.week = week;
        }

        public int GetId()
        {
            return id;
        }
        public int GetWeek()
        {
            return week;
        }
        public int GetYear()
        {
            return year;
        }
        public override String ToString()
        {
            return "year " + year + " : week " + week;
        }
    }
}
