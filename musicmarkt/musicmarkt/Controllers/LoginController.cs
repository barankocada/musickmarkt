using BussinesLayer.Concrete;
using BussinesLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.Concrete;
using EntitiLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Web.SessionState;

namespace musicmarkt.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        
        AdminManager adm = new AdminManager(new EfAdminDal());
        ArtistManager arm=new ArtistManager(new EfArtistDal());
        ArtistLoginManager alm = new ArtistLoginManager(new EfArtistDal());
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]         
        public ActionResult Index(Admin p)
        {
            if (p == null) 
            {
                ViewBag.ErrorMessage = "Kullanıcı adı ve şifre boş bırakılamaz.";
                return View();
            }

            var adminuserinfo = adm.GetAdmin(p.AdminUsername, p.AdminPassword);

            if (adminuserinfo != null)
            {
                FormsAuthentication.SetAuthCookie(adminuserinfo.AdminUsername,false);
                Session["AdminUsername"] = adminuserinfo.AdminUsername;
                return RedirectToAction("Index", "Song");
            }
            else
            {
                ViewBag.ErrorMessage = "Kullanıcı adı veya şifre hatalı.";
                return View();
            } 
        }
        [HttpGet]
        public ActionResult ArtistLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ArtistLogin(Artist p)
        {
            if (p == null)
            {
                ViewBag.ErrorMessage = "Bilinmeyen bir hata oluştu.";
                return RedirectToAction("ArtistLogin");
            }
            var Artistuserinfo = alm.GetArtist(p.ArtistMail, p.ArtistPassword);                    
            if (Artistuserinfo != null)
            {
               FormsAuthentication.SetAuthCookie(Artistuserinfo.ArtistMail, false);
               Session["ArtistMail"] = Artistuserinfo.ArtistMail;
               return RedirectToAction("MyContent", "ArtistPanelContent"); 
            }
            else
            {
                ViewBag.ErrorMessage = "Kullanıcı adı veya şifre hatalı.";
               return RedirectToAction("ArtistLogin");
            }
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("songs", "Default");
        }

    }
}