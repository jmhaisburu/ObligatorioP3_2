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
        private PortlogContext db = new PortlogContext();

        public bool Add(Producto pro)
        {
            if (pro != null && !pro.Validar())
                return false;

            db.Productos.Add(pro);
            db.SaveChanges();
            return true;
        }

        public IEnumerable<Producto> FindAll()
        {
            return db.Productos.ToList();

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
