using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class GameForecastedWeather : Game
    {
        public GameForecastedWeather(int daysToPlay)
        {
            this.daysToPlay = daysToPlay;
        }

        public override void GameLogic()
        { 
            newDay.dayWeather.GenerateForecastTemperature();
            Console.ReadLine();
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
                newDay.CalculateProfit(player1);
                DisplayDailyStats();
                Console.ReadLine();
            }
            LastDay();
            DisplayPlayerStats();
            PlayAgain();
        }

        public override void LastDay()
        {
            player1.PlayerMoney += player1.playerInventory.cups * myStore.cupCost;
            player1.PlayerMoney += player1.playerInventory.lemons * myStore.lemonCost;
            player1.PlayerMoney += player1.playerInventory.sugarCubes * myStore.sugarCubeCost;
            player1.PlayerMoney += player1.playerInventory.iceCubes * myStore.iceCubeCost;
            double playerLiquidatedMoney = player1.playerInventory.cups * myStore.cupCost + player1.playerInventory.lemons * myStore.lemonCost + player1.playerInventory.sugarCubes * myStore.sugarCubeCost + player1.playerInventory.iceCubes * myStore.iceCubeCost;
            player1.playerInventory.lemons = 0;
            player1.playerInventory.sugarCubes = 0;
            player1.playerInventory.cups = 01;
            player1.playerInventory.iceCubes = 0;
            Console.WriteLine($"Money received by Liquidating assets - ${playerLiquidatedMoney}");
        }
        public override void DisplayDayInventoryScreen()
        {
            var ls = new StringBuilder();
            ls.AppendLine("                                                         _______                                                   ");
            ls.AppendLine("                                                        ) - | - (                                                  ");
            ls.AppendLine("********************************************************|_ --- _|**************************************************");
            ls.AppendLine("*                            ________/                 ____|__|___                                                *");
            ls.AppendLine("*                           [----|----]   ___/_       |           |                                               *");
            ls.AppendLine("*        /-------------------[   |   ]----[   ]------------------------------/                                    *");
            ls.AppendLine("*       /                     [__|__]      [_]                              /                                     *");
            ls.AppendLine("*      /-------------------------------------------------------------------/                                      *");
            ls.AppendLine("*               |                |                   |               |                                            *");
            ls.AppendLine("*               |              -----                 |             -----                                          *");
            ls.AppendLine("*            ------                               -------                                                         *");
            ls.AppendLine("*******************************************************************************************************************");
            Console.WriteLine($"**************************----LEMONADE STAND----DAY {currentDayNo}*******************************");
            Console.WriteLine(ls);
            Console.WriteLine("Weather today is " + newDay.dayWeather.weatherType.ToUpper());
            Console.WriteLine("Temperature High will be " + newDay.dayWeather.temperature + " degrees.");
            Console.WriteLine($"Potiential Customer Count today will be around {newDay.todaysCustomers.Count}");
            player1.DisplayInventory();
        }

        public override void DisplayPlayerStats()
        {
            Console.WriteLine($"---------------------------------Money - ${player1.PlayerMoney}--------------------------------");
            float totalProfitMade = Convert.ToInt32(player1.totalSales - player1.totalExpense);
            double moneyDiff = player1.PlayerMoney - 50;
            if (totalProfitMade > 0)
            {
                Console.WriteLine($"YOU MADE TOTAL OF ${moneyDiff} RUNNING LEMONADE STAND.");
                Console.WriteLine($"Player Balance ${player1.PlayerMoney}");
            }
            else if (totalProfitMade < 0)
            {
                Console.WriteLine($"YOU LOST $({totalProfitMade}) RUNNING LEMONADE STAND.");
                Console.WriteLine($"Player Balance ${player1.PlayerMoney}");
            }
            else
            {
                Console.WriteLine("YOUR BUSINESS WAS BREAK EVEN!");
            }
        }
    }
}
