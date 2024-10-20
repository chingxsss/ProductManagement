using System;
using BusinessLogic;
using DataLayer;
using Model;

namespace UILayer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter username:");
            string username = Console.ReadLine();

            Console.WriteLine("Enter password:");
            string password = Console.ReadLine();
            ProductRepository.Connect();



            UserValidationServices userValidationServices = new UserValidationServices();
            if (userValidationServices.CheckIfUserExists(username, password))
            {
                Console.WriteLine("Login successful!");
                ShowMenu();
            }
            else
            {
                Console.WriteLine("Invalid username or password.");
            }
        }

        static void ShowMenu()
        {
            ProductTransactionServices productServices = new ProductTransactionServices();

            while (true)
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. View Products");
                Console.WriteLine("2. Add Product");
                Console.WriteLine("3. Update Product");
                Console.WriteLine("4. Delete Product");
                Console.WriteLine("5. Exit");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        var products = productServices.GetAllProducts();
                        foreach (var product in products)
                        {
                            Console.WriteLine($"ID: {product.Id}, Name: {product.Name}, Price: {product.Price}");
                        }
                        break;
                    case 2:
                        Console.WriteLine("Enter product name:");
                        string name = Console.ReadLine();
                        Console.WriteLine("Enter product price:");
                        decimal price = decimal.Parse(Console.ReadLine());
                        productServices.AddProduct(new Product { Name = name, Price = price });
                        break;
                    case 3:
                        Console.WriteLine("Enter product ID to update:");
                        int updateId = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter new product name:");
                        string newName = Console.ReadLine();
                        Console.WriteLine("Enter new product price:");
                        decimal newPrice = decimal.Parse(Console.ReadLine());
                        productServices.UpdateProduct(new Product { Id = updateId, Name = newName, Price = newPrice });
                        break;
                    case 4:
                        Console.WriteLine("Enter product ID to delete:");
                        int deleteId = int.Parse(Console.ReadLine());
                        productServices.DeleteProduct(deleteId);
                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}
