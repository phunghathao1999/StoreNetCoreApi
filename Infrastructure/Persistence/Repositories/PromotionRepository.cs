using ApplicationCore.EF;
using ApplicationCore.Interfaces;

namespace Infrastructure.Persistence.Repositories
{
    public class PromotionRepository : Repository<Promotion>, IPromotionRepository
    {
        public PromotionRepository(laptopContext context) : base(context)
        {

        }

        protected new laptopContext Context => base.Context as laptopContext;
    }
}
