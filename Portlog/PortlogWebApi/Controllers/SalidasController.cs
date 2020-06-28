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

        // GET: api/Salidas/5
        public string Get(int id)
        {
            return "value";
        }

       
        // POST: api/Salidas
        [HttpPost]        [Route("")]        public IHttpActionResult Post([FromBody] SalidaViewModel sal)        {            if (ModelState.IsValid)            {                Salida s = new Salida                {                    Id = sal.Id,                    Matricula = sal.Matricula,                    Direccion=sal.Direccion,                    FechaSalida=sal.FechaSalida,                    Importacion=sal.Importacion,                    Usuario=sal.Usuario                };                if (repoSalidas.Add(s))                {                    return (CreatedAtRoute("GetById", new { id = s.Id }, s));                }                else
                {                    return InternalServerError();                }            }            return (BadRequest(ModelState));        }              /*            Al utilzar Route Attributes para una de las rutas es necesario definirlo para todas, y se anula            el ruteo por convención.             El método PUT deja de hacer coincidir la ruta api/Articulos/5 con el método Put y lo mismo ocurre             con DELETE, obteniéndose


        // PUT: api/Salidas/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Salidas/5
        public void Delete(int id)
        {
        }*/
    }
}
