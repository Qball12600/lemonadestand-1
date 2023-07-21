using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    //single responsibility principle SOLID
    internal class Recipe
    {
        // member variables (HAS A)
        public int NumberOfLemons { get; private set; }
        public int NumberOfSugarCubes { get; private set; }
        public int NumberOfIceCubes { get; private set; }
        public double Price { get; private set; }


        // constructor (SPAWNER)
        public Recipe(int numberOfLemons, int numberOfSugarCubes, int numberOfIceCubes, double price)
        {
            this.NumberOfLemons = numberOfLemons;
            this.NumberOfSugarCubes = numberOfSugarCubes;
            this.NumberOfIceCubes = numberOfIceCubes;
            this.Price = price;
        }
        //Member Methods (CAN DO)
        public void AdjustRecipe(int lemons, int sugarCubes, int iceCubes, double price)
        {
            NumberOfLemons = lemons;
            NumberOfSugarCubes = sugarCubes;
            NumberOfIceCubes = iceCubes;
            Price = price;
        }
       
        public void DisplayRecipe()
        {
            Console.WriteLine($"Your recipe currently consists of:\n{NumberOfLemons} lemons per pitcher\n{NumberOfSugarCubes} sugar cubes per pitcher\n{NumberOfIceCubes} ice cubes per pitcher");
        }

    }
}
