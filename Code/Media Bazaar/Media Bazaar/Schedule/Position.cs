using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media_Bazaar
{
   public class Position 
    {
        public int id;
        public String name;

        public Position(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public int GetId()
        {
            return id;
        }
        public String GetName()
        {
            return name;
        }
        public override String ToString()
        {
            return  name ;
        }
    }
}
