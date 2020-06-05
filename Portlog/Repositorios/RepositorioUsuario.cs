using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using PortlogDominio.EntidadesNegocio;
using PortlogDominio.InterfacesRepositorios;
//Recordar agregar en el proyecto la referencia al ensamblado System.Configuration
using System.Data;
using System.Data.SqlClient;

//Using agregados.


namespace Repositorios
{
    public class RepositorioUsuario : IRepositorio<Usuario>
    {
        private PortlogContext db = new PortlogContext();

        public bool Add(Usuario unObjeto)
        {
            if (unObjeto != null && !unObjeto.Validar())
                return false;          
            db.Usuarios.Add(unObjeto);
            db.SaveChanges();
            return true;
        }

        public IEnumerable<Usuario> FindAll()
        {
            IEnumerable<Usuario> usuarios = db.Usuarios.ToList(); //transformo la tabla en una lista
            return usuarios;
        }

        public Usuario FindById(object Id)
        {
            throw new NotImplementedException();
        }

        public bool Remove(object Id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Usuario unObjeto)
        {
            throw new NotImplementedException();
        }

        /* public bool Add(Usuario usu)
         {
             //valiamos que el usuario no sea null y cumpla con los requisitos
             if (usu == null || !usu.Validar()) return false;
             //Preparar la conexión

             SqlConnection cn = new SqlConnection(cadenaConexion);
             try
             {
                 SqlParameter paramCi = new SqlParameter("@ci", usu.Ci);
                 SqlParameter paramRol = new SqlParameter("@rol", usu.Rol);
                 SqlParameter paramPass = new SqlParameter("@pass", usu.Pass);

                 string cadenaComando = "insert into usuario values (@ci, @pass, @rol)";

                 SqlCommand cmd = new SqlCommand(cadenaComando, cn);
                 cmd.Parameters.Add(paramCi);
                 cmd.Parameters.Add(paramRol);
                 cmd.Parameters.Add(paramPass);

                 cn.Open();

                 int filasAfectadas = cmd.ExecuteNonQuery();

                 cn.Close();

                 return (filasAfectadas==1);

             }
             catch (Exception ex)
             {
                 return false;
             }
         }


         public IEnumerable<Usuario> FindAll()
         {
             //Preparar la conexión
             SqlConnection cn = new SqlConnection(cadenaConexion);
             try
             {
                 //Preparar el comando incluyendo: la conexión, la consulta. No requiere parámetros.
                 SqlCommand cmd = new SqlCommand();
                 cmd.CommandText = "SELECT * FROM Usuario";
                 cmd.Connection = cn;

                 //Todo pronto para ejecutar, se abre la conexión y se ejecuta.
                 cn.Open();
                 //La select devuelve filas, las obtenemos en un SqlDataReader
                 SqlDataReader readerUsuario = cmd.ExecuteReader();
                 //Leemos la fila activa. El reader lee mediante el método Read() una sola fila por vez, 
                 //la carga y retorna true. Cuando llega al final e intenta leer una fila inexistente retorna false,
                 if (readerUsuario.HasRows)
                 {
                     List<Usuario> losUsuarios = new List<Usuario>();
                     while (readerUsuario.Read())
                     {
                         losUsuarios.Add(new Usuario
                         {
                             Ci = (int)readerUsuario["ci"],
                             Rol = readerUsuario["rol"].ToString(),
                             Pass = readerUsuario["pass"].ToString(),
                         });
                     }
                     //ya leyó todos y los cargó en la lista a retornar, ahora se puede cerrar la conexión
                     cn.Close();
                     return losUsuarios;
                 }

                 else
                     return null; //no había clientes


             }
             //en cada excepción poner un punto de parada para inspeccionar la instancia de la excepción (en este caso ex)
             catch (Exception ex)
             {
                 //Si se produjo una excepción no hay datos para retornar
                 return null;
             }
         }

         public Usuario FindById(object Ci)
         {
             //El Id es un int, pero viene bajo "forma" de object, hay que hacer casting
             int CiBuscada = (int)Ci; //Si no era compatible con int se producirá excepción e irá al catch
             //Preparar la conexión
             SqlConnection cn = new SqlConnection(cadenaConexion);
             try
             {
                 //Preparar el comando incluyendo: la conexión, la consulta. No requiere parámetros.
                 SqlCommand cmd = new SqlCommand();
                 cmd.CommandText = "SELECT * FROM Usuario WHERE ci=@ci";
                 cmd.Connection = cn;
                 cmd.Parameters.Add(new SqlParameter("@ci", CiBuscada));

                 //Todo pronto para ejecutar, se abre la conexión y se ejecuta.
                 cn.Open();
                 //La select devuelve una fila - o ninguna si no existe el coincidente - que obtenemos en un SqlDataReader
                 SqlDataReader readerUsuario = cmd.ExecuteReader();
                 //Leemos la fila activa -en este caso solo 1. El reader lee mediante el método Read() una sola fila por vez, 
                 //la carga y retorna true. Cuando llega al final e intenta leer una fila inexistente retorna false,
                 Usuario unUsuario = null;
                 if (readerUsuario.HasRows) //¿Hay una fila? La leemos
                 {
                     if (readerUsuario.Read()) //Si pusiera un while de todos modos sería uno, alcanza con un if
                     {
                         unUsuario = new Usuario
                         {
                             Ci = (int)readerUsuario["ci"],
                             Rol = readerUsuario["rol"].ToString(),
                             Pass = readerUsuario["pass"].ToString(),
                         };
                     }
                     //ya leyó todos y los cargó en la lista a retornar, ahora se puede cerrar la conexión
                     cn.Close();

                 }
                 return unUsuario;
             }
             //en cada excepción poner un punto de parada para inspeccionar la instancia de la excepción (en este caso ex)
             catch (Exception ex)
             {
                 //Si se produjo una excepción no hay datos para retornar
                 return null;
             }
         }

         public bool Remove(object Ci)
         {
             //El Id es un int, pero viene bajo "forma" de object, hay que hacer casting
             int CiBuscada = (int)Ci; //Si no era compatible con int se producirá excepción e irá al catch
             //Preparar la conexión
             SqlConnection cn = new SqlConnection(cadenaConexion);
             try
             {
                 //Preparar el comando incluyendo: la conexión, la consulta. No requiere parámetros.
                 SqlCommand cmd = new SqlCommand();
                 cmd.CommandText = "DELETE Usuario WHERE ci=@ci";
                 cmd.Connection = cn;
                 cmd.Parameters.Add(new SqlParameter("@ci", CiBuscada));

                 //Todo pronto para ejecutar, se abre la conexión y se ejecuta.
                 cn.Open();
                 //La select devuelve una fila - o ninguna si no existe el coincidente - que obtenemos en un SqlDataReader
                 int filasAfectadas = cmd.ExecuteNonQuery();
                 cn.Close();
                 return filasAfectadas == 1;

             }
             //en cada excepción poner un punto de parada para inspeccionar la instancia de la excepción (en este caso ex)
             catch (Exception ex)
             {
                 //Si se produjo una excepción no hay datos para retornar
                 return false; ;
             }
         }

         public bool Update(Usuario unObjeto)
         {
             //No seguir adelante si el parámetro es null
             if (unObjeto == null || !unObjeto.Validar()) return false;
             //Preparar la conexión
             SqlConnection cn = new SqlConnection(cadenaConexion);
             try
             {
                 //Preparar el comando incluyendo: la conexión, la consulta y si se requieren los parámetros.
                 SqlCommand cmd = new SqlCommand();
                 //El Id no se modifica, pero forma parte de la restricción (Where)
                 cmd.CommandText = "UPDATE Usuario SET pass=@pass, rol=@rol WHERE ci=@ci";
                 cmd.Connection = cn;
                 //Lo hice de la otra manera, me parecia que se escribe menos codigo, me queda la duda que de esta manera la ci no se puede modificar ya que es la clave.
                 //Agregamos una clave id? o dejamos la ci sin que se pueda modificar?
                 cmd.Parameters.AddWithValue("@pass", unObjeto.Pass);
                 cmd.Parameters.AddWithValue("@rol", unObjeto.Rol);
                 cmd.Parameters.AddWithValue("@ci", unObjeto.Ci);
                 //Todo pronto para ejecutar, se abre la conexión y se ejecuta.
                 cn.Open();
                 int filas = cmd.ExecuteNonQuery();
                 cn.Close();
                 return (filas == 1);

             }
             //en cada excepción poner un punto de parada para inspeccionar la instancia de la excepción (en este caso ex)
             catch (Exception ex)
             {
                 return false;
             }
         }*/
    }
}
