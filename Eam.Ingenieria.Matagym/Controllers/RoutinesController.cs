using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Eam.Ingenieria.Matagym;

namespace Eam.Ingenieria.Matagym.Controllers
{
    public class RoutinesController : Controller
    {
        private Entities db = new Entities();

        // GET: Routines
        public async Task<ActionResult> Index()
        {
            return View(await db.Routines.ToListAsync());
        }

        // GET: Routines/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Routine routine = await db.Routines.FindAsync(id);
            if (routine == null)
            {
                return HttpNotFound();
            }
            return View(routine);
        }

        // GET: Routines/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Routines/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,description,kindOfRoutine,name,typeRoutine")] Routine routine)
        {
            if (ModelState.IsValid)
            {
                routine.id = Guid.NewGuid();
                db.Routines.Add(routine);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(routine);
        }

        // GET: Routines/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Routine routine = await db.Routines.FindAsync(id);
            if (routine == null)
            {
                return HttpNotFound();
            }
            return View(routine);
        }

        // POST: Routines/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,description,kindOfRoutine,name,typeRoutine")] Routine routine)
        {
            if (ModelState.IsValid)
            {
                db.Entry(routine).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(routine);
        }

        // GET: Routines/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Routine routine = await db.Routines.FindAsync(id);
            if (routine == null)
            {
                return HttpNotFound();
            }
            return View(routine);
        }

        // POST: Routines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            Routine routine = await db.Routines.FindAsync(id);
            db.Routines.Remove(routine);
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
