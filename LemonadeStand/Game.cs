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
            Console.WriteLine("Hey " + player1.firstName + "!. Ready to own a LEMONADE STAND!!");
            DisplayRules();
            newDay.CreateDayWeather();
            myStore.SellCups(player1);
            Console.ReadLine();
            
            player1.SetCupPrice();
        }

        public void DisplayRules()
        {
            Console.Clear();
            Console.WriteLine("Rules of the Game");
            Console.WriteLine("Player will have $25 to start their own Lemonade Stand.");
        }

        public void GameLogic()
        {
            double cupPrice = player1.SetCupPrice();
            //newDay.currentDayTemperature;
            //newDay.currentDayWeatherType;
        }
    }
}
