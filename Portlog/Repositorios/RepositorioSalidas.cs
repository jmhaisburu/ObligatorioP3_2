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
    public class RepositorioSalidas : IRepositorio<Salida>
    {
        public bool Add(Salida unObjeto)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Salida> FindAll()
        {
            throw new NotImplementedException();
        }

        public Salida FindById(object Id)
        {
            throw new NotImplementedException();
        }

        public bool Remove(object Id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Salida unObjeto)
        {
            throw new NotImplementedException();
        }
    }
}
