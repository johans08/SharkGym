using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharkGym.DB.Modelo;

namespace SharkGym.DB.Interface
{
    interface IGestorUsuario // Se crea la inteface para el manejo de contratos
    {
        // Acciones que tendra el contrato
        IEnumerable<Usuario> ListadoUsuarios(); // Se crea un Ienumerable para el manejo de la lista

        int CrearUsuario(Usuario pUsuario); // Accion para crear el Usuario

        int ActualizarUsuario(Usuario pUsuario); // Accion para actualizar el Usuario

        int BorrarUsuario(int pIdUsuario); // Accion para borrar el Usuario

        int Login(Usuario pUsuario);

        int Profile(int id, Usuario pUsuario);
    }
}

