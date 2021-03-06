﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortlogMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult ImportarArchivos()
        {
            UtilidadesArchivos.LeerArchivo.LeerClienteDesdeArchivo("ArchivosTxt", "Clientes", "#");
           UtilidadesArchivos.LeerArchivo.LeerUsuarioDesdeArchivo("ArchivosTxt", "Usuarios", "#");

            UtilidadesArchivos.LeerArchivo.LeerProductoDesdeArchivo("ArchivosTxt", "Productos", "#");

            

            UtilidadesArchivos.LeerArchivo.LeerImportacionDesdeArchivo("ArchivosTxt", "Importaciones", "#");

            return RedirectToAction("Index", "Home");
        }




        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}