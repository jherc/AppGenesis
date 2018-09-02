namespace AppGenesis.API.Controllers
{
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
    using AppGenesis.Domain;

    [Authorize]
    public class NotasController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Notas
        public IQueryable<Nota> GetNotas()
        {
            return db.Notas;
        }

        // GET: api/Notas/5
        [ResponseType(typeof(Nota))]
        public async Task<IHttpActionResult> GetNota(int id)
        {
            Nota nota = await db.Notas.FindAsync(id);
            if (nota == null)
            {
                return NotFound();
            }

            return Ok(nota);
        }

        // PUT: api/Notas/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutNota(int id, Nota nota)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != nota.IdNota)
            {
                return BadRequest();
            }

            db.Entry(nota).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NotaExists(id))
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

        // POST: api/Notas
        [ResponseType(typeof(Nota))]
        public async Task<IHttpActionResult> PostNota(Nota nota)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Notas.Add(nota);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = nota.IdNota }, nota);
        }

        // DELETE: api/Notas/5
        [ResponseType(typeof(Nota))]
        public async Task<IHttpActionResult> DeleteNota(int id)
        {
            Nota nota = await db.Notas.FindAsync(id);
            if (nota == null)
            {
                return NotFound();
            }

            db.Notas.Remove(nota);
            await db.SaveChangesAsync();

            return Ok(nota);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NotaExists(int id)
        {
            return db.Notas.Count(e => e.IdNota == id) > 0;
        }
    }
}