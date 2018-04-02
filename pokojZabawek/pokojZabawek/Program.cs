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


            /*
            Zabawka zabawka1 = new Zabawka(2, 3, 4);

            PokojZabawek pokojZabawek = new PokojZabawek();

            pokojZabawek.dodajZabawke(zabawka1);

            pokojZabawek.wyswietlPokoj();

            pokojZabawek.zmienSzybkosc(69);

            pokojZabawek.wyswietlPokoj();
            */

            /*
            Wartosc test = new Wartosc(3, 3);
            test.WartoscSentymentalna = -1;

            Zabawka zabawka2 = new Zabawka(1, 1, 1, test);
            zabawka2.Wiek = 3;

            Console.Write("Wartosc aktualna: " + zabawka2.WartoscAktualna);
            */

            Wartosc wartosc = new Wartosc(1, 4);

            Zabawka zabawka1 = new Zabawka(2, 3, 4, 2, new Wartosc(3, 1));
            Zabawka zabawka2 = new Zabawka(3, 1, 3, 1, wartosc);

            PokojZabawek pokojZabawek = new PokojZabawek();
          

            //pokojZabawek.PrzyPrzekroczeniuLiczbyZabawek += new PokojZabawek.PrzekroczonaLiczbaZabawek(wyswietlInformacje);

            pokojZabawek.dodajZabawke(zabawka1);

            pokojZabawek.wyswietlPokoj();

            pokojZabawek.dodajZabawke(zabawka2);

            pokojZabawek.wyswietlPokoj();

            

            Console.ReadLine();
        }

       
    }
    



}
