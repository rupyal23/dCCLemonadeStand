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
                    value = 0;
                }
            }
        }

        public double cupPrice;

        public Inventory playerInventory = new Inventory();

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

       
        //Need to work on this yet
        public double SetCupPrice()
        {
            Console.WriteLine("Enter the selling price(in cents) of the cup :");
            cupPrice = double.Parse(Console.ReadLine())/100;
            return cupPrice;
        }

        //Need to work on this yet
        public void SellLemonade(List<Customer>dayCustomers)
        {
            for(int i = 0; i <= dayCustomers.Count; i++)
            {
                //if (dayCustomers[i].BuyLemonade() == "true")
                //{

                //}
            }
            
        }

        public void CreateRecipe()
        {
            Console.WriteLine("1 Pitcher amounts to 5 Cups of lemonade");
            Console.WriteLine("How many Pitchers do you want to make for today");
            int pitchers = int.Parse(Console.ReadLine());

            Console.WriteLine("How many Lemons you want to use per pitcher?");
            int lemonsUsed = int.Parse(Console.ReadLine());
            playerInventory.lemons -= lemonsUsed;

            Console.WriteLine("How many Sugar Cubes you want to put in a pitcher?");
            int sugarUsed = int.Parse(Console.ReadLine());
            playerInventory.sugarCubes -= sugarUsed;

            Console.WriteLine("How many Ice Cubes you want to put in a pitcher?");
            int iceUsed = int.Parse(Console.ReadLine());
            playerInventory.iceCubes -= iceUsed;

            DisplayInventory();
        }
        public void DisplayInventory()
        {
            Console.Clear();
            Console.WriteLine($"You have {playerInventory.cups} cups left.");
            Console.WriteLine($"You have {playerInventory.lemons} lemons left.");
            Console.WriteLine($"You have {playerInventory.sugarCubes} Sugar Cubes left.");
            Console.WriteLine($"You have {playerInventory.iceCubes} Ice Cubes left.");
            Console.WriteLine($"You have ${PlayerMoney} left");
        }
    }
}
