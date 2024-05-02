using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dnsstore;

namespace Dnsstore
{
    internal class Kassa
    {
        private int number_kassen;
        private int count_cash;
        private bool qr_code;

        public int Number_Kassen
        {
            get { return number_kassen; }
        }
        public int Count_cash
        {
            get { return count_cash; }
            set { count_cash = value; }
        }
        public bool Qr_code
        {
            get { return qr_code; }

        }
        public Kassa(int number_kassen, int count_cash, bool qr_code)
        {
            this.number_kassen = number_kassen;
            this.count_cash = count_cash;
            this.qr_code = qr_code;
        }
    }
}
