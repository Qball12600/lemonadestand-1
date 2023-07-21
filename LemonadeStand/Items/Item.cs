using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    //single responsibility principle SOLID
    // also demonstrates open/closed principle
    abstract class Item
    {// member variables (HAS A)
        public string Name { get; protected set; }
        public double Price { get; protected set; }
        // constructor (SPAWNER)
        public Item(string name)
            {
            Name = name;
            Price = 0.0;
            }
        // member methods (CAN DO)
        public void SetPrice(double price)
        {
            Price = price;
        }
        
   
        

        
    }
}
