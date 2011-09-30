using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1.Control.TabControlTodos
{
    class UtilidadesComunes
    {

       public static void DesactivarTodosLosControles(System.Windows.Forms.Control control){
           foreach (System.Windows.Forms.Control c in control.Controls) {
               c.Enabled = false;
           }
        
        
        }

       public static void ActivarTodosLosControles(System.Windows.Forms.Control control)
       {
           foreach (System.Windows.Forms.Control c in control.Controls)
           {
              
                   c.Enabled = true;
               
           }


       }


       internal static void LimpiaTodosTextbox(System.Windows.Forms.Control control)
       {
           foreach (System.Windows.Forms.Control c in control.Controls)
           { 
           if ( c.GetType() == typeof(TextBox)){

               c.ResetText();
               
           }
           
           }
       }
       internal static void LimpiaTodosListbox(System.Windows.Forms.Control control)
       {
           foreach (System.Windows.Forms.Control c in control.Controls)
           {
               if (c.GetType() == typeof(ListBox))
               {

                   ((ListBox)c).Items.Clear();

               }

           }
       }



      


    }
}
