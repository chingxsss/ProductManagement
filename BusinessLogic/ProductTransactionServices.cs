using System.Collections.Generic;
using Model;
using DataLayer;

namespace BusinessLogic
{
    public class ProductTransactionServices
    {
        private readonly ProductRepository productRepository = new ProductRepository();

        public List<Product> GetAllProducts()
        {
            return productRepository.GetProducts();
        }

        public void AddProduct(Product product)
        {
            productRepository.AddProduct(product);
        }

        public void UpdateProduct(Product product)
        {
            productRepository.UpdateProduct(product);
        }

        public void DeleteProduct(int productId)
        {
            productRepository.DeleteProduct(productId);
        }
    }
}
