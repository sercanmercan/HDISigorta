using HDISigorta.Domain.Entities.Agreements;
using HDISigorta.Domain.Entities.Enums;
using HDISigorta.Domain.Entities.Products;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDISigorta.Application.Dtos.Products
{
    public class CreateProductRequestDto
    {
        public string Name { get; set; }
        public double BuyingPrice { get; set; }
        public double SellingPrice { get; set; }
        //public ProductStatusEnum ProductStatus { get; set; }

        //Değişen parçası var mı
        public bool IsChangedPart { get; set; }

        //Tamir edilen parçası var mı
        public bool IsRepairedPart { get; set; }

        //Değişen parçası maliyeti
        public double ChangedPartCost { get; set; }

        //Tamir edilen parça maliyeti
        public double RepairedPartCost { get; set; }

        //Satış zamanı
        //public DateTime? SellingTime { get; set; }

        //Alış zamanı
        public DateTime? BuyingTime { get; set; }

        //Garanti id si
        public Guid AgreementId { get; set; }
        //public ICollection<ProductHistory> ProductHistories { get; set; }

        //Kar marjı
        //public double ProfitMargin { get; set; }

        //Kar maliyeti
        //public double ProfitCost { get; set; }

        //Garanti risk maliyeti
        //public double RiskCost { get; set; }

        public bool IsCheckValid()
        {
            if (string.IsNullOrWhiteSpace(Name) || BuyingPrice <= 0 || SellingPrice <= 0 || AgreementId == Guid.Empty )
                return false;
            return true;
        }
    }
}
