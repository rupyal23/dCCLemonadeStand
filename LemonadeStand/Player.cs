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
        private double playerMoney = 100;
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
        public double profit;
        public double loss;

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
            Console.WriteLine("Enter the selling price(in cents) of the cup :");
            cupPrice = double.Parse(Console.ReadLine()) / 100;
            return cupPrice;
        }



        public void CreateRecipe(Store store)
        {
            Console.WriteLine("1 Pitcher amounts to 5 Cups of lemonade");
            Console.WriteLine("How many Pitchers do you want to make for today");
            int pitchers = int.Parse(Console.ReadLine());

            LemonAgain: 
            Console.WriteLine("How many Lemons you want to use per pitcher?");
            int lemonsUsed = int.Parse(Console.ReadLine());
            if (playerInventory.lemons >= lemonsUsed * pitchers)
            {
                playerInventory.lemons -= lemonsUsed;
            }
            else if (playerInventory.lemons < lemonsUsed * pitchers && playerInventory.lemons > 0)
            {
                Console.WriteLine($"You don't have enough lemons. Only {playerInventory.lemons} lemons left.");
                goto LemonAgain;
            }
            else
            {
                Console.WriteLine($"You have {playerInventory.lemons} lemons left.");
                store.SellLemons(this);
                goto LemonAgain;
            }

            SugarAgain:
            Console.WriteLine("How many Sugar Cubes you want to put in a pitcher?");
            int sugarUsed = int.Parse(Console.ReadLine());

            if (playerInventory.sugarCubes >= sugarUsed * pitchers)
            {
                playerInventory.sugarCubes -= sugarUsed;
            }
            else if(playerInventory.sugarCubes < sugarUsed*pitchers && playerInventory.sugarCubes > 0)
            {
                Console.WriteLine($"You don't have enough Sugar Cubes. Only {playerInventory.sugarCubes} Cubes left.");
                goto SugarAgain;
            }
            else
            {
                Console.WriteLine($"You have {playerInventory.sugarCubes} SUGAR CUBES left");
                store.SellSugar(this);
                goto SugarAgain;
            }

            IceAgain:
            Console.WriteLine("How many Ice Cubes you want to put in a pitcher?");
            int iceUsed = int.Parse(Console.ReadLine());

            if (playerInventory.iceCubes >= iceUsed * pitchers)
            {
                playerInventory.iceCubes -= iceUsed;
            }
            else if (playerInventory.iceCubes < iceUsed * pitchers && playerInventory.iceCubes > 0)
            {
                Console.WriteLine($"You don't have enough Ice Cubes. Only {playerInventory.iceCubes} Cubes left.");
                goto IceAgain;
            }
            else
            {
                Console.WriteLine($"You have {playerInventory.iceCubes} ICE CUBES left");
                store.SellIce(this);
                goto IceAgain;
            }

            DisplayInventory();
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
            Console.Clear();
            Console.WriteLine("YOU HAVE");
            Console.WriteLine($"------------------------------------------{playerInventory.cups} CUPS ------------------------------------------------------");
            Console.WriteLine($"------------------------------------------{playerInventory.lemons} LEMONS ------------------------------------------------------");
            Console.WriteLine($"------------------------------------------{playerInventory.sugarCubes} SUGAR CUBES ------------------------------------------------------");
            Console.WriteLine($"------------------------------------------{playerInventory.iceCubes} ICE CUBES ------------------------------------------------------");
            Console.WriteLine($"You have ${PlayerMoney} left");
        }
    }
}
