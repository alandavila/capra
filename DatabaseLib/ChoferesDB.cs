using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DatabaseLib
{
    class ChoferesDB
    {
        //returns a list of choferes for a given client
        //PENDING IMPLEMENTATION, CODE BELOW WAS COPIED FROM CLIENTESDB.CS
        /*       public static List<Cliente> GetClients()
                {
                    List<Cliente> Clientes = new List<Cliente>();
                    SqlConnection connection = RecoleccionDB.GetConnection();
                    string selectStatement = "SELECT ClientesID, Nombre, Direccion, CodigoPostal,Ciudad,Telefono, RFC"
                                           + " FROM tblClientes "
                                           + "ORDER BY Nombre";
                    SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = selectCommand.ExecuteReader();
                        while (reader.Read())
                        {
                            Cliente cliente = new Cliente();
                            cliente.ClienteID = reader["ClientesID"].ToString();
                            cliente.Nombre = reader["Nombre"].ToString();
                            cliente.Direction = reader["Direccion"].ToString();
                            cliente.CodigoPostal = reader["CodigoPostal"].ToString();
                            cliente.Ciudad = reader["Ciudad"].ToString();
                            cliente.Telefono = reader["Telefono"].ToString();
                            cliente.RFC = reader["RFC"].ToString();
                            Clientes.Add(cliente);
                        }
                        reader.Close();
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
              */
    }
}
