using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WindowsFormsApplication1.Vista.InterrogatorioDonante;
namespace WindowsFormsApplication1.Vista.TabControlTodos
{
    public partial class TabTodosControles : Form
    {
        public TabTodosControles()
        {
            InitializeComponent();
        }

        private void button30_Click(object sender, EventArgs e)
        {
            //cambiar despues por singleton.
            InterrogatorioDonante.InterrogatorioDonante interrForm = new InterrogatorioDonante.InterrogatorioDonante();
            interrForm.ShowDialog();
        }
    }
}
