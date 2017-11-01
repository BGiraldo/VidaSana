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
    public class PeopleController : Controller
    {
        private Entities db = new Entities();

        // GET: People
        public async Task<ActionResult> Index()
        {
            var persons = db.Persons.Include(p => p.Gym);
            return View(await persons.ToListAsync());
        }

        // GET: People/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = await db.Persons.FindAsync(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // GET: People/Create
        public ActionResult Create()
        {
            ViewBag.gymid = new SelectList(db.Gyms, "id", "name");
            return View();
        }

        // POST: People/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,address,age,documentId,email,gymid,lastname,name,phone")] Person person)
        {
            if (ModelState.IsValid)
            {
                person.id = Guid.NewGuid();
                db.Persons.Add(person);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.gymid = new SelectList(db.Gyms, "id", "name", person.gymid);
            return View(person);
        }

        // GET: People/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = await db.Persons.FirstOrDefaultAsync(p => p.documentId == id);
            if (person == null)
            {
                return HttpNotFound();
            }
            ViewBag.gymid = new SelectList(db.Gyms, "id", "name", person.gymid);
            return View(person);
        }

        // POST: People/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,address,age,documentId,email,gymid,lastname,name,phone")] Person person)
        {
            if (ModelState.IsValid)
            {
                db.Entry(person).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.gymid = new SelectList(db.Gyms, "id", "name", person.gymid);
            return View(person);
        }

        // GET: People/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = await db.Persons.FirstOrDefaultAsync(p => p.documentId == id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // POST: People/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Person person = await db.Persons.FirstOrDefaultAsync(p => p.documentId == id);
            db.Persons.Remove(person);
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
