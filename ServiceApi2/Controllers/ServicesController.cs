using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ServiceApi2.Models;

namespace ServiceApi2.Controllers
{
    public class ServicesController : ApiController
    {
        // GET: api/Services
        public IEnumerable<VwServic> Get()
        {
            ServicesEntities ctx = new ServicesEntities();
            return ctx.VwServics.ToList();
        }

        // GET: api/Services/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Services
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Services/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Services/5
        public void Delete(int id)
        {
        }
    }
}
