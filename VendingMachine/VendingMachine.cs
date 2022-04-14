using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace VendingMachine
{
    public interface IVending
    {
       
        abstract void Purchase(Products productChoice);
        abstract void ShowAll();
        abstract int InsertMoney();
        abstract bool EndTransaction();
    }
    public class VendingMachine : IVending
    {
        public static Products Choice = new Products
        {
            ProductId = 0,
            ProductName = "",
            Price = 0,
            Description = ""
        };
        public static int MoneyPool { get; set; }
        public static bool insert { get; private set; }
        public static List<Products> Cart = new List<Products>();
        private static readonly int[] moneyArr = new int[] { 1, 5, 10, 20, 50, 100, 500, 1000 };
        
        public int InsertMoney() // Insert money in the money pool
        {
            Console.Clear();
            Console.WriteLine("INSERT MONEY\n");

            bool insert = true;
            
            while (insert)
            {
                Console.WriteLine("Insert money: (enter) back to menu)");
                string inputText = Console.ReadLine();

                insert = int.TryParse(inputText, out int inputMoney);

                if (string.IsNullOrWhiteSpace(inputText))
                {
                    if (MoneyPool > 0)
                    {

                    }
                    insert = false;
                }

                if (insert == true)
                {
                    int value = Array.Find(moneyArr, p => p.Equals(inputMoney));

                    if (value == inputMoney)
                    {
                        MoneyPool += inputMoney;
                    }
                    else
                    {
                        Console.WriteLine("Insert a valid value, please");
                    }
                }
                else
                {
                    Console.WriteLine("Return to menu");
                }
            }
            return MoneyPool;
        }

        public void Purchase(Products productChoice) // Buy a product
        {
            Products ProductChoice = productChoice;

            if (MoneyPool < productChoice.Price)
            {
                
                Console.WriteLine("\nSorry, price is {0} and  {1} in the money pool.\n", ProductChoice.Price, MoneyPool);
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                Cart.Add(ProductChoice);
                var shoppingItem = Cart.Last().ProductName;
                Console.WriteLine("You purchased a {0}\n", shoppingItem);
                Console.WriteLine(Choice.Use(productChoice.ProductName));
                MoneyPool -= ProductChoice.Price;
                Console.ReadKey();
                Console.Clear();
            }
        }

        public void ShowAll() // Show all products in cart
        {
            Console.Clear();
            Console.WriteLine("SHOPPING CART\n");
            Console.WriteLine("\nIn the cart:\n");

            foreach (var item in Cart)
            {
                Console.WriteLine($"Product: {item.ProductName}\t\tPrice: {item.Price}\n\n");
            }
            Console.ReadKey();
            Console.Clear();
        }

        public bool EndTransaction() // Change is recieved in valid amounts / Exits Application
        {
            int quantity1000 = MoneyPool / 1000;
            int quantity500 = (MoneyPool % 1000) / 500;
            int quantity100 = (MoneyPool % 500) / 100;
            int quantity50 = (MoneyPool % 100) / 50;
            int quantity20 = (MoneyPool % 50) / 20;
            int quantity5 = (MoneyPool % 10) / 5;
            int quantity1 = (MoneyPool % 5) / 1;

            int quantity10 = ((MoneyPool / 10) % 10);

            if (quantity10 == 2 | quantity10 == 3)
                { quantity10 = (quantity10 - 2); }

            if (quantity10 == 6 | quantity10 == 8)
                { quantity10 = 1; }

            if (quantity10 == 4 | quantity10 == 5 | quantity10 == 7 | quantity10 == 9)
                { quantity10 = 0; }

            Dictionary<int, int> dix = new Dictionary<int, int>(8);
            dix.Add(1, quantity1);
            dix.Add(5, quantity5);
            dix.Add(10, quantity10);
            dix.Add(20, quantity20);
            dix.Add(50, quantity50);
            dix.Add(100, quantity100);
            dix.Add(500, quantity500);
            dix.Add(1000, quantity1000);

            Console.Clear();
            Console.WriteLine("CHANGE");

            foreach (KeyValuePair<int, int> item in dix)
            {
                Console.WriteLine("\n" + item.Key + " quantity: " + item.Value);
            }

            Console.WriteLine("\nTotal change recieved: {0}\n", MoneyPool);

            return insert = false;
        }

    }

}
