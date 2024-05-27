using coderush.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace coderush.Controllers
{
    using System;
    using System.Linq;
    using System.Web.DynamicData;
    using System.Web.Mvc;
    using System.Web.Razor.Parser.SyntaxTree;
    using coderush.Models;

    
    public class FormController : Controller
    {
        public RestaurantEntities db = new RestaurantEntities(); // Thay thế YourDbContext bằng tên thực tế của DbContext của bạn
        public ActionResult DATBAN()
        {

            var db_ban = db.BANs.ToList();
            var db_hd = db.CHI_TIET_HOA_DON.ToList();
            var db_mon = db.MONs.ToList();
            ViewBag.bantrong = db_ban;
            ViewBag.ChiTietHoaDons = db_hd;
            ViewBag.doan = db_mon;
            return View();
        }

        [HttpPost]
        public ActionResult DATBAN(KHACH_HANG reservation)
        {
            if (ModelState.IsValid)
            {
               

                //lay du lieu tu ba
                int soBan = int.Parse(Request.Form["ban"]);
                // tao noi luu tru kh moi
                reservation.TENKH = Request.Form["TENKH"];
                reservation.MAKH = Request.Form["MAKH"];
                reservation.SDT = Request.Form["MAKH"];
                reservation.DIACHI = "";
                reservation.EMAIL = "1@gmail.com";

                // Create a new KHACH_HANG entity
                KHACH_HANG newCustomer = new KHACH_HANG
                {
                    MAKH = reservation.MAKH,
                    SDT = reservation.SDT,
                    EMAIL = reservation.EMAIL,
                    TENKH = reservation.TENKH,
                    DIACHI = reservation.DIACHI
                };

                // Add the new customer to the DbSet
               
                db.Configuration.ValidateOnSaveEnabled = false;
                db.KHACH_HANG.Add(newCustomer);

                // Save changes to the database
                db.SaveChanges();

                // Tìm bàn tương ứng trong CSDL
                var banToUpdate = db.BANs.SingleOrDefault(b => b.SOBAN == soBan);

                if (banToUpdate != null)
                {
                    // Cập nhật trạng thái của bàn từ "trống" sang "đã đặt"
                    banToUpdate.TINHTRANG = "Đã đặt";

                    // Lưu thay đổi vào CSDL
                    db.SaveChanges();
                }
               


                // Redirect to a success page or take further actions
                return RedirectToAction("DATBAN");
            }

            // If ModelState is not valid, return to the form with errors
            return View("DATBAN", reservation);
        }

        // Add other controller actions as needed

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


        public ActionResult Advanced()
        {
            return View();
        }

        public ActionResult Editor()
        {
            return View();
        }
    }
}
