using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using ECommerceConsoleApp.Repositories;
using ECommerceConsoleApp.Models;
using ECommerceConsoleApp.Interface.Services;
using ECommerceConsoleApp.Interface.Repositories;

namespace ECommerceConsoleApp.Service
{
    
    public class ProductService:IProductService
    {
        private readonly IProductRepository _productrepository;

        public ProductService(IProductRepository productRepository)
        {
            _productrepository = productRepository;
        }

        //add
        public void AddProduct(Product product)
        {

           _productrepository.AddonProduct(product);
        }
        //calling complete product by its id for quanity 
        public Product GetProductById(int productId)
        {
            return _productrepository.GetProductById(productId);
        }


        //validation
        public bool ValidateProductId(int productId)
        {
            int condition = _productrepository.ValidateProduct(productId);

            if (condition > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        //update
        public void UpdateProduct(Product product)
        {
            _productrepository.UpdateProduct(product);
        }

        //view
        public IEnumerable<Product> GetAllProducts()
        {
           return _productrepository.GetAllProducts();
        }

        //delete
        public void DeleteProduct(int productId)
        {
            _productrepository.DeleteProduct(productId);
        }

        //stockcheck
        public int CheckQuantity(int productId)
        {
           return _productrepository.CheckQuantity(productId);
        }
    }

}
