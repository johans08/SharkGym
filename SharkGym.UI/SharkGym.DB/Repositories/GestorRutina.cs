using SharkGym.DB.Interface;
using SharkGym.DB.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharkGym.DB.Repositories
{
    class GestorRutina : IGestorRutina
    {
        public int ActualizarRutina(Rutina pRutina)
        {
            int n = 0;
            using (SharkGymEntities ContextDB = new SharkGymEntities())
            {
                ContextDB.Entry<Rutina>(pRutina).State = System.Data.Entity.EntityState.Modified;
                n = ContextDB.SaveChanges();
            }
            return n;
        }

        public int BorrarRutina(int pIdRutina)
        {
            int n = 0;
            using (SharkGymEntities ContextDB = new SharkGymEntities())
            {
                var obj = ContextDB.Rutinas.Where(x => x.PK_IdRutina == pIdRutina).FirstOrDefault();
                if (obj == null)
                {
                    n = 0;
                }
                else
                {
                    ContextDB.Entry<Rutina>(obj).State = System.Data.Entity.EntityState.Deleted;
                    n = ContextDB.SaveChanges();
                }
            }
            return n;
        }

        public int CrearRutina(Rutina pRutina)
        {
            int n = 0;
            using (SharkGymEntities ContextDB = new SharkGymEntities())
            {
                ContextDB.Rutinas.Add(pRutina);
                n = ContextDB.SaveChanges(); // Se guardan los datos en la base de datos
            }
            return n; // Se retornan el campo en la base de datos con sus datos
        }

        IEnumerable<Rutina> IGestorRutina.ListadoRutinas()
        {
            List<Rutina> _Rutina = new List<Rutina>(); // Se crea el objeto facturas de tipo lista
            using (SharkGymEntities ContextDB = new SharkGymEntities()) // Se crea el contexto de base de datos
            {
                _Rutina = ContextDB.Rutinas.ToList();
            }

            return _Rutina; // Retornamos la lista de Rutinas
        }
    }
}
