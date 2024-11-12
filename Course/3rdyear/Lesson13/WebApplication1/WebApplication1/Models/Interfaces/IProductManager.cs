using WebApplication1.Models.Models;

namespace WebApplication1.Models.Interfaces
{
    public interface IProductManager
    {
        void CreateProduct(ProductModel product);
        List<ProductModel> GetAllProducts();
        string UpdateProduct(int id, ProductModel product);
    }
}
