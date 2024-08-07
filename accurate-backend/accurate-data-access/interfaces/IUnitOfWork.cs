using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace accurate_data_access.interfaces
{
    public interface IUnitOfWork
    {
        IProductRepository Product {  get; }
        ICategoryRepository Category { get; }
    }
}
