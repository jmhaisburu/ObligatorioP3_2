using PortlogDominio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Repositorios
{
    public class PortlogContext:DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Importacion> Importaciones{ get; set; }
        public DbSet<Salida> Salidas { get; set; }
        

        public PortlogContext() : base("conexionPortlog2")
        {

        }
    }
   
}
