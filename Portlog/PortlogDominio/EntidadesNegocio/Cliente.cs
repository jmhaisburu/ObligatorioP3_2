using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PortlogDominio.EntidadesNegocio

{
    [Table("Cliente")]
    public class Cliente
    {
        #region atributos
        [Key]
        public string Rut { get; set;}

        public string Nombre { get; set; }

        #endregion
 
        public bool Validar()
        {
            return true;
        }

        
    }
}
