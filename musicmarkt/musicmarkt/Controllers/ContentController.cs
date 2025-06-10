using BussinesLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace musicmarkt.Controllers
{
    public class ContentController : Controller
    {
        ContentManager cm = new ContentManager(new EfContentDal());

        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult GetALLContents(string p)
        {
            var values = cm.GetList(p);
            var filtered = string.IsNullOrEmpty(p)
                ? values
                : values.Where(x => x.ContentValue.Contains(p)).ToList();

            return View(filtered);
        }
  
        public ActionResult ContentBySong(int id)
        {
            var contentvalues=cm.GetListBySongID(id);
            return View(contentvalues);
        }
    }
}