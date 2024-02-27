using HDISigorta.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace HDISigorta.Application.Repositories
{
    public interface IRepository<T> where T : BaseEntity<Guid>
    {
        DbSet<T> Table { get; }
    }
}
