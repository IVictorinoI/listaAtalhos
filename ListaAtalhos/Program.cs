using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace ListaAtalhos
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
            string processo = Process.GetCurrentProcess().ProcessName;

            if (Process.GetProcessesByName(processo).Length > 1)
            {
                MessageBox.Show("Victor");
                Form FormPrincipal = Application.OpenForms["FormPrincipal"];
                MessageBox.Show(FormPrincipal.Text);
                FormPrincipal.Show();
            } else
            {
                FormPrincipal frm = new FormPrincipal();
                Application.Run(frm);
            }

        }
    }
}
