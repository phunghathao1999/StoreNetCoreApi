using System.Threading.Tasks;
using ApplicationCore.Interfaces;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace LaptopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartDetailController : ControllerBase
    {
        public readonly ICartDetailService _service;
        public CartDetailController(ICartDetailService service)
        {
            _service = service;
        }
        // GET: api/CartDetail
        [HttpGet]
        public async Task<PaginationModels<cartdetailModels>> GetCartdetail([FromQuery] searchString search, [FromQuery] Pagination pagination)
        {
            var cart = await _service.GetCartdetailAsync(search, pagination);
            return cart;
        }

        // GET: api/CartDetail/5
        [HttpGet("{id}")]
        public async Task<cartdetailModels> GetCartdetailId(int id)
        {
            var cartdetail = await _service.GetByIdAsync(id);
            return cartdetail;
        }

        // POST: api/CartDetail
        [HttpPost]
        public async Task PostCartdetail(cartdetailModels cartdetail)
        {
            await _service.CreateCartdetailAsync(cartdetail);
        }

        // PUT: api/CartDetail/5
        [HttpPut]
        public async Task PutCartdetail(cartdetailModels cartdetail)
        {
            await _service.UpdateCartdetailAsync(cartdetail);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task DeleteCartdetail(int id)
        {
            await _service.DeleteCartdetailAsync(id);
        }
    }
}
