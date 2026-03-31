//using ECommerceConsoleApp.Controller;
using ECommerceConsoleApp.Interface.Repositories;
using ECommerceConsoleApp.Interface.Services;
using ECommerceConsoleApp.Models;
//using ECommerceConsoleApp.Repositories;

namespace ECommerceConsoleApp.Service
{
    public class CustomerService : ICustomerService
    {

        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }


        //add
        public void AddonCustomer(Customer customer)
        {
            _customerRepository.AddonCustomer(customer);
        }

        //view

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _customerRepository.GetAllCustomers();
        }

        //validation
        public bool ValidateCustomerId(int cutomerId)
        {
            int condition = _customerRepository.ValidateCustomer(cutomerId);

            if (condition > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        // edit

        public void UpdateCustomer(Customer customer)
        {
            _customerRepository.UpdateCustomer(customer);
        }

        // delete

        public void DeleteCustomer(int customerId)
        {
            _customerRepository.DeleteCustomer(customerId);
        }

    }

}
