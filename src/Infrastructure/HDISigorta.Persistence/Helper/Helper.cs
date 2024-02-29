using HDISigorta.Application.Dtos.Helper;

namespace HDISigorta.Persistence.Helper
{
    public class Helper
    {
        #region ratio
        /// <summary>
        /// Karlılık oranını verir
        /// </summary>
        /// <returns></returns>
        public async Task<double> CalculateProfitabilityRatio(ProfitabilityRequestDto request)
        {
            // satış fiyatı - (alış fiyatı + tamir yada sorun çıkan ücreti) yüzdelik hali
            double costPrice = request.BuyingPrice + request.RepairOrChangedPartCost;
            return ((request.SellingPrice - costPrice) / costPrice) * 100;
        }

        /// <summary>
        /// Risk maliyet oranını verir.
        /// </summary>
        /// <returns></returns>
        public async Task<double> CalculateRiskCostRatio(RiskCostRequestDto request)
        {
            // (Risk olasılığı/ gerçekleşme durumunda ortaya çıkacak maliyet)
            return request.RiskProbability / request.Cost;
        }
        #endregion

        #region cost
        /// <summary>
        /// Karlılık fiyatını verir
        /// </summary>
        /// <returns></returns>
        public async Task<double> CalculateProfitabilityCost(ProfitabilityRequestDto request)
        {
            // satış fiyatı - (alış fiyatı + tamir yada sorun çıkan ücreti)
            return request.SellingPrice - (request.BuyingPrice + request.RepairOrChangedPartCost);
        }

        #endregion
    }
}
