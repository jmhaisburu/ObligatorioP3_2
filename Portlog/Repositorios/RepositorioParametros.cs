using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using PortlogDominio.EntidadesNegocio;
using PortlogDominio.InterfacesRepositorios;
using Repositorios;
using System.Data;
using System.Data.SqlClient;

namespace Repositorios
{
   public class RepositorioParametros : IRepositorio<Parametro>
    {
        //private string cadenaConexion = ConfigurationManager.ConnectionStrings["miConexion"].ConnectionString;
        private PortlogContext db = new PortlogContext();
        public bool Add(Parametro param)
        {
            Parametro unParam = db.Parametros.Find(param.Nombre);
            if (unParam == null)
            {
                if (param != null && param.Validar())
                {

                    db.Parametros.Add(param);
                    db.SaveChanges();
                    return true;
                }
            } return false;
        }

        public IEnumerable<Parametro> FindAll()
        {
            return db.Parametros.ToList();
        }

       /* public Parametro FindById(string nombre)
        {
            //string nombreBuscado = nombre;

            SqlConnection cn = new SqlConnection(cadenaConexion);
            try
            {

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT * FROM parametro WHERE nombre=@nombre";
                cmd.Connection = cn;
                cmd.Parameters.Add(new SqlParameter("@nombre", nombre));
                
                cn.Open();

                SqlDataReader readerParametro = cmd.ExecuteReader();


                Parametro tmpParametro = null;

                if (readerParametro.HasRows)
                {
                    if (readerParametro.Read())
                    {
                       tmpParametro = new Parametro
                        {                            
                            Nombre = readerParametro["Nombre"].ToString(),
                            Valor=(int)readerParametro["Valor"]
                            
                        };
                    }
                    //ya leyó todos y los cargó en la lista a retornar, ahora se puede cerrar la conexión
                    cn.Close();

                }
                return tmpParametro;
            }
            //en cada excepción poner un punto de parada para inspeccionar la instancia de la excepción (en este caso ex)
            catch (Exception ex)
            {
                //Si se produjo una excepción no hay datos para retornar
                return null;
            }
        }
        */
        public Parametro FindById(object Id)
        {
            throw new NotImplementedException();
        }

        public bool Remove(object Id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Parametro unObjeto)
        {
            throw new NotImplementedException();
        }
    }
}
