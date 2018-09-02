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
    public class MateriasController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Materias
        public IQueryable<Materia> GetMaterias()
        {
            return db.Materias;
        }

        // GET: api/Materias/5
        [ResponseType(typeof(Materia))]
        public async Task<IHttpActionResult> GetMateria(int id)
        {
            Materia materia = await db.Materias.FindAsync(id);
            if (materia == null)
            {
                return NotFound();
            }

            return Ok(materia);
        }

        // PUT: api/Materias/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMateria(int id, Materia materia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != materia.IdMateria)
            {
                return BadRequest();
            }

            db.Entry(materia).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MateriaExists(id))
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

        // POST: api/Materias
        [ResponseType(typeof(Materia))]
        public async Task<IHttpActionResult> PostMateria(Materia materia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Materias.Add(materia);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = materia.IdMateria }, materia);
        }

        // DELETE: api/Materias/5
        [ResponseType(typeof(Materia))]
        public async Task<IHttpActionResult> DeleteMateria(int id)
        {
            Materia materia = await db.Materias.FindAsync(id);
            if (materia == null)
            {
                return NotFound();
            }

            db.Materias.Remove(materia);
            await db.SaveChangesAsync();

            return Ok(materia);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MateriaExists(int id)
        {
            return db.Materias.Count(e => e.IdMateria == id) > 0;
        }
    }
}