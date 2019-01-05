using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Day
    {
        //member varibles
        public int currentDayTemperature;
        public string currentDayWeatherType;
        public Weather dayWeather = new Weather();   //instantiated weather for the day
        public List<Customer> todaysCustomers = new List<Customer>();    //instantiated customers for the day
        

        //member methods
        public void CreateDayWeather()
        {
            dayWeather.CreateWeather();
            currentDayTemperature = dayWeather.dayTemperature;
            currentDayWeatherType = dayWeather.weatherType;
            
        }

        public void PlayerInventory()
        {

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
                Console.WriteLine($"Potiential Customer Count today will be around {noOfCustomers}");
            }
            else if (weather.weatherType == "sunny")
            {
                noOfCustomers = rnd.Next(85, 140);
                for (int i = 0; i < 100; i++)
                {
                    CreateCustomers();
                }
                Console.WriteLine($"Potiential Customer Count today will be around {noOfCustomers}");
            }
            else if ((weather.weatherType == "cloudy" || weather.weatherType == "rainy") && weather.dayTemperature > 55)
            {
                noOfCustomers = rnd.Next(70, 95);
                for (int i = 0; i < 80; i++)
                {
                    CreateCustomers();
                }
                Console.WriteLine($"Potiential Customer Count today will be around {noOfCustomers}");
            }
            else if (weather.weatherType == "rainy" || weather.weatherType == "cloudy")
            {
                noOfCustomers = rnd.Next(60, 85);
                for (int i = 0; i < 60; i++)
                {
                    CreateCustomers();
                }
                Console.WriteLine($"Potiential Customer Count today will be around {noOfCustomers}");
            }
            else if (weather.weatherType == "cold")
            {
                noOfCustomers = rnd.Next(30, 60);
                for (int i = 0; i < 50; i++)
                {
                    CreateCustomers();
                }
                Console.WriteLine($"Potiential Customer Count today will be around {noOfCustomers}");
            }
        }

        //helper method for generating customers
        public void CreateCustomers()
        {
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
