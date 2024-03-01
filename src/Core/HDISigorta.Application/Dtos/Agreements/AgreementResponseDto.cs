using HDISigorta.Domain.Entities.Products;

namespace HDISigorta.Application.Dtos.Agreements
{
    public class AgreementResponseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        //Garanti içeriği
        public string Description { get; set; }

        //Geçerlilik süresi
        public int ValidityPeriod { get; set; }

        public List<Product> Products { get; set; }
    }
}
