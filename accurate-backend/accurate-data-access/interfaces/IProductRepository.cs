using accurate_data_access.Entities;
using System.Linq.Expressions;

namespace accurate_data_access.interfaces
{
    public interface IProductRepository
    {
        Task AddAsync(ProductTbl product);
        void Update(ProductTbl product);
        void Delete(ProductTbl product);
        IQueryable<ProductTbl> Where(Expression<Func<ProductTbl, bool>> filter);
        Task<bool> AnyAsync(Expression<Func<ProductTbl, bool>> filter);
    }
}
