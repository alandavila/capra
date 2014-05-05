using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace DatabaseLib
{
    public static class BitacoraDB
    {
        //get a list of bitacoras
        public static List<Bitacora> GetBitacoras() 
        {
            List<Bitacora> Bitacoras = new List<Bitacora>();
            SqlConnection connection = RecoleccionDB.GetConnection();
            string strSelect = "SELECT tblBitacoras.BitacorasID,tblBitacoras.ClientesID, "
                + " tblClientes.ClientesID"+" ,tblChoferes.ChoferID AS IDchofer"
                + " FROM tblBitacoras"
                + " LEFT  JOIN tblClientes ON tblBitacoras.ClientesID = tblClientes.ClientesID "            
                + " INNER JOIN tblChoferes ON tblClientes.ClientesID = tblChoferes.ClientesID "
                + " ORDER BY tblBitacoras.BitacorasID";
            /*
            string strSelect = "SELECT tblBitacoras.BitacorasID,tblBitacoras.CamionNum,tblBitacoras.NumS,"
                             + "tblBitacoras.HrEntrada,tblBitacoras.HrSalida,tblBitacoras.CantidadTambos, "
                             + "tblBitacoras.Dia,tblBitacoras.Mes,tblBitacoras.Ano,tblBitacoras.PrecioUnitario,"
                             + "tblBitacoras.Subtotal,tblBitacoras.IVA,tblBitacoras.Total, " 
                             + "tblClientes.ClientesID, tblClientes.Nombre, tblClientes.Direccion, tblClientes.CodigoPostal,tblClientes.Ciudad,tblClientes.Telefono, tblClientes.RFC,"
                             + "tblChoferes.ChoferID, tblChoferes.Nombre AS NombreChofer "
                             + "FROM tblBitacoras LEFT JOIN tblClientes ON tblBitacoras.ClientesID = tblClientes.ClientesID "
                             + " LEFT outer JOIN tblChoferes "
                             + " ON tblClientes.ClientesID = tblChoferes.ClientesID "
                             + "ORDER BY tblBitacoras.BitacorasID";
            */
            SqlCommand cmdGetbitacoras = new SqlCommand(strSelect, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = cmdGetbitacoras.ExecuteReader();
                while (reader.Read())
                {
                    Bitacora bitacora = new Bitacora();
                    bitacora.BitacoraID = (int)reader["BitacorasID"];
                    bitacora.Folio = 0;
                    bitacora.ClienteID = (int)reader["ClientesID"];
                    //if(reader["choferID"]!= null)
                    bitacora.ChoferID = (int)reader["IDchofer"];
                //    bitacora.NumCamion = (int)reader["CamionNum"];
                 //   bitacora.NS = (int)reader["NumS"];
            /*        bitacora.HoraEntrada = reader["HrEntrada"].ToString();
                    bitacora.HoraSalida = reader["HrSalida"].ToString();
                    bitacora.NumTambos = (int)reader["CantidadTambos"];
                    //bitacora.Observaciones = reader["vservaciones"].ToString();
                    bitacora.Dia = (int)reader["Dia"];
                    bitacora.Mes = (int)reader["Mes"];
                    bitacora.Year = (int)reader["Ano"];
                    bitacora.PrecioUnitario = (double)reader["PrecioUnitario"];
                    bitacora.Iva = (double)reader["IVA"];
                    bitacora.Total = (double)reader["Total"];
                    bitacora.Chofer = reader["Nombre"].ToString();
                    bitacora.Empresa = reader["NombreChofer"].ToString();
                    
              */      Bitacoras.Add(bitacora);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                //external code will take care of exception
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return Bitacoras;

        }
        //get bitacora by BitacorasID, change later to folio!!s
        public static Bitacora GetBitacora(int BitacoraID)
        {
            SqlConnection connection = RecoleccionDB.GetConnection();
            string strSelect = "SELECT BitacorasID,folio, ClientesID, ChoferID, CamionNum,"
                              + "NumS, HrEntrada, HrSalida, CantidadTambos, Observaciones,"
                              + "Dia, Mes, Ano, PrecioUnitario, Subtotal, IVA, Total"
                              + " FROM tblBitacoras WHERE BitacoraID = @BitacoraID";

            SqlCommand command = new SqlCommand(strSelect, connection);
            command.Parameters.AddWithValue("@BitacoraID", BitacoraID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    Bitacora bitacora = new Bitacora();
                    bitacora.BitacoraID = (int)reader["BitacoraID"];
                    bitacora.Folio = (int)reader["folio"];
                    bitacora.ClienteID = (int)reader["ClientesID"];
                    bitacora.ChoferID = (int)reader["ChoferID"];
                    bitacora.NumCamion = (int)reader["CamionNum"];
                    bitacora.NS = (int)reader["NumS"];
                    bitacora.HoraEntrada = reader["HrEntrada"].ToString();
                    bitacora.HoraSalida = reader["HrSalida"].ToString();
                    bitacora.NumTambos = (int)reader["CantidadTambos"];
                    bitacora.Observaciones = reader["vservaciones"].ToString();
                    bitacora.Dia = (int)reader["Dia"];
                    bitacora.Mes = (int)reader["Mes"];
                    bitacora.Year = (int)reader["Ano"];
                    bitacora.PrecioUnitario = (double)reader["PrecioUnitario"];
                    bitacora.Iva = (double)reader["IVA"];
                    bitacora.Total = (double)reader["Total"];
                    return bitacora;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                //external code will take care of exception
                throw ex;
            }
            finally
            {
                connection.Close();
            }

        }

        public static int AddBitacora(Bitacora bitacora)
        {
            SqlConnection connection = RecoleccionDB.GetConnection();
            string strInsert = "INSERT tblBitacoras "
                + "(ClientesID, folio,CamionNum,NumS,HrEntrada,"
                + "HrSalida, CantidadTambos, Observaciones,Dia,Mes,Ano,PrecioUnitario,"
                + "Subtotal,IVA,Total,ChoferID)"
                + " VALUES (@ClientesID,@folio,@CamionNum,@NumS,@HrEntrada,"
                + "@HrSalida,@CantidadTambos,@Observaciones,@Dia,@Mes,@Ano,@PrecioUnitario,"
                + "@Subtotal,@IVA,@Total,@ChoferID)";
            SqlCommand insertCommand = new SqlCommand(strInsert, connection);
            TimeSpan ts = new TimeSpan();
            ts = TimeSpan.Parse(bitacora.HoraEntrada);
            insertCommand.Parameters.AddWithValue("@ClientesID", bitacora.ClienteID);
            insertCommand.Parameters.AddWithValue("@folio", bitacora.Folio);
            insertCommand.Parameters.AddWithValue("@CamionNum", bitacora.NumCamion);
            insertCommand.Parameters.AddWithValue("@NumS", bitacora.NS);
            insertCommand.Parameters.AddWithValue("@HrEntrada", ts);
            ts = TimeSpan.Parse(bitacora.HoraSalida);
            insertCommand.Parameters.AddWithValue("@HrSalida", ts);
            insertCommand.Parameters.AddWithValue("@CantidadTambos", bitacora.NumTambos);
            insertCommand.Parameters.AddWithValue("@Observaciones", bitacora.Observaciones);
            insertCommand.Parameters.AddWithValue("@Dia", bitacora.Dia);
            insertCommand.Parameters.AddWithValue("@Mes", bitacora.Mes);
            insertCommand.Parameters.AddWithValue("@Ano", bitacora.Year);
            insertCommand.Parameters.AddWithValue("@PrecioUnitario", bitacora.PrecioUnitario);
            insertCommand.Parameters.AddWithValue("@Subtotal", bitacora.Subotal);
            insertCommand.Parameters.AddWithValue("@IVA", bitacora.Iva);
            insertCommand.Parameters.AddWithValue("@Total", bitacora.Total);
            insertCommand.Parameters.AddWithValue("@ChoferID", bitacora.ChoferID);
            try
            {
                connection.Open();
                insertCommand.ExecuteNonQuery();
                string strSelect = "SELECT IDENT_CURRENT('tblBitacoras') FROM tblBitacoras";
                SqlCommand selectCommand = new SqlCommand(strSelect, connection);
                int bitacoraID = Convert.ToInt32(selectCommand.ExecuteScalar());
                return bitacoraID;

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
        public static bool UpdateBitacora(Bitacora oldBitacora, Bitacora newBitacora)
        {
            SqlConnection connection = RecoleccionDB.GetConnection();
            string strupdate = "UPDATE tblBitacoras SET"
                + "ClientesID = @newClientesID,"
                + "ChoferID = @newChoferID,"
                + "CamionNum = @newCamionNum,"
                + "NumS = @newNumS,"
                + "HrEntrada = @newHrEntrada,"
                + "HrSalida = @newHrSalida,"
                + "CantidadTambos = @newCantidadTambos,"
                + "Observaciones  =@newObservaciones,"
                + "Dia = @newDia,"
                + "Mes = @newMes,"
                + "Ano = @newAno,"
                + "PrecioUnitario = @newPrecioUnitario,"
                + "Subtotal = @newSubtotal,"
                + "IVA = @newIVA,"
                + "Total = @newTotal"
                + "WHERE "
                + "ClientesID = @oldClientesID"
                + "AND ChoferID = @oldChoferID,"
                + "AND CamionNum = @oldCamionNum,"
                + "AND NumS = @oldNumS,"
                + "AND HrEntrada = @oldHrEntrada,"
                + "AND HrSalida = @oldHrSalida,"
                + "AND CantidadTambos = @oldCantidadTambos,"
                + "AND Observaciones  =@oldObservaciones,"
                + "AND Dia = @oldDia,"
                + "AND Mes = @oldMes,"
                + "AND Ano = @oldAno,"
                + "AND PrecioUnitario = @oldPrecioUnitario,"
                + "AND Subtotal = @oldSubtotal,"
                + "AND IVA = @oldIVA,"
                + "AND Total = @oldTotal"
                ;
            SqlCommand updateCommand = new SqlCommand(strupdate, connection);
            updateCommand.Parameters.AddWithValue("@newClientesID", newBitacora.ClienteID);
            updateCommand.Parameters.AddWithValue("@newChoferID", newBitacora.ChoferID);
            updateCommand.Parameters.AddWithValue("@newCamionNum", newBitacora.NumCamion);
            updateCommand.Parameters.AddWithValue("@newNumS", newBitacora.NS);
            updateCommand.Parameters.AddWithValue("@newHrEntrada", newBitacora.HoraEntrada);
            updateCommand.Parameters.AddWithValue("@newHrSalida", newBitacora.HoraSalida);
            updateCommand.Parameters.AddWithValue("@newCantidadTambos", newBitacora.NumTambos);
            updateCommand.Parameters.AddWithValue("@newObservaciones", newBitacora.Observaciones);
            updateCommand.Parameters.AddWithValue("@newDia", newBitacora.Dia);
            updateCommand.Parameters.AddWithValue("@newMes", newBitacora.Mes);
            updateCommand.Parameters.AddWithValue("@newAno", newBitacora.Year);
            updateCommand.Parameters.AddWithValue("@newPrecioUnitario", newBitacora.PrecioUnitario);
            updateCommand.Parameters.AddWithValue("@newSubtotal", newBitacora.Subotal);
            updateCommand.Parameters.AddWithValue("@newIVA", newBitacora.Iva);
            updateCommand.Parameters.AddWithValue("@newTotal", newBitacora.Total);
            updateCommand.Parameters.AddWithValue("@oldClientesID", oldBitacora.ClienteID);
            updateCommand.Parameters.AddWithValue("@oldChoferID", oldBitacora.ChoferID);
            updateCommand.Parameters.AddWithValue("@oldCamionNum", oldBitacora.NumCamion);
            updateCommand.Parameters.AddWithValue("@oldNumS", oldBitacora.NS);
            updateCommand.Parameters.AddWithValue("@oldHrEntrada", oldBitacora.HoraEntrada);
            updateCommand.Parameters.AddWithValue("@oldHrSalida", oldBitacora.HoraSalida);
            updateCommand.Parameters.AddWithValue("@oldCantidadTambos", oldBitacora.NumTambos);
            updateCommand.Parameters.AddWithValue("@oldObservaciones", oldBitacora.Observaciones);
            updateCommand.Parameters.AddWithValue("@oldDia", oldBitacora.Dia);
            updateCommand.Parameters.AddWithValue("@oldMes", oldBitacora.Mes);
            updateCommand.Parameters.AddWithValue("@oldAno", oldBitacora.Year);
            updateCommand.Parameters.AddWithValue("@oldPrecioUnitario", oldBitacora.PrecioUnitario);
            updateCommand.Parameters.AddWithValue("@oldSubtotal", oldBitacora.Subotal);
            updateCommand.Parameters.AddWithValue("@oldIVA", oldBitacora.Iva);
            updateCommand.Parameters.AddWithValue("@oldTotal", oldBitacora.Total);

            try
            {
                connection.Open();
                int rowsAffected = updateCommand.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }

        }
        public static bool DeleteBitacora(Bitacora bitacora)
        {
            SqlConnection connection = RecoleccionDB.GetConnection();
            string strDelete = "DELETE FROM tblBitacoras "
                + "WHERE BitacorasID = @bitacorasID "
                + "AND folio = @folio "
                + "AND ClientesID = @clientesID "
                + "AND ChoferID = @choferID "
                + "AND CamionnNum = @camionNum "
                + "AND NumS = @numS "
                + "AND HrEntrada = @hrEntrada "
                + "AND HrSalida = @hrSalida "
                + "AND CantidadTambos = @cantidadTambos "
                + "AND Observaciones = @observaciones "
                + "AND  Dia = @dia "
                + "AND Mes = @mes "
                + "AND Ano = @ano "
                + "AND PrecioUnitario = @precioUnitario "
                + "AND Subtotal = @subtotal "
                + "AND IVA = @iva "
                + "AND Total = @total";
            SqlCommand deletecommand = new SqlCommand(strDelete, connection);
            deletecommand.Parameters.AddWithValue("@bitacorasID", bitacora.BitacoraID);
            deletecommand.Parameters.AddWithValue("@folio", bitacora.Folio);
            deletecommand.Parameters.AddWithValue("@clientesID", bitacora.ClienteID);
            deletecommand.Parameters.AddWithValue("@choferID", bitacora.ChoferID);
            deletecommand.Parameters.AddWithValue("@camionNum", bitacora.NumCamion);
            deletecommand.Parameters.AddWithValue("@numS", bitacora.NS);
            deletecommand.Parameters.AddWithValue("@hrEntrada", bitacora.HoraEntrada);
            deletecommand.Parameters.AddWithValue("@hrSalida", bitacora.HoraSalida);
            deletecommand.Parameters.AddWithValue("@cantidadTambos", bitacora.NumTambos);
            deletecommand.Parameters.AddWithValue("@Observaciones", bitacora.Observaciones);
            deletecommand.Parameters.AddWithValue("@dia", bitacora.Dia);
            deletecommand.Parameters.AddWithValue("@mes", bitacora.Mes);
            deletecommand.Parameters.AddWithValue("@ano", bitacora.Year);
            deletecommand.Parameters.AddWithValue("@precioUnitario", bitacora.PrecioUnitario);
            deletecommand.Parameters.AddWithValue("@subtotal", bitacora.Subotal);
            deletecommand.Parameters.AddWithValue("@iva", bitacora.Iva);
            deletecommand.Parameters.AddWithValue("@total", bitacora.Total);

            try
            {
                connection.Open();
                int deletedRows = deletecommand.ExecuteNonQuery();
                if (deletedRows > 0)
                    return true;
                else
                    return false;
            }
            catch (SqlException ex)
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
