using HDISigorta.Application.Dtos.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDISigorta.Application.Abstractions.Helper
{
    public interface IHelper
    {
        Task<double> CalculateProfitabilityRatio(ProfitabilityRequestDto request);
        Task<double> CalculateRiskCostRatio(RiskCostRequestDto request);
        Task<double> CalculateProfitabilityCost(ProfitabilityRequestDto request);
    }
}
