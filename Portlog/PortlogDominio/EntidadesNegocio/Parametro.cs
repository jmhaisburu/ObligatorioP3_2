using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortlogDominio.EntidadesNegocio
{
    public class Parametro
    {
        private string nombre;
        private int valor;

        public string Nombre { get => nombre; set => nombre = value; }
        public int Valor { get => valor; set => valor = value; }
    }
}
