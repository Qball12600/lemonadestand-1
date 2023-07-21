using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace LemonadeStand
{
    internal class Day
    {
       public Weather Weather { get; set; }
       public List<Customer> Customers{get; set; }

        public Day(Weather weather, List<Customer> customers)
        {

            Weather = weather;
            Customers = customers;
        }
            
        public bool SimulateDay(Player player)
        {
            Console.WriteLine("Weather:" + Weather.Forecast);
            Console.WriteLine("Temperature:" + Weather.ForecastTemperature + "°c");
            Console.WriteLine("Number of customers:" + Customers.Count);

            foreach (Customer customer in Customers)
            {
                bool purchaseMade = customer.BuyLemonade((int)player.Recipe.Price);
            
            if (purchaseMade)
            
                player.Wallet.AcceptMoney(player.Recipe.Price);
            }
           
                Console.WriteLine("Day simulation completed.");
            return true;
        }
        
    }
}
