using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    //single responsibility principle SOLID
    class IceCube : Item
    {
        // member variables (HAS A)
        public int Quantity { get; private set; }
      

        // constructor (SPAWNER)
        public IceCube() : base("IceCube")
        {
            Quantity = 0;
           
        }  
        public void AddIceCube(int amount)
        {
            Quantity += amount;
        }
        // member methods (CAN DO)
        public void RemoveIceCube(int amount)
        {
            if (Quantity >= amount)
            {
                Quantity -= amount;
            }
            else
            {
                Console.WriteLine("Insuffienct icecubes in inventory.");

            }
        }
      
        

        
    }
}
