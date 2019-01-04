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
        public double playerMoney = 25;
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
            

        }
    }
}
