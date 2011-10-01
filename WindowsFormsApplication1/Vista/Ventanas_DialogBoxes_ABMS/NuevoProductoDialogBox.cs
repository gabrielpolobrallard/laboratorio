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
    public partial class NuevoProductoDialogBox : Form
    {
        public int modificacion = 0;
        private tb_Insumos prod;
        public NuevoProductoDialogBox(int mod = 0)
        {
            switch (mod)
            {
                case 0:
                    {
                        this.modificacion = 0;
                        break;
                    }
                default:
                    {
                        this.modificacion = 1;
                        using (var ctx = new LabDBEntities())
                        {
                            this.prod = ctx.tb_Insumos.Find(mod);
                        }

                        break;
                    }
            }

            InitializeComponent();
            cargarComboboxes();
            if (this.modificacion != 0) { cargarTextoUpdate(); }
        }

        private void cargarTextoUpdate()
        {
            textBoDetalle.Text = prod.detalle;
            textBoxCantDisp.Text = prod.cant_disponible.ToString();
            textBoxCantMin.Text = prod.cant_minima.ToString();
            comboMarca.SelectedValue = prod.marca_id.Value;
            comboMedida.SelectedValue = prod.medida.Value;
            comboTipo.SelectedValue = prod.tipo_id.Value;
            textBoxPrecio.Text = prod.precio_unidad.ToString();
        }


        private void cargarComboboxes()
        {
            using (var ctx = new LabDBEntities())
            {
                comboMedida.DataSource = ctx.tb_Medida_Insumo.ToList();
                comboMedida.DisplayMember = "descripcion";
                comboMedida.ValueMember = "id_medida";
                comboMedida.SelectedIndex = -1;
                comboTipo.DataSource = ctx.tb_Tipo_Insumo.ToList();
                comboTipo.DisplayMember = "detalles";
                comboTipo.ValueMember = "id_tipo_insumo";
                comboTipo.SelectedIndex = -1;
                comboMarca.DataSource = ctx.tb_Insumo_Marca.ToList();
                comboMarca.DisplayMember = "descripcion";
                comboMarca.ValueMember = "id_marca";
                comboMarca.SelectedIndex = -1;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            using (var ctx = new LabDBEntities())
            {
                if (this.modificacion == 0)
                {
                    prod = new tb_Insumos();
                }

                else {
                    prod = ctx.tb_Insumos.Find(prod.id_insumo);
                }
                prod.detalle = textBoDetalle.Text;
                prod.marca_id = Convert.ToInt32(comboMarca.SelectedValue);
                prod.medida = Convert.ToInt32(comboMedida.SelectedValue);
                prod.tipo_id = Convert.ToInt32(comboTipo.SelectedValue);
                prod.precio_unidad = Convert.ToDecimal(textBoxPrecio.Text);
                prod.cant_disponible = Convert.ToInt32(textBoxCantDisp.Text);
                prod.cant_minima = Convert.ToInt32(textBoxCantMin.Text);

                if (this.modificacion == 0)
                {
                    ctx.tb_Insumos.Add(prod);
                }
                if (ctx.SaveChanges() != 0)
                {
                    if (modificacion == 0)
                    {
                        MessageBox.Show("Producto Guardado Correctamente");
                    }
                    if (modificacion != 0)
                    {
                        MessageBox.Show("Producto Actualizado Correctamente");
                    }
                    this.DialogResult = DialogResult.OK;
                }
            }
        }





    }
}
