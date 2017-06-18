using MobileShopConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;

namespace MobileShop.Areas.Admin.Models.SanPhamaAdminBus
{
    public class QuanLyTaiKhoanBus
    {
        public static IEnumerable<AspNetUser> DanhSach()
        {
            var dsLoaiTaiKhoan = new MobileShopConnectionDB();
            return dsLoaiTaiKhoan.Query<AspNetUser>("select * from AspNetUsers");
        }
        public static MobileShopConnection.AspNetUser ChiTietUser(string id)
        {
            var db = new MobileShopConnectionDB();
            return db.SingleOrDefault<MobileShopConnection.AspNetUser>("select * from AspNetUsers where Id = @0", id);
        }
        public static void Delete(string id, MobileShopConnection.AspNetUser us)
        {
            var db = new MobileShopConnectionDB();
            db.Delete<AspNetUser>("where Id = @0", id);
        }
        public static void Update(string id, MobileShopConnection.AspNetUser us)
        {
            var password = Crypto.Hash(us.PasswordHash, "MD5");
            var db = new MobileShopConnectionDB();
            db.Update<AspNetUser>("SET Email = @0, PasswordHash = @1, PhoneNumber = @2, UserName = @3 where Id = @4",us.Email, password, us.PhoneNumber, us.UserName,id);
        }
        public static void ThemTaiKhoan(MobileShopConnection.AspNetUser us)
        {
            var db = new MobileShopConnectionDB();    
            db.Insert(us);
        }
    }
}