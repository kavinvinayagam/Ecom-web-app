    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceConsoleApp.Models;

namespace ECommerceConsoleApp.Interface.Services
{
    public interface IOrderService
    {
        void AddOrder(Order order);
        bool ValidateOrderId(int orderId);
        void UpdateOrder(Order order);
        IEnumerable<Order> GetAllOrders();
        void DeleteOrder(int orderId);

    }
}
