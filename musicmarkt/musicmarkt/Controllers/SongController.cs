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
    public class SongController : Controller
    {
        SongManager sm = new SongManager(new EfSongDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        ArtistManager arm = new ArtistManager(new EfArtistDal());
        public ActionResult Index()
        {
            var songvalues = sm.GetList();
            return View(songvalues);
        }

        public ActionResult SongReport()
        {
            var songvalues = sm.GetList();
            return View(songvalues);
        }

        [HttpGet]
        public ActionResult AddSong()
        {
            List<SelectListItem> valuecategory = (from x in cm.GetList() select new SelectListItem { Text = x.CategoryName, Value = x.CategoryID.ToString() }).ToList();
            List<SelectListItem> valueartist = (from x in arm.Getlist() select new SelectListItem { Text = x.ArtistName + " " + x.ArtistSurname, Value = x.ArtistID.ToString() }).ToList();
            ViewBag.vlc = valuecategory;
            ViewBag.vla = valueartist;
            return View();
        }
        [HttpPost]
        public ActionResult AddSong(Song p)
        {
            p.SongDate = DateTime.Parse(DateTime.Now.ToLongDateString());
            sm.SongAdd(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditSong(int id)
        {
            List<SelectListItem> valuecategory = (from x in cm.GetList() select new SelectListItem { Text = x.CategoryName, Value = x.CategoryID.ToString() }).ToList();
            ViewBag.vlc = valuecategory;
            var SongValue=sm.GetByID(id); 
            return View(SongValue);
        }
        [HttpPost]
        public ActionResult EditSong(Song p)
        {
            sm.SongUpdate(p);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteSong(int id)
        {
            var SongValue = sm.GetByID(id);
            SongValue.SongStatus = false;
            sm.SongDelete(SongValue);
            return RedirectToAction("Index");
        }
    }
}