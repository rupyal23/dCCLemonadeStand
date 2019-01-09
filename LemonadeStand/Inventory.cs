using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Inventory
    {

        private int _cups;
        public int cups { get { return _cups; }
            set
            {
                if(value > 0)
                {
                    _cups = value;
                }
                else
                {
                    Console.WriteLine("YOU SOLD OUT OF CUPS");
                    _cups = 0;
                }
            }
        }
        public int lemons;
        public int iceCubes;
        public int sugarCubes;

        
        
        //constructor
        public Inventory()
        {
           
        }
    }
}
