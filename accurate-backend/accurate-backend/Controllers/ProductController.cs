using accurate_data_access.DTO;
using accurate_data_access.Entities;
using accurate_services.services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace accurate_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// Get All product .
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(APIResponse<IEnumerable<ProductTbl>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(APIResponse<IEnumerable<ProductTbl>>), StatusCodes.Status500InternalServerError)]
        public  APIResponse<IEnumerable<ProductTbl>> GetProducts()
        {
            return  _productService.FetchAllProducts();
        }
    }
}
