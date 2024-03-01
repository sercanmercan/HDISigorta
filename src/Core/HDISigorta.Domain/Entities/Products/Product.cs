using HDISigorta.Domain.Entities.Agreements;
using HDISigorta.Domain.Entities.Common;
using HDISigorta.Domain.Entities.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace HDISigorta.Domain.Entities.Products
{
    public class Product : BaseEntity<Guid>
    {
        public string Name { get; set; }
        public double BuyingPrice { get; set; }
        public double SellingPrice { get; set; }
        public ProductStatusEnum ProductStatus { get; set; }
        //public bool IsSold { get; set; }

        //Değişen parçası var mı
        public bool IsChangedPart { get; set; }

        //Tamir edilen parçası var mı
        public bool IsRepairedPart { get; set; }

        //Değişen veya tamir edilen parça maliyeti
        public double RepairOrChangedPartCost { get; set; }

        //Satış zamanı
        public DateTime? SellingTime { get; set; }

        //Alış zamanı
        public DateTime? BuyingTime { get; set; }

        //Garanti içeriği
        public Agreement Agreement { get; set; }
        [ForeignKey(nameof(AgreementId))]
        public Guid AgreementId { get; set; }
        public virtual ICollection<ProductHistory> ProductHistories { get; set; } = new List<ProductHistory>();

        //Kar marjı
        //public double ProfitMargin  { get; set; }

        ////Kar maliyeti
        //public double ProfitCost { get; set; }

        ////Garanti risk maliyeti
        //public double RiskCost { get; set; }
    }
}
