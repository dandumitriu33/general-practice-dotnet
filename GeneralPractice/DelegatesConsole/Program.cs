using DelegatesLibrary;
using System;
using System.Collections.Generic;

namespace DelegatesConsole
{
    class Program
    {
        static ShoppingCartModel cart = new ShoppingCartModel();
        static void Main(string[] args)
        {
            PopulateCartWithDemoData();
            decimal total = cart.GenerateTotal(SubTotalAlert,
                                               CalculateLeveledDiscount,
                                               AlertUser);
            Console.WriteLine($"The total for the cart is {total:C2}");
            Console.WriteLine();

            decimal cart2Total = cart.GenerateTotal(
                (subTotal) => Console.WriteLine($"Cart 2: The subtotal is: {subTotal:C2}"),
                (products, subTotal) =>
                {
                    if (products.Count > 3)
                    {
                        return subTotal * 0.5M; // different calculation than the first one
                    }
                    else
                    {
                        return subTotal;
                    }
                },
                (message) => Console.WriteLine($"Cart 2: Alert: {message}")
                );
            Console.WriteLine($"Cart 2: Total: {cart2Total:C2}");
        }

        private static void SubTotalAlert(decimal subTotal)
        {
            Console.WriteLine($"The subtotal is {subTotal:C2}");
        }

        private static void AlertUser(string message)
        {
            Console.WriteLine(message);
        }

        private static decimal CalculateLeveledDiscount(List<ProductModel> items, decimal subTotal)
        {
            if (subTotal > 100)
            {
                return subTotal * 0.80M;
            }
            else if (subTotal > 50)
            {
                return subTotal * 0.85M;
            }
            else if (subTotal > 10)
            {
                return subTotal * 0.95M;
            }
            else
            {
                return subTotal;
            }
        }

        private static void PopulateCartWithDemoData()
        {
            cart.Items.Add(new ProductModel { ItemName = "Cereal", Price = 3.63M });
            cart.Items.Add(new ProductModel { ItemName = "Milk", Price = 2.95M });
            cart.Items.Add(new ProductModel { ItemName = "Strawberries", Price = 7.51M });
            cart.Items.Add(new ProductModel { ItemName = "Blueberries", Price = 8.84M });
        }
    }
}
