using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using PortlogDominio.EntidadesNegocio;

namespace PortlogMVC.Models
{
    public class ImportacionViewModel
    {
        
        public int IdImp { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime SalidaPrevista { get; set; }
        public Producto Producto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioFinal { get; set; }
        
    }
}