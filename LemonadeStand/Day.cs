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
      public int LemonadeSold { get; set; }
       public int InventoryUsed { get; set;
        }
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
            int lemonadeSold = 0;
            int inventoryUsed = 0;

            Inventory initialInventory = new Inventory();
            initialInventory.CopyInventoryFrom(player.Inventory);
           
            foreach (Customer customer in Customers)
            {
                bool purchaseMade = customer.BuyLemonade((int)player.Recipe.Price);

                if (purchaseMade)
                {
                    lemonadeSold++;
                    

                   
                    player.Wallet.AcceptMoney(player.Recipe.Price);
                }
                int customersCount = Customers.Count;
                int cupsSold = Math.Min(Customers.Count, player.Inventory.Cups.Count);
                int pitchersMade = player.Recipe.CupsPerPitcher;

                if (player.Inventory.HasEnoughIngredients(player.Recipe))
                {

                    int lemonsUsed = player.Recipe.NumberOfLemons * pitchersMade;
                    int sugarCubesUsed = player.Recipe.NumberOfSugarCubes * pitchersMade;
                    int iceCubesUsed = player.Recipe.NumberOfIceCubes * pitchersMade;
                    int cupsUsed = player.Recipe.NumberOfCups * pitchersMade;

                    player.Inventory.UpdateInventory(lemonsUsed, sugarCubesUsed, iceCubesUsed, cupsUsed);
                    inventoryUsed += lemonsUsed + sugarCubesUsed + iceCubesUsed + cupsUsed;
                  
                }
                else
                {
                    Console.WriteLine("Not enough ingredients in inventory to make lemonade.");
                

                         Console.WriteLine("Day simulation completed.");
                    Console.WriteLine($"Lemonade Sold: {lemonadeSold}");
                    Console.WriteLine($"Inventory Used: {inventoryUsed}");

                   
                    player.Inventory.DisplayInventory();
                    player.Inventory.CopyInventoryFrom(initialInventory);
                    return true;
                }
            }
            return false;
        }    
        
    }
}
