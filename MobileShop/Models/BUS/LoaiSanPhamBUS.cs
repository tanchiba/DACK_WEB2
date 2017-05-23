using MobileShopConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileShop.Models.BUS
{
    public class LoaiSanPhamBUS
    {
        public static IEnumerable<LoaiSanPham> DanhSach()
        {
            var dsLoaiSanPham = new MobileShopConnectionDB();
            return dsLoaiSanPham.Query<LoaiSanPham>("select * from LoaiSanPham");
        }

    }
}