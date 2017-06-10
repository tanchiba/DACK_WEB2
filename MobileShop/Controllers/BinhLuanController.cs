using Microsoft.AspNet.Identity;
using MobileShop.Models.BUS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

        public ActionResult Index(int MaSanPham)
        {
            ViewBag.MaSanPham = MaSanPham;
            return View(BinhLuanBUS.DanhSach(MaSanPham));
        }
    }
}