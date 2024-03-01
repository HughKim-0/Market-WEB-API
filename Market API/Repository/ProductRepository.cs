using Market_API.Data;
using Market_API.Interface;
using Market_API.Models;

namespace Market_API.Repository
{
    public class ProductRepository : IProductRepository
    {
        //Data Context//
        private readonly DataContext _context;
        public ProductRepository(DataContext context)
        {
            _context = context;
        }

        //Check the Product Exists//
        public bool ProductExists(int productId)
        {
            return _context.Product.Any(p => p.ProductId == productId);
        }
        public bool ProductExists(string productName)
        {
            return _context.Product.Any(p => p.ProductName == productName);
        }

        //Save//
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        //Create Method//
        public bool CreateProduct(int locationId, int paymentId, Product product)
        {
            var productLocationEntity = _context.Location.Where(a => a.LocationId == locationId).FirstOrDefault();
            var productPaymentEntity = _context.Payment.Where(a => a.PaymentId == paymentId).FirstOrDefault();

            var pokemonLocation = new ProductLocation()
            {
                Location = productLocationEntity,
                Product = product,
            };

            _context.Add(pokemonLocation);

            var productPayment = new ProductPayment()
            {
                Payment = productPaymentEntity,
                Product = product,
            };

            _context.Add(productPayment);

            _context.Add(product);

            return Save();
        }

        //Read Method//
        public Product GetProduct(int id)
        {
            return _context.Product.Where(p => p.ProductId == id).FirstOrDefault();
        }

        public Product GetProduct(string name)
        {
            return _context.Product.Where(p => p.ProductName == name).FirstOrDefault();
        }
        public ICollection<Product> GetProducts()
        {
            return _context.Product.OrderBy(p => p.ProductId).ToList();
        }

        //Update Method//
        public bool UpdateProduct(int locationId, int paymentId, Product product)
        {
            _context.Update(product);
            return Save();
        }

        //Delete Method//
        public bool DeleteProduct(Product product)
        {
            _context.Remove(product);
            return Save();
        }
    }
}
