using Market_API.Models;

namespace Market_API.Interface
{
    public interface IProductRepository
    {
        bool ProductExists(int productId);
        bool ProductExists(string productName);
        bool Save();
        bool CreateProduct(int locationId, int paymentId, Product product);
        Product GetProduct(int id);
        Product GetProduct(string name);
        ICollection<Product> GetProducts();
        bool UpdateProduct(int locationId, int paymentId, Product product);
        bool DeleteProduct(Product product);
    }
}
