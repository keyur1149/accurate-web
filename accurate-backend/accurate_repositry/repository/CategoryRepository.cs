using accurate_data_access.Entities;
using accurate_data_access.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace accurate_repositry.repository
{
    public class CategoryRepository:ICategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(CategoryTbl category)
        {
            await _context.CategoryTbls.AddAsync(category);
        }

        public async Task<bool> AnyAsync(Expression<Func<CategoryTbl, bool>> filter)
        {
            bool query = await _context.CategoryTbls.AnyAsync(filter);
            return query;
        }

        public void Delete(CategoryTbl category)
        {
            _context.CategoryTbls.Remove(category);
        }

        public void Update(CategoryTbl category)
        {
            _context.CategoryTbls.Update(category);
        }

        public IQueryable<CategoryTbl> Where(Expression<Func<CategoryTbl, bool>> filter)
        {
            IQueryable<CategoryTbl> query = _context.CategoryTbls.Where(filter);
            return query;
        }
    }
}
