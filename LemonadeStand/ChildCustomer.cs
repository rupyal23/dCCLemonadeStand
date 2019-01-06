﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class ChildCustomer : Customer
    {
        public override bool BuyLemonade(Weather weather)
        {
            if (chanceToBuy == 10)
            {
                return true;
            }
            if (chanceToBuy < 10 && chanceToBuy >= 8 && weather.dayTemperature > 55)
            {
                return true;
            }
            if (chanceToBuy >= 5 && chanceToBuy < 8 && weather.dayTemperature > 65)
            {
                return true;
            }
            else if (chanceToBuy < 5 && chanceToBuy >= 3 && weather.dayTemperature > 75)
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
