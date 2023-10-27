using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SachOnline.Models;
using PagedList;
using PagedList.Mvc;
using System.IO;

namespace SachOnline.Areas.Admin.Controllers
{
    public class KhachHangController : Controller
    {
        // GET: Admin/KhachHang
        dbSachOnlineDataContext db = new dbSachOnlineDataContext();

        public ActionResult Index(int? page)
        {
            int iPageNum = (page ?? 1);
            int iPageSize = 7;
            return View(db.KHACHHANGs.ToList().OrderBy(n => n.MaKH).ToPagedList(iPageNum, iPageSize));
        }

      
      

        public ActionResult Details(int id)
        {
            var khachHang = db.KHACHHANGs.SingleOrDefault(n => n.MaKH == id);
            if (khachHang == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(khachHang);
        }



       

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var khachHang = db.KHACHHANGs.SingleOrDefault(n => n.MaKH == id);
            if (khachHang == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(khachHang);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            var khachHang = db.KHACHHANGs.SingleOrDefault(n => n.MaKH == id);
            if (khachHang == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            db.KHACHHANGs.DeleteOnSubmit(khachHang);
            db.SubmitChanges();
            return RedirectToAction("Index");
        }
    }
}