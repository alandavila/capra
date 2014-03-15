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
                else
                    nuevo_cliente.Ciudad = "NA";
                if (validator.IsPresent(this.txtCodigoPostal, "Codigo Postal ") && validator.ValidateNumberInt(this.txtCodigoPostal.Text))
                    nuevo_cliente.CodigoPostal = this.txtCodigoPostal.Text;
                else
                    nuevo_cliente.CodigoPostal = "0";
                if (validator.IsPresent(this.txtRFC, "RFC "))
                    nuevo_cliente.RFC = this.txtRFC.Text;
                else
                    nuevo_cliente.RFC = "NA";
                if (validator.IsPresent(this.txtTelefono, "Telefone "))
                    nuevo_cliente.Telefono = this.txtTelefono.Text;
                else
                    nuevo_cliente.Telefono = "NA";
                //Guardar cliente en base de datos
               // try
               // {
                    nuevo_cliente.ClienteID = DatabaseLib.ClientesDB.AddCliente(nuevo_cliente).ToString();
                    this.DialogResult = DialogResult.OK;
               // }
               /* catch (Exception ex)
                {
                    MessageBox.Show("en EmpresaMaintenance.cs,btnGuardar_Click " + ex.Message, ex.GetType().ToString());
                }*/
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
