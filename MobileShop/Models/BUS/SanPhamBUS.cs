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

        //public static Page<SanPham> HienThiDanhSachSanPham(int pageNumber, int itemPerpage)
        //{
        //    var db = new MobileShopConnectionDB();
        //    return db.Page<SanPham>(pageNumber, itemPerpage, "SELECT * FROM SanPham WHERE BiXoa <> 1 ORDER BY SoLuongBan DESC ");
        //}

        public static IEnumerable<SanPham> TimKiemNangCao(string tensp, string xuatxu, string lsp, string nsx)
        {
            var db = new MobileShopConnectionDB();
            return db.Query<SanPham>("SELECT* FROM SanPham WHERE TenSanPham LIKE @0 OR XuatXu LIKE @1 OR MaLoaiSanPham LIKE @2 OR MaNhaSanXuat LIKE @3", '%' + tensp + '%', '%'+ xuatxu +'%', '%'+ lsp +'%', '%'+ nsx +'%');

        }

        public static IEnumerable<SanPham> ListSPLQ(int id)
        {
            using (var db = new MobileShopConnectionDB())
            {
                return db.Query<SanPham>("SELECT top 3 * FROM SanPham WHERE MaSanPham <> @0 AND MaLoaiSanPham =  (Select MaLoaiSanPham from SanPham where MaSanPham = @0) ORDER BY SoLuongBan DESC ", id);
            }
        }

    }
}