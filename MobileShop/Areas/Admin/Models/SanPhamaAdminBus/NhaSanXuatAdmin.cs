using MobileShopConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileShop.Areas.Admin.Models.SanPhamaAdminBus
{
    public class NhaSanXuatAdmin
    {
        public static IEnumerable<NhaSanXuat> DanhSach()
        {
            var db = new MobileShopConnectionDB();
            return db.Query<NhaSanXuat>("select * from NhaSanXuat ");

        }
    }
}