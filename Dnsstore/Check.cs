using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dnsstore
{
    internal class Chek
    {
        private List<Product> list = new List<Product>();
        private int number_kassen;
        private string name_kassir;
        private string name_man;
        private string telefon;
        private bool qr;
        private bool chek = false;

        public bool Chk
        {
            get { return chek; }
            set { chek = value; }
        }

        public Chek(Product product, int number_kassen, string name_kassir, string name_man, string telefon, bool qr, bool chek)
        {
            list.Add(product);
            this.number_kassen = number_kassen;
            this.name_kassir = name_kassir;
            this.name_man = name_man;
            this.telefon = telefon;
            this.qr = qr;
            this.chek = chek;
        }
        public Chek(List<Product> mebels, int number_kassen, string name_kassir, string name_man, string telefon, bool qr, bool chek)
        {
            list = mebels;
            this.number_kassen = number_kassen;
            this.name_kassir = name_kassir;
            this.name_man = name_man;
            this.telefon = telefon;
            this.qr = qr;
            this.chek = chek;
        }

        public void PrintChek()
        {
            int sum = 0;
            Console.WriteLine($"===============================================================");
            Console.WriteLine($"DNS");
            Console.WriteLine($"______________________________________________________________");
            Console.WriteLine($"Наименование товара/цена:");
            foreach (var item in list)
            {
                Console.WriteLine($"{item.Product_Type()} {item.Name}      {item.Price} руб");
                sum += item.Price;
            }
            Console.WriteLine($"______________________________________________________________");
            Console.WriteLine($"ИТОГО           -     {sum}");
            Console.WriteLine($"______________________________________________________________");
            Console.WriteLine($"Кассир {name_kassir}");
            Console.WriteLine($"Номер кассы     -     {number_kassen}");
            Console.WriteLine($"Покупатель      -     {name_man}");
            Console.WriteLine($"Номер телефона          -     {telefon}");
            Console.WriteLine($"Оплата QR               -     {qr}");
            Console.WriteLine($"Подпись покупателя      -     {chek}");
            Console.WriteLine($"==============================================================");

        }
    }
}

