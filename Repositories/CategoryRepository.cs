using Microsoft.EntityFrameworkCore;
using ProductCatalog.Data;
using ProductCatalog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCatalog.Repositories
{
    public class CategoryRepository
    {
        private readonly StoreDataContext _context;

        public CategoryRepository(StoreDataContext context)
        {
            _context = context;
        }

        public IEnumerable<Category> Get()
        {
            return _context.Categories.AsNoTracking().ToList();
        }

        public Category Get(int id)
        {
            return _context.Categories.AsNoTracking().Where(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<Product> GetProductByID(int id)
        {
            return _context.Products.AsNoTracking().Where(x => x.CategoryId == id).ToList();
        }

        public void Save(Category category)
        {
            _context.Add(category);
            _context.SaveChanges();
        }

        public void Update(Category category)
        {
            _context.Entry(category).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(Category category)
        {
            _context.Remove(category);
            _context.SaveChanges();
        }
    }
}