using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class GameForecastedWeather : Game
    {
        
        public override void GameLogic()
        {
            newDay.dayWeather.GenerateForecastTemperature();
            here:
            try
            {
                Console.WriteLine("FOR HOW MANY DAYS YOU WANT TO PLAY THE GAME?");
                int daysToPlay = int.Parse(Console.ReadLine());
                Console.WriteLine("Press ENTER TO START");
                Console.ReadLine();
                Console.Clear();
                for (int i = 0; i < daysToPlay; i++)
                {
                    ResetDailyValues();
                    currentDayNo = i+1;

                    newDay.dayWeather.weatherType = newDay.dayWeather.weatherList[i];
                    newDay.dayWeather.temperature = newDay.dayWeather.temperatureForecast[i];
                    newDay.GenerateCustomers(newDay.dayWeather);


                    DisplayDayInventoryScreen();

                    myStore.SellCups(player1);
                    Console.Clear();
                    DisplayDayInventoryScreen();

                    myStore.SellLemons(player1);
                    Console.Clear();
                    DisplayDayInventoryScreen();

                    myStore.SellSugar(player1);
                    Console.Clear();
                    DisplayDayInventoryScreen();

                    myStore.SellIce(player1);
                    Console.Clear();
                    DisplayDayInventoryScreen();

                    player1.CreateRecipe(myStore);
                    Console.Clear();
                    DisplayDayInventoryScreen();

                    player1.SetCupPrice();
                    Console.Clear();
                    DisplayDayInventoryScreen();

                    newDay.SellLemonade(player1);
                    Console.WriteLine($"Total {newDay.customersDidBuy} customers bought your lemonade today");
                    newDay.CalculateProfit(myStore, player1);
                    DisplayDailyStats();
                    Console.ReadLine();

                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Please input a valid number of days");
                goto here;
            }

        }

        public override void DisplayDayInventoryScreen()
        {
            Console.WriteLine($"***********************DAY {currentDayNo}*****************************");
            Console.WriteLine("Weather today is " + newDay.dayWeather.weatherType.ToUpper());
            Console.WriteLine("Temperature High will be " + newDay.dayWeather.temperature + " degrees.");
            Console.WriteLine($"Potiential Customer Count today will be around {newDay.todaysCustomers.Count}");
            player1.DisplayInventory();
            //Console.ReadLine();
        }
    }
}
