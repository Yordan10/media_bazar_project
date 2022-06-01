using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media_Bazaar
{
    public class Product
    {
        public int id;
        public String name;
        public string Model;
        public string Brand;
        public double Weight;
        public double Height;
        public double Depth;
        public int Barcode;
        public int cost;

        public ProductType ProductType { get; set; }
        public Product(int id, string name)
        {
            this.id = id;
            this.name = name;
           

        }
        public Product( string name, string model, string brand, double weight, double height, double depth, int barcode,int cost)
        {
            this.name = name;
            this.Model = model;
            this.Brand = brand;
            this.Weight = weight;
            this.Height = height;
            this.Depth = depth;
            this.Barcode = barcode;
            this.cost = cost;

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
            return name;
        }
    }
}
