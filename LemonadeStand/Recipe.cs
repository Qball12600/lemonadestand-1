using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    //single responsibility principle SOLID
    public class Recipe
    {
        // member variables (HAS A)
        public int NumberOfLemons { get;  set; }
        public int NumberOfSugarCubes { get; set; }
        public int NumberOfIceCubes { get; set; }
        public int NumberOfCups { get; set; }
        public double Price { get; set; }
       public int CupsPerPitcher { get; set; }
        public int LemonsPerPitcher { get; set; }
        public int SugarCubesPerPitcher { get; set; }
        public int IceCubesPerPitcher { get; set; }
       


        // constructor (SPAWNER)
        public Recipe(int lemonsPerPitcher, int sugarCubesPerPitcher, int iceCubesPerPitcher,int cupsPerPitcher, double price)
        {
           LemonsPerPitcher = lemonsPerPitcher;
           SugarCubesPerPitcher = sugarCubesPerPitcher;
            IceCubesPerPitcher = iceCubesPerPitcher;
            CupsPerPitcher = cupsPerPitcher;
            Price = price;
            
        }
        //Member Methods (CAN DO)
        public void AdjustRecipe(int lemons, int sugarCubes, int iceCubes, double price)
        {
            NumberOfLemons = lemons;
            NumberOfSugarCubes = sugarCubes;
            NumberOfIceCubes = iceCubes;
            Price = price;

            {
                if (NumberOfLemons >= lemons)
                {
                    NumberOfLemons = lemons;
                    NumberOfSugarCubes = sugarCubes;
                    NumberOfIceCubes = iceCubes;
                    Price = price;
                }
                else
                {
                    Console.WriteLine("Not enough lemons in inventory.");
                    Console.WriteLine($"You tried to remove: {lemons}lemons, but you only have {NumberOfLemons}lemons.");
                }
            }
        }
        public bool UseIngredientsForLemonade(int servings)
        {
            bool hasEnoughIngredients = NumberOfLemons >= servings && NumberOfSugarCubes >= servings && NumberOfIceCubes >= servings && NumberOfCups >= servings;
            if (hasEnoughIngredients)
            {
                NumberOfLemons -= servings;
                NumberOfSugarCubes -= servings;
                NumberOfIceCubes -= servings;
                NumberOfCups -= servings;
                return true;
            }
            else
            {
                Console.WriteLine("Not enough ingredients to make lemonade");
                Console.WriteLine("Return to the store and purchase more.");
                return false;
            }
        }
        public void DisplayRecipe()
        {
            Console.WriteLine($"Your recipe currently consists of:\n{NumberOfLemons} lemons per pitcher\n{NumberOfSugarCubes} sugar cubes per pitcher\n{NumberOfIceCubes} ice cubes per pitcher");
        }

    }
}
