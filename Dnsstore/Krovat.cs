using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dnsstore
{
    internal class Krovat : Product
    {
        public Krovat(string name, int price) : base(name, price)
        {
        }
        public override string Product_Type()
        {
            return "Кровать";
        }
    }
}

