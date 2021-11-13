using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharkGym.DB.Modelo;

namespace SharkGym.DB.Interface
{
    interface IGestorRutina // Se crea la inteface para el manejo de contratos
    {
        // Acciones que tendra el contrato
        IEnumerable<Rutina> ListadoRutinas(); // Se crea un Ienumerable para el manejo de la lista

        int CrearRutina(Rutina pRutina); // Accion para crear la Rutina

        int ActualizarRutina(Rutina pRutina); // Accion para actualizar la Rutina

        int BorrarRutina(int pIdRutina); // Accion para borrar la Rutina
    }
}
