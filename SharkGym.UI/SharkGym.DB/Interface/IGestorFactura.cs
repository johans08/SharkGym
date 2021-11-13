using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharkGym.DB.Modelo;

namespace SharkGym.DB.Interface
{
    interface IGestorFactura // Se crea la inteface para el manejo de contratos
    {
        // Acciones que tendra el contrato
        IEnumerable<Factura> ListadoFacturas(); // Se crea un Ienumerable para el manejo de la lista

        int CrearFactura(Factura pFactura); // Accion para crear la Factura

        int ActualizarFactura(Factura pFactura); // Accion para actualizar la Factura

        int BorrarFactura(int pIdFactura); // Accion para borrar la Factura
    }
}
