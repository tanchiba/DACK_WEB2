﻿using MobileShop.Areas.Admin.Models.SanPhamaAdminBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobileShop.Areas.Admin.Controllers
{
    public class LoaiSanPhamAdminController : Controller
    {
        // GET: Admin/LoaiSanPhamAdmin
        public ActionResult Index()
        {

            return View(LoaiSanPhamAdminBus.DanhSach());
        }

        // GET: Admin/LoaiSanPhamAdmin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/LoaiSanPhamAdmin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/LoaiSanPhamAdmin/Create
        [HttpPost]
        public ActionResult Create(MobileShopConnection.LoaiSanPham lsp)
        {
            try
            {
                // TODO: Add insert logic here
                LoaiSanPhamAdminBus.Them(lsp);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/LoaiSanPhamAdmin/Edit/5
        public ActionResult Edit(int id)
        {
            return View(LoaiSanPhamAdminBus.ChiTietLoaiSP(id));
        }

        // POST: Admin/LoaiSanPhamAdmin/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, MobileShopConnection.LoaiSanPham lsp)
        {
            try
            {
                // TODO: Add update logic here
                LoaiSanPhamAdminBus.Update(id, lsp);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/LoaiSanPhamAdmin/Delete/5
        public ActionResult Delete(int id)
        {
            return View(LoaiSanPhamAdminBus.ChiTietLoaiSP(id));
        }

        // POST: Admin/LoaiSanPhamAdmin/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, MobileShopConnection.LoaiSanPham lsp)
        {
            try
            {
                // TODO: Add delete logic here
                LoaiSanPhamAdminBus.Delete(id, lsp);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
