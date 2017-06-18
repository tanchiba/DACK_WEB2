using MobileShop.Areas.Admin.Models.SanPhamaAdminBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobileShop.Areas.Admin.Controllers
{
    public class QuanLyTaiKhoanController : Controller
    {
        // GET: Admin/QuanLyTaiKhoan
        public ActionResult Index()
        {
            var dsTaiKhoan = QuanLyTaiKhoanBus.DanhSach();
            return View(dsTaiKhoan);
        }

        // GET: Admin/QuanLyTaiKhoan/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/QuanLyTaiKhoan/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/QuanLyTaiKhoan/Create
        [HttpPost]
        public ActionResult Create(MobileShopConnection.AspNetUser us)
        {
            try
            {
                // TODO: Add insert logic here
                QuanLyTaiKhoanBus.ThemTaiKhoan(us);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/QuanLyTaiKhoan/Edit/5
        public ActionResult Edit(string id)
        {
            return View(QuanLyTaiKhoanBus.ChiTietUser(id));
        }

        // POST: Admin/QuanLyTaiKhoan/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, MobileShopConnection.AspNetUser us)
        {
            try
            {
                // TODO: Add update logic here
                QuanLyTaiKhoanBus.Update(id, us);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/QuanLyTaiKhoan/Delete/5
        public ActionResult Delete(string id)
        {
            return View(QuanLyTaiKhoanBus.ChiTietUser(id));
        }

        // POST: Admin/QuanLyTaiKhoan/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, MobileShopConnection.AspNetUser us)
        {
            try
            {
                // TODO: Add delete logic here
                QuanLyTaiKhoanBus.Delete(id, us);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
