using HDISigorta.Domain.Entities.Common;
using HDISigorta.Domain.Entities.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace HDISigorta.Domain.Entities.Products
{
    public class ProductHistory : BaseEntity<Guid>
    {
        public Product Product { get; set; }
        [ForeignKey(nameof(ProductId))]
        public Guid ProductId { get; set; }
        public ProductStatusEnum ProductStatus { get; set; }
    }
}
