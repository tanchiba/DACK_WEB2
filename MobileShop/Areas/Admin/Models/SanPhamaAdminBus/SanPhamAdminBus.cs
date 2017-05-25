using MobileShopConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileShop.Areas.Admin.Models.SanPhamaAdminBus
{
    public class SanPhamAdminBus
    {
        public static IEnumerable<SanPham> DanhSach()
        {
            var db = new MobileShopConnectionDB();
            return db.Query<SanPham>("select  * from SanPham");
        }
        public static void Them(MobileShopConnection.SanPham sp)
        {
            var db = new MobileShopConnectionDB();
            db.Insert(sp);
        }
    }
}