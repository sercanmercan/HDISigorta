using HDISigorta.Persistence.Contexts;
using HDISigorta.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDISigorta.Application.Repositories.ProductHistory
{
    public class ProductHistoryReadRepository : ReadRepository<Domain.Entities.Products.ProductHistory>, IProductHistoryReadRepository
    {
        public ProductHistoryReadRepository(HDISigortaDbContext context) : base(context)
        {
        }
    }
}
