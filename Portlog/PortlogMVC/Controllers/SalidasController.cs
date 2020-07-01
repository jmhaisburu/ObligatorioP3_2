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


        // POST: Salidas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.


        // GET: Salidas
        public ActionResult Index()
        {
            if (Session["rol"].ToString() == "depo")
            {
                IEnumerable<Salida> salidas = repoSalidas.FindAll();
                return View(salidas);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }

        // GET: Salidas/Create
        public ActionResult Create()
        {
            if (Session["rol"].ToString() == "depo")
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }

        [HttpPost]
        public ActionResult Create(Models.SalidaViewModel sal, Importacion tmpImportacion)
        {
            if (ModelState.IsValid)
            {
                if (sal.Matricula.Length > 0 && sal.Direccion.Length > 0)
                {
                    sal.Importacion = tmpImportacion;
                    sal.Usuario = repoUsu.FindById(Session["ci"]);
                    sal.FechaSalida = DateTime.Now;
                    var tareaPost = cliente.PostAsJsonAsync(salidasUri, sal);
                    var result = tareaPost.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }

                }
                TempData["ResultadoOperacion"] = "Ya existe una salida para esa importacion";
                return View();
            }
            else
            {
                TempData["ResultadoOperacion"] = "Debe llenar todos los campos";
                return View();
            }
        }
        
    }
}
