﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Game
    {
        //Member Variables
        public Player player1;
        public Store myStore;
        public Day newDay;
        public int currentDayNo;



        //Member Methods

        public Game()
        {
            player1 = new Player();
            myStore = new Store();
            newDay = new Day();
        }
        public void RunGame()
        {

            player1.GetPlayerName();
            DisplayRules();

            Console.WriteLine("Do You want to see the Forecasted Weather for next 7 Days? Enter 'yes' or 'no'.");
            here:
            string userResponse = Console.ReadLine().ToLower();
            switch (userResponse)
            {
                case "yes":
                    GameForecastedWeather newGame = new GameForecastedWeather();
                    newGame.GameLogic();
                    break;
                case "no":
                    GameLogic();
                    break;
                default:
                    Console.WriteLine("Please enter a valid response");
                    goto here;
            }
            LastDay();
            DisplayPlayerStats();
            Console.ReadLine();
        }

        public void DisplayRules()
        {
            Console.Clear();
            Console.WriteLine("Hey " + player1.firstName + "!. Ready to own a LEMONADE STAND!!");
            Console.WriteLine("Rules of the Game");
            Console.WriteLine("Player will have $100 to start their own Lemonade Stand.");
        }

        public void ResetDailyValues()
        {
            Console.Clear();
            player1.playerInventory.iceCubes = 0;
            newDay.dayLoss = 0;
            newDay.dayProfit = 0;
            player1.totalExpense = player1.dailyExpense;
            player1.totalSales = player1.dailySales;
            player1.dailyExpense = 0;
            player1.dailySales = 0;
            newDay.todaysCustomers = new List<Customer>();
        }
        public virtual void GameLogic()
        {
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
                    currentDayNo = i;

                    newDay.CreateDayWeather();
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
                GameLogic();
            }
        }


        

        public void CheckForecast()
        {
            Console.WriteLine("Do You want to see the Forecasted Weather for next 7 Days? Enter 'yes' or 'no'.");
            string userResponse = Console.ReadLine().ToLower();
            switch (userResponse)
            {
                case "yes":
                    newDay.dayWeather.GenerateForecastTemperature();
                    break;
                case "no":
                    break;
                default:
                    Console.WriteLine("Please enter a valid response");
                    CheckForecast();
                    break;
            }
        }

        public void LastDay()
        {
            player1.PlayerMoney += player1.playerInventory.cups * myStore.cupCost;
            player1.PlayerMoney += player1.playerInventory.lemons * myStore.lemonCost;
            player1.PlayerMoney += player1.playerInventory.sugarCubes * myStore.sugarCubeCost;
            player1.PlayerMoney += player1.playerInventory.iceCubes * myStore.iceCubeCost;
            double playerLiquidatedMoney = player1.playerInventory.cups * myStore.cupCost + player1.playerInventory.lemons * myStore.lemonCost + player1.playerInventory.sugarCubes * myStore.sugarCubeCost + player1.playerInventory.iceCubes * myStore.iceCubeCost;
            player1.playerInventory.cups = 0;
            player1.playerInventory.lemons = 0;
            player1.playerInventory.sugarCubes = 0;
            player1.playerInventory.iceCubes = 0;
            Console.WriteLine($"Money received by Liquidating assets - ${playerLiquidatedMoney}");
        }

        public void DisplayPlayerStats()
        {
            Console.WriteLine($"---------------------------------Money - ${player1.PlayerMoney}--------------------------------");
            double totalProfitMade = player1.totalSales - player1.totalExpense;
            Console.WriteLine($"Total profit ${totalProfitMade}");
            Console.WriteLine($"Player Balance ${player1.PlayerMoney}");
        }
        public void DisplayDailyStats()
        {
            Console.WriteLine($"---------------------------------Money - ${player1.PlayerMoney}--------------------------------");
            Console.WriteLine($"---------------------------------Today's Profit - ${newDay.dayProfit}--------------------------");
            Console.WriteLine($"---------------------------------Today's Loss - ${newDay.dayLoss}-------------------------");
            Console.WriteLine($"---------------------------------Today's Expense - ${player1.dailyExpense}---------------------");
            Console.WriteLine($"---------------------------------Today's Sales - ${player1.dailySales}-------------------------");
            
            Console.WriteLine("----------------------------------ALL OF YOUR ICE HAS MELTED----------------------");
            Console.ReadLine();
        }

        public virtual void DisplayDayInventoryScreen()
        {
            Console.WriteLine($"***********************DAY {currentDayNo + 1}*****************************");
            Console.WriteLine("Weather today is " + newDay.currentDayWeatherType.ToUpper());
            Console.WriteLine("Temperature High will be " + newDay.dayWeather.dayTemperature + " degrees.");
            Console.WriteLine($"Potiential Customer Count today will be around {newDay.todaysCustomers.Count}");
            player1.DisplayInventory();
            //Console.ReadLine();
        }
    }
}
