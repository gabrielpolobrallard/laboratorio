using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WindowsFormsApplication1.Vista.InterrogatorioDonante;
using WindowsFormsApplication1.Modelo;
using WindowsFormsApplication1.Vista.Ventanas_DialogBoxes_ABMS;
using WindowsFormsApplication1.Vista.TabControlTodos;

namespace WindowsFormsApplication1.Vista.TabControlTodos
{

    public partial class TabTodosControles : Principal
    {

        #region Variables de la Clase


        tb_Pacientes pacienteSel;



        #endregion
        //Constructor

        public TabTodosControles()
        {
            InitializeComponent();
            //Cargo Listview de Pacientes y Desactivo los Controles de Alta Modif
            //Control.TabControlTodos.ControladorPacientes.CargaPacienteTodos(listViewPacientesPacientesLV);
            //Control.TabControlTodos.UtilidadesComunes.DesactivarTodosLosControles(tabPageAltaModif);

            //btnEliminarPac.Enabled = false;//desactivo el eliminar hasta q seleccione paciente.
            //btnModifPaciente.Enabled = false;//idem

            RecargarPacientes();
            //direcciones y telefonos. solo activo boton ver y listbox.
            this.listBoxDir.Enabled = true;
            this.listBoxTel.Enabled = true; //act los dos listbox
            btnVerDir.Enabled = true; //activo los dos botones ver.

            //diagnosticos 

            btnModifDiag.Enabled = btnDiagnostBorrar.Enabled = btnNuevoDiag.Enabled = false;
            using (LabDBEntities ctx = new LabDBEntities())
            {
                comboBusquedaGrupoSang.DataSource = ctx.tb_GrupoSanguineo.ToList();
                comboBusquedaGrupoSang.DisplayMember = "descripcion";
                comboBusquedaGrupoSang.ValueMember = "id_grupo";
            }
        }
        
        #region TODO ESTO CORRESPONDE A EL TAB PACIENTE!!!!!

        //Interrogatorio boton
        private void button30_Click(object sender, EventArgs e)
        {
            //cambiar despues por singleton.
            InterrogatorioDonante.InterrogatorioDonante interrForm = new InterrogatorioDonante.InterrogatorioDonante();
            interrForm.ShowDialog();
        }
        //ListView PACIENTES - SELECTED CHANGE index.
        private void listViewPacientesPacientesLV_SelectedIndexChanged(object sender, EventArgs e)
        {

            pacienteSel = Control.TabControlTodos.ControladorPacientes.CargaPaciente(listViewPacientesPacientesLV.FocusedItem.Text);
            btnEliminarPac.Enabled = true; //activo el eliminar paciente por si quiere borrarlo.
            btnModifPaciente.Enabled = true;//idem
            #region Carga textobox con datos del paciente
            txtboxNombre.Text = pacienteSel.nombre;
            txtboxApellido.Text = pacienteSel.apellido;
            txtboxDni.Text = pacienteSel.dni.Value.ToString();
            // txtboxEdad.Text = Convert.ToString(DateTime.Now.Date.Subtract(pacienteSel.fecha_nacimiento.Value).Days / 365); //Calculo la edad
            txtboxIdPaciente.Text = pacienteSel.id_paciente.ToString();
            //comboGrupoSang.SelectedValue = pacienteSel.grupo_sanguineo.Value;
            //comboMedico.SelectedValue = pacienteSel.medico_id.Value;
            // comboObraSoc.SelectedValue = pacienteSel.obra_social_id.Value;
            checkBoxEsDonante.Checked = revisarDonante(pacienteSel.dni.Value);
            dateTimeFechaAlta.Value = pacienteSel.fecha_alta.Value;
            dateTimeFechaNac.Value = pacienteSel.fecha_nacimiento.Value;
            using (var ctx = new LabDBEntities())
            {
                //grupo sang
                comboGrupoSang.Text = ctx.tb_GrupoSanguineo.Find(pacienteSel.grupo_sanguineo.Value).descripcion;
                //obra social
                comboObraSoc.Text = ctx.tb_ObraSocial.Find(pacienteSel.obra_social_id.Value).razon_social;
                //medico
                comboMedico.Text = ctx.tb_Medicos.Find(pacienteSel.medico_id).nombre + " " + ctx.tb_Medicos.Find(pacienteSel.medico_id).apellido;


            }
            CargaListBoxDirecciones();
            CargaListBoxTelefono();
            cargarDiagnosticosListView();

            //diagnosticos botones enable
            btnModifDiag.Enabled = btnDiagnostBorrar.Enabled = btnNuevoDiag.Enabled = true;



        }

