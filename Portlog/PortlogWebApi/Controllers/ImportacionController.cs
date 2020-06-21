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
      
        // GET: api/Importacion
        public IHttpActionResult Get()
        {
            IEnumerable<Importacion> lasImportaciones = repoImportacion.FindAll();
            if (lasImportaciones == null)
                return NotFound();
            else
                return Ok(lasImportaciones);            
        }

        // GET: api/Importacion/5
        public string Get(int id)
        {
            return "value";
        }


        //filtro por codigo de producto
        [Route("{codpro}")]  // parámetro sin restricción
        public IHttpActionResult GetByProd(int codpro)
        {
            IEnumerable<Importacion> lasImportaciones = repoImportacion.FindByProducto(codpro);
            if (lasImportaciones == null)
                return NotFound();
            else
                return Ok(lasImportaciones);
        }

        //- Texto que forma parte del nombre del producto importado. 
        public IHttpActionResult GetByProductoNombre(string nombre)
        {
            IEnumerable<Importacion> lasImportaciones = repoImportacion.FindByProductoNombre(nombre);
            if (lasImportaciones == null)
                return NotFound();
            else
                return Ok(lasImportaciones);
        }


        /*
         [Route("api/clientes")]
        [HttpPost]
        public HttpResponseMessage CrearCliente(Cliente cli) 
	    { ... }
         */
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
        }
    }
}
