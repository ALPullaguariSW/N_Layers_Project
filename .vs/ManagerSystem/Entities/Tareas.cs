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
    
    public partial class Tareas
    {
        public int TareaID { get; set; }
        public int ProyectoID { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
        public System.DateTime FechaLimite { get; set; }
    }
}
