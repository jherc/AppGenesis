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
    public class NotasController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Notas
        public async Task<ActionResult> Index()
        {
            var notas = db.Notas.Include(n => n.Materia).Include(n => n.Usuario);
            return View(await notas.ToListAsync());
        }

        // GET: Notas/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nota nota = await db.Notas.FindAsync(id);
            if (nota == null)
            {
                return HttpNotFound();
            }
            return View(nota);
        }

        // GET: Notas/Create
        public ActionResult Create()
        {
            ViewBag.IdMateria = new SelectList(db.Materias, "IdMateria", "Nrc");
            ViewBag.IdUsuario = new SelectList(db.Usuarios, "IdUsuario", "Nombre");
            return View();
        }

        // POST: Notas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdNota,IdMateria,IdUsuario,Nnota,Corte")] Nota nota)
        {
            if (ModelState.IsValid)
            {
                db.Notas.Add(nota);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IdMateria = new SelectList(db.Materias, "IdMateria", "Nrc", nota.IdMateria);
            ViewBag.IdUsuario = new SelectList(db.Usuarios, "IdUsuario", "Nombre", nota.IdUsuario);
            return View(nota);
        }

        // GET: Notas/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nota nota = await db.Notas.FindAsync(id);
            if (nota == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdMateria = new SelectList(db.Materias, "IdMateria", "Nrc", nota.IdMateria);
            ViewBag.IdUsuario = new SelectList(db.Usuarios, "IdUsuario", "Nombre", nota.IdUsuario);
            return View(nota);
        }

        // POST: Notas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdNota,IdMateria,IdUsuario,Nnota,Corte")] Nota nota)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nota).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IdMateria = new SelectList(db.Materias, "IdMateria", "Nrc", nota.IdMateria);
            ViewBag.IdUsuario = new SelectList(db.Usuarios, "IdUsuario", "Nombre", nota.IdUsuario);
            return View(nota);
        }

        // GET: Notas/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nota nota = await db.Notas.FindAsync(id);
            if (nota == null)
            {
                return HttpNotFound();
            }
            return View(nota);
        }

        // POST: Notas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Nota nota = await db.Notas.FindAsync(id);
            db.Notas.Remove(nota);
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
