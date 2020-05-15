using System.Threading.Tasks;
using ApplicationCore.Interfaces;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace LaptopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        public readonly IAccountService _service;
        public AccountController(IAccountService service)
        {
            _service = service;
        }

        // GET: api/Account
        [HttpGet]
        public async Task<PaginationModels<accountModels>> GetCart([FromQuery] searchString search, [FromQuery] Pagination pagination)
        {
            var account = await _service.GetAccountAsync(search, pagination);
            return account;
        }

        // GET: api/Account/5
        [HttpGet("{id}")]
        public async Task<accountModels> GetAccountId(int id)
        {
            var account = await _service.GetByIdAsync(id);
            return account;
        }

        // POST: api/Account
        [HttpPost]
        public async Task PostCart(accountModels account)
        {
            await _service.CreateAccountAsync(account);
        }

        // PUT: api/Account/5
        [HttpPut]
        public async Task PutCart(accountModels account)
        {
            await _service.UpdateAccountAsync(account);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task DeleteCart(int id)
        {
            await _service.DeleteAccountAsync(id);
        }
    }
}
