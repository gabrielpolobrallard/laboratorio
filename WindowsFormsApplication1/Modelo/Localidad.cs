//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WindowsFormsApplication1.Modelo
{
    using System;
    using System.Collections.Generic;
    
    public partial class Localidad
    {
        public Localidad()
        {
            this.tb_Barrio = new HashSet<tb_Barrio>();
            this.tb_DireccionTodos = new HashSet<tb_DireccionTodos>();
        }
    
        // Primitive properties
    
        public int ID { get; set; }
        public int idDepartamento { get; set; }
        public string Nombre { get; set; }
    
        // Navigation properties
    
        public virtual Departamento Departamento { get; set; }
        public virtual ICollection<tb_Barrio> tb_Barrio { get; set; }
        public virtual ICollection<tb_DireccionTodos> tb_DireccionTodos { get; set; }
    
    }
}
