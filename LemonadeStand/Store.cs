using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Store
    {
        //member variables
        public double cupCost;
        public double lemonCost;
        public double sugarCubeCost;
        public double iceCubeCost;

        public Inventory storeInventory = new Inventory();

        //constructor
        public Store()
        {
            cupCost = 0.15;
            lemonCost = 0.25;
            sugarCubeCost = 0.25;
            iceCubeCost = 0.25;
        }

        //member methods


        //method to sell cups      
        public void SellCups(Player player)
        {
            Console.WriteLine("How many CUPS would you like to purchase?");
            int response = int.Parse(Console.ReadLine());
            player.playerInventory.cups += response;
            player.PlayerMoney -= cupCost*response;
            Console.WriteLine($"Money ${player.PlayerMoney}");
        }


        //method to sell lemons
        public void SellLemons(Player player)
        {
            Console.WriteLine("How many LEMONS would you like to purchase?");
            int response = int.Parse(Console.ReadLine());
            player.playerInventory.lemons += response;
            player.PlayerMoney -= lemonCost*response;
            Console.WriteLine($"Money ${player.PlayerMoney}");
        }

        //method to sell sugar
        public void SellSugar(Player player)
        {
            Console.WriteLine("How many SUGAR CUBES would you like to purchase?");
            int response = int.Parse(Console.ReadLine());
            player.playerInventory.sugarCubes += response;
            player.PlayerMoney -= sugarCubeCost*response;
            Console.WriteLine($"Money ${player.PlayerMoney}");

        }

        //method to sell ice
        public void SellIce(Player player)
        {
            Console.WriteLine("How many ICE CUBES would you like to purchase?");
            int response = int.Parse(Console.ReadLine());
            player.playerInventory.iceCubes += response;
            player.PlayerMoney -= iceCubeCost*response;
            Console.WriteLine($"Money ${player.PlayerMoney}");
        }
    }
}
