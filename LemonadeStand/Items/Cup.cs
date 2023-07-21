using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    //single responsibility principle SOLID
    class Cup : Item
    {

        // member variables (HAS A)
        public int Quantity { get; private set; }
        
       

        // constructor (SPAWNER)
        public Cup(): base ("Cup")
        {
            Quantity = 0;
           
        }
        // member methods (CAN DO)
        public void AddCups(int amount)
        {
            Quantity += amount;
        }
        public void RemoveCups(int amount)
        {
            if (Quantity >=amount)
            {
                Quantity -= amount;
            }
            else
            {
                Console.WriteLine("Insufficient cups in inventory.");

            }
        } 
       
    }
}
