namespace ListaAtalhos
{
    partial class FormStatusPesquisa
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbPastas = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lbPastas
            // 
            this.lbPastas.FormattingEnabled = true;
            this.lbPastas.Location = new System.Drawing.Point(0, 53);
            this.lbPastas.Name = "lbPastas";
            this.lbPastas.Size = new System.Drawing.Size(284, 212);
            this.lbPastas.TabIndex = 0;
            // 
            // FormStatusPesquisa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.lbPastas);
            this.Name = "FormStatusPesquisa";
            this.Text = "FormStatusPesquisa";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbPastas;
    }
}