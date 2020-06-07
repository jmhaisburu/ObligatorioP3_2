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
        #region Usuario
        public static IEnumerable<Usuario> LeerUsuarioDesdeArchivo(string carpeta, string archivo, string delimitador)
        {
            RepositorioUsuario repoUsu = new RepositorioUsuario();
            //lee del archivo delimitado y los almacena en una lista de clientes.
            string ruta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, carpeta, archivo);
            List<Usuario> lista = new List<Usuario>();
            try
            {
                using (StreamReader sr = new StreamReader(ruta))
                {
                    string linea = sr.ReadLine();
                    while (linea != null)
                    {
                        Usuario usu = LeerUsuario(linea, delimitador);
                        if (usu != null && usu.Validar() && !repoUsu.FindAll().Contains(usu)) // 
                        {
                            repoUsu.Add(usu);
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

        private static Usuario LeerUsuario(string linea, string delimitador)
        {
            RepositorioUsuario repoUsu = new RepositorioUsuario();
            const int CANT_ATRIBUTOS = 3;
            if (!String.IsNullOrEmpty(linea) && !string.IsNullOrEmpty(delimitador))
            {
                string[] vector = linea.Split(delimitador.ToCharArray());
                if (vector.Length == CANT_ATRIBUTOS)
                {
                                       
                    Usuario usu = new Usuario
                    {
                        Ci = vector[0],
                        Pass = vector[1],
                        Rol = vector[2]
                        
                    };


                    return usu;
                }
            }
            return null;//hay algún error, no se obtiene un cliente. Aquí lo ideal sería grabar en un archivo de log de errores
        }
        #endregion
        #region Parametro
        public static IEnumerable<Parametro> LeerParametroDesdeArchivo(string carpeta, string archivo, string delimitador)
        {
            RepositorioParametros repoParam = new RepositorioParametros();
            //lee del archivo delimitado y los almacena en una lista de clientes.
            string ruta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, carpeta, archivo);
            List<Parametro> lista = new List<Parametro>();
            try
            {
                using (StreamReader sr = new StreamReader(ruta))
                {
                    string linea = sr.ReadLine();
                    while (linea != null)
                    {
                        Parametro param = LeerParametro(linea, delimitador);
                        if (param != null && param.Validar() && !repoParam.FindAll().Contains(param)) // 
                        {
                            repoParam.Add(param);
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

        private static Parametro LeerParametro(string linea, string delimitador)
        {
            RepositorioParametros repoParam = new RepositorioParametros();
            const int CANT_ATRIBUTOS = 2;
            if (!String.IsNullOrEmpty(linea) && !string.IsNullOrEmpty(delimitador))
            {
                string[] vector = linea.Split(delimitador.ToCharArray());
                if (vector.Length == CANT_ATRIBUTOS)
                {

                    Parametro param = new Parametro
                    {
                        Nombre = vector[0],
                        Valor = int.Parse(vector[1])
                        

                    };


                    return param;
                }
            }
            return null;//hay algún error, no se obtiene un cliente. Aquí lo ideal sería grabar en un archivo de log de errores
        }
        #endregion
        #region Importacion
        public static IEnumerable<Importacion> LeerImportacionDesdeArchivo(string carpeta, string archivo, string delimitador)
        {
            RepositorioImportacion repoImp = new RepositorioImportacion();
            //lee del archivo delimitado y los almacena en una lista de clientes.
            string ruta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, carpeta, archivo);
            List<Importacion> lista = new List<Importacion>();
            try
            {
                using (StreamReader sr = new StreamReader(ruta))
                {
                    string linea = sr.ReadLine();
                    while (linea != null)
                    {
                        Importacion imp = LeerImportacion(linea, delimitador);
                        if (imp != null && imp.Validar() && !repoImp.FindAll().Contains(imp)) // 
                        {
                            repoImp.Add(imp);
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

        private static Importacion LeerImportacion(string linea, string delimitador)
        {
           
            RepositorioProducto repoPro = new RepositorioProducto();
            const int CANT_ATRIBUTOS = 5;
            if (!String.IsNullOrEmpty(linea) && !string.IsNullOrEmpty(delimitador))
            {
                string[] vector = linea.Split(delimitador.ToCharArray());
                if (vector.Length == CANT_ATRIBUTOS)
                {
                    Producto pro = new Producto();
                    pro = repoPro.FindById(int.Parse(vector[3]));
                    Importacion imp = new Importacion
                    {
                        Id = int.Parse(vector[0]),
                        FechaIngreso = DateTime.Parse(vector[1]),
                        SalidaPrevista = DateTime.Parse(vector[2]),
                        Producto = pro,
                        Cantidad = int.Parse(vector[4])
                    };
                

                    return imp;
                }
            }
            return null;//hay algún error, no se obtiene un cliente. Aquí lo ideal sería grabar en un archivo de log de errores
        }
        #endregion

    }
}
