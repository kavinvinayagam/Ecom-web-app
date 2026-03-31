using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceConsoleApp.Models;

namespace ECommerceConsoleApp.Interface.Repositories
{
    public interface IProductRepository
    {
        void AddonProduct(Product product);
        Product GetProductById(int productId);
        int ValidateProduct(int productId);
        void UpdateProduct(Product product);
        IEnumerable<Product> GetAllProducts();
        void DeleteProduct(int productId);
        int CheckQuantity(int productId);

    }
}
