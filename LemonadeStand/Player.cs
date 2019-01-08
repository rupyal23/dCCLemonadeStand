using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Player
    {
        public string firstName;
        private double playerMoney = 50;
        public double PlayerMoney
        {
            get { return playerMoney; }
            set
            {

                if (value > 0)
                {
                    playerMoney = value;
                }
                else
                {
                    Console.WriteLine("You don't have enough money");
                    playerMoney = 0;
                }
            }
        }
        public double dailyExpense;
        public double totalExpense;
        public double dailySales;
        public double totalSales;
        public int pitchers;

        public double cupPrice;

        public Inventory playerInventory = new Inventory();
        public List<Inventory> ingredients = new List<Inventory>(); 

        //constructor
        public Player()
        {

        }

        //member methods

        //inputs the player name
        public void GetPlayerName()
        {
            do
            {
                Console.WriteLine("Please enter your name");
                firstName = Console.ReadLine();
            }
            while (!CheckName(firstName));
        }

        //helper function to validate the name of the player
        bool CheckName(string firstName)
        {
            foreach (char a in firstName)
            {
                if (!Char.IsLetter(a))
                {
                    Console.WriteLine("Enter letters only. Please try again!");
                    return false;
                }
            }
            return true;
        }


        //method to set up the price of the cup
        public double SetCupPrice()
        {
            try
            {
                Console.WriteLine("Enter the selling price(in cents) of the cup :");
                cupPrice = double.Parse(Console.ReadLine()) / 100;
            }
            catch(FormatException)
            {
                Console.WriteLine("Please enter a valid input");
                SetCupPrice();
            }   
            return cupPrice;
        }



        public void CreateRecipe(Store store)
        {
            Console.WriteLine("----------------------CREATE YOUR SECRET RECIPE-------------------");
            Console.WriteLine("-------------------NOTE - 1 PITCHER AMOUNTS TO 8 CUPS ----------------");
            Console.WriteLine("------------------------PRESS ENTER TO CONINUE ----------------------");
            Console.ReadLine();
            AddCups(store);
            AddLemons(store);
            AddSugar(store);
            AddIce(store);
        }

        //USED SOLID ON ALL INGREDIENTS
        public void AddCups(Store store)
        {
            try
            {
                Console.WriteLine("How many Pitchers do you want to make for today");
                pitchers = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter a valid input");
                AddCups(store);
            }
        }

        public void AddLemons(Store store)
        {
            try
            {
                Console.WriteLine("How many Lemons you want to use per pitcher?");
                int lemonsUsed = int.Parse(Console.ReadLine());
                if (playerInventory.lemons >= lemonsUsed * pitchers)
                {
                    playerInventory.lemons -= lemonsUsed * pitchers;
                }
                else if (playerInventory.lemons < lemonsUsed * pitchers && playerInventory.lemons > 0)
                {
                    Console.WriteLine($"You don't have enough lemons. Only {playerInventory.lemons} lemons left.");
                    AddLemons(store);
                }
                else
                {
                    Console.WriteLine($"You have {playerInventory.lemons} lemons left.");
                    store.SellLemons(this);
                    AddLemons(store);
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter a valid input");
                AddLemons(store);
            }
        }

        public void AddSugar(Store store)
        {
            try
            {
                Console.WriteLine("How many Sugar Cubes you want to put in a pitcher?");
                int sugarUsed = int.Parse(Console.ReadLine());

                if (playerInventory.sugarCubes >= sugarUsed * pitchers)
                {
                    playerInventory.sugarCubes -= sugarUsed * pitchers;
                }
                else if (playerInventory.sugarCubes < sugarUsed * pitchers && playerInventory.sugarCubes > 0)
                {
                    Console.WriteLine($"You don't have enough Sugar Cubes. Only {playerInventory.sugarCubes} Cubes left.");
                    AddSugar(store);
                }
                else
                {
                    Console.WriteLine($"You have {playerInventory.sugarCubes} SUGAR CUBES left");
                    store.SellSugar(this);
                    AddSugar(store);
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter a valid input");
                AddSugar(store);
            }
        }

        public void AddIce(Store store)
        {
            try
            {
                Console.WriteLine("How many Ice Cubes you want to put in a pitcher?");
                int iceUsed = int.Parse(Console.ReadLine());

                if (playerInventory.iceCubes >= iceUsed * pitchers)
                {
                    playerInventory.iceCubes -= iceUsed * pitchers;
                }
                else if (playerInventory.iceCubes < iceUsed * pitchers && playerInventory.iceCubes > 0)
                {
                    Console.WriteLine($"You don't have enough Ice Cubes. Only {playerInventory.iceCubes} Cubes left.");
                    AddIce(store);
                }
                else
                {
                    Console.WriteLine($"You have {playerInventory.iceCubes} ICE CUBES left");
                    store.SellIce(this);
                    AddIce(store);
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter a valid input");
                AddIce(store);
            }
        }
        //public void ChooseIngredient()
        //{

        //    Console.WriteLine($"How many {ingredient} you want to put in a pitcher");
        //    int ingredientUsed = int.Parse(Console.ReadLine());
        //    if (playerInventory.ingredient >= ingredientUsed * pitchers)
        //    {
        //        playerInventory.ingredient -= ingredientUsed;
        //    }
        //    else if (playerInventory.ingredient < ingredientUsed * pitchers && playerInventory.ingredient > 0)
        //    {
        //        Console.WriteLine($"You don't have enough {ingredient}. Only {ingredientUsed.count} left");
        //        ChooseIngredient(ingredient);
        //    }

        //}

        public void DisplayInventory()
        {
            
            Console.WriteLine("**************************************************YOU HAVE***************************************");
            Console.WriteLine($"------------------------------------------{playerInventory.cups} CUPS------------------------------------------------------");
            Console.WriteLine($"------------------------------------------{playerInventory.lemons} LEMONS------------------------------------------------------");
            Console.WriteLine($"------------------------------------------{playerInventory.sugarCubes} SUGAR CUBES------------------------------------------------------");
            Console.WriteLine($"------------------------------------------{playerInventory.iceCubes} ICE CUBES------------------------------------------------------");
            Console.WriteLine($"You have ${PlayerMoney} Cash in hand.");
        }
    }
}
