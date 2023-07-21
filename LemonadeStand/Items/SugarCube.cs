using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    //single responsibility principle SOLID
    class SugarCube : Item
    {
        // member variables (HAS A)
        public int Quantity { get; private set; }
     
        
        // constructor (SPAWNER)
        public SugarCube() : base("SugarCube")
        {
            Quantity = 0;
           
        }
        // member methods (CAN DO)
        public void AddSugarCube(int amount)
        {
            Quantity += amount;
        }
        public void RemoveSugarCube(int amount)
        {
            if (Quantity >= amount)
            {
                Quantity -= amount;
            }
            else
            {
                Console.WriteLine("Insuffienct SugarCubes in inventory.");

            }
        }
          
        

       
    }
}
