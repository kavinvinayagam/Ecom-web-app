using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceConsoleApp.Models;

namespace ECommerceConsoleApp.Interface.Services
{
    public interface ICustomerService
    {
         void AddonCustomer(Customer customer);
        IEnumerable<Customer> GetAllCustomers();
        bool ValidateCustomerId(int cutomerId);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(int customerId);

    }
}
