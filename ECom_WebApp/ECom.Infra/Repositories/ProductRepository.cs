using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using ECommerceConsoleApp.Interface.Repositories;
using ECommerceConsoleApp.Models;

namespace ECommerceConsoleApp.Repositories
{
    public class ProductRepository:IProductRepository
    {
        private readonly string _connectionString = "Server=OPT-LAP-0136; Database=E_com1; Integrated Security=True; TrustServerCertificate=true;";

        //add
        public void AddonProduct(Product product)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    string query = "INSERT INTO Products (Name, Description, Price, StockQuantity) VALUES (@Name, @Description, @Price, @StockQuantity)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Name", product.Name);
                    command.Parameters.AddWithValue("@Description", product.Description);
                    command.Parameters.AddWithValue("@Price", product.Price);
                    command.Parameters.AddWithValue("@StockQuantity", product.StockQuantity);


                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }


        //update qunaity count

        public Product GetProductById(int productId)
        {
            SqlConnection connection = new SqlConnection(_connectionString);

            connection.Open();
            string query = "SELECT ProductID, Name, Description, Price, StockQuantity FROM Products WHERE ProductID = @ProductID AND is_deleted = 0";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ProductID", productId);
            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                return new Product
                {
                    ProductID = (int)reader["ProductID"],
                    Name = (string)reader["Name"],
                    Description = (string)reader["Description"],
                    Price = (decimal)reader["Price"],
                    StockQuantity = (int)reader["StockQuantity"]
                };
            }
            return null;
        }

        //validation 
        public int ValidateProduct(int productId)
        {
            SqlConnection connection = new SqlConnection(_connectionString);

            connection.Open();

            SqlCommand command = new SqlCommand("SELECT COUNT(1) FROM Products WHERE ProductID = @productId AND is_deleted = 0", connection);
            command.Parameters.AddWithValue("@productId", productId);
            int Count = (int)command.ExecuteScalar();
            return Count;
        }

        //update
        public void UpdateProduct(Product product)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    string query = "UPDATE Products SET Name = @Name, Description = @Description, Price = @Price, StockQuantity = @StockQuantity WHERE ProductID = @ProductID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@ProductID", product.ProductID);
                    command.Parameters.AddWithValue("@Name", product.Name);
                    command.Parameters.AddWithValue("@Description", product.Description);
                    command.Parameters.AddWithValue("@Price", product.Price);
                    command.Parameters.AddWithValue("@StockQuantity", product.StockQuantity);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("An error occurred while updating the product: " + ex.Message);
            }
        }

        //view
        public IEnumerable<Product> GetAllProducts()
        {
            var products = new List<Product>();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            string query = "SELECT ProductID, Name, Description, StockQuantity, Price  FROM Products WHERE is_deleted = 0";
            SqlCommand command = new SqlCommand(query, connection);
            var reader = command.ExecuteReader();
            
                while (reader.Read())
                {
                    products.Add(new Product
                    {
                        ProductID = (int)reader["ProductID"],
                        Name = (string)reader["Name"],
                        Description = (string)reader["Description"],
                        StockQuantity = (int)reader["StockQuantity"],
                        Price = (decimal)reader["Price"]
                    });
                }
            
            return products;
        }

        //delete
        public void DeleteProduct(int productId)
        {
            SqlConnection connection = new SqlConnection(_connectionString);

            try
            {
                connection.Open();
                string query = "UPDATE Products SET is_deleted = 1 WHERE ProductID = @productId ";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ProductID", productId);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }



        }

        //checkQuantity
        public int CheckQuantity(int productId)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand("SELECT StockQuantity FROM Products WHERE ProductID = @ProductID AND is_deleted = 0", connection);
            command.Parameters.AddWithValue("@productId", productId);
            int quantity = (int)command.ExecuteScalar();
            return quantity;

        }

    }
}