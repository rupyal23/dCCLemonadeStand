using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class RunningCustomer : Customer
    {
        public override bool BuyLemonade(Weather weather)
        {
            if (chanceToBuy == 10 && weather.temperature > 50)
            {
                return true;
            }
            if (chanceToBuy < 10 && chanceToBuy >= 8 && weather.temperature > 57)
            {
                return true;
            }
            if (chanceToBuy >= 5 && chanceToBuy < 8 && weather.temperature > 77)
            {
                return true;
            }
            else if (chanceToBuy < 5 && chanceToBuy >= 3 && weather.temperature > 82)
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
