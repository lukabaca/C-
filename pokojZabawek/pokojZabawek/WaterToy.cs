using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pokojZabawek
{
    class WaterToy : Toy, IWaterToy
    {
        private int depth;

        public WaterToy(int depth, int age, Wartosc value) : base(age, value)
        {
            this.depth = depth;
        }

        public override void showToyInfo()
        {
            base.showToyInfo();
            Console.WriteLine("Glebokosc: " + depth);
        }
        public int Depth
        {
            get
            {
                return this.depth;
            }
            set
            {
                if (value > 0)
                {
                    this.depth = value;
                }
                else
                {
                    Console.WriteLine("Glebokosc musi byc dodatnia");
                }
            }

        }

        public void changeDepth(int depth)
        {
            this.depth = depth;
        }
    }
}
