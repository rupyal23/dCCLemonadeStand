using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Game
    {
        //Member Variables
        Player player1 = new Player();
        Weather todaysWeather = new Weather();
        

        //Member Methods
        public void RunGame()
        {
            Console.WriteLine("Welcome to the LEMONADE STAND.");
            Console.ReadLine();
            player1.GetPlayerName();
            DisplayRules();
            todaysWeather.CreateWeather();
            Console.ReadLine();
        }

        public void DisplayRules()
        {
            Console.WriteLine("Rules of the Game");
        }
    }
}
