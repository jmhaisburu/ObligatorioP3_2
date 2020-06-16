using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortlogDominio.EntidadesNegocio
{
    [Table("Parametro")]
    public class Parametro
    {
        [Key]
        public string Nombre { get; set; }
        public int Valor { get; set; }

        public bool Validar()
        {
            if (Valor>0) {
                return true; }
            else { return false; }
        }
    }


}
