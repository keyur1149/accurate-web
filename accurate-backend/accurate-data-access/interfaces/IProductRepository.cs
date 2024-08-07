using accurate_data_access.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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
