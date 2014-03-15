﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ValidationLib;
using DatabaseLib;
using EmpresaMaintenance;
using ChoferMaintenance;

namespace BitacoraCAPRA
{
    public partial class BitacoraCAPRA : Form
    {
        //variables a guardar de la bitacora
        DateTime fechaBitacora = new DateTime();
        int _clienteID;
        int _choferID;
        SortedList<string,Cliente> listaClientes = new SortedList<string,Cliente>();
        List<Cliente> clientes = new List<Cliente>();
        List<Chofer> choferes = new List<Chofer>();

        public BitacoraCAPRA()
        {
            InitializeComponent();
            //fill clientes combo box
            this.LoadEmpresaComboBox();
        }        

        public bool IsPresent(TextBox textBox, string name)
        {
            if (textBox.Text == "")
            {
                MessageBox.Show(name + " no ha sido capturado(a) ", "Faltan Datos");
                textBox.Focus();
                return false;
            }
            return true;
        }
        //overload IsPresent
        public bool IsPresent(ComboBox comboBox, string name)
        {
            if (comboBox.Text  == "")
            {
                MessageBox.Show(name + " no ha sido capturado(a) ", "Faltan Datos");
                comboBox.Focus();
                return false;
            }
            return true;
        }
        //populate Empresa combo box
        private void LoadChoferComboBox()
        {
            choferes = listaClientes[cmbEmpresa.Text.Trim()].choferes;
            cmbChofer.DataSource = choferes;
            cmbChofer.DisplayMember = "Nombre";
            cmbChofer.ValueMember = "ChoferID";
        }
        //populate Empresa combo box
        private void LoadEmpresaComboBox()
        {
            try
            {
                clientes = ClientesDB.GetClients();
                cmbEmpresa.DataSource = clientes;
                //tengo que usar un methodo (get) de Cliente
                //que es el elemento de la "list"
                cmbEmpresa.DisplayMember = "Nombre";
                cmbEmpresa.ValueMember = "ClienteID";
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,ex.GetType().ToString());
 
            }
        }

        private void txtFecha_Leave(object sender, EventArgs e)
        {
            //validar aqui la fecha tiene que ser dia/mes/anio
            
            string fechaUsuario = this.cmbDia.Text;
            fechaUsuario = fechaUsuario.Trim();
            string[] fechaArray = fechaUsuario.Split('/');


            DateTime today = DateTime.Now;
            fechaBitacora = today;
            if(fechaArray.Length >=2)
            MessageBox.Show(fechaArray[1], "Fecha");

            ////la bitacora tiene que tener fecha
            //if (this.txtFecha.Text == "") 
            //{
            //    MessageBox.Show("La bitacora requiere fecha.","Faltan Datos");      
            //    txtFecha.Focus();
            //}

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //Asegurando que la bitacora tiene TODOS los datos necesarios
            if (this.IsPresent(this.cmbDia, "dia") == true)
            if (this.IsPresent(this.cmbMes, "mes") == true)
            if (this.IsPresent(this.cmbYear, "año") == true)
            if (this.IsPresent(this.cmbEmpresa, "EMPRESA") == true)
            if (this.IsPresent(this.cmbChofer, "CHOFER") == true)
            if (this.IsPresent(this.txtNoCamion, "NUMERO DE CAMION") == true)
            if (this.IsPresent(this.txtHrEntrada, "HORA DE ENTRADA") == true)
            if (this.IsPresent(this.txtHrSalida, "HORA DE SALIDA") == true)
            if (this.IsPresent(this.txtNS, "N/S") == true)
            if (this.IsPresent(this.txtCantidadTambos, "CANTIDAD DE TAMBOS") == true) {
            //Llenar la clase bitacora con la informacion en bitacoraCapra
                Bitacora bitacora = new Bitacora();
                bitacora.Folio = 0;//por ahora
                //in development...
               // int comboboxEmpresaInx = this.cmbEmpresa.SelectedIndex;
                //_clienteID = Convert.ToInt32((List<Cliente>)cmbEmpresa.DataSource[comboboxEmpresaInx].);
                bitacora.ClienteID = _clienteID;
                bitacora.ChoferID = _choferID;

                bitacora.NS = Convert.ToInt32(this.txtNS.Text);
                bitacora.Dia = Convert.ToInt32(this.cmbDia.Text);
                bitacora.Mes = Convert.ToInt32(this.cmbMes.Text);
                bitacora.Year = Convert.ToInt32(this.cmbYear.Text);
                bitacora.Empresa = this.cmbEmpresa.Text;
                bitacora.Chofer = this.cmbChofer.Text;
                bitacora.NumCamion = Convert.ToInt32(this.txtNoCamion.Text);
                bitacora.HoraEntrada = this.txtHrEntrada.Text;
                bitacora.HoraSalida = this.txtHrSalida.Text;
                bitacora.NumTambos = Convert.ToInt32(this.txtCantidadTambos.Text);
                bitacora.Observaciones = this.txtObservaciones.Text;
                //Imprimir la informacion
                MessageBox.Show((string)bitacora.InformationBitacora());
                //Guardar la informacion en un archivo de texto
                bitacora.CreateTxtFile();
                //Guardar bitacora en base de datos
                //if valid data... crear la clase de validacion de datos
                try
                {
                    bitacora.BitacoraID = DatabaseLib.BitacoraDB.AddBitacora(bitacora);
                    this.DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("en BitacoraCAPRA.cs,btnGuardar_Click " + ex.Message, ex.GetType().ToString());
                }
                                    
             }
            

        }

