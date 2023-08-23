using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp31
{
    class Program
    {
        static void TraderContact(List<Weapon> weapons, Stalker stalker)
        {
            Console.WriteLine("Дарова сталкер, з чим пожалував?");
            Console.WriteLine("1.Зброя");
            int n = int.Parse(Console.ReadLine());
            switch (n)
            {
                case 1:
                    Console.WriteLine("Яка зброя цікавить?");
                    for (int i = 0; i < weapons.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}:{weapons[i].Name}({weapons[i].BuyPrice} грн.)");
                    }
                    int x = int.Parse(Console.ReadLine()) - 1;
                    switch (x)
                    {
                        default: CanBuyWeapon(weapons[x], stalker);
                            break;
                    }
                    break;
                default:
                    Console.WriteLine("Нема такого, сталкер");
                    break;
            }
        }
        static void CanBuyWeapon(Weapon w, Stalker s)
        {
            if (s.Money >= w.BuyPrice)
            {
                Console.WriteLine("[УСПІХ] Відмінна зброя, ти не пожалкуєш, сталкер!");
                s.SetCurrentWeapon = w;
            }
            else
            {
                Console.WriteLine("[НЕВДАЧА] Недостатньо коштів.");
            }
        }
        //public Weapon w0 = new Weapon("fist", 5, 10, 0, 0, 0);
        //public Weapon w1 = new Weapon("pm", 12, 13, 5, 8, 1500);
        //public Weapon w2 = new Weapon("tt", 21, 13, 5, 10, 2500);
        //public Weapon w3 = new Weapon("obrez", 30, 12, 2, 2, 3000);
        //public List<Weapon> Weapons()
        //{
        //    List<Weapon> weapons = new List<Weapon>() { w0, w1, w2, w3 };
        //    return weapons;
        //}
        static void Main(string[] args)
        {
                                                                                        Weapon w0 = new Weapon("fist", 5, 10, 0, 0, 0);
                                                                                        Weapon w1 = new Weapon("pm", 12, 13, 5, 8, 1500);
                                                                                        Weapon w2 = new Weapon("tt", 21, 13, 5, 10, 2500);
                                                                                        Weapon w3 = new Weapon("obrez", 30, 12, 2, 2, 3000);
                                                                                        List<Weapon> weapons = new List<Weapon>() { w1, w2, w3 };
            Stalker l1 = new Stalker("vasya", 2500, "loner");
            l1.currentWeapon = w0;
            TraderContact(weapons,l1);
        }
    public class Stalker
        {
            public string nickname;
            private int hp=100;
            public int money;
            public Weapon currentWeapon;
            private string fraction;
            public Stalker(string nickname, int money, string fraction)
            {
                this.nickname = nickname;
                this.money = money;
                this.fraction = fraction;
            }
            public string Nickname
            {
                get { return nickname; }
                set { nickname = value; }
            }
            public string Fraction
            {
                get { return fraction; }
                set { fraction = value; }
            }
            public int Money
            {
                get { return money; }
            }
            public Weapon SetCurrentWeapon
            {
                get { return currentWeapon; }
                set { currentWeapon=value; }
            }
            public string NameOfCurrentWeapon
            {
                get { return currentWeapon.name; }
            }
        }
        public class Weapon
        {
            public string name;
            protected int damage;
            protected int accuracy;
            protected int distance;
            protected int ammoLoad;
            protected int buyPrice;
            public Weapon(string name,int damage, int accuracy, int distance,int ammoLoad, int buyPrice)
            {
                this.name = name;
                this.damage = damage;
                this.accuracy = accuracy;
                this.distance = distance;
                this.ammoLoad = ammoLoad;
                this.buyPrice = buyPrice;
            }
            public string Name
            {
                get { return name; }
            }
            public int BuyPrice
            {
                get { return buyPrice;}
            }
        }
       
    }
}
