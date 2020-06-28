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
using Repositorios;

namespace PortlogMVC.Controllers
{
    public class SalidasController : Controller
    {
        

        private HttpClient cliente = new HttpClient();
        private Uri salidasUri = null;
        private HttpResponseMessage response = new HttpResponseMessage();
        private RepositorioSalidas repoSalidas = new RepositorioSalidas();
        private RepositorioUsuario repoUsu = new RepositorioUsuario();


        public SalidasController()
        {
            cliente.BaseAddress = new Uri("http://localhost:57666");
            salidasUri = new Uri("http://localhost:57666/api/Salidas");
            cliente.DefaultRequestHeaders
                .Accept.Add(new System.Net.Http.Headers
                .MediaTypeWithQualityHeaderValue("application/json"));
        }
        // GET: Salidas
        /* public ActionResult Index()
         {
             return View(db.Salidas.ToList());
         }

         // GET: Salidas/Details/5
         public ActionResult Details(int? id)
         {
             if (id == null)
             {
                 return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
             }
             Salida salida = db.Salidas.Find(id);
             if (salida == null)
             {
                 return HttpNotFound();
             }
             return View(salida);
         }

         // GET: Salidas/Create
         public ActionResult Create()
         {
             return View();
         }*/

        // POST: Salidas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.

        // GET: Salidas/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Models.SalidaViewModel sal, Importacion tmpImportacion)
        {
            if (ModelState.IsValid)
            {
                sal.Importacion = tmpImportacion;
                sal.Usuario = repoUsu.FindById(Session["ci"]);
                sal.FechaSalida = DateTime.Now;
                var tareaPost = cliente.PostAsJsonAsync(salidasUri, sal);
                var result = tareaPost.Result;
                if (result.IsSuccessStatusCode)
                {
                    TempData["ResultadoOperacion"] = "Agregado el producto ";
                    return RedirectToAction("Index");
                }
                return View(sal);
            }
            else
            {
                TempData["ResultadoOperacion"] = "Ups! Verifique los datos";
                return RedirectToAction("Index");
            }
        }
        /*
        // GET: Salidas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salida salida = db.Salidas.Find(id);
            if (salida == null)
            {
                return HttpNotFound();
            }
            return View(salida);
        }

        // POST: Salidas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Matricula,Direccion,FechaSalida")] Salida salida)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salida).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(salida);
        }

        // GET: Salidas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salida salida = db.Salidas.Find(id);
            if (salida == null)
            {
                return HttpNotFound();
            }
            return View(salida);
        }

        // POST: Salidas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Salida salida = db.Salidas.Find(id);
            db.Salidas.Remove(salida);
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
        */
    }
}
