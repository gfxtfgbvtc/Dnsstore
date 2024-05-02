using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dnsstore
{
    abstract class Product
    {
        private string name;
        private int price;


        public string Name
        {
            get { return name; }
        }
        public int Price
        {
            get { return price; }
        }
        public Product(string name, int price)
        {
            this.name = name;
            this.price = price;
        }
        public virtual string Product_Type()
        {
            return "###";
        }
    }
}
