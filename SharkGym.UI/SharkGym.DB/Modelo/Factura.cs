//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SharkGym.DB.Modelo
{
    using System;
    using System.Collections.Generic;
    
    public partial class Factura
    {
        public int PK_IdFactura { get; set; }
        public int ID_Cliente { get; set; }
        public int Mensualidad { get; set; }
        public int Iva { get; set; }
        public int Total { get; set; }
    
        public virtual Usuario Usuario { get; set; }
    }
}
