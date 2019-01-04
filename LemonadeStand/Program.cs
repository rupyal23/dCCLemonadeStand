using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Program
    {
        static void Main(string[] args)
        {
            //Game myGame = new Game();
            //myGame.RunGame();

            //Weather getForecast = new Weather();
            //getForecast.GenerateForecastTemperature();

            Player testplayer = new Player();
            Weather testweather = new Weather();
            YoungCustomer newCust = new YoungCustomer();
            testplayer.SetCupPrice();
            testweather.CreateWeather();
            Console.WriteLine(testweather.dayTemperature);
            Console.WriteLine(newCust.BuyLemonade(testweather, testplayer));
            Console.ReadLine();
          
        }
    }
}
