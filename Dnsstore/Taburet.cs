using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dnsstore
{
    internal class Taburet : Product
    {
        public Taburet(string name, int price) : base(name, price)
        {
        }
        public override string Product_Type()
        {
            return "Табурет";
        }
    }
}
