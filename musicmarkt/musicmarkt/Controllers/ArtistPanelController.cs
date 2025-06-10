using BussinesLayer.Concrete;
using BussinesLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntitiLayer.Concreate;
using FluentValidation.Results;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace musicmarkt.Controllers
{
    public class ArtistPanelController : Controller
    {
        SongManager sm = new SongManager(new EfSongDal());
        CategoryManager cm=new CategoryManager(new EfCategoryDal());
        ArtistManager arm=new ArtistManager(new EfArtistDal());
        ArtistValidator artistValidator = new ArtistValidator();
        Context c=new Context();
        [HttpGet]
        public ActionResult ArtistProfile(int id = 0)
        {
            string p = (string)Session["ArtistMail"];        
            id= c.Artists.Where(x => x.ArtistMail == p).Select(y => y.ArtistID).FirstOrDefault();
            var artistvalue=arm.GetByID(id);
            return View(artistvalue);
        }
        [HttpPost]
        public ActionResult ArtistProfile(Artist p)
        {
            ArtistValidator artistvalidator =new ArtistValidator();
            ValidationResult results = artistValidator.Validate(p);
            if (results.IsValid)
            {
                arm.ArtistUpdate(p);
                return RedirectToAction("AllSong");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        public ActionResult MySong()
        {
            if (Session["ArtistMail"] == null)
            {
                return RedirectToAction("ArtistLogin", "Login");
            }

            string mail = (string)Session["ArtistMail"];
            var artist = arm.GetByMail(mail);
            if (artist == null)
            {
                // artist bulunamazsa hata sayfasına yönlendir
                return RedirectToAction("ArtistLogin", "Login");
            }

            int artistid = artist.ArtistID;
            var values = sm.GetListByArtist(artistid);
            return View(values);
        }
        [HttpGet]
        public ActionResult NewSong()
        {
            List<SelectListItem> valuecategory = (from x in cm.GetList() select new SelectListItem { Text = x.CategoryName, Value = x.CategoryID.ToString() }).ToList();
            ViewBag.vlc = valuecategory;
            return View();
        }
        [HttpPost]
        public ActionResult NewSong(Song p)
        {
            string mail = (string)Session["ArtistMail"];
            var artist = arm.GetByMail(mail);
            p.SongDate = DateTime.Parse(DateTime.Now.ToLongDateString());
            p.ArtistID = artist.ArtistID;
            p.SongStatus = true;
            sm.SongAdd(p);
            return RedirectToAction("MySong");
        }

        [HttpGet]
        public ActionResult EditSong(int id)
        {
            List<SelectListItem> valuecategory = (from x in cm.GetList() select new SelectListItem { Text = x.CategoryName, Value = x.CategoryID.ToString() }).ToList();
            ViewBag.vlc = valuecategory;
            var SongValue = sm.GetByID(id);
            return View(SongValue);
        }
        [HttpPost]
        public ActionResult EditSong(Song p)
        {
            sm.SongUpdate(p);
            return RedirectToAction("MySong");
        }
        public ActionResult DeleteSong(int id)
        {
            var SongValue = sm.GetByID(id);
            SongValue.SongStatus = false;
            sm.SongDelete(SongValue);
            return RedirectToAction("MySong");
        }
        public ActionResult AllSong(int p = 1)
        {
            var songs = sm.GetList().ToPagedList(p, 4);
            return View(songs);
        }
        public ActionResult ArtistBySong(int id)
        {
            var artistvalues = sm.GetListByArtist(id);
            return View(artistvalues);
        }
    }
}