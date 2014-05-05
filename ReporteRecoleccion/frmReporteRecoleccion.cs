using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DatabaseLib;

namespace ReporteRecoleccion
{
    public partial class frmReporteRecoleccion : Form
    {
        public frmReporteRecoleccion()
        {
            InitializeComponent();
        }

        private void btnObtener_Click(object sender, EventArgs e)
        {
            List<Bitacora> bitacoras = new List<Bitacora>();
            bitacoras = BitacoraDB.GetBitacoras();
            
            var bitacorasList = from bitacora in bitacoras select bitacora;
            string teststr = "";
            foreach (var bitacora in bitacorasList) { 
                   teststr += bitacora.BitacoraID+" ";
            }
            MessageBox.Show(teststr,"Empresas en Base de datos ");
       
        }
    }
}
