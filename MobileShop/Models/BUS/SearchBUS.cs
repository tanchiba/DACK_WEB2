using MobileShopConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileShop.Models.BUS
{
    public class SearchBUS
    {
        public static IEnumerable<SanPham> LoadDSSanPham(String txtTimKiem)
        {
            var KeyWord = txtTimKiem;
            using (var db = new MobileShopConnectionDB()) { 
                
                return db.Query<SanPham>("SELECT * FROM SanPham WHERE TenSanPham LIKE @0 OR XuatXu LIKE @0 OR MaLoaiSanPham LIKE @0 OR MaNhaSanXuat LIKE @0", '%'+ KeyWord + '%');
            }
        }
    }
}