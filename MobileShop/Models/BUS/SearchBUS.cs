using MobileShopConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileShop.Models.BUS
{
    public class SearchBUS
    {
        public static IEnumerable<SanPham> LoadDSSanPham(String KeyWord)
        {
            using (var db = new MobileShopConnectionDB())
            {
                return db.Query<SanPham>("SELECT * FROM SanPham WHERE TenSanPham = @0", KeyWord);
            }
        }
    }
}