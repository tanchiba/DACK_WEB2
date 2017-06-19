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
            ViewBag.txtTimKiem = txtTimKiem;
            return View(SearchBUS.LoadDSSanPham(txtTimKiem));
        }

        public ActionResult Search()
        {

            ViewBag.MaNhaSanXuat = new SelectList(NhaSanXuatBUS.DanhSach(), "MaNhaSanXuat", "TenNhaSanXuat");
            ViewBag.MaLoaiSanPham = new SelectList(LoaiSanPhamBUS.DanhSach(), "MaLoaiSanPham", "TenLoaiSanPham");

            return View();
        }

        public ActionResult IndexSearch(String txtTenSP, String txtXuatXu, int txtLoaiSP, int txtNSX)
        {
            ViewBag.txtTenSP = txtTenSP;
            ViewBag.txtXuatXu = txtXuatXu;
            ViewBag.txtLoaiSP = txtLoaiSP;
            ViewBag.txtNSX = txtNSX;
            return View(SearchBUS.SearchNangCao(txtTenSP, txtXuatXu, txtLoaiSP, txtNSX));
        }
    }
}