using HDISigorta.Application.Repositories;
using HDISigorta.Domain.Entities.Common;
using HDISigorta.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace HDISigorta.Persistence.Repositories
{
    //BaseEntity ile birlikte Marker pattern uygulandı.
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity<Guid>
    {
        private readonly HDISigortaDbContext _context;

        public ReadRepository(HDISigortaDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll(bool tracking = true)
        {
            var query = Table.Where(x=>!x.IsDeleted).AsQueryable();
            if (!tracking)
                query.AsNoTracking();
            return query;
        }

        public IQueryable<T> GetWhere(System.Linq.Expressions.Expression<Func<T, bool>> method, bool tracking = true)
            => Table.Where(method);

        public async Task<T> GetSingleAsync(System.Linq.Expressions.Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query.AsNoTracking();
            return await query.FirstOrDefaultAsync(method);
        }

        public async Task<T> GetByIdAsync(Guid Id, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = Table.AsNoTracking();
            return await query.FirstOrDefaultAsync(data => data.Id == Id && !data.IsDeleted);
        }
    }
}
