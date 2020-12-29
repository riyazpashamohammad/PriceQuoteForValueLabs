using System.Collections.Generic;
using System.Threading.Tasks;

namespace PriceQuoteForValueLabs.Contracts
{
    public interface IPricingQuoteService
    {
        Task<KeyValuePair<string, double?>> GetOrganisationWithMaximumPriceQuote();

        Task<double?> GetAveragePercentageChange();
    }
}