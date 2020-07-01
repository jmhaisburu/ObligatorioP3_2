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
        public ActionResult Index(int? codprod, string texto, string rut, string fechaMenor)
        {
            if (Session["rol"] != null)
            {
                if (codprod != null && codprod > 0)
                    response = cliente.GetAsync(ImportacionUri + "/porCodigoProducto/" + codprod).Result;

                else if (texto != null && texto != "")
                    response = cliente.GetAsync(ImportacionUri + "/porNombreProducto/" + texto).Result;

                else if (rut != null && rut != "")
                    response = cliente.GetAsync(ImportacionUri + "/porRutCliente/" + rut).Result;

                else if (fechaMenor != null && fechaMenor != "")
                    response = cliente.GetAsync(ImportacionUri + "/sinSalir").Result;

                else
                    response = cliente.GetAsync(ImportacionUri).Result;

                if (response.IsSuccessStatusCode)
                {
                    var imports = response.Content.
                    ReadAsAsync<IEnumerable<Models.ImportacionViewModel>>().Result;
                    if (imports != null && imports.Count() > 0)
                    {

                        if (fechaMenor != null && fechaMenor != "")
                        {
                            ViewBag.sali = "si";

                        }

                        return View("Index", imports.ToList());
                    }
                    else
                    {

                        return View("Index", new List<Models.ImportacionViewModel>());
                    }
                }
                else
                {
                    TempData["ResultadoOperacion"] = "Error desconocido";
                    return View("Index");
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
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

        
    }
}
