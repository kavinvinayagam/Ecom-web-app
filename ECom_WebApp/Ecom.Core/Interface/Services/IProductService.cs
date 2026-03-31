using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceConsoleApp.Models;

namespace ECommerceConsoleApp.Interface.Services
{
    public interface IProductService
    {
        void AddProduct(Product product);
        Product GetProductById(int productId);
        bool ValidateProductId(int productId);
        void UpdateProduct(Product product);
        IEnumerable<Product> GetAllProducts();
        void DeleteProduct(int productId);
        int CheckQuantity(int productId);


    }
}
