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
        public Player player1;
        public Store myStore;
        public Day newDay;
        public int currentDayNo;
        StringBuilder ls = new StringBuilder();

        public int daysToPlay;

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
            AskAgain:
            try
            {   
                Console.WriteLine("FOR HOW MANY DAYS YOU WANT TO PLAY THE GAME?");
                daysToPlay = int.Parse(Console.ReadLine());
                if (daysToPlay > 31)
                {
                    Console.WriteLine("Sorry! You only have a month's license to run the stand");
                    goto AskAgain;
                }
            }
            catch(FormatException)
            {
                Console.WriteLine("Please input a valid number of days");
                goto AskAgain;
            }
            Console.WriteLine("Do You want to see the Forecasted Weather for next 7 Days? Enter 'yes' or 'no'.");
            here:
            string userResponse = Console.ReadLine().ToLower();
            switch (userResponse)
            {
                case "yes":
                    GameForecastedWeather newGame = new GameForecastedWeather(daysToPlay);
                    newGame.GameLogic();
                    break;
                case "no":
                    GameLogic();
                    LastDay();
                    DisplayPlayerStats();
                    PlayAgain();
                    break;
                case "banana":
                    Console.WriteLine("No Bananas Please");
                    goto here;
                case "bananas":
                    Console.WriteLine("No Bananas Please");
                    goto here;
                default:
                    Console.WriteLine("Please enter a valid response");
                    goto here;
            }
        }

        public void ResetDailyValues()
        {
            Console.Clear();
            player1.playerInventory.iceCubes = 0;
            player1.dayLoss = 0;
            player1.dayProfit = 0;
            player1.dailyExpense = 0;
            player1.dailySales = 0;
            newDay.todaysCustomers = new List<Customer>();
        }
        public virtual void GameLogic()
        {
            
            Console.WriteLine("Press ENTER TO START");
            Console.ReadLine();
            for (int i = 0; i < daysToPlay; i++)
            {
                ResetDailyValues();
                currentDayNo = i+1;

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
                newDay.CalculateProfit(player1);
                DisplayDailyStats();
                Console.ReadLine();
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

        public virtual void LastDay()
        {
            //Sell ALL Inventory
            player1.PlayerMoney += player1.playerInventory.cups * myStore.cupCost;
            player1.PlayerMoney += player1.playerInventory.lemons * myStore.lemonCost;
            player1.PlayerMoney += player1.playerInventory.sugarCubes * myStore.sugarCubeCost;
            player1.PlayerMoney += player1.playerInventory.iceCubes * myStore.iceCubeCost;
            double playerLiquidatedMoney = player1.playerInventory.cups * myStore.cupCost + player1.playerInventory.lemons * myStore.lemonCost + player1.playerInventory.sugarCubes * myStore.sugarCubeCost + player1.playerInventory.iceCubes * myStore.iceCubeCost;
            player1.playerInventory.lemons = 0;
            player1.playerInventory.sugarCubes = 0;
            player1.playerInventory.cups = 01;
            player1.playerInventory.iceCubes = 0;
            Console.WriteLine("-------------------------------GAME OVER--------------------------------------------");
            Console.WriteLine($"Money received by Liquidating assets - ${playerLiquidatedMoney}");
        }

        //Dsiplay Game end stats
        public virtual void DisplayPlayerStats()
        {
            Console.WriteLine($"---------------------------------Money - ${player1.PlayerMoney}--------------------------------");
            float totalProfitMade = Convert.ToInt32(player1.totalSales - player1.totalExpense);
            double moneyDiff = player1.PlayerMoney - 50;
            if(totalProfitMade > 0)
            {
                Console.WriteLine($"YOU MADE TOTAL OF ${moneyDiff} RUNNING LEMONADE STAND.");
                Console.WriteLine($"Player Balance ${player1.PlayerMoney}");
            }
            else if(totalProfitMade < 0)
            {
                Console.WriteLine($"YOU LOST $({totalProfitMade}) RUNNING LEMONADE STAND.");
                Console.WriteLine($"Player Balance ${player1.PlayerMoney}");
            }
            else
            {
                Console.WriteLine("YOUR BUSINESS WAS BREAK EVEN!");
            }
            
        }
        public void DisplayDailyStats()
        {
            Console.WriteLine($"---------------------------------DAY-{currentDayNo} STATS ----------------------------------");
            Console.WriteLine($"---------------------------------TOTAL SALES - ${player1.dailySales}------------------------");
            Console.WriteLine($"---------------------------------PROFIT - ${player1.dayProfit}-------------------------------");
            Console.WriteLine($"---------------------------------LOSS - ${player1.dayLoss}-----------------------------------");
            Console.WriteLine($"---------------------------------MONEY BALANCE- ${player1.PlayerMoney}-----------------------");
            Console.ReadLine();
            Console.WriteLine("----------------------------------ALL OF YOUR ICE LEFT HAS MELTED----------------------");
            newDay.RunningProfitLoss(player1);
            
        }

        public void PlayAgain()
        {
            Console.WriteLine("Do you want to play again? Enter yes or no");
            string input = Console.ReadLine().ToLower();
            if(input == "yes")
            {
                RunGame();
            }
            else if(input == "no")
            {   
                Console.WriteLine("THANKS FOR PLAYING. BYE!");
                Console.ReadLine();
            }
            else if(input == "banana" || input =="bananas")
            {
                Console.WriteLine("Ok! YOU REALLY GOTTA STOP IT NOW");
                PlayAgain();
            }
            else
            {
                Console.WriteLine("Please Enter a valid response.");
                PlayAgain();
            }

        }
        public void DisplayRules()
        {
            Console.Clear();
            Console.WriteLine("Hey " + player1.firstName + "!. Ready to own a LEMONADE STAND!!");
            var rules = new StringBuilder();
            rules.AppendLine("********************************************RULES OF THE GAME**************************************************");
            rules.AppendLine("*                                       Player will start with $50 Cash                                       *");
            rules.AppendLine("*                        At the start of each day, player can buy items from the store.                       *");
            rules.AppendLine("*                Player will get the option of setting up the price at the start of each day.                 *");
            rules.AppendLine("*     Keep in mind the weather conditions as they strongly impact the buying experience of each customer.     *");
            rules.AppendLine("*            At the end of each day, daily sales/expense and daily profit/loss report is displayed.           *");
            rules.AppendLine("*           At the end of the game, player can see how much their Lemonade stand has made in total.           *");
            rules.AppendLine("*****************************************************ENJOY*****************************************************");
            Console.WriteLine(rules);
        }
        public virtual void DisplayDayInventoryScreen()
        {
            ls.Clear();
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
            Console.WriteLine("Weather today is " + newDay.currentDayWeatherType.ToUpper());
            Console.WriteLine("Temperature High will be " + newDay.dayWeather.dayTemperature + " degrees.");
            Console.WriteLine($"Potiential Customer Count today will be around {newDay.todaysCustomers.Count}");
            Console.WriteLine();
            player1.DisplayInventory();
        }
    }
}
