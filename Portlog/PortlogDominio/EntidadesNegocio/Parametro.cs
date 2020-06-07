using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortlogDominio.EntidadesNegocio
{
    public class Parametro
    {
        [Key]
        public string Nombre { get; set; }
        public int Valor { get; set; }

        public bool Validar()
        {
            return true;
        }
    }


}
