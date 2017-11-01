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
    public class StagesController : Controller
    {
        private Entities db = new Entities();

        // GET: Stages
        public async Task<ActionResult> Index()
        {
            return View(await db.Stages.ToListAsync());
        }

        // GET: Stages/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stage stage = await db.Stages.FindAsync(id);
            if (stage == null)
            {
                return HttpNotFound();
            }
            return View(stage);
        }

        // GET: Stages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Stages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,description,name,type")] Stage stage)
        {
            if (ModelState.IsValid)
            {
                stage.id = Guid.NewGuid();
                db.Stages.Add(stage);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(stage);
        }

        // GET: Stages/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stage stage = await db.Stages.FindAsync(id);
            if (stage == null)
            {
                return HttpNotFound();
            }
            return View(stage);
        }

        // POST: Stages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,description,name,type")] Stage stage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stage).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(stage);
        }

        // GET: Stages/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stage stage = await db.Stages.FindAsync(id);
            if (stage == null)
            {
                return HttpNotFound();
            }
            return View(stage);
        }

        // POST: Stages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            Stage stage = await db.Stages.FindAsync(id);
            db.Stages.Remove(stage);
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
