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
    public class MoSolicitud
    {
        public void Solicitud(List<IPrestacion> prestaciones, int montototal)
        {
            using (SqlConnection connection = new SqlConnection(MoConexionSQL.Instance.Conexion))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    try
                    {   // Obtengo el id del empleado que está logueado
                        command.Connection = connection;
                        connection.Open();
                        command.CommandText = "SELECT id_empleado FROM empleados WHERE id_usuario = @id";
                        command.Parameters.AddWithValue("@id", UserLoginCache.id_usuario);
                        int id_empleado = Convert.ToInt32(command.ExecuteScalar());

                        // Inserto la solicitud
                        command.CommandText = "INSERT INTO solicitudes (id_empleado, total, fecha) VALUES (@IdEmpleado, @Total, @Fecha)";
                        command.Parameters.AddWithValue("@IdEmpleado", id_empleado);
                        command.Parameters.AddWithValue("@Total", montototal);
                        command.Parameters.AddWithValue("@Fecha", DateTime.Now);
                        command.ExecuteNonQuery();

                        // Obtengo el id de la solicitud que acabo de insertar
                        command.CommandText = "SELECT id_solicitud FROM solicitudes";
                        int id_solicitud = Convert.ToInt32(command.ExecuteScalar());

                        // Obtengo el id de la deuda del empleado
                        command.CommandText = "SELECT id_deuda FROM deudas WHERE id_empleado = @idem";
                        command.Parameters.AddWithValue("@idem", id_empleado);
                        int id_deuda = Convert.ToInt32(command.ExecuteScalar());

                        // Inserto la solicitud de deuda
                        command.CommandText = "INSERT INTO solicitud_deudas (id_solicitud,id_deuda, monto) values (@IdSolicitud, @IdDeudas, @Monto)";
                        command.Parameters.AddWithValue("@IdSolicitud", id_solicitud);
                        command.Parameters.AddWithValue("@IdDeudas", id_deuda);
                        command.Parameters.AddWithValue("@Monto", montototal);
                        command.ExecuteNonQuery();
                        command.Parameters.Clear();

                        // Inserto las prestaciones de la solicitud
                        foreach (var prestacion in prestaciones)
                        {
                            command.CommandText = "SELECT id_prestacion FROM prestaciones WHERE nombre_prestacion = @nombre";
                            command.Parameters.AddWithValue("@nombre", prestacion.Nombre);
                            int id_prestacion = Convert.ToInt32(command.ExecuteScalar());
                            command.CommandText = "SELECT id_solicitud FROM solicitudes";
                            int id_soli = Convert.ToInt32(command.ExecuteScalar());

                            command.CommandText = "INSERT INTO solicitudes_prestaciones (id_solicitud, id_prestacion, monto, cuotas) VALUES (@Id, @IdPrestacion, @Monto, @Cuotas)";
                            command.Parameters.AddWithValue("@Id", id_soli);
                            command.Parameters.AddWithValue("@IdPrestacion", id_prestacion);
                            command.Parameters.AddWithValue("@Monto", prestacion.MontoSolicitado);
                            command.Parameters.AddWithValue("@Cuotas", prestacion.cuotas);
                            command.ExecuteNonQuery();
                            command.Parameters.Clear();
                        }
                        connection.Close();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }

        public DataTable MostrarSoliciudesUsuario(int CurrentPage, DateTime desde, DateTime hasta)
        {
            DataTable tabla = new DataTable();
            using (SqlConnection connection = new SqlConnection(MoConexionSQL.Instance.Conexion))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT s.id_solicitud AS ID, s.total AS Precio_total, e.Estado AS Estado, s.fecha AS Fecha_del_pedido " +
                        " FROM solicitudes s " +
                        " LEFT JOIN empleados em ON s.id_empleado = em.id_empleado " +
                        " LEFT JOIN estado e ON s.id_estado = e.id_estado" +
                        " LEFT JOIN usuarios u ON em.id_usuario = u.id_usuario " +
                        " WHERE u.id_usuario = @idusuario AND s.fecha BETWEEN @FechaDesde AND @FechaHasta " +
                        "   ORDER BY id_solicitud OFFSET ((" + CurrentPage + " - 1) * 15) ROWS FETCH NEXT 15 ROWS ONLY";
                    command.Parameters.AddWithValue("@idusuario", UserLoginCache.id_usuario);
                    command.Parameters.AddWithValue("@FechaDesde", desde);
                    command.Parameters.AddWithValue("@FechaHasta", hasta);
                    command.Parameters.AddWithValue("@id", UserLoginCache.id_usuario);
                    SqlDataReader reader = command.ExecuteReader();
                    tabla.Load(reader);
                    connection.Close();
                }
            }
            return tabla;
        }
        public DataTable MostarSoliFiltro(int CurrentPage, int estado, DateTime desde, DateTime hasta)
        {
            using (SqlConnection connection = new SqlConnection(MoConexionSQL.Instance.Conexion))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    DataTable tabla = new DataTable();
                    command.Connection = connection;
                    connection.Open();
                    command.CommandText = "SELECT s.id_solicitud AS ID, s.total AS Precio_total, e.Estado AS Estado, s.fecha AS Fecha_del_pedido" +
                        "   FROM solicitudes s " +
                        "   LEFT JOIN estado e ON s.id_estado = e.id_estado " +
                        "   LEFT JOIN empleados em ON s.id_empleado = em.id_empleado " +
                        "   LEFT JOIN usuarios u ON em.id_usuario = u.id_usuario " +
                        "   WHERE u.id_usuario =@idusuario AND s.id_estado = @estado AND s.fecha BETWEEN @FechaDesde AND @FechaHasta " +
                        "   ORDER BY id_solicitud OFFSET ((" + CurrentPage + " - 1) * 15) ROWS FETCH NEXT 15 ROWS ONLY";
                    command.Parameters.AddWithValue("@idusuario", UserLoginCache.id_usuario);
                    command.Parameters.AddWithValue("@estado", estado);
                    command.Parameters.AddWithValue("@FechaDesde", desde);
                    command.Parameters.AddWithValue("@FechaHasta", hasta);
                    tabla.Load(command.ExecuteReader());
                    command.Parameters.Clear();
                    connection.Close();
                    return tabla;
                }
            }
        }
    }
}
