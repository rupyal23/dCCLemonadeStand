using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class CheapCustomer : Customer
    {
        public override bool BuyLemonade(Weather weather)
        {
            if (chanceToBuy == 10 && weather.dayTemperature > 80)
            {
                return true;
            }
            if (chanceToBuy < 10 && chanceToBuy >= 8 && weather.dayTemperature > 82)
            {
                return true;
            }
            if (chanceToBuy >= 5 && chanceToBuy < 8 && weather.dayTemperature > 90)
            {
                return true;
            }
            else if (chanceToBuy < 5 && chanceToBuy >= 3 && weather.dayTemperature > 95)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
