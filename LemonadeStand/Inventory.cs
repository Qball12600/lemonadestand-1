using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    //single responsibility principle SOLID
    class Inventory
    {
        // member variables (HAS A)
        public List<Lemon> Lemons { get; set; }
        public List<SugarCube> SugarCubes { get; set; }
        public List<IceCube> IceCubes { get; set; }

        public List<Cup> Cups { get; set; }


        // constructor (SPAWNER)
        public Inventory()
        {
            Lemons = new List<Lemon>();
            SugarCubes = new List<SugarCube>();
            IceCubes = new List<IceCube>();
            Cups = new List<Cup>();
            AddLemonsToInventory(20);
            AddSugarCubesToInventory(20);
            AddIceCubesToInventory(100);
            AddCupsToInventory(30);
            
        }
        public void CopyInventoryFrom(Inventory source)
        {
            Lemons = new List<Lemon>(source.Lemons);
            SugarCubes = new List<SugarCube>(source.SugarCubes);
            IceCubes = new List<IceCube>(source.IceCubes);
            Cups = new List<Cup>(source.Cups);
        }
        public void DisplayInventory()
        {
            Console.WriteLine("Inventory contents: ");
            Console.WriteLine("===========================================================");
            Console.WriteLine($"Lemons: {Lemons.Count}");
            Console.WriteLine($"SugarCubes: {SugarCubes.Count}");
            Console.WriteLine($"IceCubes: {IceCubes.Count}");
            Console.WriteLine($"Cups: {Cups.Count}");
            Console.WriteLine("===========================================================");
        }
        public bool UpdateInventory(int lemonsUsed, int sugarCubesUsed, int iceCubeUsed, int cupsUsed)
        {
            if (Lemons.Count >= lemonsUsed && SugarCubes.Count >= sugarCubesUsed && IceCubes.Count >= iceCubeUsed && Cups.Count >= cupsUsed)
            {
                Lemons.RemoveRange(0, lemonsUsed);
                SugarCubes.RemoveRange(0, sugarCubesUsed);
                IceCubes.RemoveRange(0, iceCubeUsed);
                Cups.RemoveRange(0, cupsUsed);
                return true;
            }
            return false;
        }
        public bool HasEnoughIngredients(Recipe recipe)
        {
            int lemonsRequired = recipe.LemonsPerPitcher;
            int sugarCubesRequired = recipe.SugarCubesPerPitcher;
            int iceCubesRequired = recipe.IceCubesPerPitcher;
            int cupsRequired = recipe.CupsPerPitcher;

            bool hasEnoughLemons = Lemons.Count >= lemonsRequired;
            bool hasEnoughSugarCubes = SugarCubes.Count >= sugarCubesRequired;
            bool hasEnoughIceCubes = IceCubes.Count >= iceCubesRequired;
            bool hasEnoughCups = Cups.Count >= cupsRequired;
            return hasEnoughLemons && hasEnoughSugarCubes && hasEnoughIceCubes && hasEnoughCups;
        }
        public void AddLemonsToInventory(int numberOfLemons)
        {
            for (int i = 0; i < numberOfLemons; i++)
            {
                Lemon lemon = new Lemon();
                Lemons.Add(lemon);
            }
        }

        public void AddSugarCubesToInventory(int numberOfSugarCubes)
        {
            for (int i = 0; i < numberOfSugarCubes; i++)
            {
                SugarCube sugarCube = new SugarCube();
                SugarCubes.Add(sugarCube);
            }
        }

        public void AddIceCubesToInventory(int numberOfIceCubes)
        {
            for (int i = 0; i < numberOfIceCubes; i++)
            {
                IceCube iceCube = new IceCube();
                IceCubes.Add(iceCube);
            }
        }

        public void AddCupsToInventory(int numberOfCups)
        {
            for (int i = 0; i < numberOfCups; i++)
            {
                Cup cup = new Cup();
                Cups.Add(cup);
            }
        }
        public bool RemoveLemonsFromInventory(int quantity)
        {
            if (Lemons.Count >= quantity)
            {
                for (int i = 0; i < quantity; i++)
                {
                    Lemons.RemoveAt(0);
                }
                return true;
            }
            else
            {
                Console.WriteLine("Not enough lemons in inventory.");
                return false;
            }
        }
        public bool RemoveSugarCubesFromInventory(int quantity)
        {
            if (SugarCubes.Count >= quantity)
            {
                for (int i = 0; i < quantity; i++)
                {
                    SugarCubes.RemoveAt(0);
                }
                return true;
            }
            else
            {
                Console.WriteLine("Not enough sugarcubes in inventory.");
                return false;
            }
        }
        public bool RemoveIceCubesFromInventory(int quantity)
        {
            if (IceCubes.Count >= quantity)
            {
                for (int i = 0; i < quantity; i++)
                {
                    IceCubes.RemoveAt(0);
                }
                return true;
            }
            else
            {
                Console.WriteLine("Not enough icecubes in inventory.");
                return false;
            }
        }
        public bool RemoveCupsFromInventory(int quantity)
        {
            if (Cups.Count >= quantity)
            {
                for (int i = 0; i < quantity; i++)
                {
                    Cups.RemoveAt(0);
                }
                return true;
            }
            else
            {
                Console.WriteLine("Not enough cups in inventory.");
                return false;
            }
        }


    }
}
