using ApplicationCore.EF;
using ApplicationCore.Interfaces;

namespace Infrastructure.Persistence.Repositories
{
    public class AccountRepository : Repository<Account>, IAccountRepository
    {
        public AccountRepository(laptopContext context) : base(context)
        {

        }

        protected new laptopContext Context => base.Context as laptopContext;
    }
}
