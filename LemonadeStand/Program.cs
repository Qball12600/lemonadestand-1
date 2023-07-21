namespace LemonadeStand
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Lemonade Stand!");

            Game lemonadeStandGame = new Game("Your name here.");
            lemonadeStandGame.StartGame();
            //lemonadeStandGame.ConfigureDays();
            //lemonadeStandGame.SetNumberOfDaysToPlAY();
            //Create weather object
            //Weather weather = new Weather();
            //create list of customers object
            //List<Customer> customers = new List<Customer>();
            //add customers to list
            //customers.Add(new Customer(5,10));
            //customers.Add(new Customer(1,5));
            //create player object
            //Player player = new Player("Player:",20.00);
            //create day object passing weather and customers
             //Day day = new Day(weather, customers);
            // simulate day
            //bool dayResult = day.SimulateDay(player);
            //if (dayResult)
            //{
            //    Console.WriteLine("Day simulation successful");
            //}
            //else
            //{
               // Console.WriteLine("Simulation failed.");
            //}
            //
        }
    }
}