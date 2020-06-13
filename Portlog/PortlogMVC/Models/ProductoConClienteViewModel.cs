using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortlogMVC.Models
{
    public class ProductoConClienteViewModel
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public decimal Peso { get; set; }
        public string RutCliente { get; set; }
        public string NombreCliente { get; set; }
    }
}