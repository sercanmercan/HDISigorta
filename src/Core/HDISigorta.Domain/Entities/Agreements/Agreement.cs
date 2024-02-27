using HDISigorta.Domain.Entities.Common;
using HDISigorta.Domain.Entities.Products;

namespace HDISigorta.Domain.Entities.Agreements
{
    public class Agreement : BaseEntity<Guid>
    {
        public string Name { get; set; }

        //Garanti içeriği
        public string Description { get; set; }

        //Geçerlilik süresi
        public int ValidityPeriod { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
