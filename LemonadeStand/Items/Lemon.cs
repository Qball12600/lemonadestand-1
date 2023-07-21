using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    //single responsibility principle SOLID
    class Lemon : Item
    {
        // member variables (HAS A)
        public int Quantity { get; private set; }
     
        
        // constructor (SPAWNER)
        public Lemon() : base("Lemon")
        {
            Quantity = 0;
            
        }
        // member methods (CAN DO)
        public void AddLemon(int amount)
        {
            Quantity += amount;
        }
        public void RemoveLemon(int amount)
        {
            if (Quantity >= amount)
            {
                Quantity -= amount;
            }
            else
            {
                Console.WriteLine("Insuffienct lemon in inventory.");

            }
        }
       

       
    }
}
