using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PortlogDominio.EntidadesNegocio;
using Repositorios;

namespace PortlogWebApi.Controllers
{
    public class SalidasController : ApiController
    {
        RepositorioSalidas repoSalidas = new RepositorioSalidas();
        // GET: api/Salidas
        public IHttpActionResult Get()
        {
            var salidas = repoSalidas.FindAll();
            if (salidas == null)
                return NotFound();
            return Ok(salidas);
        }

        // GET: api/Salidas/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Salidas
        public IHttpActionResult Post([FromBody]Salida unaSalida)
        {
                if (unaSalida == null)
                    return BadRequest();
                if (repoSalidas.Add(unaSalida))
                {
                    return Ok(unaSalida);
                }
                return InternalServerError();
        }
       

        // PUT: api/Salidas/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Salidas/5
        public void Delete(int id)
        {
        }
    }
}
