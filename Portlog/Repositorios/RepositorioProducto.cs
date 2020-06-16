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

            if (pro != null && pro.Validar())
            {
                Producto unPro = db.Productos.Find(pro.Codigo);
                if (unPro == null)
                {
                    Cliente cli = db.Clientes.Find(pro.Cliente.Rut);
                    pro.Cliente = cli;
                    db.Productos.Add(pro);
                    db.SaveChanges();
                    return true;
                }
                
            }
            return false;
        }

        public IEnumerable<Producto> FindAll()
        {
           // IEnumerable<Producto> productos = db.Productos.ToList();

            IEnumerable<Producto> productos = db.Productos
                                .Include("Cliente")
                                .ToList();

            return productos;

        }

        public Producto FindById(object codProd)
        {
            int codigo = (int)codProd;
            Producto pro = db.Productos.Find(codigo);
            return pro;
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
