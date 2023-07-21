using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

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
            public Recipe Recipe { get; private set; }
        // constructor (SPAWNER)
        public Player(string name, double startingMoney) 
        {
            Name = name;
            Inventory = new Inventory();
            Wallet = new Wallet();
            Recipe = new Recipe(2,4,10,1.0);
        }
        public void DisplayPlayerStatus()
        {
            Console.WriteLine("Player: " + Name);
            Console.WriteLine("Money: " + Wallet.Money);
            Console.WriteLine("Inventory: ");
            Console.WriteLine("- Lemons: " + Inventory.lemons.Count);
            Console.WriteLine("- Sugar: " + Inventory.sugarCubes.Count);
            Console.WriteLine("- IceCubes: " + Inventory.iceCubes.Count);
            Console.WriteLine("- Cups: " + Inventory.cups.Count);
            Console.WriteLine("Recipe: ");
            Console.WriteLine("- Lemons: " + Recipe.NumberOfLemons);
            Console.WriteLine("- Sugar: " + Recipe.NumberOfSugarCubes);
            Console.WriteLine("- IceCubes: " + Recipe.NumberOfIceCubes);
            Console.WriteLine("- Price: " + Recipe.Price);
        }

   

    }
}
