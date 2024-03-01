using HDISigorta.Domain.Entities.Common;
using System.Linq.Expressions;

namespace HDISigorta.Application.Repositories
{
    public interface IReadRepository<T> : IRepository<T> where T : BaseEntity<Guid>
    {
        IQueryable<T> GetAll(bool tracking = true);
        IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true);
        Task<T> GetByIdAsync(Guid Id, bool tracking = true);
    }
}
