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
        public Player player1 = new Player();
        public Store myStore = new Store();
        public Day newDay = new Day();

        

        //Member Methods
        public void RunGame()
        {
            player1.GetPlayerName();
            Console.WriteLine("Hey "+player1.firstName+"!. Ready to own a LEMONADE STAND!!");
            DisplayRules();
            newDay.todaysWeather.CreateWeather();
            myStore.SellCups(player1);
            Console.ReadLine();
        }

        public void DisplayRules()
        {
            Console.WriteLine("Rules of the Game");
            Console.WriteLine("Player will have $25 to start their own Lemonade Stand.");
        }
    }
}
