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
                    command.CommandText = "SELECT d.monto AS monto" +
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
                                Deudas += Convert.ToInt32(reader["monto"]);
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
                    command.CommandText = "SELECT limite AS limite FROM limite_deudas";
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

        public bool ActualizarDeuda(int monto, string empleado)
        {
            using (SqlConnection connection = new SqlConnection(MoConexionSQL.Instance.Conexion))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    
                    command.Connection = connection;
                    connection.Open();
                    command.CommandText = "SELECT id_usuario FROM empleados WHERE CONCAT(nombre_empleado, ' ' , apellido_empleado) = @empleado";
                    command.Parameters.AddWithValue("@empleado", empleado);
                    int id = 0;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                id = Convert.ToInt32(reader["id_usuario"]);
                            }
                        }
                        command.Parameters.Clear();
                        reader.Close();
                    }
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


        public void CargarSoli_deuda(int solicitud, int monto, string empleado)
        {
            using (SqlConnection connection = new SqlConnection(MoConexionSQL.Instance.Conexion))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    int idDeuda = 0;
                    command.Connection = connection;
                    connection.Open();
                    command.CommandText = "SELECT id_usuario FROM empleados WHERE CONCAT(nombre_empleado, ' ' , apellido_empleado) = @empleado";
                    command.Parameters.AddWithValue("@empleado", empleado);
                    int id = 0;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                id = Convert.ToInt32(reader["id_usuario"]);
                            }
                        }
                        command.Parameters.Clear();
                        reader.Close();
                    }
                    //buscar id deuda
                    command.CommandText = "SELECT id_deuda FROM deudas d " +
                        " LEFT JOIN empleados e ON d.id_empleado = e.id_empleado " +
                        " WHERE e.id_usuario = @idUsuario";
                    command.Parameters.AddWithValue("@idUsuario", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                idDeuda = Convert.ToInt32(reader["id_deuda"]);
                            }
                        }
                        command.Parameters.Clear();
                    }

                    command.CommandText = "INSERT INTO solicitud_deudas (id_solicitud, id_deuda, monto) " +
                        " VALUES (@id_solicitud, @id_deuda, @monto) ";
                    command.Parameters.AddWithValue("@id_solicitud", solicitud);
                    command.Parameters.AddWithValue("@id_deuda", idDeuda);
                    command.Parameters.AddWithValue("@monto", monto);
                    if (command.ExecuteNonQuery() == 1)
                    {
                        command.Parameters.Clear();
                        connection.Close();
                    }
                    command.Parameters.Clear();
                    connection.Close();
                }
            }
        }


        public bool VerificarDeuda(string emp)
        {
            using (SqlConnection connection = new SqlConnection(MoConexionSQL.Instance.Conexion))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    
                    command.Connection = connection;
                    connection.Open();
                    command.CommandText = "SELECT id_usuario FROM empleados WHERE CONCAT(nombre_empleado, ' ' , apellido_empleado) = @empleado";
                    command.Parameters.AddWithValue("@empleado", emp);
                    int id = 0;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                id = Convert.ToInt32(reader["id_usuario"]);
                            }
                        }
                        command.Parameters.Clear();
                        reader.Close();
                    }
                    command.CommandText = "SELECT d.id_deuda FROM deudas d " +
                        "   LEFT JOIN empleados e on d.id_empleado = e.id_empleado " +
                        "   WHERE e.id_usuario = @idUsuario";
                    command.Parameters.AddWithValue("@idUsuario", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
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

        public void CrearDeuda(string empleado)
        {
            using (SqlConnection connection = new SqlConnection(MoConexionSQL.Instance.Conexion))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    
                    command.Connection = connection;
                    connection.Open();
                    command.CommandText = "SELECT id_usuario FROM empleados WHERE CONCAT(nombre_empleado, ' ' , apellido_empleado) = @empleado";
                    command.Parameters.AddWithValue("@empleado", empleado);
                    int id = 0;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                id = Convert.ToInt32(reader["id_usuario"]);
                            }
                        }
                        command.Parameters.Clear();
                        reader.Close();
                    }
                    
                    command.CommandText = "INSERT INTO deudas (id_empleado, monto, limite) VALUES (@idUsuario, @monto, @limite)";
                    command.Parameters.AddWithValue("@idUsuario", id);
                    command.Parameters.AddWithValue("@monto", 0);
                    command.Parameters.AddWithValue("@limite", 1);
                    if (command.ExecuteNonQuery() == 1)
                    {
                        command.Parameters.Clear();
                        connection.Close();
                    }
                }
            }
        }
        public int MostrarMontoDeudaEmpleado(string empleado)
        {
            using (SqlConnection connection = new SqlConnection(MoConexionSQL.Instance.Conexion))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    
                    command.Connection = connection;
                    connection.Open();
                    command.CommandText = "SELECT id_usuario FROM empleados WHERE CONCAT(nombre_empleado, ' ' , apellido_empleado) = @empleado";
                    command.Parameters.AddWithValue("@empleado", empleado);
                    int id = 0;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                id = Convert.ToInt32(reader["id_usuario"]);
                            }
                        }
                        command.Parameters.Clear();
                        reader.Close();
                    }
                    command.CommandText = "SELECT d.monto AS monto" +
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

        //Estado de cuenta

        public DataTable MostrarDetalleDeuda()
        {
            using (SqlConnection connection = new SqlConnection(MoConexionSQL.Instance.Conexion))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    int id = UserLoginCache.id_usuario;
                    command.Connection = connection;
                    connection.Open();
                    command.CommandText = "SELECT sp.id_solicitud as IdSolicitud, p.nombre_prestacion AS Prestacion, sp.monto AS Monto " +
                        " FROM solicitud_deudas sd " +
                        " LEFT JOIN solicitudes_prestaciones sp ON sd.id_solicitud = sp.id_solicitud " +
                        " LEFT JOIN prestaciones p ON sp.id_prestacion = p.id_prestacion " +
                        " LEFT JOIN deudas d ON sd.id_deuda = d.id_deuda "+
                        " LEFT JOIN empleados e ON d.id_empleado = e.id_empleado" +
                        " WHERE e.id_usuario = @idUsuario ";
                    command.Parameters.AddWithValue("@idUsuario", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        DataTable tabla = new DataTable();
                        if (reader.HasRows)
                        {
                            tabla.Load(reader);
                            command.Parameters.Clear();
                            connection.Close();
                            return tabla;
                        }
                        else
                        {
                            command.Parameters.Clear();
                            connection.Close();
                            return tabla;
                        }
                    }
                }
            }   
        }



    }
}
