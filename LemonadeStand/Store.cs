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
            for(int i = 0; i < response; i++)
            {
                Cups playerCups = new Cups();
                player.playerInventory.cups.Add(playerCups);
                player.playerMoney -= cupCost;
            }
        }


        //method to sell lemons
        public void SellLemons(Player player)
        {
            Console.WriteLine("How many LEMONS would you like to purchase?");
            int response = Console.Read();
            for (int i = 0; i < response; i++)
            {
                Lemons playerLemons = new Lemons();
                player.playerInventory.lemons.Add(playerLemons);
                player.playerMoney -= lemonCost;
            }
        }

        //method to sell sugar
        public void SellSugar(Player player)
        {
            Console.WriteLine("How many SUGAR CUBES would you like to purchase?");
            int response = Console.Read();
            for (int i = 0; i < response; i++)
            {
                Sugar playerSugar = new Sugar();
                player.playerInventory.sugarCubes.Add(playerSugar);
                player.playerMoney -= sugarCubeCost;
            }

        }

        //method to sell ice
        public void SellIce(Player player)
        {
            Console.WriteLine("How many ICE CUBES would you like to purchase?");
            int response = Console.Read();
            for (int i = 0; i < response; i++)
            {
                Ice playerIceCubes = new Ice();
                player.playerInventory.iceCubes.Add(playerIceCubes);
                player.playerMoney -= iceCubeCost;
            }
        }
    }
}
