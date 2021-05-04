using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_DB_First;

namespace MVC_DB_First.Controllers
{
    public class StagiairesController : Controller
    {
        private DBStagiaireEntities db = new DBStagiaireEntities();

        // GET: Stagiaires
        public ActionResult Index()
        {
            return View(db.Stagiaires.ToList());
        }

        // GET: Stagiaires/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stagiaire stagiaire = db.Stagiaires.Find(id);
            if (stagiaire == null)
            {
                return HttpNotFound();
            }
            return View(stagiaire);
        }

        // GET: Stagiaires/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Stagiaires/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nom,prenom,age")] Stagiaire stagiaire)
        {
            if (ModelState.IsValid)
            {
                db.Stagiaires.Add(stagiaire);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(stagiaire);
        }

        // GET: Stagiaires/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stagiaire stagiaire = db.Stagiaires.Find(id);
            if (stagiaire == null)
            {
                return HttpNotFound();
            }
            return View(stagiaire);
        }

        // POST: Stagiaires/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nom,prenom,age")] Stagiaire stagiaire)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stagiaire).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stagiaire);
        }

        // GET: Stagiaires/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stagiaire stagiaire = db.Stagiaires.Find(id);
            if (stagiaire == null)
            {
                return HttpNotFound();
            }
            return View(stagiaire);
        }

        // POST: Stagiaires/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Stagiaire stagiaire = db.Stagiaires.Find(id);
            db.Stagiaires.Remove(stagiaire);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