        //Reviso si el paciente es Donante por medio del dni. Creo no usarlo en otro lugar. VER.
        private bool revisarDonante(int dni)
        {
            bool _es = false;
            using (LabDBEntities context = new LabDBEntities())
            {
                if (context.tb_Donantes.FirstOrDefault(don => don.dni == dni) != null)
                {
                    _es = true;
                }

            }
            return _es;
        }


            #endregion

        #region Botones de Listview PACIENTES
        private void btnModifPaciente_Click(object sender, EventArgs e)
        {
            //Activo los controles para poder modificar el paciente

            Control.TabControlTodos.UtilidadesComunes.ActivarTodosLosControles(tabPageAltaModif);
        }

        private void btnNuevoPac_Click(object sender, EventArgs e)
        {
            //seteo pacienteSeleccionado a null
            pacienteSel = null;
            //Limpio todo
            Control.TabControlTodos.UtilidadesComunes.LimpiaTodosTextbox(tableLayoutPanel2);
            Control.TabControlTodos.UtilidadesComunes.LimpiaTodosListbox(panelPacienteDirecciones);
            checkBoxEsDonante.Checked = false;
            listViewPacienteDiagnosticos.Items.Clear();
            Control.TabControlTodos.UtilidadesComunes.ActivarTodosLosControles(tabPageAltaModif);
            Control.TabControlTodos.UtilidadesComunes.LimpiaTodosListbox(panelPacienteDirecciones);


        }

        private void btnGuardarTodo_Click(object sender, EventArgs e)
        {
            //Nuevo Paciente.
            #region Creo Nuevo Paciente y asigno valores
            tb_Pacientes pacienteNvo = new tb_Pacientes();
            pacienteNvo.nombre = txtboxNombre.Text;
            pacienteNvo.apellido = txtboxApellido.Text;
            pacienteNvo.dni = Convert.ToInt32(txtboxDni.Text);
            pacienteNvo.fecha_nacimiento = dateTimeFechaNac.Value;
            pacienteNvo.fecha_alta = dateTimeFechaAlta.Value;
            pacienteNvo.grupo_sanguineo = Convert.ToInt32(comboGrupoSang.SelectedValue);
            pacienteNvo.medico_id = Convert.ToInt32(comboMedico.SelectedValue);
            pacienteNvo.obra_social_id = Convert.ToInt32(comboObraSoc.SelectedValue);
            pacienteNvo.borrado = 0;
            #endregion

            if (Control.TabControlTodos.ControladorPacientes.Alta(pacienteNvo))
            {
                MessageBox.Show("Todo ok. Paciente Agregado");
            }

            RecargarPacientes();

        }


        #endregion


        private void btnNuevaDir_Click(object sender, EventArgs e)
        {

            if (pacienteSel != null)
            {
                CargarDireccion CargarDirFrm = new CargarDireccion(1);
                CargarDirFrm.pacienteId = this.pacienteSel.id_paciente;
                if (CargarDirFrm.ShowDialog(this) == DialogResult.OK)
                {

                    CargaListBoxDirecciones();
                    toolStripStatusLabel1.Text = "Direccion cargada correctamente a las " + DateTime.Now.ToString("hh:mm:ss");
                }
                else
                {
                    toolStripStatusLabel1.Text = "Se ha producido un error";
                }


            }
        }

        private void CargaListBoxDirecciones()
        {
            listBoxDir.ValueMember = "_idDir";
            listBoxDir.DisplayMember = "CadenaListBox";

            listBoxDir.Items.Clear();
            using (LabDBEntities ctx = new LabDBEntities())
            {
                foreach (var item in ctx.tb_Pacientes.Find(pacienteSel.id_paciente).tb_DireccionTodos)
                {
                    listBoxDir.Items.Add((new AtribDir(Convert.ToInt32(item.id_dir), "Calle: " + item.calle.ToString() + " - # " + item.numero + "- Localidad: " + item.Localidad.Nombre)));

                }

            }
        }

