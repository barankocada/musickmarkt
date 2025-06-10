using BussinesLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntitiLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace musicmarkt.Controllers
{
    public class AboutController : Controller
    {

        AboutManager abm = new AboutManager(new EfAboutDal());     
        public ActionResult Index()
        {
            var aboutvalues = abm.Getlist();
            return View(aboutvalues);
        }

        [HttpGet]
        public ActionResult AddAbout()
        {

            return View();

        }
        [HttpPost]
        public ActionResult AddAbout(About p)
        {
            abm.AboutAdd(p);
            return RedirectToAction("Index");
        }

        public PartialViewResult AboutPartial()
        {

            return PartialView();
        }
    }
}