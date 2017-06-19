using MobileShopConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileShop.Models.BUS
{
    public class BinhLuanBUS
    {
        public static  void Them(int MaSanPham, string MaTaiKhoan, string TenTaiKhoan, string NoiDung)
        {
            using (var db = new MobileShopConnectionDB())
            {
                //BinhLuan binhluan = new BinhLuan();
                //binhluan.MaSanPham = MaSanPham;
                //binhluan.MaTaiKhoan = MaTaiKhoan;
                //binhluan.TenTaiKhoan = TenTaiKhoan;
                //binhluan.NoiDung = NoiDung;

                string a = "INSERT INTO[MobileShop].[dbo].[BinhLuan]([MaSanPham],[MaTaiKhoan],[TenTaiKhoan],[NoiDung]) VALUES(@0, @1, @2, @3)";
                db.Execute(a, MaSanPham, MaTaiKhoan, TenTaiKhoan, NoiDung);
            }
        }

        public static IEnumerable<BinhLuan>DanhSach(int MaSanPham)
        {
            using (var db = new MobileShopConnectionDB())
            {
                return db.Query<BinhLuan>("SELECT * FROM BinhLuan WHERE MaSanPham = @0 order by Ngay desc", MaSanPham);
            }
        }
    }
}