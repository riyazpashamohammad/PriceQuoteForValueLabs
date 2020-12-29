using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PriceQuoteForValueLabs.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PriceQuoteForValueLabs.Controllers
{
    /// <summary>
    /// Controller for pricing quotes
    /// </summary>
    [ApiController]
    [Route("[controller]/[action]")]
    public class PriceQuoteController : BaseApiController
    {
        #region Variables
        private readonly IPricingQuoteService _pricingQuoteService;
        #endregion

        #region Constructor
        public PriceQuoteController(ILogger<PriceQuoteController> logger, IPricingQuoteService pricingQuoteService) : base(logger, pricingQuoteService)
        {
            _pricingQuoteService = pricingQuoteService;
        }
        #endregion

        #region GetMethods
        /// <summary>
        /// Gets the organization with maximum price quote
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<Response<KeyValuePair<string, double?>>> GetOrganisationWithMaximumPriceQuote()
        {
            return await ExecuteAsync(() => _pricingQuoteService.GetOrganisationWithMaximumPriceQuote());
        }

        /// <summary>
        /// Gets average change percentage of all organisations
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<Response<double?>> GetAverageChangePercentage()
        {
            return await ExecuteAsync(() => _pricingQuoteService.GetAveragePercentageChange());
        }

        [HttpGet]
        public string Get()
        {
            return "Hi! Welcome to pricing quote";
        }
        #endregion
    }
}