        private void CargaListBoxTelefono()
        {
            listBoxTel.ValueMember = "_idTel";
            listBoxTel.DisplayMember = "CadenaTel";

            listBoxTel.Items.Clear();
            using (LabDBEntities ctx = new LabDBEntities())
            {
                foreach (var item in ctx.tb_Pacientes.Find(pacienteSel.id_paciente).tb_TelefonosTodos)
                {
                    listBoxTel.Items.Add(new AtribTel(Convert.ToInt32(item.id_telefono), item.telefono));

                }

            }
        }



        private void btnVerDir_Click(object sender, EventArgs e)
        {
            if (listBoxDir.SelectedIndex != -1)
            {
                CargarDireccion CargarDirFrm = new CargarDireccion(1, ((AtribDir)listBoxDir.SelectedItem)._idDir);
                if (CargarDirFrm.ShowDialog() == DialogResult.OK)
                {


                }

            }
        }

        private void btnNuevoTel_Click(object sender, EventArgs e)
        {
            CargarTelefonoFrm CargaTelFrm = new CargarTelefonoFrm(1);
            CargaTelFrm.pacienteSelId = this.pacienteSel.id_paciente;
            if (CargaTelFrm.ShowDialog(this) == DialogResult.OK)
            {



                this.toolStripStatusLabel1.Text = "Telefono Agregado con exito a las " + DateTime.Now.ToString("hh:mm:ss");
                CargaListBoxTelefono();
            }
            else
            {
                toolStripStatusLabel1.Text = "Se ha producido un error";
            }



        }

        private void btnVerificarDonante_Click(object sender, EventArgs e)
        {

        }

        private void btnNuevoDiag_Click(object sender, EventArgs e)
        {
            CargarDiagnosticoFrm cargDiagFrm = new CargarDiagnosticoFrm();
            cargDiagFrm.paciente_id_sel = this.pacienteSel.id_paciente;
            if (cargDiagFrm.ShowDialog(this) == DialogResult.OK)
            {

                this.toolStripStatusLabel1.Text = "Diagnostico Agregado con exito a las " + DateTime.Now.ToString("hh:mm:ss");
                cargarDiagnosticosListView();

            }
            else
            {
                toolStripStatusLabel1.Text = "Se ha producido un error";
            }
            cargDiagFrm.Dispose();
        }

        private void cargarDiagnosticosListView()
        {
            listViewPacienteDiagnosticos.Items.Clear();
            Control.TabControlTodos.ControladorPacientes.CargarDiagsDePaciente(this.pacienteSel.id_paciente, this.listViewPacienteDiagnosticos);

        }

        private void listViewPacienteDiagnosticos_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnModifDiag.Enabled = true;
            btnNuevoDiag.Enabled = true;
            btnDiagnostBorrar.Enabled = true;
        }





        private void btnModifDiag_Click(object sender, EventArgs e)
        {
            if (listViewPacienteDiagnosticos.SelectedItems.Count != 0)
            {
                if (listViewPacienteDiagnosticos.FocusedItem.Text != string.Empty)
                {
                    CargarDiagnosticoFrm cdfrm = new CargarDiagnosticoFrm(Convert.ToInt32(listViewPacienteDiagnosticos.FocusedItem.Text));
                    if (cdfrm.ShowDialog(this) == DialogResult.OK)
                    {

                        this.toolStripStatusLabel1.Text = "Diagnostico Modificado con exito a las " + DateTime.Now.ToString("hh:mm:ss");
                        cargarDiagnosticosListView();

                    }
                    else
                    {
                        toolStripStatusLabel1.Text = "Se ha producido un error";
                    }
                    cdfrm.Dispose();
                }
            }
        }

        private void btnDiagnostBorrar_Click(object sender, EventArgs e)
        {
            using (var ctx = new LabDBEntities())
            {
                if (listViewPacienteDiagnosticos.SelectedItems.Count != 0)
                {
                    ctx.tb_Diagnosticos.Find(Convert.ToInt32(listViewPacienteDiagnosticos.FocusedItem.Text)).borrado = 1;
                    if (ctx.SaveChanges() != 0)
                    {
                        this.toolStripStatusLabel1.Text = "Diagnostico Borrado con exito a las " + DateTime.Now.ToString("hh:mm:ss");
                        cargarDiagnosticosListView();
                    }
                    else
                    {
                        toolStripStatusLabel1.Text = "Se ha producido un error";
                    }
                }

            }
        }

