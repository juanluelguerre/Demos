using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Reto1Api.DataModel;

namespace Reto1Api.Controllers
{
    public class ModeladosController : ApiController
    {
        private Reto1DBEntities db = new Reto1DBEntities();

        // GET: api/Modeladoes
        public IQueryable<Modelado> GetModeladoes()
        {
            return db.Modeladoes;
        }

        // GET: api/Modeladoes/5
        [ResponseType(typeof(Modelado))]
        public IHttpActionResult GetModelado(int id)
        {
            Modelado modelado = db.Modeladoes.Find(id);
            if (modelado == null)
            {
                return NotFound();
            }

            return Ok(modelado);
        }


        // GET: api/Modeladoes/5
        [ResponseType(typeof(Modelado))]
        [HttpGet]
        [Route("api/Modelados/Codigo/{codigo}")]
        public IHttpActionResult FindByCodigo(string codigo)
        {
            Modelado modelado = db.Modeladoes.Where(c => c.Codigo.Equals(codigo, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            if (modelado == null)
            {
                return NotFound();
            }

            return Ok(modelado);
        }

        // PUT: api/Modeladoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutModelado(int id, Modelado modelado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != modelado.Id)
            {
                return BadRequest();
            }

            db.Entry(modelado).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModeladoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Modeladoes
        [ResponseType(typeof(Modelado))]
        public IHttpActionResult PostModelado(Modelado modelado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Modeladoes.Add(modelado);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                if (ModeladoExists(modelado.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = modelado.Id }, modelado);
        }

        // DELETE: api/Modeladoes/5
        [ResponseType(typeof(Modelado))]
        public IHttpActionResult DeleteModelado(int id)
        {
            Modelado modelado = db.Modeladoes.Find(id);
            if (modelado == null)
            {
                return NotFound();
            }

            db.Modeladoes.Remove(modelado);
            db.SaveChanges();

            return Ok(modelado);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ModeladoExists(int id)
        {
            return db.Modeladoes.Count(e => e.Id == id) > 0;
        }
    }
}