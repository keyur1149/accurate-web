using accurate_data_access.Entities;
using accurate_data_access.interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace accurate_repositry.repository
{
    public class UnitOfWork:IUnitOfWork
    {
        private ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        private IProductRepository _productRepository;
        public IProductRepository Product
        {
            get
            {
                if (_productRepository == null)
                {
                    _productRepository = new ProductRepository(_context);
                }
                return _productRepository;
            }
        }
        private ICategoryRepository _categoryRepository;
        public ICategoryRepository Category
        {
            get
            {
                if (_categoryRepository == null)
                {
                    _categoryRepository = new CategoryRepository(_context);
                }
                return _categoryRepository;
            }
        }
    }
}
