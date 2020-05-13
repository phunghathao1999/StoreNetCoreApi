using ApplicationCore.EF;
using ApplicationCore.Interfaces;

namespace Infrastructure.Persistence.Repositories
{
    public class StoreRepository : Repository<Store>,IStoreRepository
    {
        public StoreRepository(laptopContext context) : base(context)
        {

        }

        protected new laptopContext Context => base.Context as laptopContext;
    }
}
