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
    
    public partial class Comentarios
    {
        public int ComentarioID { get; set; }
        public int PublicacionID { get; set; }
        public string Autor { get; set; }
        public string Contenido { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
    }
}