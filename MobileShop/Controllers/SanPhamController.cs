using MobileShop.Models.BUS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;


namespace MobileShop.Controllers
{
    public class SanPhamController : Controller
    {
        // GET: SanPham
        public ActionResult Index(int page =1, int pagesize = 9)
        {
            var dsSanPham = SanPhamBUS.DanhSach().ToPagedList(page, pagesize);

            return View(dsSanPham);
        }

        // GET: SanPham/Details/5
        public ActionResult Details(int id)
        {
            var db = SanPhamBUS.ChiTiet(id);
            return View(db);
           
        }

        // GET: SanPham/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SanPham/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SanPham/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SanPham/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SanPham/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SanPham/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult IndexSearchNangCao()
        {

            ViewBag.MaNhaSanXuat = new SelectList(NhaSanXuatBUS.DanhSach(), "MaNhaSanXuat", "TenNhaSanXuat");
            ViewBag.MaLoaiSanPham = new SelectList(LoaiSanPhamBUS.DanhSach(), "MaLoaiSanPham", "TenLoaiSanPham");

            return View();
        }
        [HttpGet]
        //int nsx, int lsp, 
        public ActionResult TimKiemNangCao(string tensp, string xuatxu, string lsp, string nsx, MobileShopConnection.SanPham sp)
        {
            var dsSanPham = SanPhamBUS.DanhSach();

            dsSanPham = SanPhamBUS.TimKiemNangCao(tensp, xuatxu, lsp, nsx);
            return View(dsSanPham);
        }
    }
}
