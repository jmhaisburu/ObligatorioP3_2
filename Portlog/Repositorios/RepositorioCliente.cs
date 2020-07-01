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

        public bool Add(Cliente cli)
        {

            if (cli != null && cli.Validar())
            {
                Cliente unCli = db.Clientes.Find(cli.Rut);

                if (unCli == null)
                {
                    db.Clientes.Add(cli);
                    db.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public IEnumerable<Cliente> FindAll()
        {
            return db.Clientes.ToList();
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

   

        

        
    }
}
