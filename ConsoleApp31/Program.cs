using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp31
{
    class Program
    {
        static void TraderContact(List<Weapon> weapons)
        {
            Console.WriteLine("Дарова сталкер, з чим пожалував?");
            Console.WriteLine("1.Зброя");
            int n = int.Parse(Console.ReadLine());
            switch (n)
            {
                case 1: Console.WriteLine("Яка зброя цікавить?");
                    for (int i = 0; i < weapons.Count; i++)
                    {
                        Console.WriteLine($"{i+1}:{weapons[i].Name}");
                    }
                    break;
                
                
                
                
                
                default: Console.WriteLine("Нема такого, сталкер");
                    break;
            }
        }
        static void Main(string[] args)
        {
            //Stalker l1 = new Stalker("vasya",20000,"loner");
            Weapon w1 = new Weapon("pm",12, 13,5,8);
            Weapon w2 = new Weapon("tt", 21, 13, 5, 10);
            Weapon w3 = new Weapon("obrez",30, 12, 2, 2);
            List<Weapon> weapons = new List<Weapon>() { w1,w2,w3};
            TraderContact(weapons);
        }
        public class Stalker
        {
            public string nickname;
            private int hp=100;
            public int money;
            public string currentWeapon = "fist";
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
            public string CurrentWeapon
            {
                get { return currentWeapon; }
            }
        }
        public class Weapon
        {
            protected string name;
            protected int damage;
            protected int accuracy;
            protected int distance;
            protected int ammoLoad;
            protected int BuyPrice;
            public Weapon(string name,int damage, int accuracy, int distance,int ammoLoad, int BuyPrice)
            {
                this.name = name;
                this.damage = damage;
                this.accuracy = accuracy;
                this.distance = distance;
                this.ammoLoad = ammoLoad;
                this.BuyPrice = BuyPrice;
            }
            public string Name
            {
                get { return name; }//1
            }
        }
       
    }
}
