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
    
    public partial class tb_Analisis_Enzimologia
    {
        public tb_Analisis_Enzimologia()
        {
            this.tb_Analisis = new HashSet<tb_Analisis>();
        }
    
        // Primitive properties
    
        public int id_enzimologia { get; set; }
        public Nullable<decimal> lipasa { get; set; }
        public Nullable<decimal> amilasa { get; set; }
        public Nullable<decimal> fosfatasa_acida_total { get; set; }
        public Nullable<decimal> fosfatasa_acida_prostatica { get; set; }
        public Nullable<decimal> fosfatasa_alcalina { get; set; }
        public Nullable<decimal> snt { get; set; }
        public Nullable<decimal> ldh { get; set; }
        public Nullable<decimal> cpk { get; set; }
        public Nullable<decimal> gamma_gt { get; set; }
        public Nullable<decimal> got { get; set; }
        public Nullable<decimal> gpt { get; set; }
        public Nullable<int> estado_id { get; set; }
        public Nullable<int> analisis_id { get; set; }
    
        // Navigation properties
    
        public virtual ICollection<tb_Analisis> tb_Analisis { get; set; }
        public virtual tb_Estado_Analisis tb_Estado_Analisis { get; set; }
    
    }
}
