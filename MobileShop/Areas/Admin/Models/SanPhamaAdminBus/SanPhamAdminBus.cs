using MobileShopConnection;
using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileShop.Areas.Admin.Models.SanPhamaAdminBus
{
    public class SanPhamAdminBus
    {
        public static Page<SanPham> DanhSach(int pageNumber, int itemPerpage)
        {
            var db = new MobileShopConnectionDB();
            return db.Page<SanPham>(pageNumber, itemPerpage,"select  * from SanPham");
        }
        public static void Them(MobileShopConnection.SanPham sp)
        {
            var db = new MobileShopConnectionDB();
            db.Insert(sp);
        }
        public static void Update(int id, MobileShopConnection.SanPham sp)
        {
            var db = new MobileShopConnectionDB();
            db.Update<SanPham>("SET TenSanPham = @0, MoTa = @1, XuatXu = @2, MaNhaSanXuat = @3, GiaBan = @4, SoLuongBan = @5, SoLuongTon = @6, MaLoaiSanPham = @7, HinhAnh = @8 where MaSanPham = @9", sp.TenSanPham, sp.MoTa, sp.XuatXu, sp.MaNhaSanXuat, sp.GiaBan, sp.SoLuongBan, sp.SoLuongTon, sp.MaLoaiSanPham, sp.HinhAnh,id);
        }
        public static void Delete(int id, MobileShopConnection.SanPham sp)
        {
            var db = new MobileShopConnectionDB();
            db.Delete<SanPham>("where masanpham = @0", id);
        }
        public static MobileShopConnection.SanPham ChiTietSP(int id)
        {
            var db = new MobileShopConnectionDB();
            return db.SingleOrDefault<MobileShopConnection.SanPham>("select * from sanpham where masanpham = @0", id);
        }
    }
}