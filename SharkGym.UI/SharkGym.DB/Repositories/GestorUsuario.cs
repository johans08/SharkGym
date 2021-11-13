using SharkGym.DB.Interface;
using SharkGym.DB.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharkGym.DB.Repositories
{
    class GestorUsuario : IGestorUsuario
    {
        //Método para mostrar a todos los usuarios en la vista de mantenimientos
        IEnumerable<Usuario> IGestorUsuario.ListadoUsuarios()
        {
            List<Usuario> _Usuarios = new List<Usuario>(); // Se crea el objeto usuario de tipo lista
            using (SharkGymEntities ContextDB = new SharkGymEntities()) // Se crea el contexto de base de datos
            {
                _Usuarios = ContextDB.Usuarios.ToList();
            }

            return _Usuarios; // Retornamos la lista de usuarios
        }

        // Método para actualizar un usuario
        public int ActualizarUsuario(Usuario pUsuario)
        {
            int n = 0;
            using (SharkGymEntities ContextDB = new SharkGymEntities())
            {
                ContextDB.Entry<Usuario>(pUsuario).State = System.Data.Entity.EntityState.Modified;
                n = ContextDB.SaveChanges();
            }
            return n;
        }

        // Método para borrar un usuario
        public int BorrarUsuario(int pIdUsuario)
        {
            int n = 0;
            using (SharkGymEntities ContextDB = new SharkGymEntities())
            {
                var obj = ContextDB.Usuarios.Where(x => x.PK_IdUsuario == pIdUsuario).FirstOrDefault();
                if (obj == null)
                {
                    n = 0;
                }
                else
                {
                    ContextDB.Entry<Usuario>(obj).State = System.Data.Entity.EntityState.Deleted;
                    n = ContextDB.SaveChanges();
                }
            }
            return n;
        }
        
        // Método para registrar a un nuevo usuario
        public int CrearUsuario(Usuario pUsuario)
        {
            int n = 0;
            using (SharkGymEntities ContextDB = new SharkGymEntities())
            {
                ContextDB.Usuarios.Add(pUsuario);
                n = ContextDB.SaveChanges(); // Se guardan los datos en la base de datos
            }
            return n; // Se retornan el campo en la base de datos con sus datos
        }

        //Método para ingresar en sesión, QUITAR 
        public int Login(Usuario pUsuario)
        {
            int n = 0;
            using (SharkGymEntities ContextoBD = new SharkGymEntities())
            {
                var obj = ContextoBD.Usuarios.Where(a => a.Usuario1.Equals(pUsuario.Usuario1) && a.Contraseña.Equals(pUsuario.Contraseña)).FirstOrDefault();

            }
            return n;
        }

        //Método para mostrar los datos del usuario que ingreso en sesión, QUITAR
        public int Profile(int id, Usuario pUsuario)
        {
            int n = 0;
            using (SharkGymEntities ContextoBD = new SharkGymEntities())
            {
                var info = from Usuario in ContextoBD.Usuarios
                           where pUsuario.PK_IdUsuario == id
                           select Usuario;
                var user = info.FirstOrDefault<Usuario>();
            }

            return n;
        }
    }
}
