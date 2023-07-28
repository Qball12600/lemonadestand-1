using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace LemonadeStand
{
    //single responsibility principle SOLID
    //also demonstrates open/closed principle
    class Player
    {
        // member variables (HAS A)
       
            public string Name { get; set; }
            public Inventory Inventory { get; private set; }
            public Wallet Wallet { get; private set; }
            public  Recipe Recipe { get; set; }


        // constructor (SPAWNER)
        public Player(string name, double startingMoney) 
        {
            Name = name;
            Inventory = new Inventory();
            Wallet = new Wallet();
            Recipe = new Recipe(2,4,10,1,0);
        }
        public void SimulateDay(Day day)
        {
            int cupsPossible = Math.Min(Inventory.Lemons.Count / Recipe.LemonsPerPitcher, Math.Min(Inventory.SugarCubes.Count / Recipe.SugarCubesPerPitcher, Inventory.IceCubes.Count / Recipe.IceCubesPerPitcher));
            int cupsToSell = Math.Min(cupsPossible, Recipe.CupsPerPitcher);
            if (cupsToSell > 0)
            {
                day.LemonadeSold = cupsToSell;
                day.InventoryUsed = cupsToSell * Recipe.CupsPerPitcher;
            }
            else
            {
                day.LemonadeSold = 0;
                day.InventoryUsed = 0;
            }
        }
        public void DisplayPlayerStatus()
        {
            Console.WriteLine("Player: " + Name);
            Console.WriteLine("Money: " + Wallet.Money);
            Console.WriteLine("Inventory: ");
            Console.WriteLine("- Lemons: " + Inventory.Lemons.Count);
            Console.WriteLine("- Sugar: " + Inventory.SugarCubes.Count);
            Console.WriteLine("- IceCubes: " + Inventory.IceCubes.Count);
            Console.WriteLine("- Cups: " + Inventory.Cups.Count);
            Console.WriteLine("Recipe: ");
            Console.WriteLine("- Lemons: " + Recipe.NumberOfLemons);
            Console.WriteLine("- Sugar: " + Recipe.NumberOfSugarCubes);
            Console.WriteLine("- IceCubes: " + Recipe.NumberOfIceCubes);
            Console.WriteLine("- Price: " + Recipe.Price);
        }
        public void AdjustRecipe(int lemons, int sugarCubes, int iceCubes, double price)
        {
            Recipe.AdjustRecipe(lemons, sugarCubes, iceCubes, price);
            Console.WriteLine("Recipe successfully adjusted!");
        }

   

    }
}
