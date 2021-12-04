using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SharkGym.DB.Modelo;

namespace SharkGym.UI.Controllers
{
    public class RutinasController : Controller
    {
        private SharkGymEntities db = new SharkGymEntities();

        // GET: Rutinas
        public ActionResult Index()
        {
            var rutinas = db.Rutinas.Include(r => r.Usuario).Include(r => r.Usuario1);
            return View(rutinas.ToList());
        }

        // GET: Rutinas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rutina rutina = db.Rutinas.Find(id);
            if (rutina == null)
            {
                return HttpNotFound();
            }
            return View(rutina);
        }

        // GET: Rutinas/Create
        public ActionResult Create()
        {
            ViewBag.ID_Cliente = new SelectList(db.Usuarios, "PK_IdUsuario", "Nombre");
            ViewBag.ID_Entrenador = new SelectList(db.Usuarios, "PK_IdUsuario", "Nombre");
            return View();
        }

        // POST: Rutinas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PK_IdRutina,ID_Cliente,ID_Entrenador,Ejercicio1,Ejercicio2,Ejercicio3,Ejercicio4")] Rutina rutina)
        {
            if (ModelState.IsValid)
            {
                db.Rutinas.Add(rutina);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Cliente = new SelectList(db.Usuarios, "PK_IdUsuario", "Nombre", rutina.ID_Cliente);
            ViewBag.ID_Entrenador = new SelectList(db.Usuarios, "PK_IdUsuario", "Nombre", rutina.ID_Entrenador);
            return View(rutina);
        }

        public ActionResult RutinasUser()
        {
            var sesion = (Int32)Session["Ide"];
            var rutinas = db.Rutinas.Where(r => r.ID_Cliente.Equals(sesion));
            return View(rutinas.ToList());

        }

        // GET: Rutinas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rutina rutina = db.Rutinas.Find(id);
            if (rutina == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Cliente = new SelectList(db.Usuarios, "PK_IdUsuario", "Nombre", rutina.ID_Cliente);
            ViewBag.ID_Entrenador = new SelectList(db.Usuarios, "PK_IdUsuario", "Nombre", rutina.ID_Entrenador);
            return View(rutina);
        }

        // POST: Rutinas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PK_IdRutina,ID_Cliente,ID_Entrenador,Ejercicio1,Ejercicio2,Ejercicio3,Ejercicio4")] Rutina rutina)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rutina).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Cliente = new SelectList(db.Usuarios, "PK_IdUsuario", "Nombre", rutina.ID_Cliente);
            ViewBag.ID_Entrenador = new SelectList(db.Usuarios, "PK_IdUsuario", "Nombre", rutina.ID_Entrenador);
            return View(rutina);
        }

        // GET: Rutinas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rutina rutina = db.Rutinas.Find(id);
            if (rutina == null)
            {
                return HttpNotFound();
            }
            return View(rutina);
        }

        // POST: Rutinas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Rutina rutina = db.Rutinas.Find(id);
            db.Rutinas.Remove(rutina);
            db.SaveChanges();
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
