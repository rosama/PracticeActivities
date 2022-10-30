using RestfulActivity.DBContexts;
using RestfulActivity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestfulActivity.Services
{
    public class CategoryReprository : ICategoryReprository
    {
        private readonly ProductsContext _context;
        public CategoryReprository(ProductsContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public IEnumerable<Category> GetCategories()
        {
            return _context.Category;
        }
    }
}
