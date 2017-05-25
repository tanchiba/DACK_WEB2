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
            return dsLoaiSanPham.Query<LoaiSanPham>("select * from LoaiSanPham where BiXoa = 0");
        }

        public static IEnumerable<SanPham> ChiTiet(int id)
        {
            var db = new MobileShopConnectionDB();
            return db.Query<SanPham>("select * from SanPham where MaLoaiSanPham = @0", id);
        }

        //public static Page<SanPham>HienThiDanhSach(int pageNumber, int itemPerpage)
        //{
        //    var db = new MobileShopConnectionDB();
        //    return db.Page<SanPham>(pageNumber, itemPerpage, "select * from SanPham where BiXoa <> 1");
        //}
    }
}