using AMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AMS.Controllers
{
    public class HomeController : Controller
    {
        AMSDbContext adb = new AMSDbContext();
        // GET: Home
        [Authorize]
        public ActionResult Index()
        {
            var data = adb.Users.ToList();
            return View(data);
        }
    }
}