using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Website.Models;

namespace Website.Data.Repositories
{
    public interface ICategoryRepository
    {
        IEnumerable<CategoryViewModel> GetCategories();
    }

    public class CategoryRepository : ICategoryRepository
    {
        private WebsiteDatabaseContext _context;

        public CategoryRepository(WebsiteDatabaseContext context)
        {
            _context = context;
        }
        public IEnumerable<CategoryViewModel> GetCategories()
        {
            return _context.Categories
                                            .Select(c => new CategoryViewModel()
                                            {
                                                CategoryName = c.Name,
                                                CategoryID = c.ID,
                                                ProductCount = _context.CategorytoProducts.Count(p => p.CategoryID == c.ID)
                                            }).ToList();
        }
    }
}
