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
    public class NhaXuatBanController : Controller
    {
        private dbSachOnlineDataContext db = new dbSachOnlineDataContext();

        // GET: Admin/NhaXuatBan
        public ActionResult Index()
        {
            List<NHAXUATBAN> nhaXuatBanList = db.NHAXUATBANs.ToList();
            return View(nhaXuatBanList);
        }

        // GET: Admin/NhaXuatBan/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/NhaXuatBan/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NHAXUATBAN nhaXuatBan)
        {
            if (ModelState.IsValid)
            {
                db.NHAXUATBANs.InsertOnSubmit(nhaXuatBan);
                db.SubmitChanges();
                return RedirectToAction("Index");
            }

            return View(nhaXuatBan);
        }

        // GET: Admin/NhaXuatBan/Edit/5
        public ActionResult Edit(int id)
        {
            NHAXUATBAN nhaXuatBan = db.NHAXUATBANs.SingleOrDefault(nxb => nxb.MaNXB == id);

            if (nhaXuatBan == null)
            {
                return HttpNotFound();
            }

            return View(nhaXuatBan);
        }

        // POST: Admin/NhaXuatBan/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, NHAXUATBAN nhaXuatBan)
        {
            if (ModelState.IsValid)
            {
                NHAXUATBAN nxb = db.NHAXUATBANs.SingleOrDefault(n => n.MaNXB == id);

                if (nxb == null)
                {
                    return HttpNotFound();
                }

                nxb.TenNXB = nhaXuatBan.TenNXB;
                nxb.DiaChi = nhaXuatBan.DiaChi;
                nxb.DienThoai = nhaXuatBan.DienThoai;

                db.SubmitChanges();

                return RedirectToAction("Index");
            }

            return View(nhaXuatBan);
        }

        // GET: Admin/NhaXuatBan/Delete/5
        public ActionResult Delete(int id)
        {
            NHAXUATBAN nhaXuatBan = db.NHAXUATBANs.SingleOrDefault(nxb => nxb.MaNXB == id);

            if (nhaXuatBan == null)
            {
                return HttpNotFound();
            }

            return View(nhaXuatBan);
        }

        // POST: Admin/NhaXuatBan/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection collection)
        {
            NHAXUATBAN nhaXuatBan = db.NHAXUATBANs.SingleOrDefault(nxb => nxb.MaNXB == id);

            if (nhaXuatBan == null)
            {
                return HttpNotFound();
            }

            db.NHAXUATBANs.DeleteOnSubmit(nhaXuatBan);
            db.SubmitChanges();

            return RedirectToAction("Index");
        }
    }
}