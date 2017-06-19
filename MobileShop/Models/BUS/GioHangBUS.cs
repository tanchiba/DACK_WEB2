using MobileShopConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileShop.Models.BUS
{
    public class GioHangBUS
    {
       

        public static void ThemSanPhamVaoGioHang(int maSanPham, String maTaiKhoan)
        {
            using (var db = new MobileShopConnectionDB())
            {
                var a = db.FirstOrDefault<tempGioHang>("SELECT * FROM tempGioHang WHERE MaSanPham = @0", maSanPham);
                if(a != null)
                {
                    db.Execute("UPDATE tempGioHang SET SoLuong = SoLuong + 1 WHERE MaSanPham = @0", maSanPham);
                }
                else
                {
                    tempGioHang gioHang = new tempGioHang()
                    {
                        MaTaiKhoan = maTaiKhoan,
                        MaSanPham = maSanPham,
                        SoLuong = 1

                    };
                    db.Insert(gioHang);
                }
            }
        }
        public static IEnumerable<vGioHang> LoadListGioHang(String maTaiKhoan)
        {
            using (var db = new MobileShopConnectionDB())
            {
                return db.Query<vGioHang>("SELECT * FROM vGioHang WHERE MaTaiKhoan = @0", maTaiKhoan);
            }
        }
        public static void CapNhatSoLuong(int id, int soLuong)
        {
            using (var db = new MobileShopConnectionDB())
            {
                if(soLuong < 0)
                {
                    soLuong = 1;
                    db.Execute("UPDATE tempGioHang SET SoLuong = @0 WHERE id = @1", soLuong, id);
                }
                else
                {
                    if (soLuong == 0)
                    {
                        db.Execute("DELETE FROM tempGioHang WHERE id = @1", soLuong, id);
                    }
                    else
                    {
                        if(soLuong > 1 && soLuong < 15)
                        {
                            db.Execute("UPDATE tempGioHang SET SoLuong = @0 WHERE id = @1", soLuong, id);
                        }                  
                        else
                        {
                            soLuong = 1;
                            db.Execute("UPDATE tempGioHang SET SoLuong = @0 WHERE id = @1", soLuong, id);
                        }
                    }
                }
               
            }
        }
        public static void RemoveTaiKhoan(String maTaiKhoan)
        {
            using (var db = new MobileShopConnectionDB())
            {
                db.Execute("DELETE FROM tempGioHang WHERE MaTaiKhoan = @0", maTaiKhoan);
            }
        }
        public static void RemoveSanPham(int maSanPham, String maTaiKhoan)
        {
            using (var db = new MobileShopConnectionDB())
            {
                var a = db.Query<tempGioHang>("SELECT * FORM tempGioHang WHERE MaSanPham = @0 AND MaTaiKhoan = @1", maSanPham, maTaiKhoan).FirstOrDefault();
                db.Delete(a);
                //db.Execute("DELETE FROM tempGioHang WHERE MaSanPham = @0", maSanPham);
            }
        }

        public static void RemoveSPGioHang(int id)
        {
            using (var db = new MobileShopConnectionDB())
            {
                db.Execute("DELETE FROM tempGioHang WHERE id = @0", id);
            }
        }
       
    }
}