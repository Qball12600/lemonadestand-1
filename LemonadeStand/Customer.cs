using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    internal class Customer
    {
        private int patienceLevel;
        private int money;

        public Customer(int patienceLevel, int money)
        {
            this.patienceLevel = patienceLevel;
            this.money = money;
        }

        public bool BuyLemonade(int price)
        {
            if (money >= price && patienceLevel > 0)
            {
                money -= price;
                patienceLevel--;

                Console.WriteLine("Customer bought a cup of lemonade.");
                return true;
            }
            else
            {
                Console.WriteLine("Customer didn't buy any lemonade.");
                return false;

            }

        }

    }
}
