using MobileShopConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using PetaPoco;
using System.Web;

namespace MobileShop.Models.BUS
{
    public class SanPhamBUS
    {
        public static IEnumerable<SanPham> DanhSach()
        {
            var db = new MobileShopConnectionDB();
            return db.Query<SanPham>("Select * from SanPham where BiXoa!=1");
        }

        public static SanPham ChiTiet(int id)
        {
            var db = new MobileShopConnectionDB();
            return db.SingleOrDefault<SanPham>("select * from SanPham where MaSanPham = @0 ", id);

        }

        public static Page<SanPham> HienThiDanhSachSanPham(int pageNumber, int itemPerpage)
        {
            var db = new MobileShopConnectionDB();
            return db.Page<SanPham>(pageNumber, itemPerpage, "SELECT * FROM SanPham WHERE BiXoa <> 1 ORDER BY SoLuongBan DESC ");
        }


    }
}