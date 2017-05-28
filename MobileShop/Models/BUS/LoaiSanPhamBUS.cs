using MobileShopConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PetaPoco;

namespace MobileShop.Models.BUS
{
    public class LoaiSanPhamBUS
    {
        public static IEnumerable<LoaiSanPham> DanhSach()
        {
            var dsLoaiSanPham = new MobileShopConnectionDB();
            return dsLoaiSanPham.Query<LoaiSanPham>("select * from loaisanpham where BiXoa = 0");
        }

        public static IEnumerable<SanPham> ChiTiet(int id)
        {
            var db = new MobileShopConnectionDB();
            return db.Query<SanPham>("select * from sanpham where MaLoaiSanPham = @0", id);
        }
    }
}