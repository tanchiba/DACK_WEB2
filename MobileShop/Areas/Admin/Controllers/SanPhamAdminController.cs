using MobileShop.Areas.Admin.Models.SanPhamaAdminBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobileShop.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SanPhamAdminController : Controller
    {
        // GET: Admin/SanPhamAdmin
        public ActionResult Index()
        {
            return View(SanPhamAdminBus.DanhSach());
        }

        // GET: Admin/SanPhamAdmin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/SanPhamAdmin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/SanPhamAdmin/Create
        [HttpPost]
        public ActionResult Create(MobileShopConnection.SanPham sp)
        {
            try
            {
                // TODO: Add insert logic here
                if (HttpContext.Request.Files.Count > 0)
                {
                    var hpf = HttpContext.Request.Files[0];
                    if (hpf.ContentLength > 0)
                    {
                        string fileName = Guid.NewGuid().ToString();
                       
                        string fullPathWithFileName = "/Assets/images/home/" + fileName + ".jpg";
                        hpf.SaveAs(Server.MapPath(fullPathWithFileName));
                        sp.HinhAnh = fullPathWithFileName;
                    }
                }
                sp.BiXoa = 0;
                SanPhamAdminBus.Them(sp);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/SanPhamAdmin/Edit/5
        public ActionResult Edit(int id)
        {
            return View(SanPhamAdminBus.ChiTietSP(id));
        }

        // POST: Admin/SanPhamAdmin/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, MobileShopConnection.SanPham sp)
        {
            try
            {
                // TODO: Add update logic here
                SanPhamAdminBus.Update(id, sp);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/SanPhamAdmin/Delete/5
        public ActionResult Delete(int id)
        {
            return View(SanPhamAdminBus.ChiTietSP(id));
        }

        // POST: Admin/SanPhamAdmin/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, MobileShopConnection.SanPham sp)
        {
            try
            {
                // TODO: Add delete logic here
                SanPhamAdminBus.Delete(id, sp);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
