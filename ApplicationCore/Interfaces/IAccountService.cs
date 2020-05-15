using ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IAccountService
    {
        Task<PaginationModels<accountModels>> GetAccountAsync([FromQuery] searchString search, [FromQuery] Pagination pagination);
        Task<accountModels> GetByIdAsync(int id);
        Task CreateAccountAsync(accountModels obj);
        Task UpdateAccountAsync(accountModels obj);
        Task DeleteAccountAsync(int id);
    }
}
