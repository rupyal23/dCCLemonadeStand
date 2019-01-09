using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class NeverBuyCustomer : Customer
    {
        public override bool BuyLemonade(Weather weather)
        {
            if (chanceToBuy == 10 && weather.temperature > 100)
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
