using Hedgar.Exchanges.Backend.API.Models;
using Hedgar.Exchanges.Backend.Domain.DTO;
using Hedgar.Exchanges.Backend.Domain.Models;
using Hedgar.Exchanges.Backend.Services.Services;
using LazyCache;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Hedgar.Exchanges.Backend.API.Controllers
{
    [RoutePrefix("v1/api/Currencies")]
    public class CurrenciesController : ApiController
    {
        [HttpGet]
        [Route("All")]
        public IHttpActionResult Listar(string ids = "")
        {
            try
            {
                IAppCache cache = new CachingService();

                var currencyService = new CurrencyService();
                Func<List<Currency>> getCurrenciesFunc = () => currencyService.GetCurrencies(ids).ToList();

                var cachedCurrencies = cache.GetOrAdd("currencies", getCurrenciesFunc);

               // return Ok(currencyService.GetCurrencies(ids));
                return Ok(cachedCurrencies);

            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }


        [HttpGet]
        [Route("Sparkline")]
        public IHttpActionResult PriceThroughDates(string start = "", string end = "", string ids = "")
        {
            try
            {
                IAppCache cache = new CachingService();

                var currencyService = new CurrencyService();
                Func<List<CurrencySparkline>> getCurrenciesFunc = () => currencyService.GetCurrencySparklines(start, end, ids).ToList();

                var cachedCurrencies = cache.GetOrAdd("currencies-sparklines", getCurrenciesFunc);

                // return Ok(currencyService.GetCurrencies(ids));
                return Ok(cachedCurrencies);

            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

    }
}
