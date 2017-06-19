using MobileShopConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileShop.Models.BUS
{
    public class GioHangBUS
    {
        public static IEnumerable<ViewGioHang> LoadListChiTietGioHang(String maTaiKhoan)
        {
            using (var db = new MobileShopConnectionDB())
            {
                return db.Query<ViewGioHang>("SELECT * FROM ViewGioHang WHERE MaTaiKhoan = @0", maTaiKhoan);
            }
        }

        public static void ThemSanPham(int maSanPham, String MaTaiKhoan)
        {
            using (var db = new MobileShopConnectionDB())
            {
                GioHang gioHang = new GioHang()
                {
                    NgayLap = DateTime.Now,
                    MaSanPham = maSanPham,
                    SoLuong = 1,
                    MaTaiKhoan = MaTaiKhoan,
                    MaTinhTrang = 1
                };
                db.Insert(gioHang);
            }
        }

        public static int checkEmtyGioHang(String maTaiKhoan)
        {
            using (var db = new  MobileShopConnectionDB())
            {
                GioHang gioHang = db.SingleOrDefault<GioHang>("Select * From GioHang where MaTaiKhoan = @0", maTaiKhoan);
                if(gioHang == null)
                {
                    return 0;
                }
                return gioHang.idGioHang;
            }
        }
    }
}