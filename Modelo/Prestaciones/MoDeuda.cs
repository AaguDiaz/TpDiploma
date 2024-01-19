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
        private MoConexionSQL Conexion = new MoConexionSQL();
        private SqlCommand command = new SqlCommand();

        public int MostrarMontoDeuda()
        {
            int id = UserLoginCache.id_usuario;
            command.Connection = Conexion.AbirConexion();
            command.CommandText = "SELECT d.monto " +
                "       FROM deudas d" +
                "       LEFT JOIN empleados em ON d.id_empleado = em.id_empleado" +
                "       LEFT JOIN usuarios u ON em.id_usuario = u.id_usuario" +
                "       WHERE u.id_usuario = @idUsuario";
            command.Parameters.AddWithValue("@idUsuario", id);
            using (SqlDataReader reader = command.ExecuteReader()) { 
                int Deudas = 0;
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Deudas = Convert.ToInt32(reader["monto"]);
                    }
                    command.Parameters.Clear();
                    Conexion.CerrarConexion();
                    return Deudas;
                }
                else
                {
                    command.Parameters.Clear();
                    Conexion.CerrarConexion();
                    return Deudas;
                }
            }
        }
        public int MostrarLimiteDeuda()
        {
            int id = UserLoginCache.id_usuario;
            command.Connection = Conexion.AbirConexion();
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
                    Conexion.CerrarConexion();
                    return limite;
                }
                else
                {
                    command.Parameters.Clear();
                    Conexion.CerrarConexion();
                    return limite;
                }
            }
        }

        public bool ActualizarDeuda(int monto)
                {
                    int id = UserLoginCache.id_usuario;
                    command.Connection = Conexion.AbirConexion();
                    command.CommandText = "UPDATE deudas SET monto = @monto WHERE id_empleado = @idUsuario";
                    command.Parameters.AddWithValue("@monto", monto);
                    command.Parameters.AddWithValue("@idUsuario", id);
                    if (command.ExecuteNonQuery() == 1)
                    {
                        command.Parameters.Clear();
                        Conexion.CerrarConexion();
                        return true;
                    }
                    else
                    {
                        command.Parameters.Clear();
                        Conexion.CerrarConexion();
                        return false;
                    }   
                }

    }
}
