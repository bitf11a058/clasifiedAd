using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Mvc;
using ClassifiedAds.Models;

namespace ClassifiedAds.Controllers
{
    
    public class AdDetailController : Controller
    {
        public Database1Entities7 db = new Database1Entities7();

        //
        // GET: /AdDetail/
       
        public ActionResult ShowDetails()
        {

            
            int id = 0;
            try
            {
                String id1 = Request["id"];
                id = int.Parse(id1);
            }
            catch
            {
                return RedirectToAction("../Home/Home");
            }
            List<AdDetail> det = new List<AdDetail>();
            List<AdDetail> list = db.AdDetails.ToList();
            foreach (var p in list)
            {
                if (p.User_Id == id)
                    det.Add(p);
            }
            ViewBag.list = det;
            return View();
        }
        public ActionResult Inbox()
        {
            return View();
        }

        public ActionResult PostAds()
        {
            return View();
        }

        public ActionResult PostAd(HttpPostedFileBase file)
        {
            
         
            AdDetail ad=new AdDetail();
            var c_login = db.AdDetails;

            ad.AdTitle = Request["title"];
            ad.AdType = Request["type"];
            ad.Status = Request["status"];
            ad.Price = Request["price"];
            ad.Quantity = Request["quantity"];
            //ad.User_Id = Int32.Parse(Request["uid"]);
            
            string file_name="";

            for (int i = 0; i < Request.Files.Count; i++)
            {
                HttpPostedFileBase files = Request.Files[i];
                file.SaveAs(Server.MapPath(@"~\Images\" + files.FileName));
                file_name = files.FileName;
            
            }

            ad.Image_path = file_name;
            
            db.AdDetails.Add(ad);
        
            db.SaveChanges();
            return RedirectToAction("Home", "Admin");


        }


        public ActionResult search()
        {

            return View();
        }

        public ActionResult search2()
        {

            int id = Convert.ToInt32(Request["search"]);
            ViewBag.X = db.AdDetails.First(x => x.AdId == id);
            return View();

        
        }

        public ActionResult ViewAllAds()
        {
            
            var viewad = db.AdDetails;
            ViewBag.X = viewad.ToList();

            return View();
        }

        public ActionResult getProductDetailsByCategory(String type)
        {
            ViewBag.X= db.AdDetails.Where(c => c.AdTitle.Equals(type)).ToList();
            return View();
          
        }
       /* public JsonResult getProductDetails(String tittle)
        {

            return this.Json(obj.getProductDetails(tittle), JsonRequestBehavior.AllowGet);
        }*/






          

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}