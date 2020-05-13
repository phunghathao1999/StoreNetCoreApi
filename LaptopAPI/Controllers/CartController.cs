using System.Threading.Tasks;
using ApplicationCore.Interfaces;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace LaptopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        public readonly ICartService _service;
        public CartController(ICartService service)
        {
            _service = service;
        }
        // GET: api/Cart
        [HttpGet]
        public async Task<PaginationModels<cartModels>> GetCart([FromQuery] searchString search, [FromQuery] Pagination pagination)
        {
            var cart = await _service.GetCartAsync(search, pagination);
            return cart;
        }

        // GET: api/Cart/5
        [HttpGet("{id}")]
        public async Task<cartModels> GetCartId(int id)
        {
            var cart = await _service.GetByIdAsync(id);
            return cart;
        }

        // POST: api/Cart
        [HttpPost]
        public async Task PostCart(cartModels cart)
        {
            await _service.CreateCartAsync(cart);
        }

        // PUT: api/Cart/5
        [HttpPut]
        public async Task PutCart(cartModels cart)
        {
            await _service.UpdateCartAsync(cart);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task DeleteCart(int id)
        {
            await _service.DeleteCartAsync(id);
        }
    }
}
