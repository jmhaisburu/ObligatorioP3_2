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
    public class RepositorioImportacion : IRepositorio<Importacion>
    {
        private PortlogContext db = new PortlogContext();
        /*
        private string cadenaConexion = ConfigurationManager.ConnectionStrings["miConexion"].ConnectionString;
        public bool Add(Importacion unaImpo)
        {
            if (unaImpo == null) { return false; } // validar impo? hacer un metodo en impo de validacion
               SqlConnection cn = new SqlConnection(cadenaConexion);
            try {
                SqlParameter paramfechaIngreso = new SqlParameter("@fechaIngreso", unaImpo.FechaIngreso);
                SqlParameter paramsalidaPrevista = new SqlParameter("@salidaPrevista", unaImpo.SalidaPrevista);
                SqlParameter paramcodProducto = new SqlParameter("@codProducto", unaImpo.Producto.Codigo);
                SqlParameter paramdestino = new SqlParameter("@destino", unaImpo.Destino); 
                SqlParameter paramcantidad = new SqlParameter("@cantidad", unaImpo.Cantidad);
                SqlParameter paramprecioUnitario = new SqlParameter("@precioUnitario", unaImpo.PrecioUnitario);
                unaImpo.CalcularPrecio();
                SqlParameter paramprecioFinal = new SqlParameter("@precioFinal", unaImpo.PrecioFinal);// vamos a tener q hacer un metodo para calcular el precio creo
                SqlParameter paramenDeposito = new SqlParameter("@enDeposito", unaImpo.EnDeposito);
                string cadenaComando = "insert into importacion values (@fechaIngreso, @salidaPrevista,@codProducto,@destino, @cantidad,@precioUnitario, @precioFinal, @enDeposito)"; // agregar destino si lo ponemos

                SqlCommand cmd = new SqlCommand(cadenaComando, cn);
                cmd.Parameters.Add(paramfechaIngreso);
                cmd.Parameters.Add(paramsalidaPrevista);
                cmd.Parameters.Add(paramcodProducto);
                cmd.Parameters.Add(paramdestino);
                cmd.Parameters.Add(paramcantidad);
                cmd.Parameters.Add(paramprecioUnitario);
                cmd.Parameters.Add(paramprecioFinal);
                cmd.Parameters.Add(paramenDeposito);


                cn.Open();

                int filasAfectadas = cmd.ExecuteNonQuery();

                cn.Close();

                return (filasAfectadas == 1);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IEnumerable<Importacion> FindAll()
        {
            throw new NotImplementedException();
        }

        public Importacion FindById(object Id)
        {
            int idBuscado = (int)Id;
            
            SqlConnection cn = new SqlConnection(cadenaConexion);
            try
            {

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT * FROM Importacion WHERE id=@id";
                cmd.Connection = cn;
                cmd.Parameters.Add(new SqlParameter("@id", idBuscado));


                cn.Open();

                SqlDataReader readerImportacion = cmd.ExecuteReader();


                Importacion tmpImpo = null;

                if (readerImportacion.HasRows)
                {
                    if (readerImportacion.Read())
                    {
                        RepositorioProducto repoProd = new RepositorioProducto();

                        bool enDepo = false;
                        if ((bool)readerImportacion["enDeposito"])
                        {
                            enDepo = true;
                        }

                        tmpImpo = new Importacion
                        {
                            FechaIngreso =(DateTime) readerImportacion["fechaIngreso"],
                            SalidaPrevista = (DateTime)readerImportacion["salidaPrevista"],
                            Producto = repoProd.FindById((int)readerImportacion["codProducto"]),
                            Destino = readerImportacion["destino"].ToString(),
                            Cantidad = (int)readerImportacion["cantidad"],
                            PrecioUnitario = (decimal)readerImportacion["precioUnitario"],
                            EnDeposito = enDepo,                        
                        };
                    }
                    //ya leyó todos y los cargó en la lista a retornar, ahora se puede cerrar la conexión
                    cn.Close();

                }
                return tmpImpo;
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

        public bool Update(Importacion unObjeto)
        {
            throw new NotImplementedException();
        }

        int ObtenerAntiguedadMin()
        {
            RepositorioParametros repoParam = new RepositorioParametros();
            int antiguedadmin = repoParam.FindById("antiguedadmin").Valor;
            return antiguedadmin;

        }

        int ObtenerTasaGanancia()
        {
            RepositorioParametros repoParam = new RepositorioParametros();
            int tasaGanancia = repoParam.FindById("tasaganancia").Valor;
            return tasaGanancia;

        }
        int ObtenerDescuentoxAntiguedad()
        {
            RepositorioParametros repoParam = new RepositorioParametros();
            int descuentoxantiguedad = repoParam.FindById("descuentoxantiguedad").Valor;
            return descuentoxantiguedad;

        }

        public decimal CalcularGanancia(int idImportacion)
        {
            Importacion unaImpo = FindById(idImportacion);
            decimal ganancia = unaImpo.CalcularPrevisionGanancia(ObtenerTasaGanancia(), ObtenerDescuentoxAntiguedad(), ObtenerAntiguedadMin());
            return ganancia;
        }

  
  */
        public bool Add(Importacion imp)
        {
            Importacion unaImp = db.Importaciones.Find(imp.IdImp);
            if (unaImp == null)
            {
                if (imp != null && imp.Validar())
                {

                    Producto pro = db.Productos.Find(imp.Producto.Codigo);
                    imp.Producto = pro;
                    db.Importaciones.Add(imp);
                    db.SaveChanges();
                    return true;
                }
            }
                return false;
        }

        public IEnumerable<Importacion> FindAll()
        {
            return db.Importaciones.ToList();
        }

        public Importacion FindById(object Id)
        {
            throw new NotImplementedException();
        }

        public bool Remove(object Id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Importacion unObjeto)
        {
            throw new NotImplementedException();
        }
    }
}
