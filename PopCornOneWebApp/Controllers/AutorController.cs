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
    public class AutorController : Controller
    {
        private PopCornOneWebAppContext context = new PopCornOneWebAppContext();

        //
        // GET: /Autor/

        public ViewResult Index()
        {
            return View(context.Autors.Include(autor => autor.Phrases).ToList());
        }

        //
        // GET: /Autor/Details/5

        public ViewResult Details(int id)
        {
            Autor autor = context.Autors.Single(x => x.AutorId == id);
            return View(autor);
        }

        //
        // GET: /Autor/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Autor/Create

        [HttpPost]
        public ActionResult Create(Autor autor)
        {
            if (ModelState.IsValid)
            {
                context.Autors.Add(autor);
                context.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(autor);
        }
        
        //
        // GET: /Autor/Edit/5
 
        public ActionResult Edit(int id)
        {
            Autor autor = context.Autors.Single(x => x.AutorId == id);
            return View(autor);
        }

        //
        // POST: /Autor/Edit/5

        [HttpPost]
        public ActionResult Edit(Autor autor)
        {
            if (ModelState.IsValid)
            {
                context.Entry(autor).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(autor);
        }

        //
        // GET: /Autor/Delete/5
 
        public ActionResult Delete(int id)
        {
            Autor autor = context.Autors.Single(x => x.AutorId == id);
            return View(autor);
        }

        //
        // POST: /Autor/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Autor autor = context.Autors.Single(x => x.AutorId == id);
            context.Autors.Remove(autor);
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