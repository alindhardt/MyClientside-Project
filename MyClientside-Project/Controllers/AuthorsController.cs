using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyClientside_Project.Controllers
{
    public class AuthorsController : Controller
    {
        // GET: Authors
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id = 1)
        {
            ViewBag.Id = id;
            return View();
        }
    }
}