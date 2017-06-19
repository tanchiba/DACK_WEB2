using Microsoft.AspNet.Identity;
using MobileShop.Models.BUS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace MobileShop.Views
{
    public class BinhLuanController : Controller
    {
        // GET: BinhLuan
        [Authorize]
        public ActionResult Create(int MaSanPham = 0, String NoiDung ="")
        {
            if (MaSanPham == 0)
                return Redirect("/");
            BinhLuanBUS.Them(MaSanPham, User.Identity.GetUserId(), User.Identity.Name, NoiDung);
            return RedirectToAction("Details", "SanPham", new { Id = MaSanPham});
        }

        public ActionResult Index(int MaSanPham, int page = 1, int pagesize = 3)
        {
            ViewBag.MaSanPham = MaSanPham;
            var dsBinhLuan = BinhLuanBUS.DanhSach(MaSanPham).ToPagedList(page, pagesize);
            return View(dsBinhLuan);
        }
    }
}