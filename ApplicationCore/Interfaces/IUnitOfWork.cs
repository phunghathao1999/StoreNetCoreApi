using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IUnitOfWork
    {
        IProductRepository Product { get; }
        ICartRepository Cart { get; }
        ICartDetailRepository CartDetail { get; }
        IPromotionRepository Promotion { get; }
        Task<int> CompleteAsync();
    }
}
