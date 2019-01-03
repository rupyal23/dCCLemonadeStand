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

       

        public void SetCupPrice()
        {

        }

        public void SellLemonade()
        {

        }
    }
}
