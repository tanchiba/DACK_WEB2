using MobileShopConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileShop.Areas.Admin.Models.SanPhamaAdminBus
{
    public class LoaiSanPhamAdminBus
    {
        public static IEnumerable<LoaiSanPham> DanhSach()
        {
            var dsLoaiSanPham = new MobileShopConnectionDB();
            return dsLoaiSanPham.Query<LoaiSanPham>("select * from loaisanpham");
        }
        public static void Them(MobileShopConnection.LoaiSanPham lsp)
        {
            var db = new MobileShopConnectionDB();
            db.Insert(lsp);
        }
        public static void Delete(int id, MobileShopConnection.LoaiSanPham lsp)
        {
            var db = new MobileShopConnectionDB();
            db.Delete<LoaiSanPham>("where MaLoaiSanPham = @0", id);
        }
        public static MobileShopConnection.LoaiSanPham ChiTietLoaiSP(int id)
        {
            var db = new MobileShopConnectionDB();
            return db.SingleOrDefault<MobileShopConnection.LoaiSanPham>("select * from LoaiSanPham where MaLoaiSanPham = @0", id);
        }
        public static void Update(int id, MobileShopConnection.LoaiSanPham lsp)
        {
            var db = new MobileShopConnectionDB();
            db.Update<LoaiSanPham>("SET TenLoaiSanPham = @0,BiXoa = @1 where MaLoaiSanPham = @2",lsp.TenLoaiSanPham, lsp.BiXoa, id);
        }
    }
}