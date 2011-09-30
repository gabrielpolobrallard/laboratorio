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
    public partial class CargarDireccion : Form
    {
        #region VARIABLES DE LA CLASE
        private int tipo = 0;
        public int pacienteId { get; set; }
        public int idDirCargada { get; set; }
        private tb_DireccionTodos nvaDirCargada; 
        #endregion

        public CargarDireccion(int opcion)

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
            cargarCombos(0);
        }
        public CargarDireccion(int opcion, int id /*id a cargar*/)
        {
            InitializeComponent();
            using (var ctx = new LabDBEntities())
            {
                
                tb_DireccionTodos dirACargar = ctx.tb_DireccionTodos.Find(id);
                txtboxCalle.Text = dirACargar.calle;
                txtboxNumCalle.Text = dirACargar.numero.ToString();
                txtboxDescDep.Text = dirACargar.desc_dep;
                txtboxNumDep.Text = dirACargar.numero_dep;
                comboBarrios.Text = ctx.tb_Barrio.Find(dirACargar.barrio).descripcion;
                comboLocalidad.Text = ctx.Localidad.Find(dirACargar.localidad_id).Nombre;
                comboDepartamento.Text = ctx.Departamento.Find(dirACargar.Localidad.idDepartamento).Nombre;
                int idDep = Convert.ToInt32(dirACargar.Localidad.idDepartamento.ToString());
                comboProvincia.Text = ctx.Provincia.FirstOrDefault(prov => prov.ID == prov.Departamento.FirstOrDefault(dep => dep.ID == idDep).idProvincia).Nombre;
                btnGuardar.Enabled = btnLimpiar.Enabled = btnNuevaLocalidad.Enabled = btnNvoBarrio.Enabled = false; //desactivo los botones
            }
        }


       
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            using (var ctx = new LabDBEntities())
            {
                switch (this.tipo)
                {
                    case 1: //paciente
                        {
                            nvaDirCargada = new tb_DireccionTodos();
                            nvaDirCargada.calle = txtboxCalle.Text;
                            nvaDirCargada.numero = Convert.ToInt32(txtboxNumCalle.Text);
                            nvaDirCargada.desc_dep = txtboxDescDep.Text;
                            nvaDirCargada.numero_dep = txtboxNumDep.Text;
                            nvaDirCargada.localidad_id = Convert.ToInt32(comboLocalidad.SelectedValue);
                            nvaDirCargada.barrio = Convert.ToInt32(comboBarrios.SelectedValue);

                            ctx.tb_Pacientes.Find(pacienteId).tb_DireccionTodos.Add(nvaDirCargada);
                            if (ctx.SaveChanges() != 0)
                            {

                                this.DialogResult = DialogResult.OK;
                            }
                            else {
                                this.DialogResult = DialogResult.Cancel;
                            }

                            

                            break;
                        }
                }



            }
        }


        private void cargarCombos(int opcion)
        {
            switch (opcion)
            {
                case 0:
                    {
                        using (var ctx = new LabDBEntities())
                        {
                            //
                           // comboProvincia.SelectedValue = null;
                            comboProvincia.ValueMember = "ID";
                            comboProvincia.DisplayMember = "Nombre";
                            comboProvincia.DataSource = ctx.Provincia.ToList();
                            
                            //
                            //comboLocalidad.SelectedValue = null;
                            comboLocalidad.ValueMember = "ID";
                            comboLocalidad.DisplayMember = "Nombre";
                            comboLocalidad.DataSource = ctx.Localidad.ToList();

                            //
                            comboDepartamento.ValueMember = "ID";
                            comboDepartamento.DisplayMember = "Nombre";
                            // comboDepartamento.SelectedValue = null;
                            comboDepartamento.DataSource = ctx.Departamento.ToList();
                            //
                            //comboBarrios.ValueMember = "id_barrio";
                            //comboBarrios.DisplayMember = "descripcion";
                            ////comboBarrios.SelectedValue = null;
                            //comboBarrios.DataSource = ctx.tb_Barrio.ToList();

                        }
                        break;
                    }
                case 1://Cargo combo dep segun prov 
                    {
                        using (var ctx = new LabDBEntities())
                        {
                            int idprovsv = Convert.ToInt32(comboProvincia.SelectedValue.ToString());
                            comboDepartamento.ValueMember = "ID";
                            comboDepartamento.DisplayMember = "Nombre";
                            comboDepartamento.DataSource = ctx.Departamento.Where(dp => dp.idProvincia == idprovsv).ToList();

                        }
                        break;
                    }
                case 2://Cargo localidades segun depart
                    {
                        using (var ctx = new LabDBEntities())
                        {
                            int iddepsv = Convert.ToInt32(comboDepartamento.SelectedValue.ToString());
                            if (iddepsv != 0)
                            {
                                comboLocalidad.ValueMember = "ID";
                                comboLocalidad.DisplayMember = "Nombre";
                                comboLocalidad.DataSource = ctx.Localidad.Where(dp => dp.idDepartamento == iddepsv).ToList();
                            }
                        }
                        break;

                    }
                case 3: //cargo barrios segun localidad
                    {

                        using (var ctx = new LabDBEntities())
                        {

                            int idlocsv = Convert.ToInt32(comboLocalidad.SelectedValue.ToString());
                            if (idlocsv != 0)
                            {

                                comboBarrios.DataSource = ctx.tb_Barrio.Where(dp => dp.localidad_id == idlocsv).ToList();
                                comboBarrios.ValueMember = "id_barrio";
                                comboBarrios.DisplayMember = "descripcion";
                            }
                        }
                        break;

                    }

                case 4://Limpio los combos y txbox
                    {
                        comboLocalidad.ResetText();
                        comboProvincia.ResetText();
                        comboDepartamento.ResetText();
                        comboBarrios.ResetText();
                        Control.TabControlTodos.UtilidadesComunes.LimpiaTodosTextbox(this.panelCargDir);
                        break;
                    }
            }
        }

        private void comboProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarCombos(1);
        }

        private void comboDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarCombos(2);
        }

        private void comboLocalidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarCombos(3);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            cargarCombos(4); //limpia
        }
    }




}
