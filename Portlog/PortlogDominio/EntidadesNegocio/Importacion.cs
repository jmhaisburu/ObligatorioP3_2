using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PortlogDominio.EntidadesNegocio
{
    [Table("Importacion")]
    public class Importacion
    {

        #region atributos
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdImp { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime SalidaPrevista { get; set; }
        public Producto Producto { get; set; }
        public int Cantidad { get; set; }
        public static decimal PrecioFinal { get; set; }

        public bool Validar()
        {
            if (SalidaPrevista<FechaIngreso && Cantidad>0 && PrecioFinal>0) {
                return true; }
            else { return false; }
        }


        #endregion






    }
}
