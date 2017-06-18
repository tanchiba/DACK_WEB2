using MobileShopConnection;
using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileShop.Areas.Admin.Models.SanPhamaAdminBus
{
    public class QuanLyDonDatHangBus
    {
         public static IEnumerable<DonDatHang> DanhSach()
        {
            var db = new MobileShopConnectionDB();
            return db.Query<DonDatHang>( "select  * from DonDatHang");
        }
    }
}