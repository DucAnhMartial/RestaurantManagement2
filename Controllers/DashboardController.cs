using coderush.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace coderush.Controllers
{
    public class DashboardController : Controller
    {
        RestaurantEntities db = new RestaurantEntities();
        public ActionResult Dashboardv2()
        {
            RestaurantEntities db = new RestaurantEntities();


            // Lấy dữ liệu từ cơ sở dữ liệu
            var db_nv = db.NHAN_VIEN.ToList();
            var db_hd = db.CHI_TIET_HOA_DON.ToList();
            var db_mon = db.MONs.ToList();

            // Đặt dữ liệu vào ViewBag để sử dụng trong view
            ViewBag.NhanViens = db_nv;
            ViewBag.ChiTietHoaDons = db_hd;
            ViewBag.Mons = db_mon;
            string MAHOADON = ViewBag.MAHOADON; // Giả sử MAHOADON đã được đặt trong ViewBag

            // Kiểm tra nếu MAHOADON có giá trị
            if (!string.IsNullOrEmpty(MAHOADON))
            {
                // Tìm các chi tiết hóa đơn có mã hóa đơn tương ứng
                var chiTietHoaDons = db.CHI_TIET_HOA_DON.Where(ct => ct.MAHOADON == MAHOADON).ToList();

                // Xóa từng chi tiết hóa đơn
                foreach (var chiTietHoaDon in chiTietHoaDons)
                {
                    db.CHI_TIET_HOA_DON.Remove(chiTietHoaDon);
                }

                // Lưu thay đổi vào cơ sở dữ liệu
                db.SaveChanges();
            }
            return View();
        }

        [HttpPost]
        public ActionResult Xoa(int id)
        {
            var model = db.CHI_TIET_HOA_DON.Find(id);
            db.CHI_TIET_HOA_DON.Remove(model);
            db.SaveChanges();
            return RedirectToAction("Dashboardv2");
        }
    }
}
