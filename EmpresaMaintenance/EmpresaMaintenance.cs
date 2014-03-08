using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ValidationLib;
using DatabaseLib;

namespace EmpresaMaintenance
{
    public partial class EmpresaMaintenance : Form
    {
        public EmpresaMaintenance()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Validator validator = new Validator();
            if (validator.IsPresent(this.txtNombre,"Nombre "))
                if(validator.IsPresent(this.txtDireccion,"Direccion "))
            {
                Cliente nuevo_cliente = new Cliente();
                nuevo_cliente.Nombre = this.txtNombre.Text;
                nuevo_cliente.Direction = this.txtDireccion.Text;
                if (validator.IsPresent(this.txtCiudad, "Ciudad "))
                    nuevo_cliente.Ciudad = this.txtCiudad.Text; 
                if (validator.IsPresent(this.txtCodigoPostal, "Codigo Postal "))
                    nuevo_cliente.CodigoPostal = this.txtCodigoPostal.Text;
                if (validator.IsPresent(this.txtRFC, "RFC "))
                    nuevo_cliente.RFC = this.txtRFC.Text;
                if (validator.IsPresent(this.txtTelefono, "Telefone "))
                    nuevo_cliente.Telefono = this.txtTelefono.Text;
                //Guardar cliente en base de datos
                try
                {
                    //bitacora.BitacoraID = DatabaseLib.BitacoraDB.AddBitacora(bitacora);
                    this.DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("en EmpresaMaintenance.cs,btnGuardar_Click " + ex.Message, ex.GetType().ToString());
                }
            }
        }
    }
}
