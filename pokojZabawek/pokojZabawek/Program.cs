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
        private static void test1()
        {
            Wartosc wartosc = new Wartosc(1, 4);

            FlyingToy samolot = new FlyingToy(3, 5, 10, wartosc);
            WaterToy zaglowka = new WaterToy(9, 1, wartosc);
            GroundToy mis = new GroundToy(50, wartosc);
            //samolot.showToyInfo();

            ToyRoom pokojZabawek = new ToyRoom();

            //samolot.showToyInfo();

            //pokojZabawek.PrzyPrzekroczeniuLiczbyZabawek += new PokojZabawek.PrzekroczonaLiczbaZabawek(wyswietlInformacje);

            pokojZabawek.dodajZabawke(samolot);
            pokojZabawek.dodajZabawke(zaglowka);
            //pokojZabawek.dodajZabawke(mis);

            pokojZabawek.wyswietlPokoj();

            pokojZabawek.changeDepthForAll(666);
            pokojZabawek.wyswietlPokoj();

            Console.WriteLine("Koniec testu 1");
            Console.WriteLine("---------------------------------");
        }

        private static void test2()
        {
            Wartosc wartosc = new Wartosc(3, 5);

            FlyingToy samolot = new FlyingToy(3, 5, 10, wartosc);

            ToyRoom pokojZabawek = new ToyRoom();

            pokojZabawek.dodajZabawke(samolot);

            pokojZabawek.wyswietlPokoj();

            Console.WriteLine("Wartosc aktualna zabawki: " + samolot.WartoscAktualna);

            Console.WriteLine("Koniec testu 2");
            Console.WriteLine("---------------------------------");
        }

        private static void test3()
        {
            ToyRoom pokojZabawek = new ToyRoom();
            pokojZabawek.wyswietlPokoj();


            Console.WriteLine("Koniec testu 3");
            Console.WriteLine("---------------------------------");
        }

        static void Main(string[] args)
        {
            Thread thread1 = new Thread(test1);
            Thread thread2 = new Thread(test2);
            Thread thread3 = new Thread(test3);



            thread1.Start();
            thread2.Start();
            thread3.Start();

            Console.ReadLine();
        }

       
    }
    



}
