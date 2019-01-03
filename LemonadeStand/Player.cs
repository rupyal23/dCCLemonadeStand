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
        public double playerMoney;
        public int playerCups;
        public int playerLemons;
        public int playerSugarCubes;
        public int playerIceCubes;
        public double playerDailyProfit;
        public double playerDailyLoss;
        public double playerRunningTotal;

        public Player(string firstName, double playerMoney, int playerCups, int playerLemons, int playerSugarCubes, int playerIceCubes)
        {
            this.firstName = firstName;
            this.playerMoney = playerMoney;
            this.playerCups = playerCups;
            this.playerLemons = playerLemons;
            this.playerSugarCubes = playerSugarCubes;
            this.playerIceCubes = playerIceCubes;

        }

        public Player()
        {

        }

        public void GetPlayerName()
        {
            do
            {
                Console.WriteLine("Please enter your name");
                firstName = Console.ReadLine();
            }
            while (!CheckName(firstName));
        }


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


    }
}
