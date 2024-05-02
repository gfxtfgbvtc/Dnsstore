using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace Dnsstore
{
    internal class Shop
    {
        private Kassa kasse1 = new Kassa(1, 5000, false);
        private Kassa kasse2 = new Kassa(2, 5000, true);

        private List<Konsultant> kassirs = new List<Konsultant>
        {
            new Konsultant("Илья Михайлович", true),
            new Konsultant("Иван Темуриевич", false),
            new Konsultant("Сережа", true)
        };

        private List<Product> mebelss = new List<Product>();

        public void AddStul(Product mebel)
        {
            mebelss.Add(mebel);
        }
        public void AddStul(List<Product> st)
        {
            mebelss.AddRange(st);
        }
        private void ComeMan(Man man)
        {
            Console.WriteLine($"{man.Name} - Здравствуйте. Мне нужна мебель");
            int index_kassir = -1;
            foreach (var item in kassirs)
            {
                index_kassir++;
                if (item.Busy == false)
                {
                    break;
                }
            }
            if (index_kassir != -1)
            {
                Console.WriteLine($"{kassirs[index_kassir].Name} -  Здравствуйте, я {kassirs[index_kassir].Name}. Да. Смотрите выбирайте.");
                PrintStuls();
            }
            else
            {
                Console.WriteLine("нет свободных кассиров");
                return;
            }
        }
        public void OpenCloseShop(bool Open)
        {
            Console.WriteLine("         МАГАЗИН МЕБЕЛИ         ");
            if (Open)
                Console.WriteLine("              ОТКРЫТ              ");
            else
                Console.WriteLine("              ЗАКРЫТ              ");
            Console.WriteLine("             КАССИРЫ              ");
            int i = 0;
            foreach (var item in kassirs)
            {
                i++;
                if (item.Busy)
                    Console.WriteLine($" {i}. {item.Name}  - занят ");
                else
                    Console.WriteLine($" {i}. {item.Name}  - свободен ");
            }
            Console.WriteLine();
            Console.WriteLine("   СКЛАД МЕБЕЛИ ");
            i = 0;
            foreach (var item in mebelss)
            {
                i++;
                Console.WriteLine($" {i}. {item.Product_Type()}  -  {item.Name}  ");
            }
            Console.WriteLine();
            Console.WriteLine("        БАЛАНС  КАСС  ");
            Console.WriteLine($" КАССА 1 - {kasse1.Count_cash} руб.");
            Console.WriteLine($" КАССА 2 - {kasse2.Count_cash} руб.");
            Console.WriteLine();

        }
        public void BuyStul(Man man, Product mebel)
        {
            ComeMan(man);
            int index_kassir = -1;
            foreach (var item in kassirs)
            {
                index_kassir++;
                if (item.Busy == false)
                {
                    break;
                }
            }
            if (index_kassir != -1)
            {
                kassirs[index_kassir].Busy = true;
                Console.WriteLine($"{man.Name} - Я хочу этот {mebel.Product_Type()} {mebel.Name}");
                if (mebelss.Contains(mebel))
                {
                    Console.WriteLine($"{kassirs[index_kassir].Name} - Да, цена {mebel.Price}");
                    if (mebel.Price < man.CountCash)
                    {
                        Console.WriteLine($"{man.Name} - Ооо, у меня есть эти деньги, Беру");
                        Console.WriteLine($"{kassirs[index_kassir].Name} - Наличка или QR-код");
                        if (man.Qr_code)
                        {
                            Console.WriteLine($"{man.Name} - QR");
                            Console.WriteLine($"{kassirs[index_kassir].Name} - Идите в Касса Номер {kasse2.Number_Kassen}");
                            Console.WriteLine("Kassa");
                            Console.WriteLine($"{kassirs[index_kassir].Name} - Ваше имя и номер телефона?");
                            Console.WriteLine($"{man.Name} - {man.Telefon}");
                            Console.WriteLine($"{kassirs[index_kassir].Name} - Платите");
                            man.CountCash -= mebel.Price;
                            kasse2.Count_cash += mebel.Price;
                            Console.WriteLine($"{kassirs[index_kassir].Name} - Вот ваш чек");
                            Chek chek = new Chek(mebel, kasse2.Number_Kassen, kassirs[index_kassir].Name, man.Name, man.Telefon, man.Qr_code, false);
                            chek.PrintChek();
                            Console.WriteLine($"{kassirs[index_kassir].Name} - Распишитесь здесь и здесь");
                            man.Chek_Signature(chek);
                            chek.PrintChek();
                            mebelss.Remove(mebel);
                        }
                        else
                        {
                            Console.WriteLine($"{man.Name} - Nalitchka");
                            Console.WriteLine($"{kassirs[index_kassir].Name} - Идите в Касса Номер {kasse1.Number_Kassen}");
                            Console.WriteLine("Kassa");
                            Console.WriteLine($"{kassirs[index_kassir].Name} - Ваше имя и номер телефона?");
                            Console.WriteLine($"{man.Name} - {man.Telefon}");
                            Console.WriteLine($"{kassirs[index_kassir].Name} - Платите");
                            man.CountCash -= mebel.Price;
                            kasse1.Count_cash += mebel.Price;
                            Console.WriteLine($"{kassirs[index_kassir].Name} - Вот ваш чек");
                            Chek chek = new Chek(mebel, kasse2.Number_Kassen, kassirs[index_kassir].Name, man.Name, man.Telefon, man.Qr_code, false);
                            chek.PrintChek();
                            Console.WriteLine($"{kassirs[index_kassir].Name} - Распишитесь здесь и здесь");
                            man.Chek_Signature(chek);
                            chek.PrintChek();
                            mebelss.Remove(mebel);

                        }
                        Console.WriteLine($"{man.Name} - Спасибо");
                        Console.WriteLine($"{kassirs[index_kassir].Name} - Приходите еще.");
                        kassirs[index_kassir].Busy = false;
                    }
                    else
                    {
                        Console.WriteLine($"{man.Name} - Ооо, без денег. Хорошая покупка");
                        kassirs[index_kassir].Busy = false;
                    }
                }
                else
                {
                    Console.WriteLine($"{kassirs[index_kassir].Name} - Простите но такого у нас на складе нет");
                    Console.WriteLine($"{man.Name} - Спасибо, До свидания");
                    Console.WriteLine($"{kassirs[index_kassir].Name} - Приходите еще.");
                }

            }
            else
                Console.WriteLine("ВСЕ КАССИРЫ ЗАНЯТЫ, ПОДОЖДИТЕ ИЛИ ПРИХОДИТЕ ПОЗЖЕ");
        }
        public void BuyStul(Man man, List<Product> mebels)
        {
            ComeMan(man);
            int index_kassir = -1;
            foreach (var item in kassirs)
            {
                index_kassir++;
                if (item.Busy == false)
                {
                    break;
                }
            }
            if (index_kassir != -1)
            {

                foreach (var item in mebels)
                {
                    if (!mebelss.Contains(item))
                    {
                        Console.WriteLine($"{kassirs[index_kassir].Name} - Простите но такого {item.GetType()} {item.Name} нет на складе");
                        return;
                    }
                }

                kassirs[index_kassir].Busy = true;
                Console.Write($"{man.Name} - Я хочу ");
                foreach (var item in mebels)
                {
                    Console.Write($"{item.Product_Type()} {item.Name}, ");
                }
                Console.WriteLine();
                int sum_price = 0;
                Console.Write($"{kassirs[index_kassir].Name} - Да, цена ");
                foreach (var item in mebels)
                {
                    Console.Write($"и {item.Price} руб. ");
                    sum_price += item.Price;
                }
                Console.WriteLine();
                if (sum_price < man.CountCash)
                {
                    Console.WriteLine($"{man.Name} - Ооо, у меня есть эти деньги, Беру");
                    Console.WriteLine($"{kassirs[index_kassir].Name} - Наличка или QR-код");
                    if (man.Qr_code)
                    {
                        Console.WriteLine($"{man.Name} - QR");
                        Console.WriteLine($"{kassirs[index_kassir].Name} - Идите в Касса Номер {kasse2.Number_Kassen}");
                        Console.WriteLine("Kassa");
                        Console.WriteLine($"{kassirs[index_kassir].Name} - Ваше имя и номер телефона?");
                        Console.WriteLine($"{man.Name} - {man.Telefon}");
                        Console.WriteLine($"{kassirs[index_kassir].Name} - Платите");
                        man.CountCash -= sum_price;
                        kasse2.Count_cash += sum_price;
                        Console.WriteLine($"{kassirs[index_kassir].Name} - Вот ваш чек");
                        Chek chek = new Chek(mebels, kasse2.Number_Kassen, kassirs[index_kassir].Name, man.Name, man.Telefon, man.Qr_code, false);
                        chek.PrintChek();
                        Console.WriteLine($"{kassirs[index_kassir].Name} - Распишитесь здесь и здесь");
                        man.Chek_Signature(chek);
                        chek.PrintChek();
                        mebelss.RemoveRange(mebelss.FindIndex(item => item == mebels[0]), mebels.Count);
                    }
                    else
                    {
                        Console.WriteLine($"{man.Name} - Nalitchka");
                        Console.WriteLine($"{kassirs[index_kassir].Name} - Идите в Касса Номер {kasse2.Number_Kassen}");
                        Console.WriteLine("Kassa");
                        Console.WriteLine($"{kassirs[index_kassir].Name} - Ваше имя и номер телефона?");
                        Console.WriteLine($"{man.Name} - {man.Telefon}");
                        Console.WriteLine($"{kassirs[index_kassir].Name} - Платите");
                        man.CountCash -= sum_price;
                        kasse2.Count_cash += sum_price;
                        Console.WriteLine($"{kassirs[index_kassir].Name} - Вот ваш чек");
                        Chek chek = new Chek(mebels, kasse2.Number_Kassen, kassirs[index_kassir].Name, man.Name, man.Telefon, man.Qr_code, false);
                        chek.PrintChek();
                        Console.WriteLine($"{kassirs[index_kassir].Name} - Распишитесь здесь и здесь");
                        man.Chek_Signature(chek);
                        chek.PrintChek();
                        mebelss.RemoveRange(mebelss.FindIndex(item => item == mebels[0]), mebels.Count);

                    }
                    Console.WriteLine($"{man.Name} - Спасибо");
                    Console.WriteLine($"{kassirs[index_kassir].Name} - Приходите еще.");
                    kassirs[index_kassir].Busy = false;
                }
                else
                {
                    Console.WriteLine($"{man.Name} - Ооо, без денег. Хорошая покупка");
                    kassirs[index_kassir].Busy = false;
                }
            }
            else
                Console.WriteLine("ВСЕ КАССИРЫ ЗАНЯТЫ, ПОДОЖДИТЕ ИЛИ ПРИХОДИТЕ ПОЗЖЕ");
        }
        public void PrintStuls()
        {
            Console.WriteLine("##################################################");
            Console.WriteLine("#################_СКЛАД СТУЛЬЕВ_#################");
            foreach (var item in mebelss)
            {
                Console.WriteLine(item.Product_Type() + " " + item.Name);
            }
            Console.WriteLine("##################################################");
        }
    }
}
