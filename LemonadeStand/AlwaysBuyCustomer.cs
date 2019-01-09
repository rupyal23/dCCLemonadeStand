using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class AlwaysBuyCustomer : Customer
    {
        public override bool BuyLemonade(Weather weather)
        {
            if (chanceToBuy == 10)
            {
                return true;
            }
            if (chanceToBuy < 10 && chanceToBuy >= 2 && weather.temperature > 30)
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
