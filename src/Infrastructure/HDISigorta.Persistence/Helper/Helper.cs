using HDISigorta.Application.Abstractions.Helper;
using HDISigorta.Application.Dtos.Helper;

namespace HDISigorta.Persistence.Helper
{
    public class Helper : IHelper
    {
        #region ratio
        /// <summary>
        /// Karlılık oranını verir
        /// </summary>
        /// <returns></returns>
        public async Task<double> CalculateProfitabilityRatio(ProfitabilityRequestDto request)
        {
            // satış fiyatı - (alış fiyatı + tamir yada sorun çıkan ücreti) yüzdelik hali
            double costPrice = request.BuyingPrice + request.TotalRepairOrChangedPartCost;
            return ((request.SellingPrice - costPrice) / costPrice) * 100;
        }

        /// <summary>
        /// Risk maliyet oranını verir.
        /// </summary>
        /// <returns></returns>
        public async Task<double> CalculateRiskCostRatio(RiskCostRequestDto request)
        {
            // (toplam tamir masrafı / satış fiyatı) * 100
            // (Risk olasılığı/ gerçekleşme durumunda ortaya çıkacak maliyet)
            return ((request.TotalRepairOrChangedPartCost / request.SellingPrice) * 100) / request.TotalRepairOrChangedPartCost;
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
            return request.SellingPrice - (request.BuyingPrice + request.TotalRepairOrChangedPartCost);
        }

        #endregion
    }
}
