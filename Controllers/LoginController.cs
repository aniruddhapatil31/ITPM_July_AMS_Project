using AMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AMS.Controllers
{
    public class LoginController : Controller
    {
       AMSDbContext ams = new AMSDbContext();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(User u, string ReturnUrl)
        {
            if (IsValid(u) == true)
            {
                FormsAuthentication.SetAuthCookie(u.Name, false); //true for persistent cookiee
                Session["Name"] = u.Name.ToString();
                if (ReturnUrl != null)
                {
                    return Redirect(ReturnUrl);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return View();
            }
        }

        public bool IsValid(User u)
        {
            var credentials = ams.Users.Where(model => model.Name == u.Name && model.Password == u.Password && model.Role == u.Role).FirstOrDefault();
            if (credentials != null)
            {
                return (u.Name == credentials.Name && u.Password == credentials.Password && u.Role == credentials.Role);
            }
            else
            {
                return false;
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session["Name"] = null;
            TempData["LogoutSuccessfully"] = "<script>(alert('Logout Successfully')</script>";
            return RedirectToAction("Index", "Home");

        }
    }
}