using ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface ICartDetailService
    {
        Task<PaginationModels<cartdetailModels>> GetCartdetailAsync([FromQuery] searchString search, [FromQuery] Pagination pagination);
        Task<cartdetailModels> GetByIdAsync(int id);
        Task CreateCartdetailAsync(cartdetailModels obj);
        Task UpdateCartdetailAsync(cartdetailModels obj);
        Task DeleteCartdetailAsync(int id);
    }
}
