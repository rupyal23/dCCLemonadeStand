using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Weather
    {
        public float dayTemperature;
        public List<string> weatherType = new List<string>() { "hot", "sunny", "cloudy", "rainy", "cold" };



        //member methods
        public string CreateWeatherType()
        {
            Random todaysWeather = new Random();
            int position = todaysWeather.Next(weatherType.Count);
            string currentWeatherType = weatherType[position];
            return currentWeatherType;
        }
                 
        public float CreateTemperature(int min, int max)
        {
            Random todaysTemperature = new Random();
            int currentTemperature = todaysTemperature.Next(min, max);
            return currentTemperature;
        }
        public void CreateWeather()
        {
            float currentDayTemperature;
            string currentDayWeatherType = CreateWeatherType();
            if(currentDayWeatherType == "hot")
            {
                currentDayTemperature = CreateTemperature(88, 110);
            }
            else if(currentDayWeatherType == "sunny")
            {
                currentDayTemperature = CreateTemperature(70, 87);
            }
            else if(currentDayWeatherType == "cloudy" || currentDayWeatherType == "rainy")
            {
                currentDayTemperature = CreateTemperature(45, 69);
            }
            else
            {
                currentDayTemperature = CreateTemperature(25, 45);
            }
            Console.WriteLine("Weather today is "+currentDayWeatherType.ToUpper());
            Console.WriteLine("Temperature High will be "+currentDayTemperature+" degrees.");
        }
    }
}
