using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace DatabaseLib
{
    public static class ChoferesDB
    {
        public static int AddChofer(Chofer chofer,int Id_cliente)
        {
            SqlConnection connection = RecoleccionDB.GetConnection();
            string strInsert = "INSERT tblChoferes "
                + "(Nombre,ClientesID)"
                + " VALUES (@Nombre,@ClientesID)";
            SqlCommand insertCommand = new SqlCommand(strInsert, connection);
            insertCommand.Parameters.AddWithValue("@Nombre", chofer.Nombre);
            insertCommand.Parameters.AddWithValue("@ClientesID",Id_cliente );
            try
            {
                connection.Open();
                insertCommand.ExecuteNonQuery();
                string strSelect = "SELECT IDENT_CURRENT('tblChoferes') FROM tblChoferes";
                SqlCommand selectCommand = new SqlCommand(strSelect, connection);
                int choferID = Convert.ToInt32(selectCommand.ExecuteScalar());
                return choferID;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }

        }
    }
}
