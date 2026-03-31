using System;

namespace ECommerceConsoleApp.Controller
{
    public class MainController
    {
        private readonly CustomersController _customerscontroller; 
        private readonly ProductController _productcontroller; 
        private readonly OrderController _ordercontroller; 

        public MainController(CustomersController customersController, ProductController productController ,OrderController orderController)
        {
            _customerscontroller = customersController;
            _productcontroller = productController;
            _ordercontroller =  orderController;
        }
        public void MainMenu()
        {
            while (true)
            {
                
                Console.WriteLine(" E-Commerce Console Application ");
                Console.WriteLine("1. Customer Management");
                Console.WriteLine("2. Product Management");
                Console.WriteLine("3. Order Management");
                Console.WriteLine("4. Exit");
                Console.Write("Select an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        _customerscontroller.CustomerMenu();
                        break;
                    case "2":
                        _productcontroller.ProductMenu();
                        break;
                    case "3":
                        _ordercontroller.OrderMenu();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Press Enter to try again.");
                        Console.ReadLine();
                        break;
                }
            }

        }
    }
}
