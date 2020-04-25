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
                Form form1 = Application.OpenForms["Form1"];
                MessageBox.Show(form1.Text);
                form1.Show();
            } else
            {
                Form1 frm = new Form1();
                Application.Run(frm);
            }

        }
    }
}
