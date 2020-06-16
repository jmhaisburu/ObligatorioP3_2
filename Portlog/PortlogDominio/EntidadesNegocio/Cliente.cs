using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            string patronRut = @"^[0-9]*$";
            Regex rg = new Regex(patronRut);
            if (Rut.Length == 12 && rg.IsMatch(Rut) && Nombre.Length > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        
    }
}
