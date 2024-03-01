namespace HDISigorta.Application.Dtos.Helper
{
    public class RiskCostRequestDto
    {
        public double SellingPrice { get; set; }
        public double TotalRepairOrChangedPartCost { get; set; }
        //risk olasılığı
        //public double RiskProbability { get; set; }

        ////Gerçekleşme durumunda ortaya çıkan maliyet
        //public double Cost { get; set; }

    }
}
