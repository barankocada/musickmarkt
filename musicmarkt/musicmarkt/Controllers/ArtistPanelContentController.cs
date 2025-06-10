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
    public class ArtistPanelContentController : Controller
    {
        ContentManager cm = new ContentManager(new EfContentDal());
        ArtistManager arm = new ArtistManager(new EfArtistDal());

        public ActionResult MyContent()
        {         
            string mail = (string)Session["ArtistMail"];
            var artist = arm.GetByMail(mail);            
            int artistId = artist.ArtistID;
            var contentList = cm.GetListByArtist(artist.ArtistID);
            return View(contentList);
        }
        [HttpGet]
        public ActionResult AddContent(int id)
        {
            ViewBag.d = id;
            return View();
        }
        [HttpPost]
        public ActionResult AddContent(Content p)
        {
            if (Session["ArtistMail"] == null)
            {
                return RedirectToAction("ArtistPanelContent", "AddContent");
            }
            string mail = (string)Session["ArtistMail"];
            var artist = arm.GetByMail(mail);          
            int artistId = artist.ArtistID;

            if (artist == null)
            {
                // artist bulunamazsa hata sayfasına yönlendir
                return RedirectToAction("ArtistPanelContent", "AddContent");
            }

            p.ArtistID = artistId;
            p.ContentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.ContentStatus = true;

            cm.ContentAddBL(p);
            return RedirectToAction("MyContent");
        }        
    }
}