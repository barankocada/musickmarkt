using BussinesLayer.Concrete;
using BussinesLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntitiLayer.Concreate;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace musicmarkt.Controllers
{
    public class CategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryDal());


        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetCategoryList()
        {
            var categoryvalues = cm.GetList();
            return View(categoryvalues);
        }
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category p)
        {
            //cm.GetAllBl();
            CategoryValidatior categoryValidatior = new CategoryValidatior();
            ValidationResult result = categoryValidatior.Validate(p);
            if (result.IsValid)
            {
                cm.CategoryAddBL(p);
                return RedirectToAction("GetCategoryList");
            }

            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

    }
}