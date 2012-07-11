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
        private PopCornOneWebAppContext context = new PopCornOneWebAppContext();

        //
        // GET: /Language/

        public ViewResult Index()
        {
            return View(context.Languages.Include(language => language.Languages).ToList());
        }

        //
        // GET: /Language/Details/5

        public ViewResult Details(int id)
        {
            Language language = context.Languages.Single(x => x.LanguageId == id);
            return View(language);
        }

        //
        // GET: /Language/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Language/Create

        [HttpPost]
        public JsonResult Create(Language language)
        {
            if (ModelState.IsValid)
            {
                context.Languages.Add(language);
                context.SaveChanges();
                return Json("Almacenado Exitoso", JsonRequestBehavior.AllowGet);
            }

            return Json(language);
        }
        
        //
        // GET: /Language/Edit/5
 
        public ActionResult Edit(int id)
        {
            Language language = context.Languages.Single(x => x.LanguageId == id);
            return View(language);
        }

        //
        // POST: /Language/Edit/5

        [HttpPost]
        public JsonResult Edit(Language language)
        {
            if (ModelState.IsValid)
            {
                context.Entry(language).State = EntityState.Modified;
                context.SaveChanges();
                return Json("Almacenado Exitoso", JsonRequestBehavior.AllowGet);
            }
            return Json(language);
        }

        //
        // GET: /Language/Delete/5
 
        public ActionResult Delete(int id)
        {
            Language language = context.Languages.Single(x => x.LanguageId == id);
            return View(language);
        }

        //
        // POST: /Language/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Language language = context.Languages.Single(x => x.LanguageId == id);
            context.Languages.Remove(language);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult LanguageWidget()
        {
            return View(context.Languages.Include(language => language.Languages).ToList());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}