using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace LemonadeStand
{
    class Day
    {
        //member varibles
        public int currentDayTemperature;
        public string currentDayWeatherType;
        public Weather dayWeather = new Weather();   //instantiated weather for the day
        public List<Customer> todaysCustomers = new List<Customer>();    //instantiated customers for the day
        
        
        public int customersDidBuy;


        //member methods
        public void CreateDayWeather()
        {
            dayWeather.CreateWeather();
            currentDayTemperature = dayWeather.dayTemperature;
            currentDayWeatherType = dayWeather.weatherType;
        }

        //Need to work on this yet
        public int SellLemonade(Player player)
        {
            customersDidBuy = 0;
            for (int i = 0; i < todaysCustomers.Count; i++)
            {
               todaysCustomers[i].CustomerExpectedPrice(player);
               if (todaysCustomers[i].BuyLemonade(dayWeather) == true && player.playerInventory.cups > 0)
               {
                    customersDidBuy++;
                    player.playerInventory.cups--;
                    if(customersDidBuy == todaysCustomers.Count)
                    {
                        Console.WriteLine("YOU SOLD OUT OF LEMONADE! SHOULD'VE MADE MORE PITCHERS");
                    }
               }
            }
            return customersDidBuy;
        }

        public void CalculateProfit(Player player)
        {
            
            player.dailySales = customersDidBuy * player.cupPrice;
            player.totalSales += player.dailySales;
            player.totalExpense += player.dailyExpense;

            if (player.dailySales > player.dailyExpense)
            {
                player.dayProfit = player.dailySales - player.dailyExpense;
                player.PlayerMoney += player.dailySales ;
            }
            else if(player.dailySales < player.dailyExpense)
            {
                player.dayLoss = player.dailyExpense - player.dailySales;
                player.PlayerMoney += player.dailySales;
            }
            else
                Console.WriteLine("Break Even Today");
        }

        //method to calculate the running profit or loss
        public void RunningProfitLoss(Player player)
        {
            //added melted ice to the loss
            player.totalExpense += player.playerInventory.iceCubes * .10;
            if(player.totalSales > player.totalExpense)
            {
                player.runningProfit = player.totalSales - player.totalExpense;
                Console.WriteLine($"------------------------------TOTAL PROFIT SO FAR : {String.Format("{0:0.##}", player.runningProfit)}------------------------");
            }
            else if(player.totalSales < player.totalExpense)
            {
                player.runningLoss = player.totalSales - player.totalExpense;
                Console.WriteLine($"------------------------------TOTAL LOSS SO FAR : {String.Format("{0:0.##}", player.runningLoss)}------------------------");
            }
            else
            {
                Console.WriteLine("-----------------------------------BREAK EVEN SO FAR---------------------------");
            }
        }

       
        //method to generate number of customers based on weather on the given day
        public void GenerateCustomers(Weather weather)
        {
            Random rnd = new Random();
            int noOfCustomers;
            Random rand = new Random();
            

            if (weather.weatherType == "hot")
            {
                noOfCustomers = rnd.Next(110, 140);
                for (int i = 0; i < noOfCustomers; i++)
                {
                    int randomInt = rand.Next(0, 8);
                    CreateCustomers(randomInt);
                }
            }
            else if (weather.weatherType == "sunny")
            {
                noOfCustomers = rnd.Next(85, 140);
                for (int i = 0; i < noOfCustomers; i++)
                {
                    int randomInt = rand.Next(0, 8);
                    CreateCustomers(randomInt);
                }
            }
            else if ((weather.weatherType == "cloudy" || weather.weatherType == "rainy") && weather.dayTemperature > 55)
            {
                noOfCustomers = rnd.Next(70, 95);
                for (int i = 0; i < noOfCustomers; i++)
                {
                    int randomInt = rand.Next(0, 8);
                    CreateCustomers(randomInt);
                }
            }
            else if (weather.weatherType == "rainy" || weather.weatherType == "cloudy")
            {
                noOfCustomers = rnd.Next(60, 85);
                for (int i = 0; i < noOfCustomers; i++)
                {
                    int randomInt = rand.Next(0, 8);
                    CreateCustomers(randomInt);
                }
            }
            else if (weather.weatherType == "cold")
            {
                noOfCustomers = rnd.Next(30, 60);
                for (int i = 0; i < noOfCustomers; i++)
                {
                    int randomInt = rand.Next(0, 8);
                    CreateCustomers(randomInt);
                }
            }
        }

        //helper method for generating customers
        public void CreateCustomers(int number)
        {
            
            switch (number)
            {   
                case 0:
                    todaysCustomers.Add(new YoungCustomer());
                    break;
                case 1:
                    todaysCustomers.Add(new OldCustomer());
                    break;
                case 2:
                    todaysCustomers.Add(new OfficeCustomer());
                    break;
                case 3:
                    todaysCustomers.Add(new ThirstyCustomer());
                    break;
                case 4:
                    todaysCustomers.Add(new ChildCustomer());
                    break;
                case 5:
                    todaysCustomers.Add(new CheapCustomer());
                    break;
                case 6:
                    todaysCustomers.Add(new RunningCustomer());
                    break;
                case 7:
                    todaysCustomers.Add(new NeverBuyCustomer());
                    break;
                case 8:
                    todaysCustomers.Add(new AlwaysBuyCustomer());
                    break;
                default:
                    break;
            }
        }
    }
}
