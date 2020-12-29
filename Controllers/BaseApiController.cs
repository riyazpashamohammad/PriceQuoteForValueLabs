using Microsoft.Extensions.Logging;
using PriceQuoteForValueLabs.Contracts;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace PriceQuoteForValueLabs.Controllers
{
    public class BaseApiController : ApiController
    {
        #region Variables
        private readonly ILogger<PriceQuoteController> _logger;
        private readonly IPricingQuoteService _pricingQuoteService;
        #endregion

        public BaseApiController(ILogger<PriceQuoteController> logger, IPricingQuoteService pricingQuoteService)
        {
            _logger = logger;
            _pricingQuoteService = pricingQuoteService;
        }

        protected async Task<Response<T>> ExecuteAsync<T>(Func<Task<T>> serviceAction)
        {
            try
            {
                return Response<T>.CreateSuccessResponse(await serviceAction.Invoke());
            }
            catch (Exception ex)
            {
                _logger.LogError("An error has occured at", ex.Message);
                return Response<T>.CreateErrorResponse(ex);
            }
        }

    }
}