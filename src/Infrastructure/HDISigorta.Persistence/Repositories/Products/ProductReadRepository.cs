using HDISigorta.Application.Repositories.Products;
using HDISigorta.Persistence.Contexts;

namespace HDISigorta.Persistence.Repositories.Product
{
    public class ProductReadRepository : ReadRepository<Domain.Entities.Products.Product>, IProductReadRepository
    {
        public ProductReadRepository(HDISigortaDbContext context) : base(context)
        {
        }

    }
}
