using HDISigorta.Application.Repositories.Dealers;
using HDISigorta.Domain.Entities.Dealers;
using HDISigorta.Persistence.Contexts;

namespace HDISigorta.Persistence.Repositories.Dealers
{
    public class DealerWriteRepository : WriteRepository<Dealer>, IDealerWriteRepository
    {
        public DealerWriteRepository(HDISigortaDbContext context) : base(context)
        {
        }
    }
}
