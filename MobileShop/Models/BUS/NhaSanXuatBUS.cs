using MobileShopConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileShop.Models.BUS
{
    public class NhaSanXuatBUS
    {
        public static IEnumerable<NhaSanXuat> DanhSach()
        {
            var db = new MobileShopConnectionDB();
            return db.Query<NhaSanXuat>("select * from NhaSanXuat where BiXoa = 0");

        }

        public static IEnumerable<SanPham> ChiTiet(int id)
        {
            var db = new MobileShopConnectionDB();
            return db.Query<SanPham>("select * from SanPham where MaNhaSanXuat = @0", id);

        }
    }
 }