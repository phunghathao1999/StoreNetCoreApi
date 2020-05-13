using System;
using System.Linq.Expressions;

namespace ApplicationCore.Interfaces
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> Criteria { get; }
        int PageSize { get; }
        int PageIndex { get; }
        bool IsPaginated { get; }
    }
}
