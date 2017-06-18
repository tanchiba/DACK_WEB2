using System;
using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MobileShop.Controllers
{
    public class ApiGioHangController : ApiController
    {
        // GET: api/ApiGioHang
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/ApiGioHang/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ApiGioHang
        public void Post(int id)
        {
            User.Identity.GetUserId();
        }

        // PUT: api/ApiGioHang/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ApiGioHang/5
        public void Delete(int id)
        {
        }
    }
}
