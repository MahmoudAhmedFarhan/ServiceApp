using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ServiceApi2.Models;

namespace ServiceApi2.Controllers
{
    public class ServiceProvidersController : ApiController
    {
        // GET: api/ServiceProviders
        public IEnumerable<VwServiceProvider> Get()
        {
            ServicesEntities ctx = new ServicesEntities();
            return ctx.VwServiceProviders.ToList();
        }

        // GET: api/ServiceProviders/5
        public IEnumerable<VwServiceProvider> Get(int id)
        {
            ServicesEntities ctx = new ServicesEntities();
            return ctx.VwServiceProviders.Where(a=>a.ServiceId==id).ToList();
        }

        // POST: api/ServiceProviders
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ServiceProviders/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ServiceProviders/5
        public void Delete(int id)
        {
        }
    }
}
