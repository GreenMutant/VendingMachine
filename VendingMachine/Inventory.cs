using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace VendingMachine
{
    public interface BaseClass
    {
        public abstract void Examine();
        public abstract string Use(string ProductName);
    }

    public class Products : BaseClass
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }

        public void Examine() // Show the products price and description
        {

            foreach (var item in Inventory.AvailableProducts)
                {
                    Console.WriteLine($"({item.ProductId}): {item.ProductName} Price: {item.Price}\nDescription: {item.Description}\n");
                }

        }
        public virtual string Use(string ProductName)
        {
            string value = "Cart is empty";
            return value;
        }        
    }

    public class Drinks : Products
    {
        public override string Use(string ProductName)
        {
            string value = "Drink it!";
            return value;
        }
    }
    public class Snacks : Products
    {
        public override string Use(string ProductName)
        {
            string value = "Eat the snacks!";
            return value;
        }
    }
    public class Candy : Products
    {
        public override string Use(string ProductName)
        {
            string value = "Eat the candy!";
            return value;
        }
    }

    public class Inventory
    {
        public static Products Init = new Products
        {
            ProductId = 0,
            ProductName = "",
            Price = 0,
            Description = ""
        };

        public static Drinks Trocadero = new Drinks
        {
            ProductId = 1,
            ProductName = "Trocadero",
            Price = 5,
            Description = "A mix of coke and orange."
        };

        public static Drinks AppleMust = new Drinks
        {
            ProductId = 2,
            ProductName = "Apple Must",
            Price = 10,
            Description = "Tasty apple juice."
        };

        public static Snacks RoastedNuts = new Snacks
        {
            ProductId = 3,
            ProductName = "Roasted Nuts",
            Price = 10,
            Description = "A mix of roasted nuts."
        };

        public static Snacks Chips = new Snacks
        {
            ProductId = 4,
            ProductName = "Chips",
            Price = 10,
            Description = "Sourcream & union taste."
        };

        public static Candy Snickers = new Candy
        {
            ProductId = 5,
            ProductName = "Snickers",
            Price = 10,
            Description = "Choclate, nuts and toffee."
        };

        public static Candy HealthyBar = new Candy
        {
            ProductId = 6,
            ProductName = "Healthy Bar",
            Price = 10,
            Description = "Oats and fruit."
        };

        public static List<Products> AvailableProducts = new List<Products>
        {
            Trocadero,
            AppleMust,
            RoastedNuts,
            Chips,
            Snickers,
            HealthyBar
        };
   
    }

}
    

