using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dnsstore;
internal class Program
{
    static void Main(string[] args)
    {
        Shop Hmel = new Shop();
        Man man1 = new Man("Андрей Александрович Балакин", "8 800 353 55 55", 1700000, true);

        Product stul1 = new Taburet("Marius", 100);
        Product stul2 = new Stul("Adde", 2400);
        Product stul3 = new Krovat("Stefan", 9900);
        Product stul4 = new Taburet("Teodoros", 600);
        Product stul5 = new Stul("Odger", 3000);

        Hmel.AddStul(stul1);
        Hmel.AddStul(stul2);
        Hmel.AddStul(stul3);
        Hmel.AddStul(stul4);
        Hmel.AddStul(stul5);

        List<Product> list = new List<Product>();
        list.Add(stul1);
        list.Add(stul2);
        list.Add(stul3);

        Hmel.OpenCloseShop(true);

        Hmel.BuyStul(man1, list);

        Hmel.OpenCloseShop(false);

    }
}

