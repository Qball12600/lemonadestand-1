using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace LemonadeStand
{
    internal class Game
    {
        private Weather weather;
        private Player player;
        private List<Day> days;
        private int currentDay;
        private Store store;
        private Random random;
        public Game(string playerName)
        {
            weather = new Weather();
            player = new Player(playerName, 20.00);
            days = new List<Day>();
            currentDay = 0;
            store = new Store();
            random = new Random();
        }
        public void SetNumberOfDaysToPlAY()
        {
            Console.WriteLine("Enter the number of days you would like to play (between 7 and 21): ");
            int numberOfDays = 0;
            bool validInput = false;
            while (!validInput)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out numberOfDays))
                {
                    if (numberOfDays >= 6 && numberOfDays <= 22)
                    {
                        validInput = true;
                    }
                    else
                    {
                        Console.WriteLine("Please enter a number between 7 and 21.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
                
                
            }
        }
        public void AddDay(Weather weather, List<Customer> customers)
        {
            Day day = new Day(weather, customers);
            days.Add(day);
        }
        public void StartGame()
        {
        
            //Game loop
            ConfigurePlayer();
            ConfigureDays();

            while (currentDay < days.Count)
            {
                Console.WriteLine("=======================================");
                Console.WriteLine("Day "  + (currentDay + 1)     +   "Weather: "    +     days[currentDay].Weather.Forecast);
                Console.WriteLine("=======================================");

                Day currentDayObject = days[currentDay];
                Console.WriteLine("Weather: "  +  currentDayObject.Weather.Forecast);
                Console.WriteLine("Temperature: "  +  currentDayObject.Weather.ForecastTemperature + "°c");
                
                player.DisplayPlayerStatus();
                GoToStore();
                NonStorePurchaseMessage();

                //Console.WriteLine("Would you like to simulate day?"(Y / N));
                Console.WriteLine("Running day simulation.");
                currentDayObject.SimulateDay(player);

               


                currentDay++;
                Console.WriteLine();
                Console.WriteLine("Press enter to continue to next day.");
                Console.ReadLine();
            
            }
            
            
            Console.WriteLine("Total Profit:$" + player.Wallet.Money);
        }
        public void ConfigurePlayer()
        {
            Console.WriteLine("Enter player name:");
            string playerName = Console.ReadLine();
            player.Name = playerName;

        }
        public void GoToStore()
        {

            Console.WriteLine("========================================================================");
            Console.WriteLine("Do you want to modify the recipe and price of the lemonade? (Y/N) ");
            string response = Console.ReadLine();
            if (response.ToLower() == "y")
            {
                Console.WriteLine("Enter the number of lemons.");
                int lemons = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the number of sugarcubes.");
                int sugarCubes = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the number of icecubes.");
                int iceCubes = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the price per cup of lemonade. ");
                double price = double.Parse(Console.ReadLine());
                player.AdjustRecipe(lemons, sugarCubes, iceCubes, price);
                Console.WriteLine("Recipe was Adjusted successfully.");
            }
            Console.WriteLine("Welcome to the store.");
            Console.WriteLine("====================================================================================================");
            Console.WriteLine("Do you want to purchase items from the store? (Y/N)");
            string storeresponse = Console.ReadLine();
            if (storeresponse.ToLower() == "y")
            {
                bool wantToBuyMore = true;
                while (wantToBuyMore)
                {
                    Console.WriteLine("What items would you like to purchase?");
                    Console.WriteLine("1. Lemons");
                    Console.WriteLine("2. Sugar cubes");
                    Console.WriteLine("3. Ice cubes");
                    Console.WriteLine("4. Cups");
                    Console.WriteLine("0. Exit");

                    int selection = Convert.ToInt32(Console.ReadLine());
                    switch (selection)
                    {
                        case 1:



                            store.SellLemons(player);

                            break;
                        case 2:


                            store.SellSugarCubes(player);
                            break;
                        case 3:


                            store.SellIceCubes(player);
                            break;
                        case 4:


                            store.SellCups(player);
                            break;
                        case 0:
                            wantToBuyMore = false;
                            Console.WriteLine("Thank you for visiting our store.");
                            break;
                        default:
                            Console.WriteLine("Invalid selection. Please try again.");
                            break;
                            Console.WriteLine("Do you want to purchase anything else? (Y/N)");
                            response = Console.ReadLine();
                            wantToBuyMore = response.ToLower() == "y";

                    }
                    if (wantToBuyMore)
                    {
                        Console.WriteLine("Do you want to buy more items? (Y?N)");
                        response = Console.ReadLine();
                        wantToBuyMore = response.ToLower() == "y";
                    }

                    Console.WriteLine("==================================================================");
                    Console.WriteLine("Updated Wallet: ");
                    player.Wallet.DisplayMoney();
                    Console.WriteLine("===================================================================");
                    Console.WriteLine("Updated Inventory: ");
                    player.Inventory.DisplayInventory();
                    Console.WriteLine("===================================================================");
                }
                Console.WriteLine("Current recipe.");
                Console.WriteLine($"Lemons: {player.Recipe.NumberOfLemons}");
                Console.WriteLine($"Sugar: {player.Recipe.NumberOfSugarCubes}");
                Console.WriteLine($"IceCubes: {player.Recipe.NumberOfIceCubes}");
                Console.WriteLine($"Price: {player.Recipe.Price}");



               

            }
            else
            {
                Console.WriteLine("You chose not to buy anything from the store.");

            }

                
                
            
                
        }
        
        public void NonStorePurchaseMessage()
        {
            Console.WriteLine("Would you like to run simulation? (Y/N");
            string response = Console.ReadLine().ToLower();
        }
        public void RunSimulation(Day day, Player player)
        {
            bool simulateResult = day.SimulateDay(player);
            if (simulateResult)
            {
                double totalSales = day.LemonadeSold * player.Recipe.Price;
                double totalExpenses = day.InventoryUsed * player.Recipe.Price;
                double profit = totalSales - totalExpenses;

                player.Wallet.AcceptMoney(profit);

                Console.WriteLine("Simulation Results: ");
                Console.WriteLine($"Lemonade Sold: {day.LemonadeSold}");
                Console.WriteLine($"Total Sales: ${totalSales:F2}");
                Console.WriteLine($"Total Expenses: ${totalExpenses:F2}");
                Console.WriteLine($"Profit: ${profit:F2}");

                player.Inventory.DisplayInventory();
            }
            else
            {
                Console.WriteLine("Simulation failed.");
            }
        }
        public List<Customer> GenerateRandomCustomers()
        {
            List<Customer> customersForDay = new List<Customer>();
            int numberOfCustomers = random.Next(5, 15);
            for (int i = 0; i < numberOfCustomers; i++)
            {
                int randomPatienceLevel = random.Next(1, 10);
                int randomMoney = random.Next(10, 50);
                Customer customer = new Customer(randomPatienceLevel, randomMoney);
                customersForDay.Add(new Customer(randomPatienceLevel,randomMoney));
            }
            return customersForDay;
        }
        public void ConfigureDays()
        {
            days = new List<Day>();
            Console.WriteLine("Enter the number of days to play.");
            int numberOfDays = Convert.ToInt32(Console.ReadLine());

            for (int dayNumber = 1 ; dayNumber <= numberOfDays ; dayNumber++)
            {
                Console.WriteLine($"\nDay{dayNumber}");
                Weather forecastWeather = GenerateRandomWeather();
                List<Customer> customersForDay = GenerateRandomCustomers();
                List<Customer> customers = new List<Customer>();
                Day day = new Day(forecastWeather, customersForDay);
                days.Add(day);

            }

        }
        private Weather GenerateRandomWeather()
        {
            string[] possibleWeatherConditions = { "Sunny", "Cloudy", "Rainy", "Windy", "Snowy" };
            int randomWeatherIndex = random.Next(possibleWeatherConditions.Length);
            string randomWeatherCondition = possibleWeatherConditions[randomWeatherIndex];
            int randomTemperature = random.Next(50, 99);
            Weather forecastWeather = new Weather {Forecast = randomWeatherCondition,ForecastTemperature = randomTemperature};
            return forecastWeather;

        }

            
       

    } 
}           // select number of days
            // inventory/purchase and starting cash
            // price/quality control
            // run day simulation
            // show inventory loses
            // loop back to inventory/purchasing
            //run simulation for number of days selected and ask if they would like to play again










        
