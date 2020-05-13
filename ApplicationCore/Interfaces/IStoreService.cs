using ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IStoreService
    {
        Task<PaginationModels<storeModels>> GetStoreAsync([FromQuery] searchString search, [FromQuery] Pagination pagination);
        Task<storeModels> GetByIdAsync(int id);
        Task CreateStoreAsync(storeModels obj);
        Task UpdateStoreAsync(storeModels obj);
        Task DeleteStoreAsync(int id);
    }
}
