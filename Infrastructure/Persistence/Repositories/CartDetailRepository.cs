using ApplicationCore.EF;
using ApplicationCore.Interfaces;

namespace Infrastructure.Persistence.Repositories
{
    public class CartDetailRepository : Repository<Cartdetail>, ICartDetailRepository
    {
        public CartDetailRepository(laptopContext context) : base(context)
        {

        }

        protected new laptopContext Context => base.Context as laptopContext;
    }
}
