using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class OfficeCustomer : Customer
    {
        public override bool BuyLemonade(Weather weather)
        {
            if (chanceToBuy == 10 && weather.dayTemperature > 40)
            {
                return true;
            }
            if (chanceToBuy < 10 && chanceToBuy >= 8 && weather.dayTemperature > 75)
            {
                return true;
            }
            if (chanceToBuy < 8 && chanceToBuy >= 5 && weather.dayTemperature > 95)
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
