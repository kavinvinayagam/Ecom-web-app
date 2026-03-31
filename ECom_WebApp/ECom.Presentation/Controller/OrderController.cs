using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceConsoleApp.Service;
using ECommerceConsoleApp.Models;
//using System.Runtime.Remoting.Messaging;
using ECommerceConsoleApp.Interface.Repositories;
using ECommerceConsoleApp.Interface.Services;

namespace ECommerceConsoleApp.Controller
{
    public class OrderController
    {

        private readonly IOrderService _orderService;
        private readonly IProductService _productService; 
        private readonly ICustomerService _customerService;
        public OrderController(ICustomerService customerService, IProductService productService, IOrderService orderService)
        {
            _orderService = orderService;
            _productService = productService;
            _customerService = customerService;
        }
        public void OrderMenu()
        {
            while(true)
            {
                
                Console.WriteLine(" Order Management ");
                Console.WriteLine("1. Add Order");
                Console.WriteLine("2. Update Order");
                Console.WriteLine("3. Delete Order");
                Console.WriteLine("4. View Order");
                Console.WriteLine("5. Back to Main Menu");
                Console.Write("Select an option: ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":

                        AddOrder();
                        break;
                    case "2":
                        UpdateOrder();
                        break;
                    case "3":
                        DeleteOrder();
                        break;
                    case "4":
                        GetAllOrders();
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

        //add
        private void AddOrder()
        {

            Console.WriteLine("Enter Customer ID:");
            int customerId = Convert.ToInt32(Console.ReadLine());

            var customer = _customerService.ValidateCustomerId(customerId);
            if (customer == false)
            {
                Console.WriteLine("Customer not found.");
                return;
            }

            Console.WriteLine("Enter Product ID:");
            int productId = Convert.ToInt32(Console.ReadLine());

            var product = _productService.ValidateProductId(productId);
            if (product == false)
            {
                Console.WriteLine("productID not found.");
                return;
            }

            Console.WriteLine("Enter Stock Quantity");
            int productQuantity = int.Parse(Console.ReadLine());
            int quantity = _productService.CheckQuantity(productId);

            if (productQuantity > quantity)
            {
                Console.WriteLine("Insufficient stock.");
                return;
            }

            _orderService.AddOrder(new Order { CustomerID = customerId, ProductID = productId, ProductQuantity = productQuantity });


            Console.WriteLine("Order placed successfully!");
        }

        //update
        public void UpdateOrder()
        {
            
            Console.WriteLine("Enter Order ID to update:");
            int orderId = Convert.ToInt32(Console.ReadLine());

            var order = _orderService.ValidateOrderId(orderId);
            if (order == false)
            {
                Console.WriteLine("OrderID not found.");
                return;
            }

            Console.WriteLine("Enter Customer ID:");
            int customerId = Convert.ToInt32(Console.ReadLine());

            var customer = _customerService.ValidateCustomerId(customerId);
            if (customer == false)
            {
                Console.WriteLine("Customer not found.");
                return;
            }

            Console.WriteLine("Enter Product ID:");
            int productId = Convert.ToInt32(Console.ReadLine());

            var product = _productService.ValidateProductId(productId);
            if (product == false)
            {
                Console.WriteLine("productID not found.");
                return;
            }

            Console.WriteLine("Enter Stock Quantity");
            int productQuantity = int.Parse(Console.ReadLine());
            int quantity = _productService.CheckQuantity(productId);

            if (productQuantity > quantity)
            {
                Console.WriteLine("Insufficient stock.");
                return;
            }

            _orderService.UpdateOrder(new Order
            { OrderID = orderId, CustomerID = customerId, ProductID = productId, ProductQuantity = productQuantity });
            Console.WriteLine("Order updated successfully!");
        }
        //delete
        public void DeleteOrder()
        {
            
            Console.WriteLine("Enter Order ID to delete:");
            int orderId = Convert.ToInt32(Console.ReadLine());

            _orderService.DeleteOrder(orderId);
            Console.WriteLine("Order deleted successfully!");
        }

        //view
        public void GetAllOrders()
        {

            Console.WriteLine("View Orders");

            var orders = _orderService.GetAllOrders();

            if (orders != null )
            {

                foreach (var order in orders)
                {
                    Console.WriteLine($"OrderID: {order.OrderID} | CustomerID: {order.CustomerID} | ProductID: {order.CustomerID}  | Quantity: {order.ProductQuantity} | Total_price: {order.Total_Price}");
                }
            }
            else
            {
                Console.WriteLine("No Orders found.");
            }

            Console.WriteLine("Press Enter to continue.");
            Console.ReadLine();
        }
    }
}
