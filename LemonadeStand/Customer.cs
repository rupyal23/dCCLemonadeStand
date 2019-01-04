using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Customer
    {
        
        public int chanceToBuy = 10;
        
        

        //member methods

        public void CustomerExpectedPrice(Player player)
        {
            
            List<double> priceRange = new List<double>() { .15, .25, .35, .45, .55, .65, .75, .85, .95, 1.05};
            for (int i = 0; i < priceRange.Count; i++)
            {
                if (player.cupPrice > priceRange[i])
                {

                    chanceToBuy--;
                }
            }
        }
        public virtual bool BuyLemonade(Weather weather, Player player)
        {
            //weather affects
            //price affects
            CustomerExpectedPrice(player);

            if(chanceToBuy == 10 && weather.dayTemperature > 40)
            {
                return true;
            }
            if(chanceToBuy < 10 && chanceToBuy >= 8 && weather.dayTemperature > 60)
            {
                return true;
            }
            if(chanceToBuy >= 5 && chanceToBuy < 8 && weather.dayTemperature > 70)
            {
                return true;
            }
            else if(chanceToBuy < 5 && chanceToBuy >= 3 && weather.dayTemperature > 95)
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
