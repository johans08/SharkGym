using SharkGym.DB.Interface;
using SharkGym.DB.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharkGym.DB.Repositories
{
    class GestorFactura : IGestorFactura
    {
        public int ActualizarFactura(Factura pFactura)
        {
            int n = 0;
            using (SharkGymEntities ContextDB = new SharkGymEntities())
            {
                ContextDB.Entry<Factura>(pFactura).State = System.Data.Entity.EntityState.Modified;
                n = ContextDB.SaveChanges();
            }
            return n;
        }

        public int BorrarFactura(int pIdFactura)
        {
            int n = 0;
            using (SharkGymEntities ContextDB = new SharkGymEntities())
            {
                var obj = ContextDB.Facturas.Where(x => x.PK_IdFactura == pIdFactura).FirstOrDefault();
                if (obj == null)
                {
                    n = 0;
                }
                else
                {
                    ContextDB.Entry<Factura>(obj).State = System.Data.Entity.EntityState.Deleted;
                    n = ContextDB.SaveChanges();
                }
            }
            return n;
        }

        public int CrearFactura(Factura pFactura)
        {
            int n = 0;
            using (SharkGymEntities ContextDB = new SharkGymEntities())
            {
                ContextDB.Facturas.Add(pFactura);
                n = ContextDB.SaveChanges(); // Se guardan los datos en la base de datos
            }
            return n; // Se retornan el campo en la base de datos con sus datos
        }

        IEnumerable<Factura> IGestorFactura.ListadoFacturas()
        {
            List<Factura> _Factura = new List<Factura>(); // Se crea el objeto facturas de tipo lista
            using (SharkGymEntities ContextDB = new SharkGymEntities()) // Se crea el contexto de base de datos
            {
                _Factura = ContextDB.Facturas.ToList();
            }

            return _Factura; // Retornamos la lista de Facturas
        }
    }
}
