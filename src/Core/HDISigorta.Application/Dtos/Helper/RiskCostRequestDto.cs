namespace HDISigorta.Application.Dtos.Helper
{
    public class RiskCostRequestDto
    {
        //risk olasılığı
        public double RiskProbability { get; set; }

        //Gerçekleşme durumunda ortaya çıkan maliyet
        public double Cost { get; set; }

    }
}
