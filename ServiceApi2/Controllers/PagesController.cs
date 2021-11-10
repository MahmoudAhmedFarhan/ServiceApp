using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ServiceApi2.Models;

namespace ServiceApi2.Controllers
{
    public class PagesController : ApiController
    {
        // GET: api/Pages
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Pages/5
        public TbPage Get(int id)
        {
            ServicesEntities ctx = new ServicesEntities();
            return ctx.TbPages.Where(a => a.PageId == id).FirstOrDefault();
        }

        // POST: api/Pages
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Pages/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Pages/5
        public void Delete(int id)
        {
        }
    }
}
