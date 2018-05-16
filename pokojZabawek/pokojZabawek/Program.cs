using pokojZabawek;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace pokojZabawek
{
    class Program
    {
        private static void test1(ToyRoom toyRoom)
        {
            Wartosc wartosc = new Wartosc(1, 4);

            FlyingToy samolot = new FlyingToy(3, 5, 10, wartosc);
            WaterToy zaglowka = new WaterToy(9, 1, wartosc);
            GroundToy mis = new GroundToy(50, wartosc);
            //samolot.showToyInfo();

            
            toyRoom.dodajZabawke(samolot);
            toyRoom.dodajZabawke(zaglowka);
            //pokojZabawek.dodajZabawke(mis);

            toyRoom.wyswietlPokoj();

            toyRoom.changeDepthForAll(666);
            toyRoom.wyswietlPokoj();

            Console.WriteLine("Koniec testu 1");
            Console.WriteLine("---------------------------------");
        }

        private static void test2(ToyRoom toyRoom)
        {
            Wartosc wartosc = new Wartosc(3, 5);

            FlyingToy samolot = new FlyingToy(3, 5, 10, wartosc);

           

            for (int i = 0; i < 10; i++)
            {
                toyRoom.dodajZabawke(samolot);
            }

            toyRoom.wyswietlPokoj();
            

            Console.WriteLine("Wartosc aktualna zabawki: " + samolot.WartoscAktualna);

            Console.WriteLine("Koniec testu 2");
            Console.WriteLine("---------------------------------");
        }

        private static void test3(ToyRoom toyRoom)
        {
            
            Wartosc wartosc = new Wartosc(3, 5);
            FlyingToy samolot = new FlyingToy(2, 3, 5, wartosc);

            for(int i = 0; i < 10; i++)
            {
                toyRoom.dodajZabawke(samolot);
                
            }
            toyRoom.wyswietlPokoj();
            toyRoom.changeSpeedForAll(50);

            Console.WriteLine("Koniec testu 3");
            Console.WriteLine("---------------------------------");
        }

        static void Main(string[] args)
        {
            ToyRoom toyRoom = new ToyRoom();

            Thread thread1 = new Thread(() => test1(toyRoom));
            Thread thread2 = new Thread(() => test2(toyRoom));
            Thread thread3 = new Thread(() => test3(toyRoom));



            thread1.Start();
            thread2.Start();
            thread3.Start();

            
            thread1.Join();
            thread2.Join();
            thread3.Join();
            

            Console.ReadLine();
        }

       
    }
    



}
