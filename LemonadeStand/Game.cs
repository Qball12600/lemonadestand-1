using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace LemonadeStand
{
    internal class Game
    {

        private Player player;
        private List<Day> days;
        private int currentDay;
        private Random random;
        public Game(string playerName)
        {
            player = new Player(playerName, 20.00);
            days = new List<Day>();
            currentDay = 0;
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
                Console.WriteLine("Day " + (currentDay + 1) + "Weather: " + days[currentDay].Weather.Forecast);
                Console.WriteLine("=======================================");

                Day currentDayObject = days[currentDay];
                Console.WriteLine("Weather: " + currentDayObject.Weather.Forecast);
                Console.WriteLine("Temperature: " + currentDayObject.Weather.ForecastTemperature + "°c");
                player.DisplayPlayerStatus();
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

            for (int dayNumber = 1; dayNumber <= numberOfDays; dayNumber++)
            {
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










        
