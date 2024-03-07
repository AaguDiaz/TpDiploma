using System;
using System.IO;
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
                       // Obtengo el id del empleado que está logueado
                        command.Connection = connection;
                        connection.Open();
                        command.CommandText = "SELECT id_empleado FROM empleados WHERE id_usuario = @id";
                        command.Parameters.AddWithValue("@id", UserLoginCache.id_usuario);
                        int id_empleado = Convert.ToInt32(command.ExecuteScalar());

                        // Inserto la solicitud
                        command.CommandText = "INSERT INTO solicitudes (id_empleado, total, fecha, id_estado) OUTPUT INSERTED.id_solicitud  VALUES (@IdEmpleado, @Total, @Fecha, @estado)";
                        command.Parameters.AddWithValue("@IdEmpleado", id_empleado);
                        command.Parameters.AddWithValue("@Total", montototal);
                        command.Parameters.AddWithValue("@Fecha", DateTime.Now);
                        command.Parameters.AddWithValue("@estado", 1);
                        int id_solicitud = Convert.ToInt32(command.ExecuteScalar());

                        // Inserto las prestaciones de la solicitud
                        foreach (var prestacion in prestaciones)
                        {
                            command.Parameters.Clear();
                            command.CommandText = "SELECT id_prestacion FROM prestaciones WHERE nombre_prestacion = @nombre";
                            command.Parameters.AddWithValue("@nombre", prestacion.Nombre);
                            int id_prestacion = Convert.ToInt32(command.ExecuteScalar());
                            
                            byte[] pdf = null;
                            if (prestacion.pdf != null)
                            {
                                pdf = File.ReadAllBytes(prestacion.pdf);
                            }
                            command.CommandText = "INSERT INTO solicitudes_prestaciones (id_solicitud, id_prestacion, monto, cuotas, archivo) VALUES (@Id, @IdPrestacion, @Monto, @Cuotas, @archivo)";
                            command.Parameters.AddWithValue("@Id", id_solicitud);
                            command.Parameters.AddWithValue("@IdPrestacion", id_prestacion);
                            command.Parameters.AddWithValue("@Monto", prestacion.MontoSolicitado);
                            command.Parameters.AddWithValue("@Cuotas", prestacion.cuotasSolicitado);
                            SqlParameter archivoParam = new SqlParameter("@archivo", SqlDbType.VarBinary);
                            if (pdf != null)
                            {
                                archivoParam.Value = pdf;
                            }
                            else
                            {
                                archivoParam.Value = DBNull.Value;
                            }
                            command.Parameters.Add(archivoParam);
                            command.ExecuteNonQuery();
                            command.Parameters.Clear();
                        }
                        connection.Close();
                    
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

        public DataTable MostrarSoliXID(int id, int currentpage)
        {
            using (SqlConnection connection = new SqlConnection(MoConexionSQL.Instance.Conexion))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    DataTable tabla = new DataTable();
                    command.Connection = connection;
                    connection.Open();
                    command.CommandText = " SELECT sp.id_solicitud_prestacion as ID, p.nombre_prestacion AS Prestacion, sp.monto AS Monto, sp.cuotas AS Cuotas " +
                        " FROM solicitudes_prestaciones sp " +
                        " LEFT JOIN prestaciones p ON sp.id_prestacion = p.id_prestacion " +
                        " WHERE sp.id_solicitud = @id " +
                        " ORDER BY ID OFFSET (( " + currentpage + "- 1) * 15) ROWS FETCH NEXT 15 ROWS ONLY";
                    command.Parameters.AddWithValue("@id", id);
                    tabla.Load(command.ExecuteReader());
                    command.Parameters.Clear();
                    connection.Close();
                    return tabla;
                }
            }
        }
        public byte[] BuscarPDF(int id)
        {
            using (SqlConnection connection = new SqlConnection(MoConexionSQL.Instance.Conexion))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    connection.Open();
                    command.CommandText = "SELECT archivo FROM solicitudes_prestaciones WHERE id_solicitud_prestacion = @id";
                    command.Parameters.AddWithValue("@id", id);
                    byte[] pdf = (byte[])command.ExecuteScalar();
                    connection.Close();
                    return pdf;
                }
            }
        }

        public DataTable MostrarTodasPrestaciones(int CurrentPage)
        {
            using (SqlConnection connection = new SqlConnection(MoConexionSQL.Instance.Conexion))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    DataTable tabla = new DataTable();
                    command.Connection = connection;
                    connection.Open();
                    command.CommandText = "SELECT  CONCAT(emp.nombre_empleado, ' ' , emp.apellido_empleado) AS Empleado, u.mail AS Mail , s.id_solicitud AS ID, s.total AS Precio_total, e.Estado AS Estado, s.fecha AS Fecha_prestacion " +
                        "   FROM solicitudes s " +
                        "   LEFT JOIN estado e ON s.id_estado = e.id_estado " +
                        "   LEFT JOIN empleados emp ON s.id_empleado = emp.id_empleado " +
                        "   LEFT JOIN usuarios u ON emp.id_usuario = u.id_usuario " +
                        "   ORDER BY id_solicitud OFFSET ((" + CurrentPage + " - 1) * 12) ROWS FETCH NEXT 15 ROWS ONLY";
                    tabla.Load(command.ExecuteReader());
                    connection.Close();
                    return tabla;
                }
            }
        }
        public DataTable MostrarSolicitudABMFiltro(int CurrentPage, int estado)
        {
            using (SqlConnection connection = new SqlConnection(MoConexionSQL.Instance.Conexion))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    DataTable tabla = new DataTable();
                    command.Connection = connection;
                    connection.Open();
                    command.CommandText = "SELECT  CONCAT(emp.nombre_empleado, ' ' , emp.apellido_empleado) AS Empleado, u.mail AS Mail ,s.id_solicitud AS ID, s.total AS Precio_total, e.Estado AS Estado, s.fecha AS Fecha_prestacion " +
                        "   FROM solicitudes s " +
                        "   LEFT JOIN estado e ON s.id_estado = e.id_estado " +
                        "   LEFT JOIN empleados emp ON s.id_empleado = emp.id_empleado " +
                        "   LEFT JOIN usuarios u ON emp.id_usuario = u.id_usuario " +
                        "   WHERE s.id_estado = @estado " +
                        "   ORDER BY id_solicitud OFFSET ((" + CurrentPage + " - 1) * 12) ROWS FETCH NEXT 15 ROWS ONLY";
                    command.Parameters.AddWithValue("@estado", estado);
                    tabla.Load(command.ExecuteReader());
                    command.Parameters.Clear();
                    connection.Close();
                    return tabla;
                }
            }
        }

        public void CambiarEstado(int id_solicitud, int estado)
        {
            using (SqlConnection connection = new SqlConnection(MoConexionSQL.Instance.Conexion))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    connection.Open();
                    command.CommandText = "UPDATE solicitudes SET id_estado = @estado WHERE id_solicitud = @id_solicitud";
                    command.Parameters.AddWithValue("@estado", estado);
                    command.Parameters.AddWithValue("@id_solicitud", id_solicitud);
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                    connection.Close();
                }
            }
        }
    }
}
