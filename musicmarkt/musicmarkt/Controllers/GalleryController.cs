using BussinesLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace musicmarkt.Controllers
{
    public class GalleryController : Controller
    {
        ImageFileManager ım = new ImageFileManager(new EfImageFileDal());
        public ActionResult Index()
        {
            var files=ım.Getlist();
            return View(files);
        }
    }
}