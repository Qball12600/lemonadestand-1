using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    //single responsibility principle   SOLID
    class Wallet
    {
        // member variables (HAS A)
        public double Money { get; private set;}
       

        //constructor (SPAWNER)
        public Wallet()
        {
            Money = 20.00;
        }

        //Member Methods (CAN DO)
        public void PayMoneyForItems(double transactionAmount)
        {
            Money -= transactionAmount;
        }

        public void AcceptMoney(double income)
        {
            Money += income;
        }
        

    }


}
