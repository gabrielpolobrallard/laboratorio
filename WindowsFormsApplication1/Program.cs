using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsApplication1.Vista.TabControlTodos;
using WindowsFormsApplication1.Vista.Ventanas;

namespace WindowsFormsApplication1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Form pr = new Principal();
            //pr.WindowState = FormWindowState.Maximized;
            //Form tbContTodos = new TabTodosControles();
            //tbContTodos.MdiParent = pr;
            //tbContTodos.WindowState = FormWindowState.Maximized;
            //tbContTodos.Show();
            Application.Run(new  TabTodosControles());
        }
    }
}
