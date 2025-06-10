using BussinesLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace musicmarkt.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default
        SongManager sm = new SongManager(new EfSongDal());
        ContentManager cm = new ContentManager(new EfContentDal());
        public ActionResult songs()
        {
            var songlist = sm.GetList();
            return View(songlist);
        }       
        public PartialViewResult Index(int id = 0)
        {
            var contentlist=cm.GetListBySongID(id);
            return PartialView(contentlist);
            
        }
    }
}