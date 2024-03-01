using HDISigorta.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace HDISigorta.Domain.Entities.Products
{
    public class ProductHistory : BaseEntity<Guid>
    {
        public Product Product { get; set; }
        [ForeignKey(nameof(ProductId))]
        public Guid ProductId { get; set; }
        //public ProductStatusEnum ProductStatus { get; set; }

        //Kar marjı
        public double ProfitMargin { get; set; }

        //Kar maliyeti
        public double ProfitCost { get; set; }

        //Garanti risk maliyeti
        public double RiskCost { get; set; }

        //Toplamda değişen parça maliyeti
        public double TotalRepairOrChangedPartCost { get; set; }

        //Bu alan tek seferde her tamir veya değişim parça maliyetini gösterir.
        public double RepairOrChangedPartCost { get; set; }
    }
}
