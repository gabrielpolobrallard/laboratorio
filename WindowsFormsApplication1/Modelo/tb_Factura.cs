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
    
    public partial class tb_Factura
    {
        public tb_Factura()
        {
            this.tb_Factura_x_Analisis = new HashSet<tb_Factura_x_Analisis>();
        }
    
        // Primitive properties
    
        public int id_factura { get; set; }
        public Nullable<int> tipo { get; set; }
        public Nullable<int> paciente_id { get; set; }
        public Nullable<decimal> subtotal { get; set; }
        public Nullable<decimal> total { get; set; }
        public Nullable<int> iva_id { get; set; }
        public Nullable<System.DateTime> fecha { get; set; }
    
        // Navigation properties
    
        public virtual tb_IVA tb_IVA { get; set; }
        public virtual tb_Pacientes tb_Pacientes { get; set; }
        public virtual ICollection<tb_Factura_x_Analisis> tb_Factura_x_Analisis { get; set; }
    
    }
}