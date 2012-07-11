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
    public class OriginController : Controller
    {
        private PopCornOneWebAppContext context = new PopCornOneWebAppContext();

        //
        // GET: /Origin/

        public ViewResult Index()
        {
            return View(context.Origins.Include(origin => origin.Phrases).ToList());
        }

        //
        // GET: /Origin/Details/5

        public ViewResult Details(int id)
        {
            Origin origin = context.Origins.Single(x => x.OriginId == id);
            return View(origin);
        }

        //
        // GET: /Origin/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Origin/Create

        [HttpPost]
        public ActionResult Create(Origin origin)
        {
            if (ModelState.IsValid)
            {
                context.Origins.Add(origin);
                context.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(origin);
        }
        
        //
        // GET: /Origin/Edit/5
 
        public ActionResult Edit(int id)
        {
            Origin origin = context.Origins.Single(x => x.OriginId == id);
            return View(origin);
        }

        //
        // POST: /Origin/Edit/5

        [HttpPost]
        public ActionResult Edit(Origin origin)
        {
            if (ModelState.IsValid)
            {
                context.Entry(origin).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(origin);
        }

        //
        // GET: /Origin/Delete/5
 
        public ActionResult Delete(int id)
        {
            Origin origin = context.Origins.Single(x => x.OriginId == id);
            return View(origin);
        }

        //
        // POST: /Origin/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Origin origin = context.Origins.Single(x => x.OriginId == id);
            context.Origins.Remove(origin);
            context.SaveChanges();
            return RedirectToAction("Index");
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