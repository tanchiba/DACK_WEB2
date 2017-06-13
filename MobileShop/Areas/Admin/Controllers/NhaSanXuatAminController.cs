using MobileShop.Areas.Admin.Models.SanPhamaAdminBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobileShop.Areas.Admin.Controllers
{
    public class NhaSanXuatAminController : Controller
    {
        // GET: Admin/NhaSanXuatAmin
        public ActionResult Index()
        {
            return View(NhaSanXuatAdminBus.DanhSach());
        }

        // GET: Admin/NhaSanXuatAmin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/NhaSanXuatAmin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/NhaSanXuatAmin/Create
        [HttpPost]
        public ActionResult Create(MobileShopConnection.NhaSanXuat nsx)
        {
            //try
            //{
                // TODO: Add insert logic here
                NhaSanXuatAdminBus.Them(nsx);
                return RedirectToAction("Index");
            //}
            //catch
            //{
            //    return View();
            //}
        }

        // GET: Admin/NhaSanXuatAmin/Edit/5
        public ActionResult Edit(int id)
        {
            return View(NhaSanXuatAdminBus.ChiTiet(id));
        }

        // POST: Admin/NhaSanXuatAmin/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, MobileShopConnection.NhaSanXuat nsx)
        {
            try
            {
                // TODO: Add update logic here
                NhaSanXuatAdminBus.Update(id, nsx);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/NhaSanXuatAmin/Delete/5
        public ActionResult Delete(int id)
        {
            var kq = NhaSanXuatAdminBus.ChiTiet(id);
            return View(kq);
        }

        // POST: Admin/NhaSanXuatAmin/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, MobileShopConnection.NhaSanXuat nsx)
        {
            //try
            //{
                // TODO: Add delete logic here
                NhaSanXuatAdminBus.Delete(id, nsx);
                return RedirectToAction("Index");
            //}
            //catch
            //{
            //    return View();
            //}
        }
    }
}
