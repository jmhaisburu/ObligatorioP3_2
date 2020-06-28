using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortlogDominio.EntidadesNegocio
{
    [Table("Salida")]
    public class Salida
    {
        [Key]
        public int Id { get; set; }
        public string Matricula { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaSalida { get; set; }        
        public Importacion Importacion { get; set; }
        public Usuario Usuario { get; set; }

        public bool Validar()
        {
            if (Matricula.Length > 0 && Matricula.Length<8 && Direccion.Length > 0)
            {
                return true;
            }
            else { return false; }
        }

    }
}
