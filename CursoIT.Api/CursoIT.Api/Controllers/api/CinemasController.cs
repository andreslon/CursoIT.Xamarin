using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using CursoIT.Api.Models;

namespace CursoIT.Api.Controllers.api
{
    public class CinemasController : ApiController
    {
        private itxamarindatabaseEntities db = new itxamarindatabaseEntities();

        // GET: api/Cinemas
        public IQueryable<Cinemas> GetCinemas()
        {
            return db.Cinemas;
        }

        // GET: api/Cinemas/5
        [ResponseType(typeof(Cinemas))]
        public async Task<IHttpActionResult> GetCinemas(int id)
        {
            Cinemas cinemas = await db.Cinemas.FindAsync(id);
            if (cinemas == null)
            {
                return NotFound();
            }

            return Ok(cinemas);
        }

        // PUT: api/Cinemas/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCinemas(int id, Cinemas cinemas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cinemas.id)
            {
                return BadRequest();
            }

            db.Entry(cinemas).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CinemasExists(id))
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

        // POST: api/Cinemas
        [ResponseType(typeof(Cinemas))]
        public async Task<IHttpActionResult> PostCinemas(Cinemas cinemas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Cinemas.Add(cinemas);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = cinemas.id }, cinemas);
        }

        // DELETE: api/Cinemas/5
        [ResponseType(typeof(Cinemas))]
        public async Task<IHttpActionResult> DeleteCinemas(int id)
        {
            Cinemas cinemas = await db.Cinemas.FindAsync(id);
            if (cinemas == null)
            {
                return NotFound();
            }

            db.Cinemas.Remove(cinemas);
            await db.SaveChangesAsync();

            return Ok(cinemas);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CinemasExists(int id)
        {
            return db.Cinemas.Count(e => e.id == id) > 0;
        }
    }
}