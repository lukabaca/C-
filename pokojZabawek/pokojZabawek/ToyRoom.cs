using pokojZabawek;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pokojZabawek
{



    class ToyRoom
    {
        private static int maksymalnaLiczbaZabawek = 50;
        private static int aktualnaLiczbaZabawek = 0;

        private static double maksymalnaWartoscZabawekWpokoju = 20;

        public delegate void PrzekroczonaLiczbaZabawek();
        public delegate void PrzekroczonaWartoscZabawek();

        public event PrzekroczonaLiczbaZabawek PrzyPrzekroczeniuLiczbyZabawek;

        public event PrzekroczonaWartoscZabawek PrzyPrzekroczeniuWartosciZabawek;

        private static System.Threading.Mutex mutex = new System.Threading.Mutex();

        List<Toy> listaZabawek = new List<Toy>();

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
            mutex.WaitOne();
            int i = 0;
            int iloscZabawek = listaZabawek.Count;
            if (iloscZabawek > 0)
            {
                listaZabawek.RemoveAt(iloscZabawek - 1);
                aktualnaLiczbaZabawek--;
            }
            mutex.ReleaseMutex();
        }
        private double zwrocWartoscZabawekWPokoju()
        {
            double wartoscCalkowita = 0;
            foreach (Toy toy in listaZabawek)
            {
                    wartoscCalkowita += toy.WartoscAktualna;
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
        public void dodajZabawke(Toy toy)
        {
            mutex.WaitOne();
            if (aktualnaLiczbaZabawek >= maksymalnaLiczbaZabawek)
            {
                przekroczonaLiczbaZabawekObsluga();
            }
            
            else
            {
                listaZabawek.Add(toy);
                aktualnaLiczbaZabawek++;
                if(zwrocWartoscZabawekWPokoju() >= maksymalnaWartoscZabawekWpokoju)
                {
                    przekroczonaWartoscZabawekObsluga();
                }
            }

            mutex.ReleaseMutex();
        }
      

        public void wyswietlPokoj()
        {
            mutex.WaitOne();
            foreach (Toy toy in listaZabawek)
            {
                toy.showToyInfo();
            }
            mutex.ReleaseMutex();
        }

        public void changeSpeedForAll(int speed)
        {
            mutex.WaitOne();
            foreach (Toy toy in listaZabawek)
            {
                if(toy is IFlyingToy)
                {
                    ((FlyingToy)toy).changeSpeed(speed);
                }
            }
            mutex.ReleaseMutex();
        }

        

        public void changeDepthForAll(int depth)
        {
            mutex.WaitOne();
            foreach (Toy toy in listaZabawek)
            {
                if (toy is IWaterToy)
                {
                    ((IWaterToy)toy).changeDepth(depth);
                }
            }
            mutex.ReleaseMutex();
        }

    }



}
