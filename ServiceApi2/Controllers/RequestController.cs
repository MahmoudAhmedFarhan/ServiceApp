using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using ServiceApi2.Models;

namespace ServiceApi2.Controllers
{
    public class RequestController : ApiController
    {
        // GET: api/Request
        public IEnumerable<VwRequest> Get()
        {
            ServicesEntities ctx = new ServicesEntities();
            return ctx.VwRequests.ToList();
        }

        // GET: api/Request/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Request
        public string Post([FromBody]TbRequest request)
        {
            try
            {
                byte[] imageData = Convert.FromBase64String(request.ImageName);
                MemoryStream ms = new MemoryStream(imageData);
                Image i = Image.FromStream(ms);
                Guid imageId = Guid.NewGuid();
                i.Save(HttpContext.Current.Server.MapPath("~") + "//Content//Images//" + imageId + ".jpg");
                request.ImageName = imageId + ".jpg";

                ServicesEntities ctx = new ServicesEntities();
                request.RequestDate = DateTime.Now;
                ctx.TbRequests.Add(request);
                ctx.SaveChanges();
                return string.Empty;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        // PUT: api/Request/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Request/5
        public void Delete(int id)
        {
        }
    }
}
