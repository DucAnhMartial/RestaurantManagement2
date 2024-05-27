using coderush.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace coderush.Controllers
{
    public class TableController : Controller
    {
        RestaurantEntities db = new RestaurantEntities();



        public ActionResult Data()
        {

            var db_kh = db.KHACH_HANG.ToList();
            var db_ban = db.BANs.ToList();
            var db_dat = db.DON_DAT.ToList();

            var db_hd = db.CHI_TIET_HOA_DON.ToList();

            var db_nv = db.NHAN_VIEN.ToList();
            ViewBag.Bans = db_ban;
            ViewBag.DON_DAT = db_dat;
            ViewBag.KH = db_kh;
            ViewBag.ChiTietHoaDons = db_hd;
            ViewBag.NhanViens = db_nv;
            return View();
        }
        [HttpPost]
        public ActionResult Xoa(int id)
        {
            var model = db.BANs.Find(id);
            db.BANs.Remove(model);
            db.SaveChanges();
            return RedirectToAction("Data");
        }
    }
}