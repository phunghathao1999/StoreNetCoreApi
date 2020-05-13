using ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IProductService
    {
        Task<PaginationModels<productModels>> GetProductAsync([FromQuery] searchString search, [FromQuery] Pagination pagination);
        Task<productModels> GetByIdAsync(int id);
        Task CreateProductAsync(productModels obj);
        Task UpdateProductAsync(productModels obj);
        Task DeleteProductAsync(int id);
    }
}