        private void btnEliminarPac_Click(object sender, EventArgs e)
        {
            if (listViewPacientesPacientesLV.SelectedItems.Count != 0)
            {
                using (var ctx = new LabDBEntities())
                {
                    ctx.tb_Pacientes.Find(pacienteSel.id_paciente).borrado = 1;
                    if (ctx.SaveChanges() != 0)
                    {
                        this.toolStripStatusLabel1.Text = "Paciente Borrado con exito a las " + DateTime.Now.ToString("hh:mm:ss");
                        RecargarPacientes();
                    }
                    else
                    {
                        toolStripStatusLabel1.Text = "Se ha producido un error";
                    }

                }



            }
        }


        private void RecargarPacientes()
        {
            listViewPacientesPacientesLV.Items.Clear();
            Control.TabControlTodos.ControladorPacientes.CargaPacienteTodos(listViewPacientesPacientesLV);
            Control.TabControlTodos.UtilidadesComunes.DesactivarTodosLosControles(tabPageAltaModif);

            btnEliminarPac.Enabled = false;//desactivo el eliminar hasta q seleccione paciente.
            btnModifPaciente.Enabled = false;//idem
        }
        //Recargar paciente(INT) BUSQUEDA SEGUN CRITERIOS.
        private void BuscarPacientes()
        {
            listViewPacientesPacientesLV.Items.Clear();

            IList<tb_Pacientes> pac;

            using (var ctx = new LabDBEntities())
            {
                pac = (from pacient in ctx.tb_Pacientes.Include("tb_GrupoSanguineo").Where(paci => paci.borrado == 0) select pacient).ToList();

            }
            if (Convert.ToInt32(comboBusquedaGrupoSang.SelectedValue) != -1)
            {
                if (Convert.ToInt32(comboBusquedaGrupoSang.SelectedValue) != 1)
                {
                    pac = (pac.Where(pgr => pgr.grupo_sanguineo == Convert.ToInt32(comboBusquedaGrupoSang.SelectedValue))).ToList();
                }
                else
                {
                    // no filtro nada x grupo sang.
                }
            }
            if (txtboxBusquedaApell.Text != string.Empty)
            {
                pac = (pac.Where(p => p.apellido.ToLower().Contains(txtboxBusquedaApell.Text.ToLower().ToString()))).ToList();
            }
            if (txtboxBusquedaNombre.Text != string.Empty)
            {
                pac = (pac.Where(pnom => pnom.nombre.ToLower().Contains(txtboxBusquedaNombre.Text.ToLower()))).ToList();
            }


            foreach (tb_Pacientes p in pac)
            {

                ListViewItem item = new ListViewItem(p.id_paciente.ToString());
                item.SubItems.Add(p.nombre.ToString() + " " + p.apellido.ToString());
                item.SubItems.Add(p.dni.ToString());
                item.SubItems.Add(p.tb_GrupoSanguineo.descripcion.ToString());
                item.SubItems.Add(p.obra_social_id.ToString());
                this.listViewPacientesPacientesLV.Items.Add(item);
            }
            Control.TabControlTodos.UtilidadesComunes.DesactivarTodosLosControles(tabPageAltaModif);

            btnEliminarPac.Enabled = false;//desactivo el eliminar hasta q seleccione paciente.
            btnModifPaciente.Enabled = false;//idem
        }



