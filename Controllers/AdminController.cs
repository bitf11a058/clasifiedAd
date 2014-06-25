using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClassifiedAds.Models;

namespace ClassifiedAds.Controllers
{
    public class AdminController : Controller
    {
        public Database1Entities7 db = new Database1Entities7();

        //
        // GET: /Admin/


        public ActionResult Home()
        {

            var ads = db.AdDetails;
            ViewBag.ads = ads.ToList();
            return View();
        }
       
        public ActionResult Index()
        {
            return View(db.Admins.ToList());
        }

        //
        // GET: /Admin/Details/5

        public ActionResult Details(int id = 0)
        {
            Admin admin = db.Admins.Find(id);
            if (admin == null)
            {
                return HttpNotFound();
            }
            return View(admin);
        }
        public ActionResult Update(int id = 0)
        {

            var ads = db.AdDetails;
            ViewBag.ads= ads.Find(id);
              AdDetail adsToUpdate= ads.Find(id);
            if (adsToUpdate== null)
            {
                return HttpNotFound();
            }
            return View(adsToUpdate);

        }
        [HttpPost]
        public ActionResult UpdateProductDB(AdDetail ads1)
        {
          
            AdDetail new_ad = new AdDetail();
            if (ModelState.IsValid)
            {
                db.Entry(ads1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ads1);

        }
        //
        // GET: /Admin/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/Create

        [HttpPost]
        public ActionResult Create(Admin admin)
        {
            if (ModelState.IsValid)
            {
                db.Admins.Add(admin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(admin);
        }

        //
        // GET: /Admin/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Admin admin = db.Admins.Find(id);
            if (admin == null)
            {
                return HttpNotFound();
            }
            return View(admin);
        }

        //
        // POST: /Admin/Edit/5

        [HttpPost]
        public ActionResult Edit(Admin admin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(admin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(admin);
        }

        //
        // GET: /Admin/Delete/5

       


        public ActionResult DeleteAds(int id = 0)
        {
            var ads = db.AdDetails;
            ViewBag.ad =ads.Find(id);
             AdDetail adToDelete =ads.Find(id);
            if (adToDelete == null)
            {
                return HttpNotFound();
            }
            return View(adToDelete);

        }
        [HttpPost, ActionName("DeleteAds")]
        public ActionResult Delete(int id)
        {
            var ads = db.AdDetails;
            ViewBag.X = ads.Find(id);
            AdDetail ToDeleted = ads.Find(id);
            ads.Remove(ToDeleted);
             db.SaveChanges();
            return RedirectToAction("Home","Admin");

        }
        public ActionResult EditAds(int id = 0)
        {

            var ads = db.AdDetails;
            ViewBag.ad = ads.Find(id);
            AdDetail AdToEdit=ads.Find(id);
            if (AdToEdit == null)
            {
                return HttpNotFound();
            }
            return View(AdToEdit);

        }
        [HttpPost]
        public ActionResult Update(AdDetail AdToEdit)
        {
         
            AdDetail newObj= new AdDetail();
            if (ModelState.IsValid)
            {
                db.Entry(AdToEdit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Home","Admin");
            }
            return View(AdToEdit);

        }


        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}