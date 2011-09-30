using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WindowsFormsApplication1.Modelo;
namespace WindowsFormsApplication1.Vista.Ventanas_DialogBoxes_ABMS
{
    public partial class CargarDiagnosticoFrm : Form
    {
        public int paciente_id_sel { get; set; }
        private int modificar = 0;

        private int _id_a_modif { get; set; }

        public CargarDiagnosticoFrm()
        {
            InitializeComponent();
        }

        public CargarDiagnosticoFrm(int id)
        {
            InitializeComponent();
            this.modificar = 1;
            this._id_a_modif = id;
            using (var ctx=new LabDBEntities()){
                monthCalendar1.SelectionStart = ctx.tb_Diagnosticos.Find(id).fecha.Value;
                textBoxDiag.Text = ctx.tb_Diagnosticos.Find(id).descripcion;

            }
        }



        private void btnGuardar_Click(object sender, EventArgs e)
        {
            using (var ctx = new LabDBEntities())
            {
                switch (this.modificar)
                {
                    case 0:
                        {//agregar uno nuevo
                            monthCalendar1.MaxSelectionCount = 1;
                            DateTime dia = monthCalendar1.SelectionStart;
                            tb_Diagnosticos diag = new tb_Diagnosticos();
                            diag.descripcion = textBoxDiag.Text;
                            diag.fecha = dia;

                            ctx.tb_Pacientes.Find(paciente_id_sel).tb_Diagnosticos.Add(diag);
                            if (ctx.SaveChanges() != 0)
                            {
                                this.DialogResult = DialogResult.OK;
                                this.Close();

                            }
                            else
                            {
                                this.DialogResult = DialogResult.Cancel;
                            }

                            break;
                        }
                    case 1:
                        {//modificar
                            monthCalendar1.MaxSelectionCount = 1;
                            ctx.tb_Diagnosticos.Find(this._id_a_modif).descripcion = textBoxDiag.Text;
                            ctx.tb_Diagnosticos.Find(this._id_a_modif).fecha = monthCalendar1.SelectionStart;
                            if (ctx.SaveChanges() != 0)
                            {
                                this.DialogResult = DialogResult.OK;
                                this.Close();
                               
                            }
                            else {
                                this.DialogResult = DialogResult.Cancel;
                            }
                            break;

                        }

                }

            }
        }




    }
}
