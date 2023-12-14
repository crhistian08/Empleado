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
   public class DatosSalarialesController : Controller
{
    private ApplicationDbContext db = new ApplicationDbContext();

    // GET: DatosSalariales
    public ActionResult Index()
    {
        var datosSalariales = db.DatosSalariales.ToList();
        return View(datosSalariales);
    }

    // GET: DatosSalariales/Details/5
    public ActionResult Details(int? id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        DatosSalariales datosSalariales = db.DatosSalariales.Find(id);

        if (datosSalariales == null)
        {
            return HttpNotFound();
        }

        return View(datosSalariales);
    }

    // GET: DatosSalariales/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: DatosSalariales/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create([Bind(Include = "IdEmpleado,Salario,FechaInicioContrato")] DatosSalariales datosSalariales)
    {
        try
        {
            if (ModelState.IsValid)
            {
                db.DatosSalariales.Add(datosSalariales);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
        catch (Exception ex)
        {
            ModelState.AddModelError(string.Empty, "Error al intentar crear datos salariales.");
        }

        return View(datosSalariales);
    }

    // GET: DatosSalariales/Edit/5
    public ActionResult Edit(int? id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        DatosSalariales datosSalariales = db.DatosSalariales.Find(id);

        if (datosSalariales == null)
        {
            return HttpNotFound();
        }

        return View(datosSalariales);
    }

    // POST: DatosSalariales/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit([Bind(Include = "IdEmpleado,Salario,FechaInicioContrato")] DatosSalariales datosSalariales)
    {
        try
        {
            if (ModelState.IsValid)
            {
                db.Entry(datosSalariales).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
        catch (Exception ex)
        {
            ModelState.AddModelError(string.Empty, "Error al intentar editar datos salariales.");
        }

        return View(datosSalariales);
    }

    // GET: DatosSalariales/Delete/5
    public ActionResult Delete(int? id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        DatosSalariales datosSalariales = db.DatosSalariales.Find(id);

        if (datosSalariales == null)
        {
            return HttpNotFound();
        }

        return View(datosSalariales);
    }

    // POST: DatosSalariales/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
        try
        {
            DatosSalariales datosSalariales = db.DatosSalariales.Find(id);
            db.DatosSalariales.Remove(datosSalariales);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        catch (Exception ex)
        {
            ModelState.AddModelError(string.Empty, "Error al intentar eliminar datos salariales.");
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
