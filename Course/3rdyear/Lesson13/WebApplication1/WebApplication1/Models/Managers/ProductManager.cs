using System.ComponentModel.DataAnnotations;
using WebApplication1.Models.Interfaces;
using WebApplication1.Models.Models;

namespace WebApplication1.Models.Managers
{
    public class ProductManager : IProductManager
    {
        
        private readonly DatabaseContext _databaseContext;

        public ProductManager(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        
        public void CreateProduct(ProductModel product)
        {
            _databaseContext.Products.Add(product);
            _databaseContext.SaveChanges();
        }

        public List<ProductModel> GetAllProducts()
        {
            return _databaseContext.Products.ToList();
        }

        public string UpdateProduct(int id, ProductModel product)
        {
            ProductModel? findProduct = _databaseContext.Products.FirstOrDefault(u => u.Id == id);

            if (findProduct == null)
            {
                return "Product not found";
            }
            
            findProduct.Name = product.Name;
            findProduct.Cost = product.Cost;
            
            _databaseContext.SaveChanges();
            return "Product updated";

        }
    }
}