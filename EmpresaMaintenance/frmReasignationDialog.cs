using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DatabaseLib;

namespace EmpresaMaintenance
{
    public partial class frmReasignationDialog : Form
    {
        public frmReasignationDialog()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            ClienteProductorDB.DeletEntry(1, 2);
            ClienteProductorDB.AddEntry(3, 4);
        }
    }
}
