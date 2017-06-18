using MobileShopConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileShop.Areas.Admin.Models.SanPhamaAdminBus
{
    public class NhaSanXuatAdminBus
    {
        public static IEnumerable<NhaSanXuat> DanhSach()
        {
            var db = new MobileShopConnectionDB();
            return db.Query<NhaSanXuat>("select * from NhaSanXuat ");
        }
        public static void Them(MobileShopConnection.NhaSanXuat nsx)
        {
            var db = new MobileShopConnectionDB();
            db.Insert(nsx);
        }
        public static void Delete(int id, MobileShopConnection.NhaSanXuat nsx)
        {
            var db = new MobileShopConnectionDB();
            db.Update<NhaSanXuat>("SET BiXoa  = 1 where MaNhaSanXuat = @0", id);
        }
        public static MobileShopConnection.NhaSanXuat ChiTiet(int id)
        {
            var db = new MobileShopConnectionDB();
            return db.SingleOrDefault<MobileShopConnection.NhaSanXuat>("select * from NhaSanXuat where MaNhaSanXuat = @0", id);

        }

        public static void Update(int id, MobileShopConnection.NhaSanXuat nsx)
        {
            var db = new MobileShopConnectionDB();
            db.Update<NhaSanXuat>("SET TenNhaSanXuat = @0,BiXoa = @1 where MaNhaSanXuat = @2", nsx.TenNhaSanXuat, nsx.BiXoa, id);
        }
    }
}