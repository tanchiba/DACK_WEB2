using MobileShopConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileShop.Models.BUS
{
    public class OderBUS
    {
        public static void Them(string userid, int tongtien, string name, string _address, string _phone, string _email)
        {
            using (var db = new MobileShopConnectionDB())
            {
                GioHang a = new GioHang()
                {
                    NgayLap = DateTime.Today,
                    TongThanhTien = tongtien,
                    MaTaiKhoan = userid,
                    MaTinhTrang = 1
                };
                db.Insert(a);
                KhachHang b = new KhachHang()
                {
                    idKhachHang = userid,
                    HoTen = name,
                    DiaChi = _address,
                    SDT = _phone,
                    Email = _email
                };
                db.Insert(b);

            }

        }

        public static GioHang getOrder(string userid, int tongtien)
        {
            using (var db = new MobileShopConnectionDB())
            {
                return db.FirstOrDefault<GioHang>("SELECT * FROM GioHang where MaTaiKhoan =@0 and TongThanhTien =@1", userid, tongtien);
            }
        }

        public static IEnumerable<ViewDonHang> list()
        {
            using (var db = new MobileShopConnectionDB())
            {
                return db.Query<ViewDonHang>("SELECT * FROM ViewDonHang");
            }
        }
    }
}