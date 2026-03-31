using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using ECommerceConsoleApp.Repositories;
using ECommerceConsoleApp.Models;
using System.Xml;
using ECommerceConsoleApp.Interface.Services;
using ECommerceConsoleApp.Interface.Repositories;

namespace ECommerceConsoleApp.Service
{
    public class OrderService: IOrderService
    {
        private readonly IOrderRepository _orderRepository; 
        private readonly IProductService _productService; 


        public OrderService(IOrderRepository orderRepository, IProductService productService )
        {
            _orderRepository = orderRepository;
            _productService = productService;
        }

        //add
        public void AddOrder(Order order)
        {
            Product product = _productService.GetProductById(order.ProductID);


            order.Total_Price = order.ProductQuantity * product.Price;

            _orderRepository.AddOrder(order);
            product.StockQuantity -= order.ProductQuantity;
            _productService.UpdateProduct(product);


        }


        //validationof OrderID
        public bool ValidateOrderId(int orderId)
        {
            int condition = _orderRepository.ValidateOrderId(orderId);

            if (condition > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        //update

        public void UpdateOrder(Order order)
        {
            Product product = _productService.GetProductById(order.ProductID);

            
            order.Total_Price = 0;

            order.Total_Price = order.ProductQuantity * product.Price;

            _orderRepository.UpdateOrder(order);
            product.StockQuantity -= order.ProductQuantity;
            _productService.UpdateProduct(product);

        }

        //view

        public IEnumerable<Order> GetAllOrders()
        {
           return _orderRepository.GetAllOrders();
        }

        //delete
        public void DeleteOrder(int orderId)
        {
            _orderRepository.DeleteOrder(orderId);
        }





    }
}

