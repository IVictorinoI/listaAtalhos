using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IWshRuntimeLibrary;
using System.Diagnostics;

namespace ListaAtalhos
{
    public partial class Form1 : Form
    {
        Atalhos atalhos = new Atalhos();

        private void FiltraLista(string conteudoFiltrar)
        {
            lbAtalhos.Items.Clear();
            foreach (var atalho in atalhos.Search(conteudoFiltrar))
            {
                lbAtalhos.Items.Add(atalho.Caminho);
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            OpenFileFromPath(lbAtalhos.Text);
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            atalhos.Initialize();
            textPesquisa.Focus();
            CreateShortcut();
            FiltraLista("");
        }

        private void textPesquisa_TextChanged(object sender, EventArgs e)
        {
            FiltraLista(textPesquisa.Text);
            lbAtalhos.Focus();
            if (lbAtalhos.Items.Count > 0)
                lbAtalhos.SetSelected(0, true);
        }

        private void TrataTeclaPressionada(KeyEventArgs e)
        {
            if ((e.KeyCode >= Keys.A && e.KeyCode <= Keys.Z))
            {
                textPesquisa.Text = textPesquisa.Text + e.KeyData.ToString().ToLower();
            }
            else if ((e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9))
            {
                textPesquisa.Text = textPesquisa.Text + e.KeyData.ToString().Replace("D", "").ToLower();
            }
            else if ((e.KeyCode == Keys.Space))
            {
                textPesquisa.Text = textPesquisa.Text + " ";
            }
            else if ((e.KeyCode == Keys.Back) && (textPesquisa.Text.Length > 0))
            {
                textPesquisa.Text = textPesquisa.Text.Substring(0, textPesquisa.Text.Length - 1);
            }
            else if (e.KeyCode == Keys.Enter)
            {
                OpenFileFromPath(lbAtalhos.Text);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                textPesquisa.Focus();
            }
        }

        private void lbAtalhos_KeyDown(object sender, KeyEventArgs e)
        {
            TrataTeclaPressionada(e);
        }

        private void lbAtalhos_SelectedIndexChanged(object sender, EventArgs e)
        {
            showHint();
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            maximizar();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                minimizar();
            }
        }

        private void OpenFileFromPath(string path)
        {
            if (lbAtalhos.Items.Count > 0)
            {
                atalhos.StartProgramFromPath(path);
                //minimizar();
                Close();
            }

        }

        public void minimizar()
        {
            this.Visible = false;
            this.ShowInTaskbar = false;
            this.WindowState = FormWindowState.Minimized;
            notifyIcon1.Visible = true;
        }

        public void maximizar()
        {
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
            notifyIcon1.Visible = false;
        }

        private void showHint()
        {
            var tooltip = new ToolTip();
            tooltip.Hide(lbAtalhos);
            tooltip.SetToolTip(lbAtalhos, lbAtalhos.Text);
            tooltip.Show(lbAtalhos.Text, lbAtalhos);
        }

        private void textPesquisa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void CreateShortcut()
        {
            object shDesktop = (object)"Desktop";
            WshShell shell = new WshShell();
            string shortcutAddress = (string)shell.SpecialFolders.Item(ref shDesktop) + @"\Jump.lnk";
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutAddress);
            shortcut.Description = "Jump o localizador de atalhos";
            shortcut.Hotkey = "Ctrl+F3";
            shortcut.TargetPath = Application.ExecutablePath;
            shortcut.Save();
        }

        private void lvAtalhos_SelectedIndexChanged(object sender, EventArgs e)
        {
            showHint();
        }

        private void lvAtalhos_KeyDown(object sender, KeyEventArgs e)
        {
            TrataTeclaPressionada(e);
        }

        private void lvAtalhos_DoubleClick(object sender, EventArgs e)
        {
            //OpenFileFromPath(lvAtalhos.Text);
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {

        }
    }
}
