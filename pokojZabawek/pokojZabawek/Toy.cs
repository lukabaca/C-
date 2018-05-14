using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pokojZabawek
{
    struct Wartosc
    {
        private double cena;
        private double wartoscSentymentalna;

        public double Cena
        {
            get
            {
                return cena;
            }

            set
            {
                if (value >= 0)
                {
                    cena = value;
                }
                else
                {
                    Console.WriteLine("Nalezy podac wartosc nieujemna!");
                }
            }
        }

        public double WartoscSentymentalna
        {
            get
            {
                return wartoscSentymentalna;
            }

            set
            {
                if (value >= 0)
                {
                    wartoscSentymentalna = value;
                }
                else
                {
                    Console.WriteLine("Nalezy podac wartosc nieujemna!");
                }
            }
        }

        public Wartosc(double cena, double wartoscSentymentalna)
        {
            this.cena = cena;
            this.wartoscSentymentalna = wartoscSentymentalna;
        }

    };

    class Toy
    {
        private int age;

        private Wartosc wartoscBazowa;

        public Toy(int age, Wartosc wartoscBazowa)
        {
            this.age = age;
            this.wartoscBazowa = wartoscBazowa;
        }
        public virtual void showToyInfo()
        {
            Console.WriteLine("Wiek: " + age + "Cena: " + wartoscBazowa.Cena + "Wartosc Sentymentalna: " + wartoscBazowa.WartoscSentymentalna);
        }

        public double WartoscAktualna
        {
            get
            {
                return (wartoscBazowa.Cena / age) + wartoscBazowa.WartoscSentymentalna;
            }
        }

        public Wartosc WartoscBazowa
        {
            get
            {
                return this.wartoscBazowa;
            }
            set
            {
                this.wartoscBazowa = value;
            }
        }

        public int Age
        {
            get
            {
                return age;
            }

            set
            {
                if (value > 0)
                {
                    age = value;
                }
                else
                {
                    Console.WriteLine("Wiek musi byc dodatni");
                }
            }
        }
    }
}
