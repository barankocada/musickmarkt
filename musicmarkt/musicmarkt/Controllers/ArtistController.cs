using BussinesLayer.Concrete;
using BussinesLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntitiLayer.Concreate;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace musicmarkt.Controllers
{
    public class ArtistController : Controller
    {
        ArtistManager arm = new ArtistManager(new EfArtistDal());
        ArtistValidator artistValidator = new ArtistValidator();
        public ActionResult Index()
        {
            var ArtistValues = arm.Getlist();
            return View(ArtistValues);
        }
        [HttpGet]
        public ActionResult AddArtist()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddArtist(Artist p)
        {    
            ValidationResult results=artistValidator.Validate(p);
            if (results.IsValid)
            {
                arm.ArtistAdd(p);
                return RedirectToAction("Index");
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
        [HttpGet]
        public ActionResult EditArtist(int id)
        {
            var artistvalue=arm.GetByID(id);
            return View(artistvalue);
        }
        [HttpPost]
        public ActionResult EditArtist(Artist p)
        {
            ValidationResult results = artistValidator.Validate(p);
            if (results.IsValid)
            {
                arm.ArtistUpdate(p);
                return RedirectToAction("Index");
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
    }
}