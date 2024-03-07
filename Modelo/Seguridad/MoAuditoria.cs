using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using COMUN.Cache;
using COMUN;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Remoting.Messaging;


namespace Modelo.Seguridad
{
    public class MoAuditoria
    {

        SqlDataReader reader;
        public DateTime startDate;
        public DateTime endDate;

        public void InsertarAuditoria(string registro)
        {
            using (SqlConnection connection = new SqlConnection(MoConexionSQL.Instance.Conexion))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    connection.Open();
                    int id_emp = 0;
                    command.CommandText = "SELECT id_empleado FROM empleados WHERE id_usuario = @Usuario";
                    command.Parameters.AddWithValue("@Usuario", UserLoginCache.id_usuario);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                id_emp = reader.GetInt32(0);
                            }
                        }
                    }
                    command.CommandText = "INSERT INTO audioria (id_empleado,  registro, fecha) VALUES (@id, @Registro, @Fecha)";
                    command.Parameters.AddWithValue("@id", id_emp);
                    command.Parameters.AddWithValue("@Registro", registro);
                    command.Parameters.AddWithValue("@Fecha", DateTime.Now);
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                    connection.Close();
                }
            }
        }

        public DataTable CargarInicio(int currentPage, DateTime desde, DateTime hasta)
        {
            DataTable tabla = new DataTable();
            using (SqlConnection connection = new SqlConnection(MoConexionSQL.Instance.Conexion))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = " SELECT a.id_auditoria AS ID, CONCAT(emp.nombre_empleado, ' ' , emp.apellido_empleado) AS Empleado, a.registro AS Registro, a.fecha AS Fecha " +
                        " FROM audioria a " +
                        "   LEFT JOIN empleados emp ON a.id_empleado = emp.id_empleado " +
                        " WHERE a.fecha BETWEEN @desde AND @hasta " +
                        "  ORDER BY fecha DESC OFFSET ((" + currentPage + " - 1) * 18) ROWS FETCH NEXT 18 ROWS ONLY";
                    command.Parameters.AddWithValue("@desde", desde);
                    command.Parameters.AddWithValue("@hasta", hasta);
                    command.Parameters.AddWithValue("@currentPage", currentPage);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        tabla.Load(reader);
                    }
                }
                connection.Close();
            }
            return tabla;
        }

        public void CargarTablaInico(DateTime desde, DateTime hasta)
        {
            using (SqlConnection connection = new SqlConnection(MoConexionSQL.Instance.Conexion))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    CacheReportes.TopInicio = new List<KeyValuePair<string, int>>();
                    command.Connection = connection;
                    connection.Open();
                    command.CommandText = @"SELECT TOP 5 CONCAT(emp.nombre_empleado, ' ' , emp.apellido_empleado) AS Empleado, COUNT(a.id_auditoria) as C
                                            from audioria a
                                            inner join empleados emp on emp.id_empleado = a.id_empleado
                                            where a.registro = 'Inicio de Sesión' AND a.fecha between @fromDate and @toDate 
                                            group by CONCAT(emp.nombre_empleado, ' ' , emp.apellido_empleado)
                                            order by C desc ";
                    command.Parameters.Add("@fromDate", System.Data.SqlDbType.DateTime).Value = startDate;
                    command.Parameters.Add("@toDate", System.Data.SqlDbType.DateTime).Value = endDate;
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        CacheReportes.TopInicio.Add(
                            new KeyValuePair<string, int>(reader[0].ToString(), (int)reader[1]));
                    }
                    reader.Close();
                    command.Parameters.Clear();
                    connection.Close();
                }
            }

        }

        public DataTable CargarTrazabilidad(int currentPage, DateTime desde, DateTime hasta)
        {
            DataTable tabla = new DataTable();
            using (SqlConnection connection = new SqlConnection(MoConexionSQL.Instance.Conexion))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = " SELECT a.id_producto AS ID, a.nombre_producto AS Producto, a.descripcion AS Descripcion, c.nombre AS Categoria ,CONCAT(emp.nombre_empleado, ' ' , emp.apellido_empleado) AS Empleado, a.registro AS Registro, a.fecha AS Fecha " +
                        "   FROM productos_auditoria a " +
                        "   LEFT JOIN empleados emp ON a.id_empleado = emp.id_empleado " +
                        "   LEFT JOIN categorias c ON a.categoria = c.id_categoria " +
                        "   WHERE a.fecha BETWEEN @desde AND @hasta " +
                        "   ORDER BY fecha DESC OFFSET ((" + currentPage + " - 1) * 18) ROWS FETCH NEXT 18 ROWS ONLY";
                    command.Parameters.AddWithValue("@desde", desde);
                    command.Parameters.AddWithValue("@hasta", hasta);
                    command.Parameters.AddWithValue("@currentPage", currentPage);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        tabla.Load(reader);
                    }
                }
                connection.Close();
            }
            return tabla;
        }

        public void CargarTablaTrazabilidad(DateTime desde, DateTime hasta)
        {
            using (SqlConnection connection = new SqlConnection(MoConexionSQL.Instance.Conexion))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    CacheReportes.TopTrazabilidad = new List<KeyValuePair<string, int>>();
                    command.Connection = connection;
                    connection.Open();
                    command.CommandText = @"SELECT TOP 5 a.nombre_producto AS Producto, COUNT(a.id_producto) as C
                                            from productos_auditoria a
                                            where a.fecha between @fromDate and @toDate 
                                            group by a.nombre_producto
                                            order by C desc ";
                    command.Parameters.Add("@fromDate", System.Data.SqlDbType.DateTime).Value = startDate;
                    command.Parameters.Add("@toDate", System.Data.SqlDbType.DateTime).Value = endDate;
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        CacheReportes.TopTrazabilidad.Add(
                                                       new KeyValuePair<string, int>(reader[0].ToString(), (int)reader[1]));
                    }
                    reader.Close();
                    command.Parameters.Clear();
                    connection.Close();
                }
            }

        }   

        public DataTable BuscarTrazabilidad(int currentPage, DateTime desde, DateTime hasta, int busqueda)
        {
            DataTable tabla = new DataTable();
            using (SqlConnection connection = new SqlConnection(MoConexionSQL.Instance.Conexion))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = " SELECT a.id_producto AS ID, a.nombre_producto AS Producto, a.descripcion AS Descripcion, c.nombre AS Categoria ,CONCAT(emp.nombre_empleado, ' ' , emp.apellido_empleado) AS Empleado, a.registro AS Registro, a.fecha AS Fecha " +
                        "   FROM productos_auditoria a " +
                        "   LEFT JOIN empleados emp ON a.id_empleado = emp.id_empleado " +
                        "   LEFT JOIN categorias c ON a.categoria = c.id_categoria " +
                        "   WHERE a.fecha BETWEEN @desde AND @hasta AND (a.id_producto LIKE @busqueda ) " +
                        "   ORDER BY fecha DESC OFFSET ((" + currentPage + " - 1) * 18) ROWS FETCH NEXT 18 ROWS ONLY";
                    command.Parameters.AddWithValue("@desde", desde);
                    command.Parameters.AddWithValue("@hasta", hasta);
                    command.Parameters.AddWithValue("@busqueda", "%" + busqueda + "%");
                    command.Parameters.AddWithValue("@currentPage", currentPage);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        tabla.Load(reader);
                    }
                }
                connection.Close();
            }
            return tabla;
        }


    }
}
