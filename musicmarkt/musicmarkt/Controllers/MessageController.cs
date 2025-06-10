using BussinesLayer.Concrete;
using BussinesLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web; 
using System.Web.Mvc;
using EntitiLayer.Concreate;



namespace musicmarkt.Controllers
{
    public class MessageController : Controller
    {

        MessageManager mm = new MessageManager(new EfMessageDal());
        MessageValidator messagevalidator = new MessageValidator();

        [Authorize]
        public ActionResult Inbox()
        {
            string p = (string)Session["AdminUsername"];
            var messagelist = mm.GetListInbox(p);
            return View(messagelist);
        }
        public ActionResult Sendbox()
        {
            string p = (string)Session["AdminUsername"];
            var messagelist = mm.GetListSendbox(p);
            return View(messagelist);
        }
        public ActionResult GetSendboxMessageDetails(int id)
        {
            var values = mm.GetByID(id);
            return View(values);
        }
        public ActionResult GetInboxMessageDetails(int id)
        {
            var values = mm.GetByID(id);           
            return View(values);
        }
        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message p)
        {

            ValidationResult results = messagevalidator.Validate(p);
            if (results.IsValid)
            {
                p.MessageDate = DateTime.Parse(DateTime.Now.ToString());
                mm.MessageAddBL(p);
                return RedirectToAction("Sendbox");
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