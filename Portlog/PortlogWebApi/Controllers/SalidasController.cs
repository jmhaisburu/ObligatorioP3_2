using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PortlogDominio.EntidadesNegocio;
using Repositorios;
using PortlogMVC.Models;

namespace PortlogWebApi.Controllers
{
    [RoutePrefix("api/Salidas")]
    public class SalidasController : ApiController
    {
        
        RepositorioSalidas repoSalidas = new RepositorioSalidas();
        // GET: api/Salidas
        [Route("")]
        public IHttpActionResult Get()
        {
            var salidas = repoSalidas.FindAll();
            if (salidas == null)
                return NotFound();
            return Ok(salidas);
        }

       

       
        // POST: api/Salidas
        [HttpPost]
        [Route("")]
        public IHttpActionResult Post([FromBody] SalidaViewModel sal)
        {
            
            if (sal!=null)
            {
                Salida s = new Salida
                {
                    Id = sal.Id,
                    Matricula = sal.Matricula,
                    Direccion=sal.Direccion,
                    FechaSalida=sal.FechaSalida,
                    Importacion=sal.Importacion,
                    Usuario=sal.Usuario
                };

                if (repoSalidas.Add(s))
                {
                    return Ok(s);
                }
                else
                {
                    return InternalServerError();
                }

            }
            return (BadRequest(ModelState));
        }

      
       
    }
}
