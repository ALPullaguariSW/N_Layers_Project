//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Boletos
    {
        public int BoletoID { get; set; }
        public int EventoID { get; set; }
        public int ClienteID { get; set; }
        public Nullable<System.DateTime> FechaCompra { get; set; }
    }
}
