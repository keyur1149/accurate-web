using accurate_data_access.DTO;
using accurate_data_access.Entities;
using accurate_data_access.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace accurate_services.services
{
    public class ProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductService(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

        public  APIResponse<IEnumerable<ProductTbl>> FetchAllProducts()
        {
            APIResponse<IEnumerable<ProductTbl>> response = new APIResponse<IEnumerable<ProductTbl>>();
            try
            {
                IQueryable<ProductTbl> productList = _unitOfWork.Product.Where(x=>true);

                response.IsSuccess = true;
                response.StatusCode = HttpStatusCode.OK;
                response.Result = productList;
                response.ErrorMessages.Clear();
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.ErrorMessages.Add(ex.Message);
                response.Result = null;
            }

            return response;
        }
    }
}
