using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Interfaces;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace LaptopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        public readonly IStoreService _service;
        public StoreController(IStoreService service)
        {
            _service = service;
        }
        // GET: api/Store
        [HttpGet]
        public async Task<PaginationModels<storeModels>> GetStore([FromQuery] searchString search, [FromQuery] Pagination pagination)
        {
            var store = await _service.GetStoreAsync(search, pagination);
            return store;
        }

        // GET: api/Store/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<storeModels> GetStoreId(int id)
        {
            var store = await _service.GetByIdAsync(id);
            return store;
        }

        // POST: api/Store
        [HttpPost]
        public async Task PostStore(storeModels store)
        {
            await _service.CreateStoreAsync(store);
        }

        // PUT: api/Store/5
        [HttpPut]
        public async Task PutStore(storeModels store)
        {
            await _service.UpdateStoreAsync(store);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task DeleteStore(int id)
        {
            await _service.DeleteStoreAsync(id);
        }
    }
}
