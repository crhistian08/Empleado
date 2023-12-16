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
    public class EmpleadosController : Controller
    {
        List<Empleados> ListaTipoEmp = new List<Empleados>();
        private ApplicationDbContext db = new ApplicationDbContext();


        public ActionResult ListaEmpleados()
        {
            var ListaTipoEmp = db.Empleado.ToList();
            return View(ListaTipoEmp);
        }
        // GET: Empleado
        public ActionResult Index()
        {
            var empleados = db.Empleado.Include(e => e.Cargo);
            return View(empleados.ToList());

        }


        // GET: Empleado/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Empleados empleado = db.Empleado.Find(id);

            if (empleado == null)
            {
                return HttpNotFound();
            }

            return View(empleado);
        }

        // GET: Empleado/create
        public ActionResult Create(Empleados nuevoEmpleado)
        {


            if (ModelState.IsValid)
            {
                if (nuevoEmpleado.Cedula == null)
                {

                    ModelState.AddModelError("Cedula", "La Cedula es obligatoria.");
                    return View(nuevoEmpleado);
                }

                try
                {
                    ListaTipoEmp = (from _Empleado in db.Empleado
                                    select new Empleados
                                    {

                                        Cedula = _Empleado.Cedula,
                                        Nombre1 = _Empleado.Nombre1,
                                        Nombre2 = _Empleado.Nombre2,
                                        Apellido1 = _Empleado.Apellido1,
                                        Apellido2 = _Empleado.Apellido2,
                                        CodigoCargo = _Empleado.CodigoCargo

                                    }).ToList();
                    return View(ListaTipoEmp);
                                   
                                   
                    using (var context = new ApplicationDbContext())
                    {
                        
                        context.Empleado.Add(nuevoEmpleado);
                        context.SaveChanges();
                    }

                    return RedirectToAction("index");
                }


                catch (Exception)
                {

                    ModelState.AddModelError(string.Empty, "Error al intentar crear un nuevo empleado.");

                }
                
               

              
            }


            ViewBag.CodigoCargo = new SelectList(db.Cargos, "codigocargo", "nombrecargo");
            return View(nuevoEmpleado);
        }

        // POST: Empleado/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult create([Bind(Include = "Cedula,Nombre1,Nombre2,Apellido1,Apellido2,CodigoCargo")] Models.Empleados empleado)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Empleado.Add(empleado);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                //agregar un punto de interrupción aquí o registrar el error.
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

            Empleados empleado = db.Empleado.Find(id);

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
        public ActionResult Edit([Bind(Include = "Cedula,Nombre1,Nombre2,Apellido1,Apellido2,CodigoCargo")] Models.Empleados empleado)
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

            Empleados empleado = db.Empleado.Find(id);

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
                Empleados empleado = db.Empleado.Find(id);
                db.Empleado.Remove(empleado);
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