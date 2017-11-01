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
    public class MeasurementsController : Controller
    {
        private Entities db = new Entities();

        // GET: Measurements
        public async Task<ActionResult> Index()
        {
            var measurements = db.Measurements.Include(m => m.Person);
            return View(await measurements.ToListAsync());
        }

        // GET: Measurements/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Measurement measurement = await db.Measurements.FindAsync(id);
            if (measurement == null)
            {
                return HttpNotFound();
            }
            return View(measurement);
        }

        // GET: Measurements/Create
        public ActionResult Create()
        {
            ViewBag.Personid = new SelectList(db.Persons, "id", "documentid");
            return View();
        }

        // POST: Measurements/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,Personid,bodyFat,date,heartRate,height,weight")] Measurement measurement)
        {
            if (ModelState.IsValid)
            {
                measurement.id = Guid.NewGuid();
                db.Measurements.Add(measurement);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Personid = new SelectList(db.Persons, "id", "documentid", measurement.Personid);
            return View(measurement);
        }

        // GET: Measurements/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Measurement measurement = await db.Measurements.FindAsync(id);
            if (measurement == null)
            {
                return HttpNotFound();
            }
            ViewBag.Personid = new SelectList(db.Persons, "id", "documentid", measurement.Personid);
            return View(measurement);
        }

        // POST: Measurements/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,Personid,bodyFat,date,heartRate,height,weight")] Measurement measurement)
        {
            if (ModelState.IsValid)
            {
                db.Entry(measurement).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Personid = new SelectList(db.Persons, "id", "documentid", measurement.Personid);
            return View(measurement);
        }

        // GET: Measurements/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Measurement measurement = await db.Measurements.FindAsync(id);
            if (measurement == null)
            {
                return HttpNotFound();
            }
            return View(measurement);
        }

        // POST: Measurements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            Measurement measurement = await db.Measurements.FindAsync(id);
            db.Measurements.Remove(measurement);
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
