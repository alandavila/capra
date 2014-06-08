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
            bitacoras = DatabaseLib.BitacoraDB.GetBitacoras();
            //if user clicks Obtener twice the list will be filled already
            lvBitacoras.Items.Clear();

            var bitacorasList = from bitacora in bitacoras select bitacora;
            string teststr = "";
            int i = 0;
            foreach (var bitacora in bitacorasList) {
                this.lvBitacoras.Items.Add(bitacora.BitacoraID.ToString());
                this.lvBitacoras.Items[i].SubItems.Add(bitacora.Empresa.Trim());
                this.lvBitacoras.Items[i].SubItems.Add(bitacora.HoraEntrada.Trim());
                this.lvBitacoras.Items[i].SubItems.Add(bitacora.NumTambos.ToString().Trim());
                this.lvBitacoras.Items[i].SubItems.Add(bitacora.Total.ToString().Trim());
                i += 1;
                   teststr += bitacora.Empresa.Trim() +" ";
            }
            MessageBox.Show(teststr,"Empresas en Base de datos ");
       
        }
    }
}
