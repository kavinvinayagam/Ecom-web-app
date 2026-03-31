using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceConsoleApp.Service;
using ECommerceConsoleApp.Models;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using ECommerceConsoleApp.Interface.Services;

namespace ECommerceConsoleApp.Controller
{
    public class ProductController
    {
        private readonly IProductService _productservice;
        public ProductController(IProductService productService)
        {
            _productservice = productService;
        }
            
        public void ProductMenu()
        {
            while (true)
            {
                
                Console.WriteLine(" Product Management ");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. Update Product");
                Console.WriteLine("3. Delete Product");
                Console.WriteLine("4. View Product");
                Console.WriteLine("5. Back to Main Menu");
                Console.Write("Select an option: ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":

                        AddProduct();
                        break;
                    case "2":
                        UpdateProduct();
                        break;
                    case "3":
                        DeleteProduct();
                        break;
                    case "4":
                        ViewProduct();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Press Enter to try again.");
                        Console.ReadLine();
                        break;
                }
            }
        }

        //create
        private void AddProduct()
        {
            try
            {
                Console.Write("Enter product name: ");
                string name = Console.ReadLine();

                Console.Write("Enter product description: ");
                string description = Console.ReadLine();

                Console.Write("Enter product price: ");
                decimal price = decimal.Parse(Console.ReadLine());

                Console.Write("Enter product stock quantity: ");
                int stockQuantity = int.Parse(Console.ReadLine());

                _productservice.AddProduct(new Product
                { Name= name, Description= description,Price= price,StockQuantity =stockQuantity });
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error:" + ex.Message);
            }
        }

        //update
        private void UpdateProduct()
        {
            try
            {
                 // ValidateProductID();
                Console.Write("Enter Product ID: ");
                int productId = int.Parse(Console.ReadLine());
                bool input = _productservice.ValidateProductId(productId);

                    if (input)
                    {
                      
                        Console.WriteLine("Valid ID");
                    }
                    else
                    {
                        Console.WriteLine("Invalid ID. Please try again.");
                        return;
                    }


                Console.Write("Enter new product name: ");
                string name = Console.ReadLine();
                Console.Write("Enter new product description: ");
                string description = Console.ReadLine();
                Console.Write("Enter new product price: ");
                decimal price = decimal.Parse(Console.ReadLine());
                Console.Write("Enter new product stock quantity: ");
                int stockQuantity = int.Parse(Console.ReadLine());

                _productservice.UpdateProduct(new Product
                { ProductID= productId,  Name = name, Description = description, Price = price, StockQuantity = stockQuantity });
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error:"+ex.Message);
            }
        }

        //read
        private void ViewProduct()
        {
            
            Console.WriteLine("View Customers");

            var products = _productservice.GetAllProducts();

            if (products != null )
            {

                foreach (var product in products)
                {
                    Console.WriteLine($"ProductID: {product.ProductID} |Name: {product.Name} |Description: {product.Description} |StockQuantity: {product.StockQuantity} |Price: {product.Price}");
                }
            }
            else
            {
                Console.WriteLine("No customers found.");
            }

            Console.WriteLine("Press Enter to continue.");
            Console.ReadLine();
        }

        //delete
        private void DeleteProduct()
        {
            
            Console.WriteLine(" Delete Product ");
            Console.Write("Enter Product ID: ");
            int productId = int.Parse(Console.ReadLine());
            _productservice.DeleteProduct(productId);

            Console.WriteLine("Customer deleted successfully. Press Enter to continue.");
        }

     /*   private void ValidateProductID()
        {
            bool isValid = false;
            do
            {
                Console.Write("Enter Product ID: ");

                if (int.TryParse(Console.ReadLine(), out int productId))
                {
                    bool input = _productservice.ValidateProductId(new Product { ProductID = productId });

                    if (input)
                    {
                        isValid = true;
                        Console.WriteLine("Valid ID");
                    }
                    else
                    {
                        Console.WriteLine("Invalid ID. Please try again.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a numeric Customer ID.");
                }
            } while (!isValid);
        }   */

    }
}
