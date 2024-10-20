using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using BusinessLogic;
using ProductManagement.API.Models;
using System.Reflection;

namespace ProductManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ProductTransactionServices _productServices;

        public ProductController()
        {
            _productServices = new ProductTransactionServices();
        }

        [HttpGet]
        public IEnumerable<Product> GetProducts()
        {
            var products = _productServices.GetAllProducts();
            List<Product> result = new List<Product>();
            foreach (var product in products)
            {
                result.Add(new Product { Id = product.Id, Name = product.Name, Price = product.Price });
            }
            return result;
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            _productServices.AddProduct(new Model.Product { Name = product.Name, Price = product.Price });
            return Ok();
        }

        [HttpPatch]
        public IActionResult UpdateProduct(Product product)
        {
            _productServices.UpdateProduct(new Model.Product { Id = product.Id, Name = product.Name, Price = product.Price });
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            _productServices.DeleteProduct(id);
            return Ok();
        }
    }
}
