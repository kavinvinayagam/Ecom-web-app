using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceConsoleApp.Models;

namespace ECommerceConsoleApp.Interface.Repositories
{
    public interface ICustomerRepository
    {
        void AddonCustomer(Customer customer);
        IEnumerable<Customer> GetAllCustomers();
        int ValidateCustomer(int customerId);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(int customerId);

    }
}
