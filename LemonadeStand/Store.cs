using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    //single responsibility principle SOLID
    //also demonstraes open/closed principle
    class Store
    {
        // member variables (HAS A)
        public double pricePerLemon;
        public double pricePerSugarCube;
        public double pricePerIceCube;
        public double pricePerCup;

      
        // constructor (SPAWNER)
        public Store()
        {
            pricePerLemon = .5;
            pricePerSugarCube = .1;
            pricePerIceCube = .01;
            pricePerCup = .25;
        }
        //Member Methods
        public void SellLemons(Player player)
        {
            int lemonsToPurchase = UserInterface.GetNumberOfItems("lemons");
            double transactionAmount = CalculateTransactionAmount(lemonsToPurchase, pricePerLemon);
            if(player.Wallet.Money >= transactionAmount)
            {
                player.Wallet.PayMoneyForItems(transactionAmount);
                player.Inventory.AddLemonsToInventory(lemonsToPurchase);
                Console.WriteLine($"You bought {lemonsToPurchase} lemons. ");
            }
            else
            {
                Console.WriteLine("You don't have enough money to buy lemons.");
            }
        }

        public void SellSugarCubes(Player player)
        {
            int sugarToPurchase = UserInterface.GetNumberOfItems("sugar");
            double transactionAmount = CalculateTransactionAmount(sugarToPurchase, pricePerSugarCube);
            if(player.Wallet.Money >= transactionAmount)
            {
                PerformTransaction(player.Wallet, transactionAmount);
                player.Inventory.AddSugarCubesToInventory(sugarToPurchase);
                Console.WriteLine($"You bought {sugarToPurchase} sugarCubes.");
            }
            else
            {
                Console.WriteLine("You don't have enough money to buy sugar cubes.");
            }
        }

        public void SellIceCubes(Player player)
        {
            int iceCubesToPurchase = UserInterface.GetNumberOfItems("ice cubes");
            double transactionAmount = CalculateTransactionAmount(iceCubesToPurchase, pricePerIceCube);
            if(player.Wallet.Money >= transactionAmount)
            {
                PerformTransaction(player.Wallet, transactionAmount);
                player.Inventory.AddIceCubesToInventory(iceCubesToPurchase);
                Console.WriteLine($"You bought {iceCubesToPurchase} ice cubes.");
            }
            else
            {
                Console.WriteLine("You don't have enough money to buy ice cubes.");
            }
        }

        public void SellCups(Player player)
        {
            int cupsToPurchase = UserInterface.GetNumberOfItems("cups");
            double transactionAmount = CalculateTransactionAmount(cupsToPurchase, pricePerCup);
            if(player.Wallet.Money >= transactionAmount)
            {
                PerformTransaction(player.Wallet, transactionAmount);
                player.Inventory.AddCupsToInventory(cupsToPurchase);
                Console.WriteLine($"You bought {cupsToPurchase} cups.");
            }
            else
            {
                Console.WriteLine("You don't have enough money to buy cups.");
            }
        }
        

        public double CalculateTransactionAmount(int itemCount, double itemPricePerUnit)
        {
            double transactionAmount = itemCount * itemPricePerUnit;
            return transactionAmount;
        }

        public void PerformTransaction(Wallet wallet, double transactionAmount)
        {
            wallet.PayMoneyForItems(transactionAmount);
        }
    }
}
