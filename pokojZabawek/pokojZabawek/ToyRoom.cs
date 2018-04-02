using pokojZabawek;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pokojZabawek
{



    class PokojZabawek
    {
        private static int maksymalnaLiczbaZabawek = 3;
        private static int aktualnaLiczbaZabawek = 0;

        private static double maksymalnaWartoscZabawekWpokoju = 10;

       
        public event PrzekroczonaLiczbaZabawek PrzyPrzekroczeniuLiczbyZabawek;

        public event PrzekroczonaWartoscZabawek PrzyPrzekroczeniuWartosciZabawek;



        List<Zabawka> listaZabawek = new List<Zabawka>();

        private void przekroczonaLiczbaZabawekKomunikat()
        {
            Console.WriteLine("Nie mozna juz dodac wiecej zabawek do pokoju");
        }

        private void przekroczonaWartoscZabawekWPokojuKomunikat()
        {
            Console.WriteLine("Po dodaniu tej zabawki zostala przekroczona maksymalna wartosc zabawek w pokoju, dlatego musimy ja usunac");
        }
        private void usunOstatniaZabawke()
        {
            int i = 0;
            int iloscZabawek = listaZabawek.Count;
            listaZabawek.RemoveAt(iloscZabawek - 1);
            aktualnaLiczbaZabawek--;
            
        }
        private double zwrocWartoscZabawekWPokoju()
        {
            double wartoscCalkowita = 0;
            foreach (Zabawka zabawka in listaZabawek)
            {
                    wartoscCalkowita += zabawka.WartoscAktualna;
            }
            return wartoscCalkowita;
        }
        
        private void przekroczonaLiczbaZabawekObsluga()
        {
            this.PrzyPrzekroczeniuLiczbyZabawek += new PrzekroczonaLiczbaZabawek(przekroczonaLiczbaZabawekKomunikat);
            if (PrzyPrzekroczeniuLiczbyZabawek != null)
            {
                PrzyPrzekroczeniuLiczbyZabawek();
            }
        }

        private void przekroczonaWartoscZabawekObsluga()
        {
            this.PrzyPrzekroczeniuWartosciZabawek += new PrzekroczonaWartoscZabawek(usunOstatniaZabawke);
            this.PrzyPrzekroczeniuWartosciZabawek += new PrzekroczonaWartoscZabawek(przekroczonaWartoscZabawekWPokojuKomunikat);
            if (PrzyPrzekroczeniuWartosciZabawek != null)
            {
                PrzyPrzekroczeniuWartosciZabawek();
            }
        }
        public void dodajZabawke(Zabawka zabawka)
        {
            if (aktualnaLiczbaZabawek >= maksymalnaLiczbaZabawek)
            {
                przekroczonaLiczbaZabawekObsluga();
            }
            
            else
            {
                listaZabawek.Add(zabawka);
                aktualnaLiczbaZabawek++;
                if(zwrocWartoscZabawekWPokoju() >= maksymalnaWartoscZabawekWpokoju)
                {
                    przekroczonaWartoscZabawekObsluga();
                }
            }
        }
        public void zmienSzybkosc(int szybkosc)
        {
            foreach (Zabawka zabawka in listaZabawek)
            {
                zabawka.Szybkosc = szybkosc;
            }
        }

        public void zmienWysokosc(int wysokosc)
        {
            foreach (Zabawka zabawka in listaZabawek)
            {
                zabawka.Wysokosc = wysokosc;
            }
        }

        public void zmienGlebokosc(int glebokosc)
        {
            foreach (Zabawka zabawka in listaZabawek)
            {
                zabawka.Glebokosc = glebokosc;
            }
        }

        public void wyswietlPokoj()
        {
            foreach (Zabawka zabawka in listaZabawek)
            {
                Console.WriteLine("Szybkosc zabawki: " + zabawka.Szybkosc + " Wysokosc zabawki: " + zabawka.Wysokosc + " Glebokosc zabawki: " + zabawka.Glebokosc + " Obecnie zabawek: " + aktualnaLiczbaZabawek + "/" + maksymalnaLiczbaZabawek);
                Console.WriteLine("Wartosc zabawki: " + zabawka.WartoscAktualna);
            }

        }

    }



}
