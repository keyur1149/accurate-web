using accurate_data_access.Entities;
using System.Linq.Expressions;

namespace accurate_data_access.interfaces
{
    public interface ICategoryRepository
    {
        Task AddAsync(CategoryTbl category);
        void Update(CategoryTbl category);
        void Delete(CategoryTbl category);

        Task<CategoryTbl?> GetFirstOrDefault(Expression<Func<CategoryTbl, bool>> filter);
        IQueryable<CategoryTbl> Where(Expression<Func<CategoryTbl, bool>>? filter);
        Task<bool> AnyAsync(Expression<Func<CategoryTbl, bool>> filter);
    }
}
