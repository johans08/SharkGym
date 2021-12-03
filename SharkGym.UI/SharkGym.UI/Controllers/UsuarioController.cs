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
    public class UsuarioController : Controller
    {
        private SharkGymEntities db = new SharkGymEntities();

        // GET: Usuario
        public ActionResult Index()
        {
            var usuarios = db.Usuarios.Include(u => u.TipoUsuario);
            return View(usuarios.ToList());
        }

        // GET: Usuario/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            ViewBag.FK_TipoUsuario = new SelectList(db.TipoUsuarios, "PK_TipoUsuario", "Descripcion");
            return View();
        }

        // POST: Usuario/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PK_IdUsuario,Nombre,Apellido,Direccion,Telefono,Usuario1,Correo,Contraseña,FK_TipoUsuario")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Usuarios.Add(usuario);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            ViewBag.FK_TipoUsuario = new SelectList(db.TipoUsuarios, "PK_TipoUsuario", "Descripcion", usuario.FK_TipoUsuario);
            return View(usuario);
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            ViewBag.FK_TipoUsuario = new SelectList(db.TipoUsuarios, "PK_TipoUsuario", "Descripcion", usuario.FK_TipoUsuario);
            return View(usuario);
        }

        // POST: Usuario/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PK_IdUsuario,Nombre,Apellido,Direccion,Telefono,Usuario1,Correo,Contraseña,FK_TipoUsuario")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FK_TipoUsuario = new SelectList(db.TipoUsuarios, "PK_TipoUsuario", "Descripcion", usuario.FK_TipoUsuario);
            return View(usuario);
        }

        // GET: Usuario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: Usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Usuario usuario = db.Usuarios.Find(id);
            db.Usuarios.Remove(usuario);
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

        //Muestra el formulario para ingresar sesión
        public ActionResult Login()
        {
            return View();
        }



        //Permite el Login del usuario y del administrador
        public ActionResult LoginUser(Usuario pUsuario)
        {
            if (ModelState.IsValid)
            {
                using (SharkGymEntities ContextoBD = new SharkGymEntities()) //No debería ir acá, solamente el if
                {
                    var data = ContextoBD.Usuarios.Where(a => a.Correo.Equals(pUsuario.Correo) &&
                    a.Contraseña.Equals(pUsuario.Contraseña) && a.FK_TipoUsuario.Equals(pUsuario.FK_TipoUsuario)).ToList();

                    var data2 = ContextoBD.Usuarios.Where(a => a.Correo.Equals(pUsuario.Correo) &&
                    a.Contraseña.Equals(pUsuario.Contraseña) && a.FK_TipoUsuario.Equals(pUsuario.FK_TipoUsuario)).ToList();


                    Session["Admin"] = null;
                    Session["Username"] = null;





                    if (data.Count() > 0 && pUsuario.FK_TipoUsuario.Equals(2))
                    {
                        Session["Username"] = data.FirstOrDefault().Usuario1;

                        //Para los datos del perfil del usuario y admin
                        Session["Ide"] = data.FirstOrDefault().PK_IdUsuario;
                        Session["Nombre"] = data.FirstOrDefault().Nombre;
                        Session["Apellido"] = data.FirstOrDefault().Apellido;
                        Session["Telefono"] = data.FirstOrDefault().Telefono;
                        Session["Email"] = data.FirstOrDefault().Correo;
                        Session["Pass"] = data.FirstOrDefault().Contraseña;

                        return RedirectToAction("Index", "Home");

                    }
                    else if (data.Count() > 0 && pUsuario.FK_TipoUsuario.Equals(1))
                    {

                        Session["Admin"] = data.FirstOrDefault().Usuario1;

                        //Para los datos del perfil del usuario y admin
                        Session["Ide"] = data.FirstOrDefault().PK_IdUsuario;
                        Session["Nombre"] = data.FirstOrDefault().Nombre;
                        Session["Apellido"] = data.FirstOrDefault().Apellido;
                        Session["Telefono"] = data.FirstOrDefault().Telefono;
                        Session["Email"] = data.FirstOrDefault().Correo;
                        Session["Pass"] = data.FirstOrDefault().Contraseña;


                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        return RedirectToAction("Login");
                    }


                }
            }
            return View();

        }


        //Permite eliminar de sesión a un usuario y regresarlo al Login
        public ActionResult Logout()
        {
            Session.Remove("Username");
            Session.Remove("Admin");
            return RedirectToAction("Login");
        }

    }
}
