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

        public void BuyInventory()
        {
            
        }
    }
}