        private void cmbEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Cliente> clientes = new List<Cliente>();
            try
            {
                //get clients from database and fill the list with them
                clientes = ClientesDB.GetClients();
                //get a sorted list of clients with key =  name to use in form
                listaClientes = ClientesDB.GetClientsList();
                //get the index of the client selected in combo box
                int comboboxEmpresaIndx = cmbEmpresa.SelectedIndex;
                //use index to accsess clienteID of list item
                this._clienteID = Convert.ToInt32(clientes[comboboxEmpresaIndx].ClienteID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());

            }
        }
        private void cmbChofer_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Chofer chofi in choferes) {
                if (chofi.Nombre == this.cmbChofer.Text)
                    this._choferID = Convert.ToInt32(chofi.ChoferID);
            }
        }

        private void cmbEmpresa_Leave(object sender, EventArgs e)
        {

            this.LoadChoferComboBox();
            //MessageBox.Show("elegiste: "+cmbEmpresa.Text,"informacion");
        }

        private void txtHrEntrada_Leave(object sender, EventArgs e)
        {
            Validator validator = new Validator();
            if(!validator.ValidateHour(this.txtHrEntrada.Text))
            {
                MessageBox.Show("La hora de entrada requiere el formato:\n"+
                "HH:MM\n\n"+validator._message,"Cuidado!");
                this.txtHrEntrada.Text = "00:00";
            }
        }

        private void txtHrSalida_Leave(object sender, EventArgs e)
        {
            Validator validator = new Validator();
            if (!validator.ValidateHour(this.txtHrSalida.Text))
            {
                MessageBox.Show("La hora de salida requiere el formato:\n" +
                "HH:MM\n\n" + validator._message, "Cuidado!");
                this.txtHrSalida.Text = "00:00";
            }
            if (!validator.ValidateHour(this.txtHrEntrada.Text))
            {
                MessageBox.Show("La hora de entrada requiere el formato:\n" +
                "HH:MM\n\n" + validator._message, "Cuidado!");
                this.txtHrEntrada.Text = "00:00";
            }
            if (!validator.ValidateHourDiff(this.txtHrEntrada.Text, this.txtHrSalida.Text))
            {
                MessageBox.Show("Verifique que el formato y horas de entrada y salida"+
                "sea correcto: "+validator._message, "Cuidado!");
            }

        }

        private void txtNoCamion_Leave(object sender, EventArgs e)
        {
            Validator validator = new Validator();
            if (!validator.ValidateNumberInt(this.txtNoCamion.Text,this.lblCamion.Text))
            {
                MessageBox.Show("El numero de camion no es valido:\n"+ validator._message, "Cuidado!");
                this.txtNoCamion.Text = "0";
            }
        }

        private void txtCantidadTambos_Leave(object sender, EventArgs e)
        {
            Validator validator = new Validator();
            if (!validator.ValidateNumberInt(this.txtCantidadTambos.Text, this.lblCantidadTambos.Text))
            {
                MessageBox.Show("El numero de tambos no es valido:\n" + validator._message, "Cuidado!");
                this.txtCantidadTambos.Text = "0";
            }            
        }

        private void txtNS_Leave(object sender, EventArgs e)
        {
            Validator validator = new Validator();
            if (!validator.ValidateNumberInt(this.txtNS.Text, this.lblNS.Text))
            {
                MessageBox.Show("El NS no es valido:\n" + validator._message, "Cuidado!");
                this.txtNS.Text = "0";
            }            

        }

        private void btnNuevaEmpresa_Click(object sender, EventArgs e)
        {
            EmpresaMaintenance.EmpresaMaintenance frmEmpresaMaintenance = new EmpresaMaintenance.EmpresaMaintenance();
            this.AddOwnedForm(frmEmpresaMaintenance);
            frmEmpresaMaintenance.Show();
        }

        private void BitacoraCAPRA_Enter(object sender, EventArgs e)
        {
            this.LoadEmpresaComboBox();
        }

        private void btnNuevoChofer_Click(object sender, EventArgs e)
        {
            NuevoChofer frmChofer = new NuevoChofer();
            this.AddOwnedForm(frmChofer);
            frmChofer.Show();

        }

    }
}