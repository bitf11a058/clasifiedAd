using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DotNetOpenAuth.AspNet;
using Microsoft.Web.WebPages.OAuth;
using WebMatrix.WebData;
//using ClassifiedAds.Filters;
using ClassifiedAds.Models;

namespace ClassifiedAds.Controllers
{
    public class AccountController : Controller
    {
       
        public ActionResult Index()
        {
            return View();
        }


        public JsonResult CheckUserName()
        {
            var finalpro = new Database1Entities7();
            var adminlogin = finalpro.Admins;
            var customerlogin = finalpro.Customers;
            string emailid = Request["E"];
            // Boolean flag = false;
            //check from database
            var customerlist = customerlogin.ToList();
            var adminlist = adminlogin.ToList();
            foreach (var v in adminlist)
            {
                if (v.Email.Equals(emailid))
                {
                    return this.Json(true, JsonRequestBehavior.AllowGet);
                }

            }


            return this.Json(false, JsonRequestBehavior.AllowGet);

        }


        public ActionResult signupcheck(Customer c1)
        {
            Database1Entities7 obj = new Database1Entities7();
            var c_login = obj.Customers;
            

            obj.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
        public ActionResult Signup()
        {
            return View();
        }
        public ActionResult login()
        {
            return View();
        }

        public ActionResult Adminlogin()
        {
            Database1Entities7 db = new Database1Entities7();
            var Table1 = db.Admins;
            string username = Request["login-name"];
            string password = Request["login-password"];
            //var customerlist = customerlogin.ToList(); 
            var adminlist = Table1.ToList();
            foreach (var v in adminlist)
            {
                if (v.UserName.Equals(username) && v.Password.Equals(password))
                {
                    return RedirectToAction("Index", "Admin");
                }
            }

            return RedirectToAction("login", "Account");



        }
        
        public ActionResult u_Login()
        {

            return View();
        }

        public ActionResult  User_Login()
        {
            Database1Entities7 obj = new Database1Entities7();
            var Table2 = obj.Customers;
            string username = Request["login-name"];
            string password = Request["login-password"];
         
            var customerlist = Table2.ToList();
            foreach (var v in customerlist)
            {
                if (v.UserName.Equals(username) && v.Password.Equals(password))
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            return RedirectToAction("UserPannel", "Home");
        }

    }
}