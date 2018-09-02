namespace AppGenesis.Backend.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Entity;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Net;
    using System.Web;
    using System.Web.Mvc;
    using AppGenesis.Domain;

    [Authorize]
    public class FacultadsController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Facultads
        public async Task<ActionResult> Index()
        {
            return View(await db.Facultads.ToListAsync());
        }

        // GET: Facultads/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Facultad facultad = await db.Facultads.FindAsync(id);
            if (facultad == null)
            {
                return HttpNotFound();
            }
            return View(facultad);
        }

        // GET: Facultads/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Facultads/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdFacultad,NombreFacultad")] Facultad facultad)
        {
            if (ModelState.IsValid)
            {
                db.Facultads.Add(facultad);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(facultad);
        }

        // GET: Facultads/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Facultad facultad = await db.Facultads.FindAsync(id);
            if (facultad == null)
            {
                return HttpNotFound();
            }
            return View(facultad);
        }

        // POST: Facultads/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdFacultad,NombreFacultad")] Facultad facultad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(facultad).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(facultad);
        }

        // GET: Facultads/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Facultad facultad = await db.Facultads.FindAsync(id);
            if (facultad == null)
            {
                return HttpNotFound();
            }
            return View(facultad);
        }

        // POST: Facultads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Facultad facultad = await db.Facultads.FindAsync(id);
            db.Facultads.Remove(facultad);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
