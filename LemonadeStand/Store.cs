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
            try
            {
                Console.WriteLine("How many CUPS would you like to purchase?");
                int response = int.Parse(Console.ReadLine());
                if (player.PlayerMoney >= cupCost * response)
                {
                    player.playerInventory.cups += response;
                    player.PlayerMoney -= cupCost * response;
                    player.dailyExpense += cupCost * response;
                    Console.WriteLine($"Money ${player.PlayerMoney}");
                }
                else
                {
                    Console.WriteLine("You don't have enough money");
                    Console.WriteLine($"Money ${player.PlayerMoney}");
                    SellCups(player);
                }
            }
            catch(FormatException)
            {
                Console.WriteLine("Please enter a valid number. ");
                SellCups(player);
            }
        }


        //method to sell lemons
        public void SellLemons(Player player)
        {
            try
            {
                Console.WriteLine("How many LEMONS would you like to purchase?");
                int response = int.Parse(Console.ReadLine());

                if (player.PlayerMoney >= lemonCost * response)
                {
                    player.playerInventory.lemons += response;
                    player.PlayerMoney -= lemonCost * response;
                    Console.WriteLine($"Money ${player.PlayerMoney}");
                    player.dailyExpense += lemonCost * response;
                }
                else
                {
                    Console.WriteLine("You don't have enough money");
                    Console.WriteLine($"Money ${player.PlayerMoney}");
                    SellLemons(player);
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter a valid number.");
                SellLemons(player);
            }
        }

        //method to sell sugar
        public void SellSugar(Player player)
        {
            try
            {
                Console.WriteLine("How many SUGAR CUBES would you like to purchase?");
                int response = int.Parse(Console.ReadLine());

                if (player.PlayerMoney >= sugarCubeCost * response)
                {
                    player.playerInventory.sugarCubes += response;
                    player.PlayerMoney -= sugarCubeCost * response;
                    player.dailyExpense += sugarCubeCost * response;
                    Console.WriteLine($"Money ${player.PlayerMoney}");
                }
                else
                {
                    Console.WriteLine("You don't have enough money");
                    Console.WriteLine($"Money ${player.PlayerMoney}");
                    SellSugar(player);
                }
            }
            catch(FormatException)
            {
                Console.WriteLine("Please enter a valid number.");
                SellSugar(player);
            }
        }

        //method to sell ice
        public void SellIce(Player player)
        {
            try
            {   
                Console.WriteLine("How many ICE CUBES would you like to purchase?");
                int response = int.Parse(Console.ReadLine());

                if (player.PlayerMoney >= iceCubeCost * response)
                {
                    player.playerInventory.iceCubes += response;
                    player.PlayerMoney -= iceCubeCost * response;
                    player.dailyExpense += iceCubeCost * response;
                    Console.WriteLine($"Money ${player.PlayerMoney}");
                }
                else
                {
                    Console.WriteLine("You don't have enough money");
                    Console.WriteLine($"Money ${player.PlayerMoney}");
                    SellIce(player);
                }
            }
            catch(FormatException)
            {
                Console.WriteLine("Please enter a valid number.");
                SellIce(player);
            }
        }
    }
}
