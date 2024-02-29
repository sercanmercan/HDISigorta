using HDISigorta.Application.Repositories.Agreements;
using HDISigorta.Domain.Entities.Agreements;
using HDISigorta.Persistence.Contexts;

namespace HDISigorta.Persistence.Repositories.Agreements
{
    public class AgreementWriteRepository : WriteRepository<Agreement>, IAgreementWriteRepository
    {
        public AgreementWriteRepository(HDISigortaDbContext context) : base(context)
        {
        }
    }
}
