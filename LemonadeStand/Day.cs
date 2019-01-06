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
        public double dayProfit;
        public double dayLoss;
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
                if (todaysCustomers[i].BuyLemonade(dayWeather) == true)
                {
                    customersDidBuy++;
                    player.playerInventory.cups--;
                }
            }
            return customersDidBuy;
        }

        public void CalculateProfit(Store store, Player player)
        {
            player.dailySales = SellLemonade(player) * player.cupPrice;
            
            if(player.dailySales > player.dailyExpense)
            {
                dayProfit = player.dailySales - player.dailyExpense;
                Console.WriteLine($"Your Total Profit for the day is ${dayProfit}");
                player.PlayerMoney += player.dailySales ;
            }
            else if(player.dailySales < player.dailyExpense)
            {
                dayLoss = player.dailyExpense - player.dailySales;
                Console.WriteLine($"Your Incurred Loss today of -${dayLoss}");
                player.PlayerMoney += player.dailySales;
            }
            else
                Console.WriteLine("Break Even Today");
        }

       
        //method to generate number of customers based on weather on the given day
        public void GenerateCustomers(Weather weather)
        {
            Random rnd = new Random();
            int noOfCustomers;
             
            if (weather.weatherType == "hot")
            {
                noOfCustomers = rnd.Next(110, 140);
                for (int i = 0; i < noOfCustomers; i++)
                {
                    CreateCustomers();
                }
               // Console.WriteLine($"Potiential Customer Count today will be around {noOfCustomers}");
            }
            else if (weather.weatherType == "sunny")
            {
                noOfCustomers = rnd.Next(85, 140);
                for (int i = 0; i < noOfCustomers; i++)
                {
                    CreateCustomers();
                }
                //Console.WriteLine($"Potiential Customer Count today will be around {noOfCustomers}");
            }
            else if ((weather.weatherType == "cloudy" || weather.weatherType == "rainy") && weather.dayTemperature > 55)
            {
                noOfCustomers = rnd.Next(70, 95);
                for (int i = 0; i < noOfCustomers; i++)
                {
                    CreateCustomers();
                }
               // Console.WriteLine($"Potiential Customer Count today will be around {noOfCustomers}");
            }
            else if (weather.weatherType == "rainy" || weather.weatherType == "cloudy")
            {
                noOfCustomers = rnd.Next(60, 85);
                for (int i = 0; i < noOfCustomers; i++)
                {
                    CreateCustomers();
                }
               // Console.WriteLine($"Potiential Customer Count today will be around {noOfCustomers}");
            }
            else if (weather.weatherType == "cold")
            {
                noOfCustomers = rnd.Next(30, 60);
                for (int i = 0; i < noOfCustomers; i++)
                {
                    CreateCustomers();
                }
               // Console.WriteLine($"Potiential Customer Count today will be around {noOfCustomers}");
            }
        }

        //helper method for generating customers
        public void CreateCustomers()
        {
            Thread.Sleep(1);
            Random rand = new Random();
            int randomInt = rand.Next(0, 6);
            switch (randomInt)
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
                default:
                    break;
            }
        }
    }
}
