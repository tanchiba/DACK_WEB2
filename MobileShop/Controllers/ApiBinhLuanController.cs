using MobileShop.Models.BUS;
using MobileShopConnection;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MobileShop.Controllers
{
    public class ApiBinhLuanController : ApiController
    {
        // GET: api/ApiBinhLuan
        public IEnumerable<BinhLuan> Get(int maSanPham)
        {
            return BinhLuanBUS.DanhSach(maSanPham);
        }

        // GET: api/ApiBinhLuan/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/ApiBinhLuan
        public void Post([FromBody]BinhLuan binhluan)
        {
            BinhLuanBUS.Them(binhluan.MaSanPham, User.Identity.GetUserId(), User.Identity.Name, binhluan.NoiDung);
        }

        // PUT: api/ApiBinhLuan/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ApiBinhLuan/5
        public void Delete(int id)
        {
        }
    }
}
