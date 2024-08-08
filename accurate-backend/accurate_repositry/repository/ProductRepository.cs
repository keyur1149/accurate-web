using accurate_data_access.Entities;
using accurate_data_access.interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace accurate_repositry.repository
{
    public class ProductRepository:IProductRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(ProductTbl product)
        {
           await _context.ProductTbls.AddAsync(product);
        }

        public async  Task<bool> AnyAsync(Expression<Func<ProductTbl, bool>> filter)
        {
            bool query = await _context.ProductTbls.AnyAsync(filter);
            return query;
        }

        public void Delete(ProductTbl product)
        {
            _context.ProductTbls.Remove(product);
        }

        public void Update(ProductTbl product)
        {
            _context.ProductTbls.Update(product);
        }

        public IQueryable<ProductTbl> Where(Expression<Func<ProductTbl, bool>> filter)
        {
            IQueryable<ProductTbl> query = _context.ProductTbls.Where(filter);
            return query;
        }
    }
}
