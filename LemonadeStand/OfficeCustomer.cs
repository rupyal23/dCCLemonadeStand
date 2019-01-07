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
            if (chanceToBuy == 10 && weather.temperature > 40)
            {
                return true;
            }
            if (chanceToBuy < 10 && chanceToBuy >= 8 && weather.temperature > 75)
            {
                return true;
            }
            if (chanceToBuy < 8 && chanceToBuy >= 5 && weather.temperature > 95)
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
