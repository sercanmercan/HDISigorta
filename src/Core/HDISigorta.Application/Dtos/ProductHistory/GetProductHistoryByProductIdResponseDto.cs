namespace HDISigorta.Application.Dtos.ProductHistory
{
    public class GetProductHistoryByProductIdResponseDto
    {
        public string ProductName { get; set; }
        //Kar marjı
        public double ProfitMargin { get; set; }

        //Kar maliyeti
        public double ProfitCost { get; set; }

        //Garanti risk maliyeti
        public double RiskCost { get; set; }

        //Toplamda değişen parça maliyeti
        public double TotalRepairOrChangedPartCost { get; set; }
    }
}
