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

        // GET: api/Importacion/5
        public string Get(int id)
        {
            return "value";
        }

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
