using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using cricketscore.Models;

namespace cricketscore.Controllers
{
    public class myscoreController : Controller
    {
        private cricketEntities db = new cricketEntities();

        // GET: myscore
        public async Task<ActionResult> Index()
        {
            return View(await db.scores.ToListAsync());
        }

        // GET: myscore/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            score score = await db.scores.FindAsync(id);
            if (score == null)
            {
                return HttpNotFound();
            }
            return View(score);
        }

        // GET: myscore/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: myscore/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "plno,pname,score1")] score score)
        {
            if (ModelState.IsValid)
            {
                db.scores.Add(score);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(score);
        }

        // GET: myscore/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            score score = await db.scores.FindAsync(id);
            if (score == null)
            {
                return HttpNotFound();
            }
            return View(score);
        }

        // POST: myscore/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "plno,pname,score1")] score score)
        {
            if (ModelState.IsValid)
            {
                db.Entry(score).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(score);
        }

        // GET: myscore/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            score score = await db.scores.FindAsync(id);
            if (score == null)
            {
                return HttpNotFound();
            }
            return View(score);
        }

        // POST: myscore/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            score score = await db.scores.FindAsync(id);
            db.scores.Remove(score);
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
