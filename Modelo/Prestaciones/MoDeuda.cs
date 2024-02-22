using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using COMUN.Cache;
using COMUN;

namespace Modelo
{
    public class MoDeuda
    {

        public int MostrarMontoDeuda()
        {
            using (SqlConnection connection = new SqlConnection(MoConexionSQL.Instance.Conexion))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    int id = UserLoginCache.id_usuario;
                    command.Connection = connection;
                    connection.Open();  
                    command.CommandText = "SELECT d.monto " +
                        "       FROM deudas d" +
                        "       LEFT JOIN empleados em ON d.id_empleado = em.id_empleado" +
                        "       LEFT JOIN usuarios u ON em.id_usuario = u.id_usuario" +
                        "       WHERE u.id_usuario = @idUsuario";
                    command.Parameters.AddWithValue("@idUsuario", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        int Deudas = 0;
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Deudas = Convert.ToInt32(reader["monto"]);
                            }
                            command.Parameters.Clear();
                            connection.Close();
                            return Deudas;
                        }
                        else
                        {
                            command.Parameters.Clear();
                            connection.Close();
                            return Deudas;
                        }
                    }
                }
            }
        }
        public int MostrarLimiteDeuda()
        {
            using (SqlConnection connection = new SqlConnection(MoConexionSQL.Instance.Conexion))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    connection.Open();
                    command.CommandText = "SELECT limite FROM limite_deudas";
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        int limite = 0;
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                limite = Convert.ToInt32(reader["limite"]);
                            }
                            command.Parameters.Clear();
                            connection.Close();
                            return limite;
                        }
                        else
                        {
                            command.Parameters.Clear();
                            connection.Close();
                            return limite;
                        }
                    }
                }
            }
        }

        public bool ActualizarDeuda(int monto)
        {
            using (SqlConnection connection = new SqlConnection(MoConexionSQL.Instance.Conexion))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    int id = UserLoginCache.id_usuario;
                    command.Connection = connection;
                    connection.Open();
                    command.CommandText = "UPDATE deudas SET monto = @monto WHERE id_empleado = @idUsuario";
                    command.Parameters.AddWithValue("@monto", monto);
                    command.Parameters.AddWithValue("@idUsuario", id);
                    if (command.ExecuteNonQuery() == 1)
                    {
                        command.Parameters.Clear();
                        connection.Close();
                        return true;
                    }
                    else
                    {
                        command.Parameters.Clear();
                        connection.Close();
                        return false;
                    }
                }
            } 
        }

    }
}
