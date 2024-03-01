using HDISigorta.Application.Repositories.Agreements;
using HDISigorta.Domain.Entities.Agreements;
using HDISigorta.Persistence.Contexts;

namespace HDISigorta.Persistence.Repositories.Agreements
{
    public class AgreementReadRepository : ReadRepository<Agreement>, IAgreementReadRepository
    {
        public AgreementReadRepository(HDISigortaDbContext context) : base(context)
        {
        }
    }
}
