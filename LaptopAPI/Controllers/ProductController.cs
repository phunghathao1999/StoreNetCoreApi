using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Interfaces;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace LaptopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;
        public ProductController(IProductService service)
        {
            _service = service;
        }
        // GET: api/Product
        [HttpGet]
        public async Task<PaginationModels<productModels>> GetProduct([FromQuery] searchString search, [FromQuery] Pagination pagination)
        {
            var product = await _service.GetProductAsync(search, pagination);
            return product;
        }

        // GET: api/Product/5
        [HttpGet("{id}")]
        public async Task<productModels> GetProductId(int id)
        {
            var product = await _service.GetByIdAsync(id);
            return product;
        }

         //POST: api/Product
         [HttpPost]
         public async Task PostProduct(productModels product)
         {
            await _service.CreateProductAsync(product);
         }

        //PUT: api/Product/5
         [HttpPut]
        public async Task PutProduct(productModels product)
        {
            await _service.UpdateProductAsync(product);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task DeleteAsync(int id)
        {
            await _service.DeleteProductAsync(id);
        }
    }
}
