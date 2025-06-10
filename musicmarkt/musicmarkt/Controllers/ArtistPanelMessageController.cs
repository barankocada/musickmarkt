using BussinesLayer.Concrete;
using BussinesLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntitiLayer.Concreate;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace musicmarkt.Controllers
{
    public class ArtistPanelMessageController : Controller
    {
        MessageManager mm = new MessageManager(new EfMessageDal());
        MessageValidator messagevalidator = new MessageValidator();      
        public ActionResult Inbox()
        {
            string p = (string)Session["ArtistMail"];           
            var messagelist = mm.GetListInbox(p);
            return View(messagelist);
        }
        public ActionResult Sendbox()
        {
            string p = (string)Session["ArtistMail"];           
            var messagelist = mm.GetListSendbox(p);
            return View(messagelist);
        }
        public PartialViewResult MessageListMenu()
        {
            return PartialView();
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
            string sender = (string)Session["ArtistMail"];

            ValidationResult results = messagevalidator.Validate(p);
            if (results.IsValid)
            {

                p.SenderMail = sender;
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