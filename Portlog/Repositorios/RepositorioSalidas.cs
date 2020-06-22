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
        private PortlogContext db = new PortlogContext();
        public bool Add(Salida sal)
        {
           if (sal != null && sal.Validar())
            {
                Salida unaSal = db.Salidas.Find(sal.Id);
                if (unaSal == null)
                {
                    Importacion imp = db.Importaciones.Find(sal.Importacion.IdImp);
                    if (imp != null)
                    {
                        sal.Importacion = imp;
                        Usuario cli = db.Usuarios.Find(sal.Usuario.Ci);
                        if (cli != null)
                        {
                            sal.Usuario = cli;
                            db.Salidas.Add(sal);
                            db.SaveChanges();
                            return true;
                        }                        
                    }
                }

            }
            return false;
        }

        public IEnumerable<Salida> FindAll()
        {
            IEnumerable<Salida> salidas = db.Salidas
                             .Include("Importacion")
                             .ToList();

            return salidas;
        }

        public Salida FindById(object Id)
        {
            int idSalida = (int)Id;
            Salida sal = db.Salidas.Find(idSalida);
            return sal;
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
