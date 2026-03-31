using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceConsoleApp.Interface.Repositories;
using ECommerceConsoleApp.Models;

namespace ECommerceConsoleApp.Repositories
{
    public class OrderRepository:IOrderRepository
    {
        private readonly string _connectionString = "Server=OPT-LAP-0136; Database=E_com1; Integrated Security=True;";



        //add
        public void AddOrder(Order order )
        {
            try
            {

                SqlConnection connection = new SqlConnection(_connectionString);
                
                    connection.Open();

                    string query2 = "INSERT INTO Orders (CustomerId, ProductId, ProductQuantity, Total_Price) VALUES (@CustomerId, @ProductId, @productQuantity, @Total_Price)";
                    SqlCommand command2 = new SqlCommand(query2, connection);
                    
                        command2.Parameters.AddWithValue("@CustomerID", order.CustomerID);
                        command2.Parameters.AddWithValue("@ProductID", order.ProductID);
                        command2.Parameters.AddWithValue("@productQuantity", order.ProductQuantity);
                        command2.Parameters.AddWithValue("@Total_Price", order.Total_Price);

                        command2.ExecuteNonQuery();  
                    
                
            }
            catch(SqlException ex)
            {
                Console.WriteLine("Error:" + ex.Message);
            }
        }

        //validationof OrderId
        public int ValidateOrderId(int orderId)
        {
            SqlConnection connection = new SqlConnection(_connectionString);

            connection.Open();
            SqlCommand command = new SqlCommand("SELECT COUNT(1) FROM Orders WHERE OrderID = @OrderId AND is_deleted = 0", connection);
            command.Parameters.AddWithValue("@OrderId", orderId);
            int Count = (int)command.ExecuteScalar();
            return Count;
        }


        //update


        public void UpdateOrder(Order order)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("UPDATE Orders SET  CustomerID= @customerId, ProductID= @productId, ProductQuantity= @productQuantity, Total_Price = @Total_Price WHERE OrderId = @OrderId", connection);

                command.Parameters.AddWithValue("@OrderId", order.OrderID);
                command.Parameters.AddWithValue("@customerId", order.CustomerID);
                command.Parameters.AddWithValue("@ProductId", order.ProductID);
                command.Parameters.AddWithValue("@productQuantity", order.ProductQuantity);
                command.Parameters.AddWithValue("@Total_Price", order.Total_Price);


                command.ExecuteNonQuery();
            }
        }

        //view
        public IEnumerable<Order> GetAllOrders()
        {
            var orders = new List<Order>();
            
                SqlConnection connection = new SqlConnection(_connectionString);
                connection.Open();
                string query= "SELECT * FROM Orders where is_deleted =0";
                SqlCommand command = new SqlCommand(query, connection);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    orders.Add(new Order
                    {
                        OrderID = (int)reader["OrderID"],
                        CustomerID = (int)reader["CustomerID"],
                        ProductID = (int)reader["ProductID"],
                        ProductQuantity = (int)reader["ProductQuantity"],
                        Total_Price = (decimal)reader["Total_Price"]
                    });
                }

            return orders;

        }

        //delete
        public void DeleteOrder(int orderId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("DELETE FROM Orders WHERE OrderId = @OrderId", connection);
                command.Parameters.AddWithValue("@OrderId", orderId);

                command.ExecuteNonQuery();
            }
        }
    



    }
}
