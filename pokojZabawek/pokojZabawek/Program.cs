using pokojZabawek;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pokojZabawek
{
    class Program
    {
        
        static void Main(string[] args)
        {


           

            Wartosc wartosc = new Wartosc(1, 4);

            FlyingToy samolot = new FlyingToy(3, 5, 10, wartosc);
            WaterToy zaglowka = new WaterToy(9, 1, wartosc);
            GroundToy mis = new GroundToy(50, wartosc);
            //samolot.showToyInfo();

            PokojZabawek pokojZabawek = new PokojZabawek();

            //samolot.showToyInfo();

            //pokojZabawek.PrzyPrzekroczeniuLiczbyZabawek += new PokojZabawek.PrzekroczonaLiczbaZabawek(wyswietlInformacje);

            pokojZabawek.dodajZabawke(samolot);
            pokojZabawek.dodajZabawke(zaglowka);
            //pokojZabawek.dodajZabawke(mis);

            pokojZabawek.wyswietlPokoj();

            pokojZabawek.changeDepthForAll(666);
            pokojZabawek.wyswietlPokoj();

            

            Console.ReadLine();
        }

       
    }
    



}
