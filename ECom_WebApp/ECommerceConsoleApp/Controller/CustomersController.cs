using System;
using System.Data;
using ECommerceConsoleApp.Service;
using ECommerceConsoleApp.Models;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.CompilerServices;
using ECommerceConsoleApp.Interface.Services;


namespace ECommerceConsoleApp.Controller
{
    public class CustomersController
    {
        private readonly ICustomerService _customerService; 

        public CustomersController(ICustomerService customerService)
        {
            _customerService =  customerService;
        }


        public void CustomerMenu()
        {
            while (true)
            {

                Console.WriteLine(" Customer Management ");
                Console.WriteLine("1. Add Customer");
                Console.WriteLine("2. Update Customer");
                Console.WriteLine("3. Delete Customer");
                Console.WriteLine("4. View Customers");
                Console.WriteLine("5. Back to Main Menu");
                Console.Write("Select an option: ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":

                        AddCustomer();
                        break;
                    case "2":
                        UpdateCustomer();
                        break;
                    case "3":
                        DeleteCustomer();
                        break;
                    case "4":
                        ViewCustomers();
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
        // add
        private void AddCustomer()
        {
            try
            {

                Console.WriteLine(" Add Customer ");
                Console.Write("Enter Customer Name: ");
                string name = Console.ReadLine();

                Console.Write("Enter Customer Email: ");
                string email = Console.ReadLine();

                Console.Write("Enter Customer Phone: ");

                long phone_number = long.Parse(Console.ReadLine());

                Console.Write("Enter Customer Address: ");
                string address = Console.ReadLine();

                _customerService.AddonCustomer(new Customer { Name = name, Email = email, Phone_number = phone_number, Address = address });



                Console.WriteLine("Customer added successfully. Press Enter to continue to Customer Management");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error:" + ex.Message);
            }
        }




        //edit
        private void UpdateCustomer()
        {
            try
            {
                
                Console.WriteLine(" Edit Customer ");

               // ValidateCustomerId();
                Console.WriteLine(" Enter customerID ");

                int customerId = Convert.ToInt32(Console.ReadLine());
                
                    bool input = _customerService.ValidateCustomerId(customerId);
                    if (input)
                    {
                        Console.WriteLine("Valid ID");
                        Console.Write("Enter Customer Name: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter Customer Email: ");
                        string email = Console.ReadLine();
                        Console.Write("Enter Customer Phone: ");
                        long phone_number = long.Parse(Console.ReadLine());
                        Console.Write("Enter Customer Address: ");
                        string address = Console.ReadLine();

                        _customerService.UpdateCustomer(new Customer { CustomerID = customerId, Name = name, Email = email, Phone_number = phone_number, Address = address });

                        Console.WriteLine("Customer updated successfully. Press Enter to continue to Customer Management");
                    }
                    else
                    {
                        Console.WriteLine("Invalid ID. Please try again.");
                    }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error:" + ex.Message);
            }
        }
        //delete

        private void DeleteCustomer()
        {
            try
            {
                Console.WriteLine(" Delete Customer ");
                Console.Write("Enter Customer ID: ");
                int customerId = int.Parse(Console.ReadLine());
          
                _customerService.DeleteCustomer(customerId);

                Console.WriteLine("Customer deleted successfully. Press Enter to continue to Customer Management.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error:" + ex.Message);
            }
        }

        // view


        private void ViewCustomers()
        {

            Console.WriteLine("View Customers");

            var customers = _customerService.GetAllCustomers();
            if (customers != null )
            {

                foreach (var customer in customers)
                {
                    Console.WriteLine($"CustomerID: {customer.CustomerID} |Name: {customer.Name} |Email: {customer.Email} |Phone: {customer.Phone_number} |Address: {customer.Address}");
                }
            }
            else
            {
                Console.WriteLine("No customers found.");
            }

            Console.WriteLine("Press Enter to continue to Customer Management");
            Console.ReadLine();
        }
        //validate

      /*  public void ValidateCustomerId()
        {
            bool isValid = false;
            
            do
            {
                Console.Write("Enter Customer ID: ");

                if (int.TryParse(Console.ReadLine(), out int customerId))
                //int customerId = Convert.ToInt32(Console.ReadLine());
                {
                    bool input = _customerService.ValidateCustomerId(  customerId );
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
            }
            while (!isValid);

        } */
    }
}

