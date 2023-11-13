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
        private SqlDataReader reader;

        public int MostrarDeudas()
        {
            int id = UserLoginCache.id_usuario;
            command.Connection = Conexion.AbirConexion();
            command.CommandText = "SELECT deudas.monto" +
                "FROM deudas" +
                "JOIN empleados ON deudas.id_empleados = empleados.id_empleados" +
                "JOIN usuarios ON empleados.id_usuario = usuarios.id_usuario" +
                "WHERE usuarios.id_usuario = @idUsuario;";
            command.Parameters.AddWithValue("@idUsuario", id);
            reader = command.ExecuteReader();
            int Deudas =0;
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Deudas =+ Convert.ToInt32(reader["monto"]);
                }
                Conexion.CerrarConexion();
                return Deudas;
            }
            else
            {
                Conexion.CerrarConexion();
                return Deudas;
            }
        }
    }
}
