using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortlogDominio.EntidadesNegocio
{
    public class Salida
    {
        [Key]
        public int Id { get; set; }
        public string Matricula { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaSalida{get; set;}


        
    }
}
