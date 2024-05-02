using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dnsstore
{
    internal class Konsultant
    {
        private string name;
        private bool busy;

        public string Name
        {
            get { return name; }
        }
        public bool Busy
        {
            get { return busy; }
            set { busy = value; }
        }

        public Konsultant(string name, bool busy)
        {
            this.name = name;
            this.busy = busy;
        }
    }
}
