using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WindowsFormsApplication1.Modelo;
namespace WindowsFormsApplication1.Control.TabControlTodos
{
    class ControladorPacientes
    {




        public static void CargaPacienteTodos(ListView lvPacientes)
        {



            using (var context = new LabDBEntities())
            {
                IQueryable<tb_Pacientes> pacientes = context.tb_Pacientes.Include("tb_GrupoSanguineo");
                foreach (tb_Pacientes p in pacientes.Where(pac => pac.borrado != 1))
                {

                    ListViewItem item = new ListViewItem(p.id_paciente.ToString());
                    item.SubItems.Add(p.nombre.ToString()+" "+p.apellido.ToString() );
                    item.SubItems.Add(p.dni.ToString());
                    item.SubItems.Add(p.tb_GrupoSanguineo.descripcion.ToString());
                    item.SubItems.Add(p.obra_social_id.ToString());
                    lvPacientes.Items.Add(item);
                }
                pacientes = null;
            }


        }




        internal static tb_Pacientes CargaPaciente(string p)
        {
            tb_Pacientes paciente = new tb_Pacientes();
            int id;
            Int32.TryParse(p, out id);
            using (var context = new LabDBEntities())
            {
                paciente = (tb_Pacientes)context.tb_Pacientes.Find(id);
            }
            return paciente;

        }

        internal static bool Alta(tb_Pacientes pacienteNvo)
        {
            bool _exito = false;
            using (var context = new LabDBEntities())
            {
                context.tb_Pacientes.Add(pacienteNvo);
                if (0 < context.SaveChanges())
                {
                    _exito = true;
                }

            }
            return _exito;
        }

        public static void CargarDiagsDePaciente(int idpaciente, ListView lvDiags)
        {



            using (var context = new LabDBEntities())
            {
                IQueryable<tb_Diagnosticos> diags = context.tb_Pacientes.Find(idpaciente).tb_Diagnosticos.AsQueryable();
                foreach (tb_Diagnosticos p in diags.Where(pac => pac.borrado != 1))
                {

                    ListViewItem item = new ListViewItem(p.id_diagnostico.ToString());
                    item.SubItems.Add(p.fecha.ToString());
                    item.SubItems.Add(p.descripcion.ToString());

                    lvDiags.Items.Add(item);
                }
                diags = null;
            }


        }




        internal static IList<tb_Pacientes> busquedaPaciente( string nom, string ape, string grup)
        {
            IList<tb_Pacientes> pacientesResult;
            using (var ctx = new LabDBEntities())
            {
                int groupo = 0;
                Int32.TryParse(grup, out groupo);
                if (grup=="todos")
                {
                    pacientesResult = (from pac in
                                           ctx.tb_Pacientes.Where(elPac => elPac.nombre.Contains(nom)
                                           && elPac.apellido.Contains(ape) && elPac.grupo_sanguineo.Value == groupo && elPac.borrado == 0) 

                                       select pac).ToList();
                   
                }

                else
                {

                    pacientesResult = (from pac in
                                           ctx.tb_Pacientes.Where(elPac => elPac.nombre.Contains(nom)
                                           && elPac.apellido.Contains(ape) && elPac.borrado == 0)
                                          

                                       select pac).ToList();
                }
            }

            return pacientesResult;
        }
    }
}
