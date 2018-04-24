using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CursoIT.Api.Models;

namespace CursoIT.Api.Controllers
{
    public class CinemasController : Controller
    {
        private itxamarindatabaseEntities db = new itxamarindatabaseEntities();

        // GET: Cinemas
        public async Task<ActionResult> Index()
        {
            return View(await db.Cinemas.ToListAsync());
        }

        // GET: Cinemas/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cinemas cinemas = await db.Cinemas.FindAsync(id);
            if (cinemas == null)
            {
                return HttpNotFound();
            }
            return View(cinemas);
        }

        // GET: Cinemas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cinemas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,Name,Description,Image,likes,dislikes,latitude,longitude")] Cinemas cinemas)
        {
            if (ModelState.IsValid)
            {
                db.Cinemas.Add(cinemas);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(cinemas);
        }

        // GET: Cinemas/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cinemas cinemas = await db.Cinemas.FindAsync(id);
            if (cinemas == null)
            {
                return HttpNotFound();
            }
            return View(cinemas);
        }

        // POST: Cinemas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,Name,Description,Image,likes,dislikes,latitude,longitude")] Cinemas cinemas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cinemas).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(cinemas);
        }

        // GET: Cinemas/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cinemas cinemas = await db.Cinemas.FindAsync(id);
            if (cinemas == null)
            {
                return HttpNotFound();
            }
            return View(cinemas);
        }

        // POST: Cinemas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Cinemas cinemas = await db.Cinemas.FindAsync(id);
            db.Cinemas.Remove(cinemas);
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
