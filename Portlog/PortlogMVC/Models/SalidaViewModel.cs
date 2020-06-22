using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PortlogDominio.EntidadesNegocio;
namespace PortlogMVC.Models
{
    public class SalidaViewModel
    {
        public int Id { get; set; }
        public string Matricula { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaSalida { get; set; }
        public Importacion Importacion { get; set; }
        public Usuario Usuario { get; set; }

        
    }
}