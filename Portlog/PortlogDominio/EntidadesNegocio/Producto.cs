using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortlogDominio.EntidadesNegocio
{
    public class Producto
    {
        #region atributos
        [Key]
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public decimal Peso { get; set; }
        public Cliente Cliente { get; set; }



        #endregion



        #region metodos


        #endregion
        
        /*

        public Producto (int Codigo, string Nombre, int Stock)
        {
            this.codigo = Codigo;
            this.nombre = Nombre;
            this.stock = Stock;
        }*/

        public bool Validar()
        {
            return true;
        }
    }
}
