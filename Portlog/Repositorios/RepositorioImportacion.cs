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
            return db.Importaciones.

                Include("Producto.Cliente").
                ToList();
        }

        public IEnumerable<Importacion> FindByProducto(int codpro)
        {

            return db.Importaciones.Include("Producto.Cliente").
                Where(i => i.Producto.Codigo == codpro).ToList();
        }

        //- Texto que forma parte del nombre del producto importado.
        public IEnumerable<Importacion> FindByProductoNombre(string nombre)
        {
            return db.Importaciones.Include("Producto.Cliente").
                Where(i => i.Producto.Nombre.Contains(nombre)).ToList();
        }

        //RUT del cliente que puede importar el producto de la importación. 
        public IEnumerable<Importacion> FindByRutCliente(string rut)
        {
            return db.Importaciones.Include("Producto.Cliente").
                Where(i => i.Producto.Cliente.Rut.Equals(rut)).ToList();
        }
        //- Importaciones cuya fecha prevista de salida supera la fecha del día y aun no salieron de depósito. 
        public IEnumerable<Importacion> FindSinSalir()
        {

            /* DateTime hoy = DateTime.Today;
             return db.Importaciones.
            Include("Producto.Cliente")
            .Where(i => i.SalidaPrevista > hoy).ToList();
             }*/
            DateTime hoy = DateTime.Today;
            IEnumerable<Importacion> importaciones = db.Importaciones.
            Include("Producto.Cliente")
            .Where(i => i.SalidaPrevista > hoy).ToList();
            IEnumerable<Salida> lasSalidas = db.Salidas.Include("Importacion").ToList();
            if (lasSalidas != null)
            {
                return importaciones.Where(i => !lasSalidas.Any(s => i.IdImp == s.Importacion.IdImp));
            }
            else
            {
                return importaciones;
            }
        }

        public Importacion FindById(int Id)
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
