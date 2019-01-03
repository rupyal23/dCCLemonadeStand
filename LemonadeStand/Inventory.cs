using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Inventory
    {
        public List<Cups>cups;
        public List<Lemons>lemons;
        public List<Sugar>sugarCubes;
        public List<Ice> iceCubes;
        
        //constructor
        public Inventory()
        {
            cups = new List<Cups>();
            lemons = new List<Lemons>();
            sugarCubes = new List<Sugar>();
            iceCubes = new List<Ice>();
        }
    }
}
