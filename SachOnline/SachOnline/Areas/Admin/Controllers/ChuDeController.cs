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
    public class ChuDeController : Controller
    {
        dbSachOnlineDataContext db = new dbSachOnlineDataContext();

        // GET: ChuDe
        public ActionResult Index()
        {
            return View(db.CHUDEs.ToList());
        }

        // GET: ChuDe/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ChuDe/Create
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(CHUDE chude, FormCollection f)
        {
            if (ModelState.IsValid)
            {
               
                chude.TenChuDe = f["TenChuDe"];
                // Lưu chủ đề vào CSDL
                db.CHUDEs.InsertOnSubmit(chude);
                db.SubmitChanges();
                return RedirectToAction("Index");
            }

            // Nếu ModelState không hợp lệ, trả về view Create với dữ liệu chủ đề và danh sách chủ đề
            ViewBag.MaCD = new SelectList(db.CHUDEs.ToList().OrderBy(n => n.TenChuDe), "MaCD", "TenChuDe");
            return View(chude);
        }

        // GET: ChuDe/Edit/5
        public ActionResult Edit(int id)
        {
            var chude = db.CHUDEs.SingleOrDefault(c => c.MaCD == id);

            if (chude == null)
            {
                return HttpNotFound();
            }

            return View(chude);
        }

        // POST: ChuDe/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                var chude = db.CHUDEs.SingleOrDefault(c => c.MaCD == id);

                if (chude == null)
                {
                    return HttpNotFound();
                }

                chude.MaCD = int.Parse(collection["MaCD"]);
                chude.TenChuDe = collection["TenChuDe"];

                db.SubmitChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ChuDe/Delete/5
        public ActionResult Delete(int id)
        {
            var chude = db.CHUDEs.SingleOrDefault(c => c.MaCD == id);

            if (chude == null)
            {
                return HttpNotFound();
            }

            return View(chude);
        }

        // POST: ChuDe/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var chude = db.CHUDEs.SingleOrDefault(c => c.MaCD == id);

                if (chude == null)
                {
                    return HttpNotFound();
                }

                db.CHUDEs.DeleteOnSubmit(chude);
                db.SubmitChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}