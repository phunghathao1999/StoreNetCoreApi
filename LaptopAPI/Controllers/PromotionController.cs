using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Interfaces;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LaptopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromotionController : ControllerBase
    {
        public readonly IPromotionService _service;
        public PromotionController(IPromotionService service)
        {
            _service = service;
        }
        // GET: api/Promotion
        [HttpGet]
        public async Task<PaginationModels<promotionModels>> GetProduct([FromQuery] searchString search, [FromQuery] Pagination pagination)
        {
            var promotion = await _service.GetPromotionAsync(search, pagination);
            return promotion;
        }

        // GET: api/Promotion/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Promotion
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Promotion/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
