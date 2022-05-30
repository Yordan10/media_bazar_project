using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media_Bazaar
{
    public class ProductType
    {
        public int ID { get; set; }

        public String Name { get; set; }

        public ProductType(string name)
        {
            this.Name = name;
        }
        public ProductType(int id,string name)
        {
            this.ID = id;
            this.Name = name;
        }
    }
}
