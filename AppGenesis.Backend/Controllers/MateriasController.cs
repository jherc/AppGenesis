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
    public class MateriasController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Materias
        public async Task<ActionResult> Index()
        {
            var materias = db.Materias.Include(m => m.Facultad);
            return View(await materias.ToListAsync());
        }

        // GET: Materias/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Materia materia = await db.Materias.FindAsync(id);
            if (materia == null)
            {
                return HttpNotFound();
            }
            return View(materia);
        }

        // GET: Materias/Create
        public ActionResult Create()
        {
            ViewBag.IdFacultad = new SelectList(db.Facultads, "IdFacultad", "NombreFacultad");
            return View();
        }

        // POST: Materias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdMateria,IdFacultad,Nrc,Nombre")] Materia materia)
        {
            if (ModelState.IsValid)
            {
                db.Materias.Add(materia);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IdFacultad = new SelectList(db.Facultads, "IdFacultad", "NombreFacultad", materia.IdFacultad);
            return View(materia);
        }

        // GET: Materias/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Materia materia = await db.Materias.FindAsync(id);
            if (materia == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdFacultad = new SelectList(db.Facultads, "IdFacultad", "NombreFacultad", materia.IdFacultad);
            return View(materia);
        }

        // POST: Materias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdMateria,IdFacultad,Nrc,Nombre")] Materia materia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(materia).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IdFacultad = new SelectList(db.Facultads, "IdFacultad", "NombreFacultad", materia.IdFacultad);
            return View(materia);
        }

        // GET: Materias/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Materia materia = await db.Materias.FindAsync(id);
            if (materia == null)
            {
                return HttpNotFound();
            }
            return View(materia);
        }

        // POST: Materias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Materia materia = await db.Materias.FindAsync(id);
            db.Materias.Remove(materia);
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
