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
    public class EmpleadoController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Empleado
        public ActionResult Index()
        {
            var empleados = db.Empleados.Include(e => e.Cargo);
            return View(empleados.ToList());
        }


        // GET: Empleado/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Empleados empleado = db.Empleados.Find(id);

            if (empleado == null)
            {
                return HttpNotFound();
            }

            return View(empleado);
        }

        // GET: Empleado/Create
        public ActionResult Create()
        {
            ViewBag.CodigoCargo = new SelectList(db.Cargos, "CodigoCargo", "NombreCargo");
            return View();
        }

        // POST: Empleado/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Cedula,Nombre1,Nombre2,Apellido1,Apellido2,CodigoCargo")] Empleados empleado)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Empleados.Add(empleado);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                // Puedes agregar un punto de interrupción aquí o registrar el error.
                ModelState.AddModelError(string.Empty, "Error al intentar crear un empleado.");
            }

            ViewBag.CodigoCargo = new SelectList(db.Cargos, "CodigoCargo", "NombreCargo", empleado.CodigoCargo);
            return View(empleado);
        }

        // GET: Empleado/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Empleados empleado = db.Empleados.Find(id);

            if (empleado == null)
            {
                return HttpNotFound();
            }

            ViewBag.CodigoCargo = new SelectList(db.Cargos, "CodigoCargo", "NombreCargo", empleado.CodigoCargo);
            return View(empleado);
        }

        // POST: Empleado/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Cedula,Nombre1,Nombre2,Apellido1,Apellido2,CodigoCargo")] Empleados empleado)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(empleado).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Error al intentar editar el empleado.");
            }

            ViewBag.CodigoCargo = new SelectList(db.Cargos, "CodigoCargo", "NombreCargo", empleado.CodigoCargo);
            return View(empleado);
        }

        // GET: Empleado/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Empleados empleado = db.Empleados.Find(id);

            if (empleado == null)
            {
                return HttpNotFound();
            }

            return View(empleado);
        }

        // POST: Empleado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Empleados empleado = db.Empleados.Find(id);
                db.Empleados.Remove(empleado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Error al intentar eliminar el empleado.");
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