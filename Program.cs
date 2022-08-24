using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;

namespace EcommerceTest
{
    class Program
    {
        public class Order
        {
            public List<Product> Products;
            public decimal FullPrice;

            public Order(List<Product> products)
            {
                Products = products;
                foreach (Product product in Products)
                {
                    FullPrice += product.Price;
                }
            }
        }
        public class Product
        {
            public string Name;
            public decimal Price;

            public Product(string name, decimal price)
            {
                Name = name;
                Price = price;
            }

            public void Print()
            {
                Console.WriteLine($"{Name} {Price}");
            }
        }

        public class Store
        {
            public List<Product> Products;
            public List<Product> Basket;
            public List<Order> Orders;
            public Store()
            {
                Products = new List<Product>
                {
                    new Product("Хлеб", 25),
                    new Product("Молоко", 100),
                    new Product("Печенье", 50),
                    new Product("Масло", 250),
                    new Product("Йогурт", 300),
                    new Product("Сок", 80)
                };
                Basket = new List<Product>();
                Orders = new List<Order>();
            }

            public void ShowCatalog()
            {
                Console.WriteLine("Каталог продуктов: ");
                ProductsPrint(Products);
            }

            public void AddToBasket(int productNumber)
            {
                Basket.Add(Products[productNumber-1]);
                Console.WriteLine($"Продукт {Products[productNumber-1].Name} добавлен в корзину");
                Console.WriteLine($"В корзине {Basket.Count} продуктов");
            }

            public void ShowBasket()
            {
                Console.WriteLine("Корзина: ");
                ProductsPrint(Basket);
            }

            public void ProductsPrint(List<Product>products)
            {
                int number = 1;
                foreach (Product product in products)
                {
                    Console.Write($"{number}. ");
                    product.Print();
                    number++;
                }
            }

            public void CreateOrder()
            {
                Order newOrder = new Order(Basket);
                Orders.Add(newOrder);
                Basket.Clear();
            }
        }
        static void Main(string[] args)
        {
            Store onlineStore = new Store();

            Console.WriteLine("Здравствуйте. Выберите действие:");
            Console.WriteLine("1. Показать каталог продуктов?");
            Console.WriteLine("Выберите номер действия, которое хотите совершить.");
            int numberAction = Convert.ToInt32(Console.ReadLine());
            switch (numberAction)
            {
                case 1:
                    onlineStore.ShowCatalog();
                    break;
                default:
                    Console.WriteLine("Выберите номер действия из списка");
                    break;
            }

            bool yes;
            do
            {
                Console.WriteLine("Хотите добавить продукт в корзину? наберите да/нет");
                yes = IsYes(Console.ReadLine());
                if (yes)
                {
                    onlineStore.ShowCatalog();
                    Console.Write("Введите номер продукта: \t");
                    int productNum = int.Parse(Console.ReadLine());
                    onlineStore.AddToBasket(productNum);
                }
            } while (yes);

            Console.WriteLine("Хотите посмотреть корзину, наберите да/нет");
            yes = IsYes(Console.ReadLine());
            if (yes)
            {
                onlineStore.ShowBasket();
            }
            Console.WriteLine("Хотите оформить заказ, наберите да/нет");
            yes = IsYes(Console.ReadLine());
            if (yes)
            {
                onlineStore.CreateOrder();
            }
        }

        static bool IsYes(string answer)
        {
            return answer.ToLower() == "да";
        }
    }
}