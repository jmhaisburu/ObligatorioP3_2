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
    public class UsuariosController : Controller
    {
       

       private RepositorioUsuario repo = new RepositorioUsuario(); // Instanciar el repositorio
                                                                        // GET: Login

            public ActionResult IniciarSesion()
        {
            return View();
        }

        [HttpPost]
        public ActionResult VerificarUsuario(Usuario user)
            {

                if (user.Ci.Length > 0 && user.Pass != "")
                {
                    Usuario usuBuscado = repo.FindById(user.Ci);
                    if (usuBuscado != null && user.Pass == usuBuscado.Pass)
                    {
                        Session["ci"] = usuBuscado.Ci;
                        Session["rol"] = usuBuscado.Rol;
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ViewBag.mensaje = "El usuario o el password no es correcto.";
                    }

                }
                return View();

            }
            public ActionResult CerrarSesion()
            {
                Session.Clear();
                return RedirectToAction("Index", "Home");
            }


            // GET: Usuarios
            public ActionResult Index()
        {
            IEnumerable<Usuario> usuarios = repo.FindAll();
            return View(usuarios);
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = repo.FindById(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                if (repo.Add(usuario))
                    return RedirectToAction("Index");
                else
                    return View(usuario);
            }
            return View();
        }

            
       

       /* // GET: Usuarios/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Ci,Rol,Pass")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Usuario usuario = db.Usuarios.Find(id);
            db.Usuarios.Remove(usuario);
            db.SaveChanges();
            return RedirectToAction("Index");
        }*/

       /* protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }*/
    }
}
