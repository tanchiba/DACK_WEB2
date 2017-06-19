using MobileShop.Models.BUS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobileShop.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult Index(String txtTimKiem)
        {
            ViewBag.txttimKiem = txtTimKiem;
            return View(SearchBUS.LoadDSSanPham(txtTimKiem));
        }
    }
}