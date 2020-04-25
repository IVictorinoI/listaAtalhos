using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListaAtalhos
{
    public partial class FormStatusPesquisa : Form
    {
        public FormStatusPesquisa()
        {
            InitializeComponent();
        }

        public void addPasta(String pasta)
        {
            lbPastas.Items.Add(pasta);
        }
    }
}
