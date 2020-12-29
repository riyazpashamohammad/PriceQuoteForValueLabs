using System.Threading.Tasks;

namespace PriceQuoteForValueLabs.Contracts
{
    public interface IPricingQuoteRepository
    {
        Task<PricingQuote> GetOrganisationDetails(string organisationSymbol);
    }
}