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
    
    public partial class tb_Medicos
    {
        public tb_Medicos()
        {
            this.tb_Direccion_x_Medico = new HashSet<tb_Direccion_x_Medico>();
            this.tb_Pacientes = new HashSet<tb_Pacientes>();
        }
    
        // Primitive properties
    
        public int id_medico { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public Nullable<int> dni { get; set; }
        public Nullable<int> especialidad { get; set; }
        public string email1 { get; set; }
        public string email2 { get; set; }
    
        // Navigation properties
    
        public virtual ICollection<tb_Direccion_x_Medico> tb_Direccion_x_Medico { get; set; }
        public virtual ICollection<tb_Pacientes> tb_Pacientes { get; set; }
    
    }
}
