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
    public class FacultadsController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Facultads
        public IQueryable<Facultad> GetFacultads()
        {
            return db.Facultads;
        }

        // GET: api/Facultads/5
        [ResponseType(typeof(Facultad))]
        public async Task<IHttpActionResult> GetFacultad(int id)
        {
            Facultad facultad = await db.Facultads.FindAsync(id);
            if (facultad == null)
            {
                return NotFound();
            }

            return Ok(facultad);
        }

        // PUT: api/Facultads/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutFacultad(int id, Facultad facultad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != facultad.IdFacultad)
            {
                return BadRequest();
            }

            db.Entry(facultad).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FacultadExists(id))
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

        // POST: api/Facultads
        [ResponseType(typeof(Facultad))]
        public async Task<IHttpActionResult> PostFacultad(Facultad facultad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Facultads.Add(facultad);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = facultad.IdFacultad }, facultad);
        }

        // DELETE: api/Facultads/5
        [ResponseType(typeof(Facultad))]
        public async Task<IHttpActionResult> DeleteFacultad(int id)
        {
            Facultad facultad = await db.Facultads.FindAsync(id);
            if (facultad == null)
            {
                return NotFound();
            }

            db.Facultads.Remove(facultad);
            await db.SaveChangesAsync();

            return Ok(facultad);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FacultadExists(int id)
        {
            return db.Facultads.Count(e => e.IdFacultad == id) > 0;
        }
    }
}