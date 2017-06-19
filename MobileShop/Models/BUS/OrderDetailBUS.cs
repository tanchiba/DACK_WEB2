using MobileShopConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileShop.Models.BUS
{
    public class OrderDetailBUS
    {
        public static void Them(int orderid, int productid, int _price, int _number)
        {
            using (var db = new MobileShopConnectionDB())
            {
                ChiTietGioHang ct = new ChiTietGioHang()
                {
                   idGioHang = orderid,
                   MaSanPham = productid,
                   GiaBan = _price,
                   SoLuong = _number
                };
                db.Insert(ct);
            }
        }
    }
}