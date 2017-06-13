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
        public ActionResult Create(String NoiDung)
        {
            return View();
        }
    }
}