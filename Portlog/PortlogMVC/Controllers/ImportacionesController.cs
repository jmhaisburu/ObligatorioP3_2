using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PortlogDominio.EntidadesNegocio;
using Repositorios;

namespace PortlogMVC.Controllers
{
    public class ImportacionesController : Controller
    {
        private PortlogContext db = new PortlogContext();

        // GET: Importaciones
        public ActionResult Index()
        {
            return View(db.Importaciones.ToList());
        }

        // GET: Importaciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Importacion importacion = db.Importaciones.Find(id);
            if (importacion == null)
            {
                return HttpNotFound();
            }
            return View(importacion);
        }

        // GET: Importaciones/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Importaciones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FechaIngreso,SalidaPrevista,Cantidad")] Importacion importacion)
        {
            if (ModelState.IsValid)
            {
                db.Importaciones.Add(importacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(importacion);
        }

        // GET: Importaciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Importacion importacion = db.Importaciones.Find(id);
            if (importacion == null)
            {
                return HttpNotFound();
            }
            return View(importacion);
        }

        // POST: Importaciones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FechaIngreso,SalidaPrevista,Cantidad")] Importacion importacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(importacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(importacion);
        }

        // GET: Importaciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Importacion importacion = db.Importaciones.Find(id);
            if (importacion == null)
            {
                return HttpNotFound();
            }
            return View(importacion);
        }

        // POST: Importaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Importacion importacion = db.Importaciones.Find(id);
            db.Importaciones.Remove(importacion);
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
