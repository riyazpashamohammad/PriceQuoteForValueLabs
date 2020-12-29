using PriceQuoteForValueLabs.Contracts;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriceQuoteForValueLabs.Services
{
    public class PricingQuoteService : IPricingQuoteService
    {
        #region Variables
        private readonly List<string> organisationSymbols = new List<string> { "AAWW", "AAL", "CPAAW", "PRAA", "PAAS", "RYAAY" };
        private readonly IPricingQuoteRepository _pricingQuoteRepository;
        private ConcurrentDictionary<string, double?> _allOrganisationDetails;
        #endregion

        #region Constructor
        public PricingQuoteService(IPricingQuoteRepository pricingQuoteRepository)
        {
            _pricingQuoteRepository = pricingQuoteRepository;
            _allOrganisationDetails = new ConcurrentDictionary<string, double?>();
        }
        #endregion

        #region Public Methods
        public async Task<double?> GetAveragePercentageChange()
        {
            _allOrganisationDetails = await GetAllOrganisationDetailsWithChangeinPercentage(_allOrganisationDetails);

            return _allOrganisationDetails.Average(x => x.Value);
        }

        public async Task<KeyValuePair<string, double?>> GetOrganisationWithMaximumPriceQuote()
        {
            _allOrganisationDetails = await GetAllOrganisationDetailsWithPricing(_allOrganisationDetails);

            return _allOrganisationDetails.OrderByDescending(x => x.Value).FirstOrDefault();
        }
        #endregion

        #region Private Methods
        private async Task<ConcurrentDictionary<string, double?>> GetAllOrganisationDetailsWithPricing(ConcurrentDictionary<string, double?> allOrganisationDetails)
        {
            var tasks = organisationSymbols.Select(
            async organisationSymbol =>
            {
                var OrganisationDetails = await _pricingQuoteRepository.GetOrganisationDetails(organisationSymbol);
                if (OrganisationDetails.Symbol != null)
                {
                    allOrganisationDetails.TryAdd(OrganisationDetails.Symbol, OrganisationDetails.Price);
                }
            });

            await Task.WhenAll(tasks);

            return allOrganisationDetails;
        }

        private async Task<ConcurrentDictionary<string, double?>> GetAllOrganisationDetailsWithChangeinPercentage(ConcurrentDictionary<string, double?> allOrganisationDetails)
        {
            var tasks = organisationSymbols.Select(
            async organisationSymbol =>
            {
                var OrganisationDetails = await _pricingQuoteRepository.GetOrganisationDetails(organisationSymbol);
                if (OrganisationDetails.Symbol != null)
                {
                    allOrganisationDetails.TryAdd(OrganisationDetails.Symbol, OrganisationDetails.ChangesPercentage);
                }
            });

            await Task.WhenAll(tasks);

            return allOrganisationDetails;
        }
        #endregion
    }
}