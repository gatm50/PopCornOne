using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PopCornOneWebApp.Models;

namespace PopCornOneWebApp.Controllers
{   
    public class LanguageController : Controller
    {
        public ActionResult LanguageWidget()
        {
            return View();
        }
    }
}