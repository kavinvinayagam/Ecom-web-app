using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ECommerceConsoleApp.Controller;
using ECommerceConsoleApp.Interface.Repositories;
using ECommerceConsoleApp.Models;

namespace ECommerceConsoleApp.Repositories
{
    public class CustomerRepository: ICustomerRepository
    {
        private readonly string _connectionString = "Server=OPT-LAP-0136; Database=E_com1; Integrated Security=True;";

        
        // add query
        public void AddonCustomer(Customer customer)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO Customers (Name, Email, Phone_number, Address) VALUES (@name, @email, @phone_number, @address)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Name", customer.Name);
                    command.Parameters.AddWithValue("@Email", customer.Email);
                    command.Parameters.AddWithValue("@Phone_number", customer.Phone_number);
                    command.Parameters.AddWithValue("@Address", customer.Address);

                    command.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }

        // view all_ query 
        public IEnumerable<Customer> GetAllCustomers()
        {
            var customers = new List<Customer>();
                SqlConnection connection = new SqlConnection(_connectionString);

                connection.Open();
                string query = "SELECT *  FROM Customers WHERE is_deleted = 0";
                SqlCommand command = new SqlCommand(query, connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        customers.Add(new Customer
                        {
                            CustomerID = (int)reader["CustomerID"],
                            Name = (string)reader["Name"],
                            Email = (string)reader["Email"],
                            Phone_number = (long)reader["Phone_number"],
                            Address = (string)reader["Address"]
                        });


                    }
                }
            return customers;
        }
         


        //validation
        public int ValidateCustomer(int customerId)
        {
            SqlConnection connection = new SqlConnection(_connectionString) ;

            connection.Open();
            SqlCommand command = new SqlCommand("SELECT COUNT(1) FROM Customers WHERE CustomerID = @CustomerID AND is_deleted = 0", connection);
            command.Parameters.AddWithValue("@customerId", customerId);
            int Count = (int)command.ExecuteScalar();
            return Count;
        }
      

        //edit query
        public void UpdateCustomer(Customer customer)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "UPDATE Customers SET Name = @Name, Email = @Email, Phone_number = @Phone_number, Address = @Address WHERE CustomerID = @CustomerId";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@CustomerId", customer.CustomerID);
                    command.Parameters.AddWithValue("@Name", customer.Name);
                    command.Parameters.AddWithValue("@Email", customer.Email);
                    command.Parameters.AddWithValue("@Phone_number", customer.Phone_number);
                    command.Parameters.AddWithValue("@Address", customer.Address);

                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }

        //delete query
        public void DeleteCustomer(int customerId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "UPDATE Customers SET is_deleted = 1 WHERE CustomerID = @CustomerId;"; //or is_deleted = 1
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@CustomerId", customerId);


                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
    }
}
