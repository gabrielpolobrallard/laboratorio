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
    public partial class CargarTelefonoFrm : Form
    {
        private int tipo = 0;
        public int pacienteSelId {get;set;}
        public int tel_id_guardado {get;set;}
        public CargarTelefonoFrm()
        {
            InitializeComponent();
        }
        public CargarTelefonoFrm(int opcion)
        {
            
            //opcion 1 paciente
            switch (opcion)
            {
                case 1:
                    {
                        this.tipo = 1;//tipo paciente
                        break;
                    }
                case 2:
                    {
                        this.tipo = 2; //tipo donante
                        break;
                    }
            }

            InitializeComponent();
        }
        //boton guardartelefono
        private void button1_Click(object sender, EventArgs e)
        {
            using (var ctx = new LabDBEntities())
            {
                switch (this.tipo)
                {
                    case 1:
                        { //Guarda el PACIENTE en la bd
                            tb_TelefonosTodos tel = new tb_TelefonosTodos();
                            tel.telefono = textBoxTelefono.Text;

                            ctx.tb_Pacientes.Find(pacienteSelId).tb_TelefonosTodos.Add(tel);
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
                    case 2:
                        { // carga tel ed DONANTE

                            break;
                        }
                }
            }


        }

        private void CargarTelefonoFrm_Load(object sender, EventArgs e)
        {

        }
    }
}
