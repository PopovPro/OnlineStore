using System;
using System.Collections.Generic;

namespace OnlineShop
{
    class Program
    {
        public class User
        {
            public string Name;
            public bool IsAdmin;
            public Order Orders;
            public User(string name)
            {
                Name = name;
                IsAdmin = false;
            }
            public User(string name)
            {
                Name = name;
                IsAdmin = true;
            }
            public void AddOrder()
            {
                
            }

        }
        public class Order
        {
            public List<Product> Products;
            decimal FullPrice;
            public Order(List<Product> products)
            {
                Products = products;
                foreach (var product in Products)
                {
                    FullPrice += product.Price;
                }
            }
            public decimal GetFullPrice()
            {
                return FullPrice;
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
                Console.WriteLine("\nКаталог продуктов: ");
                ShowProducts(Products);
            }
            public void AddToBasket(int numberProduct)
            {
                Basket.Add(Products[numberProduct - 1]);
                Console.WriteLine($"Продукт {Products[numberProduct - 1].Name} успешно добавлен в корзину.");
                Console.WriteLine($"В корзине {Basket.Count} продуктов.");
            }

            public void ShowBasket()
            {
                if (Basket.Count == 0)
                {
                    Console.WriteLine("\nКорзина пуста...");
                }
                else
                {
                    Console.WriteLine("\nКорзина: ");
                    ShowProducts(Basket);
                }
            }
            public void ShowProducts(List<Product> products)
            {
                int number = 1;
                foreach (Product product in products)
                {
                    Console.Write(number + ". ");
                    product.Print();
                    number++;
                }
            }

            public void CreateOrder()
            {
                //Передать продукты из корзины в доставку
                Order newOrder = new Order(Basket);
                Orders.Add(newOrder);
                Basket = new List<Product>();
                Console.WriteLine($"\nЗаказ {Orders.Count} товаров на сумму {newOrder.GetFullPrice()} успешно оформлен\n");
            }
        }

        static void Main(string[] args)
        {
            Store newStore = new Store();
            Console.Write("Введите Ваше имя пользователя: ");
            string name = Console.ReadLine();
            if (name == "Admin")
            {

            }
            else
            {
                Order newOrder = 
                User user = new User(name, newOrder);
            }
            bool exit = false;
            while (!exit)
            {
                int checkMenu = 0;
                Console.WriteLine("\nВыберите номер действия которое хотите совершить:");
                Console.WriteLine("1. Показать каталог продуктов");
                Console.WriteLine("2. Показать корзину");
                Console.WriteLine("3. Добавить продукт в корзину");
                Console.WriteLine("4. Оформить заказ");
                Console.WriteLine("5. Завершить покупки");
                Console.Write("Ваш выбор: ");
                do
                {
                    checkMenu = ShowMenu(newStore);
                } while (checkMenu == 0);

                if (checkMenu == 1)
                {
                    newStore.ShowCatalog();
                }
                if (checkMenu == 2)
                {
                    newStore.ShowBasket();
                }
                if (checkMenu == 3)
                {
                    int yes = 1;
                    while (yes == 1)
                    {
                        try
                        {
                            Console.WriteLine("Напишите номер продукта который нужно добавить в корзину:");
                            int productNumber = int.Parse(Console.ReadLine());
                            if (productNumber > newStore.Products.Count || productNumber <= 0)
                            {
                                Console.WriteLine("Введите число из списка!");
                            }
                            else
                            {
                                newStore.AddToBasket(productNumber);
                                Console.WriteLine("Хотите добавить в корзину еще продукт? Наберите да/нет ");
                                do
                                {
                                    yes = IsYes(Console.ReadLine());
                                } while (yes == 0);
                            }
                        }

                        catch (Exception)
                        {
                            Console.WriteLine("Введите число!");
                        }
                    }
                }
                if (checkMenu == 4)
                {
                    newStore.CreateOrder();
                }
                if (checkMenu == 5)
                {
                    exit = true;
                    Console.WriteLine("Покупки завершены");
                }
            }
        }

        static int ShowMenu(Store newStore)
        {
            try
            {
                int numberAction = int.Parse(Console.ReadLine());
                switch (numberAction)
                {
                    case 1:
                        return 1;
                    case 2:
                        return 2;
                    case 3:
                        return 3;
                    case 4:
                        return 4;
                    case 5:
                        return 5;
                    default:
                        Console.WriteLine("\nВведите число из списка!\n");
                        Console.Write("Ваш выбор: ");
                        return 0;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("\nВведите число!\n");
                Console.Write("Ваш выбор: ");
                return 0;
            }
        }

        static int IsYes(string answer)
        {
            if (answer.ToLower() == "да")
                return 1;
            else if (answer.ToLower() == "нет")
                return 2;
            else
                Console.WriteLine("Введите да/нет!");
            return 0;
        }
    }
}