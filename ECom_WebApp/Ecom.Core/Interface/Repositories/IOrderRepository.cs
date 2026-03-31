using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceConsoleApp.Models;

namespace ECommerceConsoleApp.Interface.Repositories
{
    public interface IOrderRepository
    {
        void AddOrder(Order order);
        int ValidateOrderId(int orderId);
        void UpdateOrder(Order order);
        IEnumerable<Order> GetAllOrders();
        void DeleteOrder(int orderId);

    }
}
