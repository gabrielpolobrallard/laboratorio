using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WindowsFormsApplication1.Modelo;

namespace WindowsFormsApplication1.Vista.Ventanas
{
    public partial class ControlStockFrm : Form
    {
        public ControlStockFrm()
        {
            InitializeComponent();
            cargarDatagridProductos();
            
        }

        private void cargarDatagridProductos()
        {
            using (var ctx = new LabDBEntities()) 
            {
                var query = from prod in ctx.tb_Insumos
                            orderby prod.detalle
                            select new
                            {
                                ID=prod.id_insumo,
                                DETALLE=prod.detalle,
                                TIPO=prod.tb_Tipo_Insumo.detalles,
                                MARCA=prod.tb_Insumo_Marca.descripcion,
                                CANT_MINIMA=prod.cant_minima,
                                CANT_DISPONIBLE=prod.cant_disponible,
                                MEDIDA=prod.tb_Medida_Insumo.descripcion,
                                PRECIO=prod.precio_unidad

                            };
               
                BindingSource bs = new BindingSource();
                bs.DataSource=query.ToList();
                dvgControlStock.DataSource = bs;
                dvgControlStock.Columns[0].Visible = false;
                comboCategorias.DataSource = ctx.tb_Tipo_Insumo.ToList();
                comboCategorias.DisplayMember = "detalles";
                    comboCategorias.ValueMember = "id_tipo_insumo";
            }
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            Ventanas_DialogBoxes_ABMS.NuevoProductoDialogBox prodFrm = new Ventanas_DialogBoxes_ABMS.NuevoProductoDialogBox();
            if (prodFrm.ShowDialog() == DialogResult.OK)
            {
                cargarDatagridProductos();
            }
        }

        private void dvgControlStock_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show(dvgControlStock.CurrentRow.Cells[0].Value.ToString());
            Ventanas_DialogBoxes_ABMS.NuevoProductoDialogBox prodFrm = new Ventanas_DialogBoxes_ABMS.NuevoProductoDialogBox(Convert.ToInt32(dvgControlStock.CurrentRow.Cells[0].Value));
            if (prodFrm.ShowDialog() == DialogResult.OK)
            {
                cargarDatagridProductos();
            }
        }
    }
}
