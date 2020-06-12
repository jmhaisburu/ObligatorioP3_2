using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortlogDominio.EntidadesNegocio
{
    [Table("Usuario")]
    public class Usuario
    {
        #region atributos
        [Key]
        public string Ci { get; set; } //Le tuve que poner decimal porque no estaba pudiendo convertir NUMERIC EN INT. lo vemos...
        public string Rol { get; set; }

        public string Pass { get; set; }
        #endregion

      

        #region metodos
        public override string ToString()
        {
            return this.Ci.ToString() + " "
                + this.Rol + " "
                + this.Pass; //mostramos la pass cuando listamos? seguridad?
        }
        #endregion
        //Usuario usu = new Usuario {ci="453423", rol = "Admin", pass= "123"};

        #region Validaciones
            
        public bool Validar()
        {   /*
            La política de seguridad de las contraseñas en general establece que deben contar con al menos 6 caracteres, 
            que deben al menos incluir una mayúscula, 
            una minúscula y un dígito.La cédula es un numérico con 7 u 8 dígitos
            */
            bool resp = false;
            string patron = @"(?=^.{6,}$)(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?!.*\s)[0-9a-zA-Z!@#$%^&*()]*$";
            Regex rg = new Regex(patron);

            if (Ci.Length > 6 && Ci.Length < 9)
            {
                if (rg.IsMatch(Pass))
                {
                    resp = true;

                }
            }
                           
                    

            return resp;
        }
        #endregion
    }

}
