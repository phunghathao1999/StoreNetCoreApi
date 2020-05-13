using ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface ICartService
    {
        Task<PaginationModels<cartModels>> GetCartAsync([FromQuery] searchString search, [FromQuery] Pagination pagination);
        Task<cartModels> GetByIdAsync(int id);
        Task CreateCartAsync(cartModels obj);
        Task UpdateCartAsync(cartModels obj);
        Task DeleteCartAsync(int id);
    }
}
