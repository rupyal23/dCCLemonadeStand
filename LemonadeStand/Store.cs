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
        public string response;
        public int responseInt;

        //constructor
        public Store()
        {
            cupCost = 0.05;
            lemonCost = 0.10;
            sugarCubeCost = 0.10;
            iceCubeCost = 0.10;
        }

        //member methods


        //method to sell cups      
        public void SellCups(Player player)
        {
            try
            {
                Console.WriteLine("How many CUPS would you like to purchase? '5¢' each.");
                response = Console.ReadLine();
                responseInt = int.Parse(response);
                if (player.PlayerMoney >= cupCost * responseInt)
                {
                    player.playerInventory.cups += responseInt;
                    player.PlayerMoney -= cupCost * responseInt;
                    player.dailyExpense += cupCost * responseInt;
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
                if(response.ToString().ToLower() == "banana" || response.ToString().ToLower() == "bananas" || response.ToString().ToLower() == "bannanas")
                {
                    Console.WriteLine("Quit with Bananas Now!");
                    SellCups(player);
                }
                else
                {
                    Console.WriteLine("Please enter a valid number. ");
                    SellCups(player);
                }
            }
        }


        //method to sell lemons
        public void SellLemons(Player player)
        {
            try
            {
                Console.WriteLine("How many LEMONS would you like to purchase? '10¢' each.");
                response = Console.ReadLine();
                responseInt = int.Parse(response);

                if (player.PlayerMoney >= lemonCost * responseInt)
                {
                    player.playerInventory.lemons += responseInt;
                    player.PlayerMoney -= lemonCost * responseInt;
                    Console.WriteLine($"Money ${player.PlayerMoney}");
                    player.dailyExpense += lemonCost * responseInt;
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
                if (response.ToString().ToLower() == "banana" || response.ToString().ToLower() == "bananas" || response.ToString().ToLower() == "bannanas")
                {
                    Console.WriteLine("Quit with Bananas Now!");
                    SellCups(player);
                }
                else
                {
                    Console.WriteLine("Please enter a valid number. ");
                    SellCups(player);
                }
            }
        }

        //method to sell sugar
        public void SellSugar(Player player)
        {
            try
            {
                Console.WriteLine("How many SUGAR CUBES would you like to purchase? '10¢' each.");
                response = Console.ReadLine();
                responseInt = int.Parse(response);

                if (player.PlayerMoney >= sugarCubeCost * responseInt)
                {
                    player.playerInventory.sugarCubes += responseInt;
                    player.PlayerMoney -= sugarCubeCost * responseInt;
                    player.dailyExpense += sugarCubeCost * responseInt;
                    Console.WriteLine($"Money ${player.PlayerMoney}");
                }
                else
                {
                    Console.WriteLine("You don't have enough money");
                    Console.WriteLine($"Money ${player.PlayerMoney}");
                    SellSugar(player);
                }
            }
            catch (FormatException)
            {
                if (response.ToString().ToLower() == "banana" || response.ToString().ToLower() == "bananas" || response.ToString().ToLower() == "bannanas")
                {
                    Console.WriteLine("Quit with Bananas Now!");
                    SellCups(player);
                }
                else
                {
                    Console.WriteLine("Please enter a valid number. ");
                    SellCups(player);
                }
            }
        }

        //method to sell ice
        public void SellIce(Player player)
        {
            try
            {   
                Console.WriteLine("How many ICE CUBES would you like to purchase? '10¢' each.");
                response = Console.ReadLine();
                responseInt = int.Parse(response);

                if (player.PlayerMoney >= iceCubeCost * responseInt)
                {
                    player.playerInventory.iceCubes += responseInt;
                    player.PlayerMoney -= iceCubeCost * responseInt;
                    player.dailyExpense += iceCubeCost * responseInt;
                    Console.WriteLine($"Money ${player.PlayerMoney}");
                }
                else
                {
                    Console.WriteLine("You don't have enough money");
                    Console.WriteLine($"Money ${player.PlayerMoney}");
                    SellIce(player);
                }
            }
            catch (FormatException)
            {
                if (response.ToString().ToLower() == "banana" || response.ToString().ToLower() == "bananas" || response.ToString().ToLower() == "bannanas")
                {
                    Console.WriteLine("Quit with Bananas Now!");
                    SellCups(player);
                }
                else
                {
                    Console.WriteLine("Please enter a valid number. ");
                    SellCups(player);
                }
            }
        }
    }
}
