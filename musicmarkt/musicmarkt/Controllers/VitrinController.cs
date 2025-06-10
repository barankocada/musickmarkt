using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace musicmarkt.Controllers
{
    public class VitrinController : Controller
    {
        [AllowAnonymous]
        public ActionResult HomePage()
        {
            return View();
        }
    }
}