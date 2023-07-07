using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Player
    {
        // member variables (HAS A)
        public Inventory inventory;
        public Wallet wallet;
        public Recipe recipe;

        // constructor (SPAWNER)
        public Player()
        {
            inventory = new Inventory();
            wallet = new Wallet();
            recipe = new Recipe();
        }

        // member methods (CAN DO)
        public Wallet Wallet
        {
            set
            {
                Wallet = value;
            }
            get
            {
                return wallet;
            }
        }   
        public Inventory Inventory
        {
            get
            {
                return inventory;
            }

        }
        public Recipe Recipe
        {
            get
            {
                return recipe;
            }
        }
        
    }
}
