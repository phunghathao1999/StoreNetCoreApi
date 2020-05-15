using ApplicationCore.EF;
using ApplicationCore.Interfaces;
using Infrastructure.Persistence.Repositories;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly laptopContext _context;

        public UnitOfWork(laptopContext context)
        {
            _context = context;
            Product = new ProductRepository(context);
            Cart = new CartRepository(context);
            CartDetail = new CartDetailRepository(context);
            Promotion = new PromotionRepository(context);
            Account = new AccountRepository(context);
        }
        public IProductRepository Product { get; }
        public ICartRepository Cart { get; }
        public ICartDetailRepository CartDetail { get; }
        public IPromotionRepository Promotion { get; }
        public IAccountRepository Account { get; }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
