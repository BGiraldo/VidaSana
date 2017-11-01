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
    public class GymsController : Controller
    {
        private Entities db = new Entities();

        // GET: Gyms
        public async Task<ActionResult> Index()
        {
            return View(await db.Gyms.ToListAsync());
        }

        // GET: Gyms/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gym gym = await db.Gyms.FindAsync(id);
            if (gym == null)
            {
                return HttpNotFound();
            }
            return View(gym);
        }

        // GET: Gyms/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Gyms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,description,latitude,longitude,name")] Gym gym)
        {
            if (ModelState.IsValid)
            {
                gym.id = Guid.NewGuid();
                db.Gyms.Add(gym);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(gym);
        }

        // GET: Gyms/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gym gym = await db.Gyms.FindAsync(id);
            if (gym == null)
            {
                return HttpNotFound();
            }
            return View(gym);
        }

        // POST: Gyms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,description,latitude,longitude,name")] Gym gym)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gym).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(gym);
        }

        // GET: Gyms/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gym gym = await db.Gyms.FindAsync(id);
            if (gym == null)
            {
                return HttpNotFound();
            }
            return View(gym);
        }

        // POST: Gyms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            Gym gym = await db.Gyms.FindAsync(id);
            db.Gyms.Remove(gym);
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
