using PortlogDominio.EntidadesNegocio;
using Repositorios;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesArchivos
{
    public class LeerArchivo
    {
        #region Cliente
        public static IEnumerable<Cliente> LeerClienteDesdeArchivo(string carpeta, string archivo, string delimitador)
        {
            RepositorioCliente repoCli = new RepositorioCliente();
            //lee del archivo delimitado y los almacena en una lista de clientes.
            string ruta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, carpeta, archivo);
            List<Cliente> lista = new List<Cliente>();
            try
            {
                using (StreamReader sr = new StreamReader(ruta))
                {
                    string linea = sr.ReadLine();
                    while (linea != null)
                    {
                        Cliente cli = LeerCliente(linea, delimitador);
                        if (cli != null && cli.Validar() && !repoCli.FindAll().Contains(cli)) // 
                        {
                            repoCli.Add(cli);
                        }
                        linea = sr.ReadLine();
                    }
                }
                return lista;
            }
            catch (FileNotFoundException ex)
            {
                return null;
            }

        }

        private static Cliente LeerCliente(string linea, string delimitador)
        {
            RepositorioCliente repoCli = new RepositorioCliente();
            const int CANT_ATRIBUTOS = 2;
            if (!String.IsNullOrEmpty(linea) && !string.IsNullOrEmpty(delimitador))
            {
                string[] vector = linea.Split(delimitador.ToCharArray());
                if (vector.Length == CANT_ATRIBUTOS)
                {

                    Cliente cli = new Cliente
                    {
                        Rut = vector[0],
                        Nombre = vector[1],

                    };


                    return cli;
                }
            }
            return null;//hay algún error, no se obtiene un cliente. Aquí lo ideal sería grabar en un archivo de log de errores
        }
        #endregion
        #region Producto
        public static IEnumerable<Producto> LeerProductoDesdeArchivo(string carpeta, string archivo, string delimitador)
        {
            RepositorioProducto repoPro = new RepositorioProducto();
            //lee del archivo delimitado y los almacena en una lista de clientes.
            string ruta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, carpeta, archivo);
            List<Producto> lista = new List<Producto>();
            try
            {
                using (StreamReader sr = new StreamReader(ruta))
                {
                    string linea = sr.ReadLine();
                    while (linea != null)
                    {
                        Producto pro = LeerProducto(linea, delimitador);
                        if (pro != null && pro.Validar() && !repoPro.FindAll().Contains(pro)) // 
                        {
                            repoPro.Add(pro);
                        }
                        linea = sr.ReadLine();
                    }
                }
                return lista;
            }
            catch (FileNotFoundException ex)
            {
                return null;
            }

        }

        private static Producto LeerProducto(string linea, string delimitador)
        {
            RepositorioCliente repoCli = new RepositorioCliente();
            const int CANT_ATRIBUTOS = 4;
            if (!String.IsNullOrEmpty(linea) && !string.IsNullOrEmpty(delimitador))
            {
                string[] vector = linea.Split(delimitador.ToCharArray());
                if (vector.Length == CANT_ATRIBUTOS)
                {

                   // Cliente cli = new Cliente();
                   Cliente cli = repoCli.FindById(vector[3]);

                    Producto pro = new Producto
                    {
                        Codigo = int.Parse(vector[0]),
                        Nombre = vector[1],
                        Peso = decimal.Parse(vector[2]),
                        Cliente = cli
                    };


                    return pro;
                }
            }
            return null;//hay algún error, no se obtiene un cliente. Aquí lo ideal sería grabar en un archivo de log de errores
        }
        #endregion
        
    
    }
}
