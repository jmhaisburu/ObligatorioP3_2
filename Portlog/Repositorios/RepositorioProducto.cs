using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using PortlogDominio.EntidadesNegocio;
using PortlogDominio.InterfacesRepositorios;
using System.Data;
using System.Data.SqlClient;

namespace Repositorios
{

    public class RepositorioProducto : IRepositorio<Producto>
    {
        private string cadenaConexion = ConfigurationManager.ConnectionStrings["miConexion"].ConnectionString;
        public bool Add(Producto unObjeto)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Producto> FindAll()
        {
            throw new NotImplementedException();

            // esto se hace aca? nos pide listar todos los productos, pero tambien con las unidades en stock
            //las unidades se registran en la importacion o , como las traemos? habria q hacer una sentencia con un join de la tabla de importaciones?
            //o aca se hace el findAll comun y en el servicio wcf se saca la info de los dos findall de producto y de importacion.
            /* SqlConnection cn = new SqlConnection(cadenaConexion);
             try
             {
                 SqlCommand cmd = new SqlCommand();
                 cmd.CommandText = "select * from producto";
                 cmd.Connection = cn;
                 cn.Open();
                 SqlDataReader readerProducto = cmd.ExecuteReader();
                 if (readerProducto.HasRows)
                 {
                     List<Producto> losProductos = new List<Producto>();
                     while (readerProducto.Read())
                     {
                         losProductos.Add(new Producto
                         {
                             Codigo=(int)readerProducto["codigo"],
                             Nombre=readerProducto["nombre"].ToString(),
                             

                         }
                     }
                 }
             }
             catch(Exception ex)
             {
                 return false;
             }*/
            /* }

             public Producto FindById(object codigo)
             {

                 int codigoBuscado = (int)codigo;

                 SqlConnection cn = new SqlConnection(cadenaConexion);
                 try
                 {

                     SqlCommand cmd = new SqlCommand();

                     cmd.CommandText = "SELECT PRODUCTO.CODIGO, PRODUCTO.NOMBRE, PRODUCTO.PESO ,PRODUCTO.rutCliente, SUM(IMPORTACION.cantidad) AS 'STOCK'";
                     cmd.CommandText += " FROM PRODUCTO left join IMPORTACION ";
                     cmd.CommandText += " on PRODUCTO.CODIGO = IMPORTACION.codProducto ";
                     cmd.CommandText +=" WHERE producto.codigo=@codigo";
                     cmd.CommandText += " GROUP BY PRODUCTO.CODIGO, PRODUCTO.NOMBRE, PRODUCTO.PESO,PRODUCTO.rutCliente;";


                     //cmd.CommandText = "SELECT * FROM Producto WHERE codigo=@codigo";
                     cmd.Connection = cn;
                     cmd.Parameters.Add(new SqlParameter("@codigo", codigoBuscado));


                     cn.Open();

                     SqlDataReader readerProducto = cmd.ExecuteReader();


                     Producto tmpProducto = null;

                     if (readerProducto.HasRows)
                     {
                         if (readerProducto.Read())
                         {
                             RepositorioCliente repoCli = new RepositorioCliente();

                             int stock = 0;
                             if (!readerProducto.IsDBNull(4))
                             {
                                 stock = (int)readerProducto["STOCK"];
                             }

                             tmpProducto = new Producto
                             {
                                 Codigo = (int)readerProducto["codigo"],
                                 Nombre = readerProducto["Nombre"].ToString(),
                                 Peso = (decimal)readerProducto["Peso"],
                                 Cliente = repoCli.FindById(readerProducto["rutCliente"].ToString()),
                                 Stock = stock
                             };
                         }
                         //ya leyó todos y los cargó en la lista a retornar, ahora se puede cerrar la conexión
                         cn.Close();

                     }
                     return tmpProducto;
                 }
                 //en cada excepción poner un punto de parada para inspeccionar la instancia de la excepción (en este caso ex)
                 catch (Exception ex)
                 {
                     //Si se produjo una excepción no hay datos para retornar
                     return null;
                 }
             }

             public bool Remove(object Id)
             {
                 throw new NotImplementedException();
             }

             public bool Update(Producto unObjeto)
             {
                 throw new NotImplementedException();
             }

             //IEnumerable<Cliente> FindAll
             public IEnumerable<Producto> StockProductos()
             {
                 SqlConnection cn = new SqlConnection(cadenaConexion);
                 try
                 {
                     SqlCommand cmd = new SqlCommand();
                     cmd.CommandText = "SELECT PRODUCTO.CODIGO, PRODUCTO.NOMBRE, PRODUCTO.PESO ,PRODUCTO.rutCliente, SUM(IMPORTACION.cantidad) AS 'STOCK'";
                     cmd.CommandText += " FROM PRODUCTO LEFT JOIN IMPORTACION ";
                     cmd.CommandText += " ON PRODUCTO.CODIGO = IMPORTACION.codProducto ";
                     cmd.CommandText += " GROUP BY PRODUCTO.CODIGO, PRODUCTO.NOMBRE, PRODUCTO.PESO,PRODUCTO.rutCliente ";
                     cmd.CommandText += " ORDER BY SUM(IMPORTACION.cantidad) DESC"; 


                     cmd.Connection = cn;
                     cn.Open();
                     SqlDataReader readerProducto = cmd.ExecuteReader();

                     Producto tmpProducto = null;
                     if (readerProducto.HasRows)
                     {
                         List<Producto> losProductos = new List<Producto>();
                         while (readerProducto.Read())
                         {
                             RepositorioCliente repoCli = new RepositorioCliente();
                             int stock = 0;

                             if(!readerProducto.IsDBNull(4))
                             {
                                stock = (int)readerProducto["STOCK"]; 
                             }

                                 tmpProducto = new Producto
                             {
                                 Codigo = (int)readerProducto["codigo"],
                                 Nombre = readerProducto["nombre"].ToString(),
                                 Peso = (decimal)readerProducto["peso"],
                                 Cliente = repoCli.FindById((readerProducto["rutCliente"])),
                                 Stock =stock
                                 };

                             losProductos.Add(tmpProducto);
                         }
                         //ya leyó todos y los cargó en la lista a retornar, ahora se puede cerrar la conexión
                         cn.Close();
                         return losProductos;

                     }
                     else
                     {
                         return null;
                     }
                 }
                 catch (Exception ex)
                 {

                     return null;
                 }*/
        }

        public Producto FindById(object Id)
        {
            throw new NotImplementedException();
        }

        public bool Remove(object Id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Producto unObjeto)
        {
            throw new NotImplementedException();
        }
    }

}
