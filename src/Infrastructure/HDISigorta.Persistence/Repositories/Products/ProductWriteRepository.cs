using HDISigorta.Application.Repositories.Products;
using HDISigorta.Persistence.Contexts;

namespace HDISigorta.Persistence.Repositories.Products
{
    public class ProductWriteRepository : WriteRepository<Domain.Entities.Products.Product>, IProductWriteRepository
    {
        public ProductWriteRepository(HDISigortaDbContext context) : base(context)
        {
        }

    }
}
