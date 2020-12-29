using Newtonsoft.Json;
using PriceQuoteForValueLabs.Contracts;
using PriceQuoteForValueLabs.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PriceQuoteForValueLabs.Repositories
{
    public class PricingQuoteRepository : IPricingQuoteRepository
    {
        #region Variables
        private HttpClient _httpClient;
        private const string baseAddress = "https://financialmodelingprep.com/api/";
        #endregion

        #region Constructor
        public PricingQuoteRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        #endregion

        public async Task<PricingQuote> GetOrganisationDetails(string organisationSymbol)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{baseAddress}v3/quote/{organisationSymbol}?apikey=516d8acff43ea76c313a3e536582d064");
                response.EnsureSuccessStatusCode();
                return JsonConvert.DeserializeObject<List<PricingQuote>>(await response.Content.ReadAsStringAsync(), new SingleOrArrayConverter<PricingQuote>())?.FirstOrDefault();
            }
            catch (HttpRequestException ex)
            {
                throw new HttpRequestException("Communication exception has occured" + ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}