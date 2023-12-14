
using Empleado.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Empleado.Controllers
{
    public class CargoController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Cargo
        public ActionResult Index()
        {
            var cargos = db.Cargos.ToList();
            return View(cargos);
        }

        // GET: Cargo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Cargo cargo = db.Cargos.Find(id);

            if (cargo == null)
            {
                return HttpNotFound();
            }

            return View(cargo);
        }

        // GET: Cargo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cargo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodigoCargo,NombreCargo")] Cargo cargo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Cargos.Add(cargo);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Error al intentar crear un cargo.");
            }

            return View(cargo);
        }

        // GET: Cargo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Cargo cargo = db.Cargos.Find(id);

            if (cargo == null)
            {
                return HttpNotFound();
            }

            return View(cargo);
        }

        // POST: Cargo/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodigoCargo,NombreCargo")] Cargo cargo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(cargo).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Error al intentar editar el cargo.");
            }

            return View(cargo);
        }

        // GET: Cargo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Cargo cargo = db.Cargos.Find(id);

            if (cargo == null)
            {
                return HttpNotFound();
            }

            return View(cargo);
        }

        // POST: Cargo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Cargo cargo = db.Cargos.Find(id);
                db.Cargos.Remove(cargo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Error al intentar eliminar el cargo.");
                return View("Delete", id);
            }
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
