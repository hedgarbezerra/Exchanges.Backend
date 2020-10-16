using Hedgar.Exchanges.Backend.Domain.Business;
using Hedgar.Exchanges.Backend.Services.Hedgar.Exchanges.Backend.Services;
using LazyCache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Hedgar.Exchanges.Backend.API.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IHttpActionResult Get()
        {
            var service = new ExampleService();
            IAppCache cache = new CachingService();

            Func<List<ExampleClass>> getExamples = () => service.Listar();

            var cachedExamples = cache.GetOrAdd("testeExamples", getExamples);


            return Ok(cachedExamples);
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
