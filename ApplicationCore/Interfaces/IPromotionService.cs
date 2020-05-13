using ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IPromotionService
    {
        Task<PaginationModels<promotionModels>> GetPromotionAsync([FromQuery] searchString search, [FromQuery] Pagination pagination);
        Task<promotionModels> GetByIdAsync(int id);
        Task CreatePromotionAsync(promotionModels obj);
        Task UpdatePromotionAsync(promotionModels obj);
        Task DeletePromotionAsync(int id);
    }
}
