using MobileShop.Models.BUS;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobileShop.Controllers
{
    public class GioHangController : Controller
    {
        [Authorize]
        // GET: GioHang
        public ActionResult Index()
        {
            return View(GioHangBUS.LoadListChiTietGioHang(User.Identity.GetUserId()));
        }

        public ActionResult ThemGioHang(int maSanPham)
        {
            GioHangBUS.ThemSanPham(maSanPham, User.Identity.GetUserId());
            return RedirectToAction("Index");
        }
    }
}