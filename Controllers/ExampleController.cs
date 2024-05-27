using coderush.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace coderush.Controllers
{
    public class ExampleController : Controller
    {
        RestaurantEntities db = new RestaurantEntities();

        public ActionResult Invoice(string id)
        {
            // Lấy thông tin chi tiết của hóa đơn từ cơ sở dữ liệu dựa trên MAHOADON
            var chiTietHoaDonList = db.CHI_TIET_HOA_DON.Include("HOA_DON").Include("MON").Where(x => x.MAHOADON == id).ToList();

            // Kiểm tra xem hóa đơn có tồn tại không
            if (chiTietHoaDonList == null || chiTietHoaDonList.Count == 0)
            {
                // Xử lý trường hợp hóa đơn không tồn tại, có thể chuyển hướng hoặc hiển thị thông báo lỗi
                return RedirectToAction("Error"); // Ví dụ: chuyển hướng đến trang thông báo lỗi
            }

            // Truyền thông tin chi tiết hóa đơn đến view
            return View(chiTietHoaDonList);
        }


        public ActionResult InvoicePrint()
        {
            return View();
        }

        public ActionResult Profile()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

    }
}