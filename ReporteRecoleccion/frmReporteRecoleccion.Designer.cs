namespace ReporteRecoleccion
{
    partial class frmReporteRecoleccion
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
            this.dtpFechaInicial = new System.Windows.Forms.DateTimePicker();
            this.lblFechaInicial = new System.Windows.Forms.Label();
            this.lblFechaFinal = new System.Windows.Forms.Label();
            this.dtpFechaFinal = new System.Windows.Forms.DateTimePicker();
            this.lblFolio = new System.Windows.Forms.Label();
            this.txtFolio = new System.Windows.Forms.TextBox();
            this.btnObtener = new System.Windows.Forms.Button();
            this.pnlFolio = new System.Windows.Forms.Panel();
            this.chkFolio = new System.Windows.Forms.CheckBox();
            this.pnlConditions = new System.Windows.Forms.Panel();
            this.chkFecha = new System.Windows.Forms.CheckBox();
            this.cmbEmpresa = new System.Windows.Forms.ComboBox();
            this.cmbChofer = new System.Windows.Forms.ComboBox();
            this.pnlFolio.SuspendLayout();
            this.pnlConditions.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtpFechaInicial
            // 
            this.dtpFechaInicial.Enabled = false;
            this.dtpFechaInicial.Location = new System.Drawing.Point(117, 100);
            this.dtpFechaInicial.Name = "dtpFechaInicial";
            this.dtpFechaInicial.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaInicial.TabIndex = 0;
            // 
            // lblFechaInicial
            // 
            this.lblFechaInicial.AutoSize = true;
            this.lblFechaInicial.Location = new System.Drawing.Point(114, 75);
            this.lblFechaInicial.Name = "lblFechaInicial";
            this.lblFechaInicial.Size = new System.Drawing.Size(70, 13);
            this.lblFechaInicial.TabIndex = 1;
            this.lblFechaInicial.Text = "Fecha Inicial:";
            // 
            // lblFechaFinal
            // 
            this.lblFechaFinal.AutoSize = true;
            this.lblFechaFinal.Location = new System.Drawing.Point(350, 75);
            this.lblFechaFinal.Name = "lblFechaFinal";
            this.lblFechaFinal.Size = new System.Drawing.Size(65, 13);
            this.lblFechaFinal.TabIndex = 2;
            this.lblFechaFinal.Text = "Fecha Final:";
            // 
            // dtpFechaFinal
            // 
            this.dtpFechaFinal.Enabled = false;
            this.dtpFechaFinal.Location = new System.Drawing.Point(353, 100);
            this.dtpFechaFinal.Name = "dtpFechaFinal";
            this.dtpFechaFinal.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaFinal.TabIndex = 3;
            // 
            // lblFolio
            // 
            this.lblFolio.AutoSize = true;
            this.lblFolio.Location = new System.Drawing.Point(190, 15);
            this.lblFolio.Name = "lblFolio";
            this.lblFolio.Size = new System.Drawing.Size(32, 13);
            this.lblFolio.TabIndex = 4;
            this.lblFolio.Text = "Folio:";
            // 
            // txtFolio
            // 
            this.txtFolio.Enabled = false;
            this.txtFolio.Location = new System.Drawing.Point(228, 11);
            this.txtFolio.Name = "txtFolio";
            this.txtFolio.Size = new System.Drawing.Size(100, 20);
            this.txtFolio.TabIndex = 5;
            // 
            // btnObtener
            // 
            this.btnObtener.Location = new System.Drawing.Point(252, 258);
            this.btnObtener.Name = "btnObtener";
            this.btnObtener.Size = new System.Drawing.Size(143, 30);
            this.btnObtener.TabIndex = 6;
            this.btnObtener.Text = "Obtener";
            this.btnObtener.UseVisualStyleBackColor = true;
            this.btnObtener.Click += new System.EventHandler(this.btnObtener_Click);
            // 
            // pnlFolio
            // 
            this.pnlFolio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFolio.Controls.Add(this.chkFolio);
            this.pnlFolio.Controls.Add(this.lblFolio);
            this.pnlFolio.Controls.Add(this.txtFolio);
            this.pnlFolio.Location = new System.Drawing.Point(24, 22);
            this.pnlFolio.Name = "pnlFolio";
            this.pnlFolio.Size = new System.Drawing.Size(688, 43);
            this.pnlFolio.TabIndex = 7;
            // 
            // chkFolio
            // 
            this.chkFolio.AutoSize = true;
            this.chkFolio.Location = new System.Drawing.Point(16, 11);
            this.chkFolio.Name = "chkFolio";
            this.chkFolio.Size = new System.Drawing.Size(145, 17);
            this.chkFolio.TabIndex = 6;
            this.chkFolio.Text = "Buscar bitacoras por folio";
            this.chkFolio.UseVisualStyleBackColor = true;
            this.chkFolio.CheckedChanged += new System.EventHandler(this.chkFolio_CheckedChanged);
            // 
            // pnlConditions
            // 
            this.pnlConditions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlConditions.Controls.Add(this.cmbChofer);
            this.pnlConditions.Controls.Add(this.cmbEmpresa);
            this.pnlConditions.Controls.Add(this.chkFecha);
            this.pnlConditions.Controls.Add(this.lblFechaInicial);
            this.pnlConditions.Controls.Add(this.dtpFechaInicial);
            this.pnlConditions.Controls.Add(this.lblFechaFinal);
            this.pnlConditions.Controls.Add(this.dtpFechaFinal);
            this.pnlConditions.Location = new System.Drawing.Point(24, 83);
            this.pnlConditions.Name = "pnlConditions";
            this.pnlConditions.Size = new System.Drawing.Size(688, 147);
            this.pnlConditions.TabIndex = 8;
            // 
            // chkFecha
            // 
            this.chkFecha.AutoSize = true;
            this.chkFecha.Location = new System.Drawing.Point(16, 75);
            this.chkFecha.Name = "chkFecha";
            this.chkFecha.Size = new System.Drawing.Size(81, 17);
            this.chkFecha.TabIndex = 4;
            this.chkFecha.Text = "Usar Fecha";
            this.chkFecha.UseVisualStyleBackColor = true;
            this.chkFecha.CheckedChanged += new System.EventHandler(this.chkFecha_CheckedChanged);
            // 
            // cmbEmpresa
            // 
            this.cmbEmpresa.FormattingEnabled = true;
            this.cmbEmpresa.Location = new System.Drawing.Point(16, 20);
            this.cmbEmpresa.Name = "cmbEmpresa";
            this.cmbEmpresa.Size = new System.Drawing.Size(121, 21);
            this.cmbEmpresa.TabIndex = 5;
            this.cmbEmpresa.Text = "Empresa";
            this.cmbEmpresa.SelectedIndexChanged += new System.EventHandler(this.cmbEmpresa_SelectedIndexChanged);
            this.cmbEmpresa.Leave += new System.EventHandler(this.cmbEmpresa_Leave);
            // 
            // cmbChofer
            // 
            this.cmbChofer.FormattingEnabled = true;
            this.cmbChofer.Location = new System.Drawing.Point(193, 20);
            this.cmbChofer.Name = "cmbChofer";
            this.cmbChofer.Size = new System.Drawing.Size(121, 21);
            this.cmbChofer.TabIndex = 6;
            this.cmbChofer.Text = "Chofer";
            // 
            // frmReporteRecoleccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 300);
            this.Controls.Add(this.pnlConditions);
            this.Controls.Add(this.pnlFolio);
            this.Controls.Add(this.btnObtener);
            this.Name = "frmReporteRecoleccion";
            this.Text = "Reporte Recoleccion";
            this.pnlFolio.ResumeLayout(false);
            this.pnlFolio.PerformLayout();
            this.pnlConditions.ResumeLayout(false);
            this.pnlConditions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpFechaInicial;
        private System.Windows.Forms.Label lblFechaInicial;
        private System.Windows.Forms.Label lblFechaFinal;
        private System.Windows.Forms.DateTimePicker dtpFechaFinal;
        private System.Windows.Forms.Label lblFolio;
        private System.Windows.Forms.TextBox txtFolio;
        private System.Windows.Forms.Button btnObtener;
        private System.Windows.Forms.Panel pnlFolio;
        private System.Windows.Forms.CheckBox chkFolio;
        private System.Windows.Forms.Panel pnlConditions;
        private System.Windows.Forms.ComboBox cmbChofer;
        private System.Windows.Forms.ComboBox cmbEmpresa;
        private System.Windows.Forms.CheckBox chkFecha;
    }
}

