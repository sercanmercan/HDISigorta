using HDISigorta.Application.Dtos.Helper;

namespace HDISigorta.Application.Abstractions.Helper
{
    public interface IHelper
    {
        Task<double> CalculateProfitabilityRatio(ProfitabilityRequestDto request);
        Task<double> CalculateRiskCostRatio(RiskCostRequestDto request);
        Task<double> CalculateProfitabilityCost(ProfitabilityRequestDto request);
    }
}
