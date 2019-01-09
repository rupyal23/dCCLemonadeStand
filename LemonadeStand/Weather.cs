using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Weather
    {
        public int dayTemperature;
        public List<string> weatherTypeList = new List<string>() { "hot", "sunny", "cloudy", "rainy", "cold" };
        public string weatherType;
        public int temperature;
        public List<int> temperatureForecast = new List<int>();
        public List<string> weatherList = new List<string>();

        //member methods
        public string CreateWeatherType()
        {
            Random todaysWeather = new Random();
            int position = todaysWeather.Next(weatherTypeList.Count);
            weatherType = weatherTypeList[position];
            return weatherType;
        }
                 
        public int CreateTemperature(int min, int max)
        {
            Random todaysTemperature = new Random();
            temperature = todaysTemperature.Next(min, max);
            return temperature;
        }

        public void CreateWeather()
        {
            string currentDayWeatherType = CreateWeatherType();
            if(currentDayWeatherType == "hot")
            {
                dayTemperature = CreateTemperature(88, 110);
            }
            else if(currentDayWeatherType == "sunny")
            {
                dayTemperature = CreateTemperature(70, 87);
            }
            else if(currentDayWeatherType == "cloudy" || currentDayWeatherType == "rainy")
            {
                dayTemperature = CreateTemperature(45, 69);
            }
            else
            {
                dayTemperature = CreateTemperature(25, 45);
            }
        }
        public List<string> GenerateForecastWeatherType()
        {
            List<string> weatherTypeForecast = new List<string>();
            Random rnd = new Random();
            weatherTypeForecast.Add(weatherTypeList[rnd.Next(0, 4)]);
            weatherTypeForecast.Add(weatherTypeList[rnd.Next(0, 4)]);
            weatherTypeForecast.Add(weatherTypeList[rnd.Next(0, 4)]);
            weatherTypeForecast.Add(weatherTypeList[rnd.Next(0, 4)]);
            weatherTypeForecast.Add(weatherTypeList[rnd.Next(0, 4)]);
            weatherTypeForecast.Add(weatherTypeList[rnd.Next(0, 4)]);
            weatherTypeForecast.Add(weatherTypeList[rnd.Next(0, 4)]);

            return weatherTypeForecast;
        }

        public void GenerateForecastTemperature()
        {
            Random rand = new Random();

            weatherList = GenerateForecastWeatherType();

            for (int i = 0; i < weatherList.Count; i++)
            {
                if(weatherList[i].ToString() == "hot")
                {
                    temperatureForecast.Insert(i, rand.Next(88, 110));
                }
                else if(weatherList[i].ToString() == "sunny")
                {
                    temperatureForecast.Insert(i, rand.Next(70, 87));
                }
                else if(weatherList[i].ToString() == "cloudy" || weatherList[i].ToString() == "rainy")
                {
                    temperatureForecast.Insert(i, rand.Next(45, 69));
                }
                else
                {
                    temperatureForecast.Insert(i, rand.Next(25, 45));
                }
            }

            DisplayForecast();
        }

        //gotta do something with this yet/maybe display the forecast here instead from generateforeacasttemp method
        //USED SOLID - displayed forecast separate instead on in generateforecasttemp
        public void DisplayForecast()
        {
            List<string> ForecastList = new List<string>();
            for (int i = 0; i < 7; i++)
            {
                ForecastList.Add(weatherList[i].ToUpper() + " with high Temperature of " + temperatureForecast[i] + "°F.");
            }

            string currentDay = DateTime.Now.DayOfWeek.ToString();
            Console.WriteLine("Today is : " + currentDay);
            Console.WriteLine("Forecast for next 7 days is : ");
            foreach (string element in ForecastList)
            {
                Console.WriteLine(element.ToString());
            }
        }
    }
}
