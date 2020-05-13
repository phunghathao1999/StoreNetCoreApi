using ApplicationCore.EF;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
    }
}
