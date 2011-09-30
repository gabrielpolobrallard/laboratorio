using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindowsFormsApplication1.Modelo;

namespace WindowsFormsApplication1.Control.TabControlTodos
{
    class ControladorDirecciones
    {

        public static int idDirCarg { get; set; }


        public static bool Alta(Modelo.tb_DireccionTodos nvaDirCargada)
        {
            
            bool exito = false;
           
            using (var ctx = new LabDBEntities())
            {
               idDirCarg = ctx.tb_DireccionTodos.Add(nvaDirCargada).id_dir;
                if (ctx.SaveChanges() != 0) {
                    exito = true;
                }
            }
       
            return exito;
        }
    }
}
