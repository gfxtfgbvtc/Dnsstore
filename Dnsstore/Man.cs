using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dnsstore
{
    internal class Man
    {
        private string name;
        private string telefon;
        private int count_cash;
        private bool qr_code;


        public string Name
        {
            get { return name; }
        }
        public string Telefon
        {
            get { return telefon; }
        }
        public int CountCash
        {
            get { return count_cash; }
            set { count_cash = value; }
        }
        public bool Qr_code
        {
            get { return qr_code; }
        }

        public Man(string name, string telefon, int count_cash, bool qr_code)
        {
            this.name = name;
            this.telefon = telefon;
            this.count_cash = count_cash;
            this.qr_code = qr_code;
        }
        public void Chek_Signature(Chek chek)
        {
            chek.Chk = true;
        }
    }
}

