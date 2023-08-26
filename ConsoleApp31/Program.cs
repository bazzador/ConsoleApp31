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
        static void Journey(Stalker stalker)
        {
            Console.WriteLine("-------------------------------");

            Random random = new Random();
            byte randomEvent = (byte)random.Next(1, 4);
            if (randomEvent == 3)
            {
                Console.WriteLine("Ти нікого не зустрів.");
                Console.WriteLine("-------------------------------");
            }
            else
            {
                byte randomAmount = (byte)random.Next(1, 4);
                byte randomDistance = (byte)random.Next(1, 3);
                Console.WriteLine("{0},{1},{2}", randomEvent, randomAmount, randomDistance);
                string[] Events = { "Сліпі пси", "Бандюгани" };
                string[] Amount = { "Символічно", "Декілька", "Середня кількість", "Багато" };
                string[] Distance = { "Близько", "Неподалеку", "Далеко" };
                Console.WriteLine($"Ти зустрів когось:\n{Events[0]}\n{Amount[random.Next(0, 3)]}\n{Distance[random.Next(0, 2)]}");
                Console.WriteLine("Що робимо???\n1.Стріляємо!.\n2.Тікаємо!");
                int x;
                do
                {
                    x = int.Parse(Console.ReadLine());
                    switch (x)
                    {
                        case 1:
                            InitialBattle(randomEvent, /*randomAmount,*/ randomDistance, stalker);
                            break;
                        case 2: break;
                        default:
                            Console.WriteLine("Нормально вибери!");
                            break;
                    }
                    Console.WriteLine("-------------------------------");
                } while (x > 2);

            }
        }
        static void InitialBattle(byte Event, /*byte Amount,*/ byte Distance, Stalker stalker)
        {
            Random random = new Random();
            int Tiles = 9;
            //switch (Event)
            //{
            //    case 0: 
                    Enemy blindDog = new Enemy(40, 20, 0, 3);
                    Distance = (byte)(Distance * 3 + 3);
                    Console.WriteLine($"Собака на відстані {Distance} тайлів: що робимо?\n1.Стріляємо\n2.Наступаємо.\n3.Відступаємо\n4.Тікаємо з поля бою[Відстань>10]\n9.Закінчити хід.");
                    Console.WriteLine("----");
                    Console.WriteLine($"КРОКІВ ЗАЛИШИЛОСЯ: {Tiles}");
                    int x; bool canEscape = false;
            do
            {
                x = int.Parse(Console.ReadLine());
                switch (x)
                {
                    case 1:
                        if (Tiles >= 4 && Distance < stalker.currentWeapon.Distance)
                        {
                            if (random.Next(1, 20) <= stalker.currentWeapon.Accuracy)
                            {

                                Console.WriteLine($"[УСПІШНО] Влучив!   {random}/20");
                                blindDog.SuccecfullHit(stalker.currentWeapon.Damage);
                                Console.WriteLine(blindDog.Health);
                                if (blindDog.Health < 0)
                                {
                                    Console.WriteLine("Ворог мертвий!");
                                    break;
                                }
                            }
                            else
                            {
                                Console.WriteLine($"[НЕВДАЧА] Куля не влучила в ціль.    {random}/20");
                            }
                            Tiles -= 4;
                        }
                        break;
                    case 2:
                        if (Tiles >= 2) Distance -= 1; Console.WriteLine($"Тепер ми на крок ближче до ворога! {Distance}");
                        break;
                    case 3:
                        if (Tiles >= 2) Distance += 1; Console.WriteLine($"Тепер ми на крок далі від ворога! {Distance}");
                        break;
                    case 4:
                        if (Distance > 10)
                        {
                            Console.WriteLine("[УСПІШНО] Вам вдалося втекти.");
                            canEscape = true;
                        }
                        else Console.WriteLine($"[НЕДВАЧА] Ворог ще близько.");
                        break;
                    case 5: Tiles = 9;
                        break;
                    default:
                        Console.WriteLine("Спробуй знову написати.");
                        break;
                }
            } while (blindDog.Health > 0 || canEscape == true || x>5 || x<1); 

                //    break;
                //case 1: 
            //}
        }
        static void CanBuyWeapon(Weapon w, Stalker s)
        {
            if (s.Money >= w.BuyPrice)
            {
                Console.WriteLine("[УСПІХ] Відмінна зброя, ти не пожалкуєш, сталкер!");
                s.SetCurrentWeapon = w;
            }
            else Console.WriteLine("[НЕВДАЧА] Недостатньо коштів.");
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
            int x;
            do
            {
                Console.WriteLine("-------------------------------");
                Console.WriteLine("Шо робим?\n1.Йдем до Сидора\n2.Шукаєм пригоди на свою голову\n10.Нафіг зону...");
                x = int.Parse(Console.ReadLine());
                switch (x)
                {
                    case 1:
                        TraderContact(weapons, l1);
                        break;
                    case 2:
                        Journey(l1);
                        break;
                    case 10:
                        break;
                    default:
                        Console.WriteLine("бб");
                        break;
                }
            } while (x != 10);

        }
        public class Stalker
        {
            public string nickname;
            private int hp = 100;
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
                set { currentWeapon = value; }
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
            private int TilesMove = 2;
            public Weapon(string name, int damage, int accuracy, int distance, int ammoLoad, int buyPrice)
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
            public int Damage
            {
                get { return damage; }
            }
            public int Accuracy
            {
                get { return accuracy; }
            }
            public int Distance
            {
                get { return distance; }
            }
            public int AmmoLoad
            {
                get { return ammoLoad; }
            }
            public int BuyPrice
            {
                get { return buyPrice; }
            }
        }
        public class Enemy
        {
            private int health;
            private int damage;
            private int distanceAttack;
            private int tilesMove;

            public int Health
            {
                get { return health; }
            }
            public int Damage
            {
                get { return damage; }
            }
            public int DistanceAttack
            {
                get { return distanceAttack; }
            }
            public int TilesMove
            {
                get { return tilesMove; }
            }
            public Enemy(int health, int damage, int distanceAttack, int tilesMove)
            {
                this.health = health;
                this.damage = damage;
                this.distanceAttack = distanceAttack;
                this.tilesMove = tilesMove;
            }
            public int SuccecfullHit(int damage)
            {
                return this.health -= damage;
            }
        }
       
    }
}
