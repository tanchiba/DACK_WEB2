using MobileShop.Models.BUS;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MobileShopConnection;

namespace MobileShop.Controllers
{
    public class GioHangController : Controller
    {
        [Authorize]
        // GET: GioHang
        public ActionResult Index()
        {
            var ds = GioHangBUS.LoadListGioHang(User.Identity.GetUserId());
            int total = 0;
            foreach(var item in ds)
            {
                total += (int)item.GiaBan * (int)item.SoLuong; 
            }
            ViewBag.Total = total;
            return View(GioHangBUS.LoadListGioHang(User.Identity.GetUserId()));
        }
        [HttpPost]
        public ActionResult ThemGioHang(int maSanPham)
        {
            GioHangBUS.ThemSanPhamVaoGioHang(maSanPham, User.Identity.GetUserId());
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult CapNhatGioHang(int id, int soLuong)
        {
            GioHangBUS.CapNhatSoLuong(id, soLuong);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult ThanhToanGioHang()
        {
            IEnumerable<vGioHang> dsCT = GioHangBUS.LoadListGioHang(User.Identity.GetUserId());
            int TongTien = 0;

            foreach(var item in dsCT)
            {
                TongTien += (int)item.GiaBan * (int)item.SoLuong;
            }

            ViewBag.Total = TongTien;
            ViewBag.id = User.Identity.GetUserId();

            return View(dsCT);
        }

        [HttpPost]
        public ActionResult RemoveSanPham(int maSanPham)
        {
            GioHangBUS.RemoveSanPham(maSanPham, User.Identity.GetUserId());
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult RemoveGioHang(int id)
        {
            GioHangBUS.RemoveSPGioHang(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult checkout(string name, string address, string phone, string email)
        {
            IEnumerable<vGioHang> dsCTGH = GioHangBUS.LoadListGioHang(User.Identity.GetUserId());
            int TongTien = 0;

            foreach (var item in dsCTGH)
            {
                TongTien += (int)item.SoLuong * (int)item.GiaBan;
                //OrderDetailBUS.Them(, item.MaSanPham, (int)item.price, item.SoLuong);
            }
            OderBUS.Them(User.Identity.GetUserId(), TongTien, name, address, phone, email);


            foreach (var item in dsCTGH)
            {
                OrderDetailBUS.Them(OderBUS.getOrder(User.Identity.GetUserId(), TongTien).idGioHang, item.MaSanPham, (int)item.GiaBan, item.SoLuong);
            }

            GioHangBUS.RemoveTaiKhoan(User.Identity.GetUserId());
            return View(OderBUS.getOrder(User.Identity.GetUserId(), TongTien));
        }

    }
}