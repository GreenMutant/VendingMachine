using System;
using Xunit;
using VendingMachine;

namespace xUnitTest
{

    public class VendingMachineTest
    {
        // Tests if subclass methods overrides baseclass method
        [Fact]
        public void TestProducts()
        {
            Products Product = new Products();
            string test = "product";
            string expected = "Empty";

            test = Product.Use(test);

            Assert.Equal(test, expected);
        }

        [Fact]
        public void TestDrinks()
        {

            Drinks Choice = new Drinks
            {
                ProductId = 1,
                ProductName = "Trocadero",
                Price = 5,
                Description = ""
            };

            string test = "test";
            string expected = "Drink it!";

            test = Choice.Use(Choice.ProductName);

            Assert.Equal(test, expected);
        }

        [Fact]
        public void TestSnacks()
        {

            Snacks Choice = new Snacks
            {
                ProductId = 3,
                ProductName = "Roasted Nuts",
                Price = 10,
                Description = ""
            };

            string test = "test";
            string expected = "Eat the snacks!";

            test = Choice.Use(Choice.ProductName);

            Assert.Equal(test, expected);
        }

        [Fact]
        public void TestCandy()
        {

            Candy Choice = new Candy
            {
                ProductId = 5,
                ProductName = "Snickers",
                Price = 10,
                Description = ""
            };

            string test = "test";
            string expected = "Eat the candy!";

            test = Choice.Use(Choice.ProductName);

            Assert.Equal(test, expected);
        }
    }
}