        private void btnLimpiarBusqueda_Click(object sender, EventArgs e)
        {

            if ((txtboxBusquedaNombre.Text != string.Empty) || (txtboxBusquedaApell.Text != string.Empty) || (comboBusquedaGrupoSang.SelectedValue != null))
            {
                Control.TabControlTodos.UtilidadesComunes.LimpiaTodosTextbox(groupBoxBusquedaPac);
            }

        }
        //Busqueda de pacientes
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if ((txtboxBusquedaNombre.Text != string.Empty) || (txtboxBusquedaApell.Text != string.Empty) || (comboBusquedaGrupoSang.SelectedValue != null))
            {
                BuscarPacientes();
            }
        }




        #endregion


        #region TAB CONROL STOCk

        private void tabPageAnalisisClinicos_Enter(object sender, EventArgs e)
        {
            using (var ctx = new LabDBEntities())
            {
                var query = (from p in ctx.tb_Pacientes.Where(paciente => paciente.borrado == 0)
                             select new { p.id_paciente, p.nombre, p.apellido, p.dni }).ToList();
                dgv_PacienteListAnalisis.DataSource = query;

            }

        }
        private void dgv_PacienteListAnalisis_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            int idp = Convert.ToInt32(this.dgv_PacienteListAnalisis.CurrentRow.Cells[0].Value);

        }
        
        //private void dgv_PacienteListAnalisis_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    using (var ctx = new LabDBEntities())
        //    {
        //        //var query = (from pf in ctx.tb_Analisis
        //        //             join enzim in ctx.tb_Analisis_Enzimologia on pf.id_analisis equals enzim.analisis_id
        //        //             into enzimRes
        //        //             from enzinResultxx in enzimRes.DefaultIfEmpty()
        //        //             join matfecal in ctx.tb_Analisis_Examen_MateriaFecal on pf.id_analisis equals matfecal.analisis_id
        //        //             into matfecalRes
        //        //             from matfecalResxxx in matfecalRes.DefaultIfEmpty()
        //        //             join hemograma in ctx.tb_Analisis_Hemograma on pf.id_analisis equals hemograma.analisis_id
        //        //             into hemogramaRes
        //        //             from hemogramaResxxx in hemogramaRes.DefaultIfEmpty()
        //        //             join hemostycoag in ctx.tb_Analisis_Hemostacia_Coagulacion on pf.id_analisis equals hemostycoag.analisis_id
        //        //             into hemostycoagRes
        //        //             from hemostycoagResxxx in hemostycoagRes.DefaultIfEmpty()
        //        //             join hepatograma in ctx.tb_Analisis_Hepatograma on pf.id_analisis equals hepatograma.analisis_id
        //        //             into hepatogramaRes
        //        //             from hepatogramaResxxx in hepatogramaRes.DefaultIfEmpty()
        //        //             join hormonas in ctx.tb_Analisis_Hormonas on pf.id_analisis equals hormonas.analisis_id
        //        //             into hormonasRes
        //        //             from hormonasResxxx in hormonasRes.DefaultIfEmpty()
        //        //             join inminoglobulinas in ctx.tb_Analisis_Inmunoglobulinas on pf.id_analisis equals inminoglobulinas.analisis_id
        //        //             into inmunoglobulinasRes
        //        //             from inmunoglobulinaResxxx in inmunoglobulinasRes.DefaultIfEmpty()
        //        //             join inmunologia in ctx.tb_Analisis_Inmunologia on pf.id_analisis equals inmunologia.analisis_id
        //        //             into inmunologiaRes
        //        //             from inmunologiaResxxx in inmunologiaRes.DefaultIfEmpty()
        //        //             join lipidogramaelectroforet in ctx.tb_Analisis_LipidoGrama_Electroforetico on pf.id_analisis equals lipidogramaelectroforet.analisis_id
        //        //             into lipidElectroforetRes
        //        //             from lipidElectroforetResxxx in lipidElectroforetRes.DefaultIfEmpty()
        //        //             join microbiolog in ctx.tb_Analisis_Microbiologico on pf.id_analisis equals microbiolog.analisis_id
        //        //             into microbiologRes 
        //        //             from microbiologResxxx in microbiologRes.DefaultIfEmpty()
        //        //             join orina_complementario in ctx.tb_Analisis_Orina_Complementarios on pf.id_analisis equals orina_complementario.tb_Analisis_Orina_Completa.analisis_id
        //        //             into orina_compRes
        //        //             from orina_compResxxx in orina_compRes.DefaultIfEmpty()
        //        //             join orina_fisico_q in ctx.tb_Analisis_Orina_Examen_Fisico_Quimico on pf.id_analisis equals orina_fisico_q.tb_Analisis_Orina_Completa.analisis_id
        //        //             into orina_completaRes
        //        //             from orina_completaResxxx in orina_completaRes.DefaultIfEmpty()
        //        //             join orina_sedimento in ctx.tb_Analisis_Orina_Examen_Sedimento on pf.id_analisis equals orina_sedimento.tb_Analisis_Orina_Completa.analisis_id
        //        //             into orina_sedimentoRes
        //        //             from orina_sedimentoResxxx in orina_sedimentoRes.DefaultIfEmpty()
        //        //             join protelectroforetico in ctx.tb_Analisis_Proteinograma_Electroforetico on pf.id_analisis equals protelectroforetico.analisis_id
        //        //             into protelectroforeticoRes 
        //        //             from protelectroforeticoResxxx in protelectroforeticoRes.DefaultIfEmpty()
        //        //             join quimica_hematica in ctx.tb_Analisis_Quimica_Hematica on pf.id_analisis equals quimica_hematica.analisis_id
        //        //             into quimicaHematicaRes
        //        //             from quimicaHematicaResxxx in quimicaHematicaRes.DefaultIfEmpty()

        //        //             select pf

        //        //             ).ToList();
        //        int idpac = Convert.ToInt32(this.dgv_PacienteListAnalisis.CurrentRow.Cells[0].Value);
        //        try
        //        {
        //            var query2 = (from p in ctx.tb_Analisis.Where(idp => idp.paciente_id == idpac)
        //                          select p).ToList();

        //            BindingSource bs = new BindingSource();
        //            bs.DataSource = query2;
        //            dgv_AnalisisxPac_fecha.DataSource = bs;
        //        }
        //        catch (Exception ex) { toolStripStatusLabel1.Text = ex.ToString(); }

        //    }

        //}

        private void btn_BuscarAnalisis_Click(object sender, EventArgs e)
        {
            using (var ctx = new LabDBEntities())
            {
                var queryBusq = (from busqRes in ctx.tb_Pacientes select busqRes);
                if (txtboxBuscarAnalisisApe.Text != string.Empty)
                {
                    queryBusq = queryBusq.Where(pacient => pacient.apellido.Contains(txtboxBuscarAnalisisApe.Text));

                }
                if (txtboxBuscarAnalisisNom.Text != string.Empty)
                {
                    queryBusq = queryBusq.Where(pacient => pacient.nombre.Contains(txtboxBuscarAnalisisNom.Text));
                }
                int dnib = 0;
                Int32.TryParse(txtboxBuscarAnalisisDni.Text, out dnib);
                if (dnib != 0)
                {
                    if (txtboxBuscarAnalisisDni.Text != string.Empty)
                    {

                        queryBusq = queryBusq.Where(pacient => pacient.dni == dnib);

                    }
                }

                if (datetpBusqAnalisisFechaInicio.Value < datetpBusqAnalisisFechaFin.Value)
                {
                    queryBusq = from pacient in queryBusq
                                where pacient.tb_Analisis.Any(an => an.fecha_solicitud.Value > datetpBusqAnalisisFechaInicio.Value && an.fecha_solicitud.Value < datetpBusqAnalisisFechaFin.Value)
                                select pacient;

                }

                BindingSource bs = new BindingSource();
                bs.DataSource = queryBusq.ToList();
                dgv_PacienteListAnalisis.DataSource = bs;
            }
        }

        private void btn_LimpiarAnalisis_Click(object sender, EventArgs e)
        {
            using (var ctx = new LabDBEntities())
            {
                var queryBusq = (from busqRes in ctx.tb_Pacientes select busqRes);
                BindingSource bs = new BindingSource();
                bs.DataSource = queryBusq.ToList();
                dgv_PacienteListAnalisis.DataSource = bs;
            }

        }
       
        #endregion

        private void tabPageControlStock_Enter(object sender, EventArgs e)
        {
            BindingSource bs = new BindingSource();
            using (var ctx = new LabDBEntities())
            {
                bs.DataSource = (from prod in ctx.tb_Insumos
                                select new {
                                id=prod.id_insumo,

                                Detalle= prod.detalle,
                                Tipo=prod.tb_Tipo_Insumo.detalles,
                                Marca= prod.marca_id,
                                
                                Cantidad_Disponible= prod.cant_disponible,
                                Cantidad_Minima=prod.cant_minima,
                                Medida=prod.tb_Medida_Insumo.descripcion,
                                PrecioUnitario = prod.precio_unidad
                               }).ToList();
            }
           
            dataGridViewContStock.DataSource = bs;
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
           Ventanas.ControlStockFrm c = new Ventanas.ControlStockFrm();
            c.ShowDialog();
        }
        
      
   
   

    }
    




    //Clase para cargar Items al listbox Direcciones
    public class AtribDir
    {

        public int _idDir { get; set; }
        public string CadenaListbox { get; set; }
        public AtribDir() { }

        public AtribDir(int id, string c)
        {
            this.CadenaListbox = c;
            this._idDir = id;
        }


    }
    //Clase para cargar Items al listbox telefonos
    public class AtribTel
    {

        public int _idTel { get; set; }
        public string CadenaTel { get; set; }
        public AtribTel() { }

        public AtribTel(int id, string c)
        {
            this.CadenaTel = c;
            this._idTel = id;
        }

        
    }
    
}



