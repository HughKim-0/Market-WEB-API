using Market_API.Data;
using Market_API.Interface;
using Market_API.Models;

namespace Market_API.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        //Data Context//
        private readonly DataContext _context;
        public CategoryRepository(DataContext context)
        {
            _context = context;
        }

        //Check the Category Exists//
        public bool CategoryExists(int categoryId)
        {
            return _context.Category.Any(c => c.CategoryId == categoryId);
        }

        public bool CategoryExists(string categoryName)
        {
            return _context.Category.Any(c => c.CategoryName == categoryName);
        }

        //Save//
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        //Create Method//
        public bool CreateCategory(Category category)
        {
            _context.Add(category);
            return Save();
        }

        //Read Method//
        public ICollection<Category> GetCategories()
        {
            return _context.Category.ToList();
        }

        public Category GetCategory(int id)
        {
            return _context.Category.Where(c => c.CategoryId == id).FirstOrDefault();
        }
        public Category GetCategory(string name)
        {
            return _context.Category.Where(c => c.CategoryName == name).FirstOrDefault();
        }

        public ICollection<Product> GetProductByCategory(int categoryId)
        {
            return _context.Product.Where(c => c.Category.CategoryId == categoryId).Select(p => p.Products).ToList();
        }

        //Update Method//
        public bool UpdateCategory(Category category)
        {
            _context.Update(category);
            return Save();
        }

        //Delete Method//
        public bool DeleteCategory(Category category)
        {
            _context.Remove(category);
            return Save();
        }

    }
}
