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
    public class RepositorioCliente : IRepositorio<Cliente>
    {
        private PortlogContext db = new PortlogContext();

        public bool Add(Cliente unObjeto)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cliente> FindAll()
        {
            throw new NotImplementedException();
        }

        public Cliente FindById(object Id)
        {
            String rut = (string)Id;

            Cliente cli = db.Clientes.Find(rut);

            return cli;
        }

        public bool Remove(object Id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Cliente unObjeto)
        {
            throw new NotImplementedException();
        }

        public Cliente FindById()
        {
            throw new NotImplementedException();
        }

        /*
                public bool Add(Cliente unObjeto)
                {
                    throw new NotImplementedException();
                }

                public Cliente FindById(object Rut)
                {
                    //El Id es un int, pero viene bajo "forma" de object, hay que hacer casting
                    string rutBuscado = (string)Rut; //Si no era compatible con int se producirá excepción e irá al catch
                    //Preparar la conexión
                    SqlConnection cn = new SqlConnection(cadenaConexion);
                    try
                    {
                        //Preparar el comando incluyendo: la conexión, la consulta. No requiere parámetros.
                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandText = "SELECT * FROM Cliente WHERE rut=@rut";
                        cmd.Connection = cn;
                        cmd.Parameters.Add(new SqlParameter("@rut", rutBuscado));

                        //Todo pronto para ejecutar, se abre la conexión y se ejecuta.
                        cn.Open();
                        //La select devuelve una fila - o ninguna si no existe el coincidente - que obtenemos en un SqlDataReader
                        SqlDataReader readerCliente = cmd.ExecuteReader();
                        //Leemos la fila activa -en este caso solo 1. El reader lee mediante el método Read() una sola fila por vez, 
                        //la carga y retorna true. Cuando llega al final e intenta leer una fila inexistente retorna false,
                        Cliente tmpCliente = null;
                        if (readerCliente.HasRows) //¿Hay una fila? La leemos
                        {
                            if (readerCliente.Read()) //Si pusiera un while de todos modos sería uno, alcanza con un if
                            {
                                tmpCliente = new Cliente
                                {
                                    FechaAlta = (DateTime)readerCliente["fechaAlta"],
                                    Rut =(string)readerCliente["rut"],
                                };
                            }
                            //ya leyó todos y los cargó en la lista a retornar, ahora se puede cerrar la conexión
                            cn.Close();

                        }
                        return tmpCliente;
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



                public bool Update(Cliente unObjeto)
                {
                    throw new NotImplementedException();
                }

                IEnumerable<Cliente> IRepositorio<Cliente>.FindAll()
                {
                    throw new NotImplementedException();
                }
            }*/
    }
}
