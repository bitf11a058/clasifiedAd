using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClassifiedAds.Models;

namespace ClassifiedAds.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {


            return View();
        }
        public ActionResult About()
        {
            

            return View();
        }

        public ActionResult Contact()
        {
           

            return View();
        }
        
        public ActionResult Logout()
        {


            return View();
        }
        public ActionResult PostAds()
        {


            return View();
        }
        public ActionResult MangoDetail()
        {
            return View();

        }
        public ActionResult WristDetail()
        {
            return View();

        }
        public ActionResult NokiaDetail()
        {
            return View();

        }
        public ActionResult ShoesDetail()
        {
            return View();

        }
        public ActionResult RingDetail()
        {
            return View();

        }
        public ActionResult SofaDetail()
        {
            return View();

        }
        public ActionResult VaseDetail()
        {
            return View();

        }
        public ActionResult User_Search()
        {
            return View();

        }
        public ActionResult U_Search2()
        {
            Database1Entities7 db = new Database1Entities7();
            var type = Request["search"];
            ViewBag.X = db.AdDetails.Where(c => c.AdTitle.Equals(type)).ToList();
            return View();
           


        }
        public ActionResult UserPannel()
        {

            return View();
        }
       
    }
}
