using accurate_data_access.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace accurate_data_access.interfaces
{
    public interface ICategoryRepository
    {
        Task AddAsync(CategoryTbl category);
        void Update(CategoryTbl category);
        void Delete(CategoryTbl category);
        IQueryable<CategoryTbl> Where(Expression<Func<CategoryTbl, bool>> filter);
        Task<bool> AnyAsync(Expression<Func<CategoryTbl, bool>> filter);
    }
}
