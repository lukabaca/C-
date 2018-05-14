using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pokojZabawek
{
    class FlyingToy :  Toy, IFlyingToy
    {
        private int speed;
        private int height;

        public FlyingToy(int speed, int height, int age, Wartosc value) : base(age, value)
        {
            this.speed = speed;
            this.height = height;

        }

        public override void showToyInfo()
        {
            base.showToyInfo();
            Console.WriteLine("Szybkosc: " + speed + "Wysokosc: " + height);
        }

        public int Speed
        {
            get
            {
                return this.speed;
            }
            set
            {
                if (value > 0)
                {
                    this.speed = value;
                }
                else
                {
                    Console.WriteLine("Szybkosc musi byc dodatnia");
                }
            }

        }

        public int Height
        {
            get
            {
                return this.height;
            }
            set
            {
                if (value > 0)
                {
                    this.height = value;
                }
                else
                {
                    Console.WriteLine("Wysokosc musi byc dodatnia");
                }
            }

        }

        public void changeSpeed(int speed)
        {
            this.speed = speed;
        }

        public void changeHeihgt(int height)
        {
            this.height = height;
        }
    }
}
