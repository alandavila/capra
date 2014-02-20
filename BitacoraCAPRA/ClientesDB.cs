﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace BitacoraCAPRA
{
    public static class ClientesDB
    {
        //returns a list of clients
        public static List<Cliente> GetClients()
        { 
            List<Cliente> Clientes = new List<Cliente>();
            SqlConnection connection = RecoleccionDB.GetConnection();
            //obtener clientes y choferes uniendo las dos bases de datos
            string selectStatement = "SELECT tblClientes.ClientesID, tblClientes.Nombre, tblClientes.Direccion, tblClientes.CodigoPostal,tblClientes.Ciudad,tblClientes.Telefono, tblClientes.RFC,"
                                    +" tblChoferes.ChoferID, tblChoferes.Nombre AS NombreChofer "
                                    + " FROM tblClientes INNER JOIN tblChoferes "
                                    + " ON tblClientes.ClientesID = tblChoferes.ClientesID "
                                    + "ORDER BY tblClientes.ClientesID";

            SqlCommand selectCommand = new SqlCommand(selectStatement,connection);
            try
            {
                connection.Open();
                SqlDataReader reader = selectCommand.ExecuteReader();
                string previusClient = "none";
                Cliente cliente = new Cliente();
                Chofer  chofer  = new Chofer();
                while (reader.Read())
                {
                    if (previusClient == "none")
                    {
                        cliente = new Cliente();
                        cliente.ClienteID = reader["ClientesID"].ToString();
                        cliente.Nombre = reader["Nombre"].ToString();
                        cliente.Direction = reader["Direccion"].ToString();
                        cliente.CodigoPostal = reader["CodigoPostal"].ToString();
                        cliente.Ciudad = reader["Ciudad"].ToString();
                        cliente.Telefono = reader["Telefono"].ToString();
                        cliente.RFC = reader["RFC"].ToString();
                    }
                    if (previusClient != reader["ClientesID"].ToString() && previusClient != "none")
                    {
                        Clientes.Add(cliente);
                        cliente = new Cliente();
                        chofer  = new Chofer();
                        cliente.ClienteID = reader["ClientesID"].ToString();
                        cliente.Nombre = reader["Nombre"].ToString();
                        cliente.Direction = reader["Direccion"].ToString();
                        cliente.CodigoPostal = reader["CodigoPostal"].ToString();
                        cliente.Ciudad = reader["Ciudad"].ToString();
                        cliente.Telefono = reader["Telefono"].ToString();
                        cliente.RFC = reader["RFC"].ToString();
                        chofer.ChoferID = reader["ChoferID"].ToString();
                        chofer.Nombre = reader["NombreChofer"].ToString();
                        cliente.choferes.Add(chofer);
                    }
                    else
                    {
                        chofer = new Chofer();
                        chofer.ChoferID = reader["ChoferID"].ToString();
                        chofer.Nombre = reader["NombreChofer"].ToString();
                        cliente.choferes.Add(chofer);
                    }
                    previusClient = reader["ClientesID"].ToString();

                }
                reader.Close();
                Clientes.Add(cliente);
            }
            catch (SqlException ex)
            {
                //exception will be handled by the code where this class is used
                throw ex;
            }
            finally
            {
                connection.Close();
            }

            return Clientes;
        }
        //returns a sorted list of clients, overloading GetClients
        public static SortedList<string,Cliente> GetClientsList()
        {
            SortedList<string,Cliente> Clientes = new SortedList<string,Cliente>();
            SqlConnection connection = RecoleccionDB.GetConnection();
            //obtener clientes y choferes uniendo las dos bases de datos
            string selectStatement = "SELECT tblClientes.ClientesID, tblClientes.Nombre, tblClientes.Direccion, tblClientes.CodigoPostal,tblClientes.Ciudad,tblClientes.Telefono, tblClientes.RFC,"
                                    + " tblChoferes.ChoferID, tblChoferes.Nombre AS NombreChofer "
                                    + " FROM tblClientes INNER JOIN tblChoferes "
                                    + " ON tblClientes.ClientesID = tblChoferes.ClientesID "
                                    + "ORDER BY tblClientes.ClientesID";

            SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = selectCommand.ExecuteReader();
                string previusClient = "none";
                string previusClientName = "none";
                Cliente cliente = new Cliente();
                Chofer  chofer = new Chofer();
                while (reader.Read())
                {
                    if (previusClient == "none")
                    {
                        cliente = new Cliente();
                        cliente.ClienteID = reader["ClientesID"].ToString();
                        cliente.Nombre = reader["Nombre"].ToString();
                        cliente.Direction = reader["Direccion"].ToString();
                        cliente.CodigoPostal = reader["CodigoPostal"].ToString();
                        cliente.Ciudad = reader["Ciudad"].ToString();
                        cliente.Telefono = reader["Telefono"].ToString();
                        cliente.RFC = reader["RFC"].ToString();
                    }
                    if (previusClient != reader["ClientesID"].ToString() && previusClient != "none")
                    {
                        Clientes.Add(previusClientName,cliente);
                        cliente = new Cliente();
                        chofer  = new Chofer();
                        cliente.ClienteID = reader["ClientesID"].ToString();
                        cliente.Nombre = reader["Nombre"].ToString();
                        cliente.Direction = reader["Direccion"].ToString();
                        cliente.CodigoPostal = reader["CodigoPostal"].ToString();
                        cliente.Ciudad = reader["Ciudad"].ToString();
                        cliente.Telefono = reader["Telefono"].ToString();
                        cliente.RFC = reader["RFC"].ToString();
                        chofer.ChoferID = reader["ChoferID"].ToString();
                        chofer.Nombre = reader["NombreChofer"].ToString();
                        cliente.choferes.Add(chofer);
                        
                    }
                    else
                    {
                        chofer = new Chofer();
                        chofer.ChoferID = reader["ChoferID"].ToString();
                        chofer.Nombre = reader["NombreChofer"].ToString();
                        cliente.choferes.Add(chofer);
                    }
                    previusClient = reader["ClientesID"].ToString();
                    previusClientName = reader["Nombre"].ToString().Trim();
                }
                reader.Close();
                Clientes.Add(previusClientName, cliente);
            }
            catch (SqlException ex)
            {
                //exception will be handled by the code where this class is used
                throw ex;
            }
            finally
            {
                connection.Close();
            }

            return Clientes;
        }
    }
}
