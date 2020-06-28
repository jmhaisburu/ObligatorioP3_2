using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using PortlogDominio.EntidadesNegocio;
using PortlogMVC.Models;
using Repositorios;

namespace PortlogMVC.Controllers
{
    public class ImportacionesController : Controller
    {
        private PortlogContext db = new PortlogContext();

        private HttpClient cliente = new HttpClient();
        private Uri ImportacionUri = null;
        private HttpResponseMessage response = new HttpResponseMessage();

        private RepositorioImportacion repoImportacion = new RepositorioImportacion();

        public ImportacionesController()
        {
            cliente.BaseAddress = new Uri("http://localhost:57666");
            ImportacionUri = new Uri("http://localhost:57666/api/Importacion");
            cliente.DefaultRequestHeaders
                .Accept.Add(new System.Net.Http.Headers
                .MediaTypeWithQualityHeaderValue("application/json"));
        }
        // GET: Importaciones http://localhost:57666/api/Importacion/porCodigoProducto/4
        public ActionResult Index(int? codprod, string texto, string rut)
        {
            if (codprod != null && codprod > 0)
                response = cliente.GetAsync(ImportacionUri+ "/porCodigoProducto/"+codprod).Result;
            
            else if(texto !=null && texto != "")
                response = cliente.GetAsync(ImportacionUri+"/porNombreProducto/"+texto).Result;

            else if (rut != null && rut != "")
                response = cliente.GetAsync(ImportacionUri + "/porRutCliente/" + rut).Result;

            else 
                response = cliente.GetAsync(ImportacionUri).Result;

            if (response.IsSuccessStatusCode)
            {
                var imports = response.Content.
                ReadAsAsync<IEnumerable<Models.ImportacionViewModel>>().Result;
                if (imports != null && imports.Count() > 0)
                    return View("Index", imports.ToList());
                else
                {
                    TempData["ResultadoOperacion"] = "No hay productos disponibles";
                    return View("Index", new List<Models.ImportacionViewModel>());
                }
            }
            else
            {
                TempData["ResultadoOperacion"] = "Error desconocido";
                return View("Index");
            }

        }

        // GET: Importaciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Importacion importacion = repoImportacion.FindById(id);

            ImportacionViewModel vm = new ImportacionViewModel
            {
                Cantidad = importacion.Cantidad,
                FechaIngreso = importacion.FechaIngreso,
                IdImp = importacion.IdImp,
                SalidaPrevista = importacion.SalidaPrevista,
                Producto = importacion.Producto
            };

            if (importacion == null)
            {
                return HttpNotFound();
            }
            return View(vm);
        }

        public ActionResult SalidaDeImportacion(int? idImp)
        {
            Importacion tmpImportacion = repoImportacion.FindById(idImp);

            return RedirectToAction("Create", "Salidas", tmpImportacion);

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
