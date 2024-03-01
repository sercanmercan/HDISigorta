using HDISigorta.Application.Repositories.Dealers;
using HDISigorta.Domain.Entities.Dealers;
using HDISigorta.Persistence.Contexts;

namespace HDISigorta.Persistence.Repositories.Dealers
{
    public class DealerReadRepository : ReadRepository<Dealer>, IDealerReadRepository
    {
        public DealerReadRepository(HDISigortaDbContext context) : base(context)
        {
        }
    }
}
