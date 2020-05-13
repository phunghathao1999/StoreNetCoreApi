using ApplicationCore.EF;
using ApplicationCore.Interfaces;

namespace Infrastructure.Persistence.Repositories
{
    public class CartRepository : Repository<Cart>, ICartRepository
    {
        public CartRepository(laptopContext context) : base(context)
        {

        }

        protected new laptopContext Context => base.Context as laptopContext;
    }
}
