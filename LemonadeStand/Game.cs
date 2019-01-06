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
            //player1.GetPlayerName();
            //DisplayRules();
            newDay.CreateDayWeather();
            newDay.GenerateCustomers(newDay.dayWeather);
            DisplayPlayerStats();
           
            myStore.SellCups(player1);
            myStore.SellLemons(player1);
            myStore.SellSugar(player1);
            myStore.SellIce(player1);
            Console.ReadLine();
            player1.DisplayInventory();
            
            player1.CreateRecipe(myStore);
            player1.SetCupPrice();
            
            Console.ReadLine();

            newDay.SellLemonade(player1);
            Console.WriteLine($"Total {newDay.customersDidBuy} bought your lemonade today"); 
        }

        public void DisplayRules()
        {
            Console.Clear();
            Console.WriteLine("Hey " + player1.firstName + "!. Ready to own a LEMONADE STAND!!");
            Console.WriteLine("Rules of the Game");
            Console.WriteLine("Player will have $100 to start their own Lemonade Stand.");
        }

        public void GameLogic()
        {
            double cupPrice = player1.SetCupPrice();
            //newDay.currentDayTemperature;
            //newDay.currentDayWeatherType;
        }

        public void DisplayPlayerStats()
        {
            Console.WriteLine($"---------------------------------Money - ${player1.PlayerMoney}");
        }
    }
}
