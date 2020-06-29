using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Repositorios;
using PortlogDominio.EntidadesNegocio;

namespace PortlogWebApi.Controllers
{
    
    public class ImportacionController : ApiController
    {
        private RepositorioImportacion repoImportacion = new RepositorioImportacion();

        // GET: api/Importacion
        public IHttpActionResult Get()
        {
            IEnumerable<Importacion> lasImportaciones = repoImportacion.FindAll();
            if (lasImportaciones == null)
                return NotFound();
            else
                return Ok(lasImportaciones);
        }
               

        //filtro por codigo de producto
        [Route("api/importacion/porCodigoProducto/{codpro:int}")]  // parámetro sin restricción
        public IHttpActionResult GetByProd(int codpro)
        {
            IEnumerable<Importacion> lasImportaciones = repoImportacion.FindByProducto(codpro);
            if (lasImportaciones == null)
                return NotFound();
            else
                return Ok(lasImportaciones);
        }

        //- Texto que forma parte del nombre del producto importado. 
        [Route("api/importacion/porNombreProducto/{nombre}")]
        public IHttpActionResult GetByProductoNombre(string nombre)
        {
            IEnumerable<Importacion> lasImportaciones = repoImportacion.FindByProductoNombre(nombre);
            if (lasImportaciones == null)
                return NotFound();
            else
                return Ok(lasImportaciones);
        }

        [Route("api/importacion/porRutCliente/{rut}")]
        public IHttpActionResult GetByRutCliente(string rut)
        {
            IEnumerable<Importacion> lasImportaciones = repoImportacion.FindByRutCliente(rut);
            if (lasImportaciones == null)
                return NotFound();
            else
                return Ok(lasImportaciones);
        }
        //Importaciones cuya fecha prevista de salida ES MENOR QUE la fecha del día y aun no salieron de depósito
        [Route("api/importacion/sinSalir")]
        public IHttpActionResult GetBySinSalir()
        {
            IEnumerable<Importacion> lasImportaciones = repoImportacion.FindSinSalir();
            if (lasImportaciones == null)
                return NotFound();
            else
                return Ok(lasImportaciones);
        }


        /*
          // GET: api/Importacion/5
        public string Get(int id)
        {
            return "value";
        }

        [Route("api/clientes")]
        [HttpPost]
        public HttpResponseMessage CrearCliente(Cliente cli) 
	    { ... }
         
        // POST: api/Importacion
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Importacion/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Importacion/5
        public void Delete(int id)
        {
        }*/
    }
}
