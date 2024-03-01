using Market_API.Models;
using System.Collections.ObjectModel;

namespace Market_API.Interface
{
    public interface ICategoryRepository
    {
        bool CategoryExists(int categoryId);
        bool CategoryExists(string categoryId);
        bool Save();
        bool CreateCategory(Category category);
        ICollection<Category> GetCategories();
        Category GetCategory(int id);
        Category GetCategory(string name);
        ICollection<Product> GetProductByCategory(int categoryId);
        bool UpdateCategory(Category category);
        bool DeleteCategory(Category category);

    }
}
