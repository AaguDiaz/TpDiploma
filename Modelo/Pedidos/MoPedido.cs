using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using COMUN;

namespace Modelo
{
    public class MoPedido
    {

        public int CargarPedido(int total)
        {
            using (SqlConnection connection = new SqlConnection(MoConexionSQL.Instance.Conexion))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    connection.Open();
                    //busco el id del empleado que está logueado
                    command.CommandText = "SELECT id_empleado FROM empleados WHERE id_usuario = @id";
                    command.Parameters.AddWithValue("@id", UserLoginCache.id_usuario);
                    int id_empleado = Convert.ToInt32(command.ExecuteScalar());
                    // Insertar en la tabla pedidos
                    command.CommandText = "INSERT INTO pedidos (id_empleado, total, id_estado, fecha_pedido) OUTPUT INSERTED.id_pedido VALUES (@id_empleado, @total, @id_estado, @fecha_pedido)";
                    command.Parameters.AddWithValue("@id_empleado", id_empleado);
                    command.Parameters.AddWithValue("@total", total);
                    command.Parameters.AddWithValue("@id_estado", 1);
                    command.Parameters.AddWithValue("@fecha_pedido", DateTime.Now);
                    object reader2 = command.ExecuteScalar();
                    int id_pedido = Convert.ToInt32(reader2);
                    command.Parameters.Clear();
                    connection.Close();
                    return id_pedido;
                }
            }
        }

        public DataTable MostarPedidosTodas(int CurrentPage, DateTime desde, DateTime hasta)
        {
            using (SqlConnection connection = new SqlConnection(MoConexionSQL.Instance.Conexion))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    DataTable tabla = new DataTable();
                    command.Connection = connection;
                    connection.Open();
                    command.CommandText = "SELECT p.id_pedido AS ID, p.total AS Precio_total, e.Estado AS Estado, p.fecha_pedido AS Fecha_del_pedido" +
                        "   FROM pedidos p " +
                        "   LEFT JOIN estado e ON p.id_estado = e.id_estado " +
                        "   LEFT JOIN empleados em ON p.id_empleado = em.id_empleado " +
                        "   LEFT JOIN usuarios u ON em.id_usuario = u.id_usuario " +
                        "   WHERE u.id_usuario = @idusuario AND p.fecha_pedido BETWEEN @FechaDesde AND @FechaHasta " +
                        "   ORDER BY id_pedido OFFSET ((" + CurrentPage + " - 1) * 15) ROWS FETCH NEXT 15 ROWS ONLY";
                    command.Parameters.AddWithValue("@idusuario", UserLoginCache.id_usuario);
                    command.Parameters.AddWithValue("@FechaDesde", desde);
                    command.Parameters.AddWithValue("@FechaHasta", hasta);
                    tabla.Load(command.ExecuteReader());
                    command.Parameters.Clear();
                    connection.Close(); 
                    return tabla;
                }
            }
        }

        public DataTable MostarPedidosFiltro(int CurrentPage,int estado, DateTime desde, DateTime hasta)
        {
            using (SqlConnection connection = new SqlConnection(MoConexionSQL.Instance.Conexion))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    DataTable tabla = new DataTable();
                    command.Connection = connection;
                    connection.Open();
                    command.CommandText = "SELECT p.id_pedido AS ID, p.total AS Precio_total, e.Estado AS Estado, p.fecha_pedido AS Fecha_del_pedido" +
                        "   FROM pedidos p " +
                        "   LEFT JOIN estado e ON p.id_estado = e.id_estado " +
                        "   LEFT JOIN empleados em ON p.id_empleado = em.id_empleado " +
                        "   LEFT JOIN usuarios u ON em.id_usuario = u.id_usuario " +
                        "   WHERE u.id_usuario =@idusuario AND p.id_estado = @estado AND p.fecha_pedido BETWEEN @FechaDesde AND @FechaHasta " +
                        "   ORDER BY id_pedido OFFSET ((" + CurrentPage + " - 1) * 15) ROWS FETCH NEXT 15 ROWS ONLY";
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


        public DataTable MostrarPedidosABM(int CurrentPage)
        {
            using (SqlConnection connection = new SqlConnection(MoConexionSQL.Instance.Conexion))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    DataTable tabla = new DataTable();
                    command.Connection = connection;
                    connection.Open();
                    command.CommandText = "SELECT  CONCAT(emp.nombre_empleado, ' ' , emp.apellido_empleado) AS Empleado, u.mail AS Mail ,p.id_pedido AS ID, p.total AS Precio_total, e.Estado AS Estado, p.fecha_pedido AS Fecha_del_pedido" +
                        "   FROM pedidos p " +
                        "   LEFT JOIN estado e ON p.id_estado = e.id_estado " +
                        "   LEFT JOIN empleados emp ON p.id_empleado = emp.id_empleado " +
                        "   LEFT JOIN usuarios u ON emp.id_usuario = u.id_usuario " +
                        "   ORDER BY id_pedido OFFSET ((" + CurrentPage + " - 1) * 12) ROWS FETCH NEXT 15 ROWS ONLY";
                    tabla.Load(command.ExecuteReader());
                    command.Parameters.Clear();
                    connection.Close();
                    return tabla;
                }
            }
        }

        public DataTable MostrarPedidosABMFiltro(int CurrentPage, int estado)
        {
            using (SqlConnection connection = new SqlConnection(MoConexionSQL.Instance.Conexion))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    DataTable tabla = new DataTable();
                    command.Connection = connection;
                    connection.Open();
                    command.CommandText = "SELECT  CONCAT(emp.nombre_empleado, ' ' , emp.apellido_empleado) AS Empleado, u.mail AS Mail ,p.id_pedido AS ID, p.total AS Precio_total, e.Estado AS Estado, p.fecha_pedido AS Fecha_del_pedido" +
                        "   FROM pedidos p " +
                        "   LEFT JOIN estado e ON p.id_estado = e.id_estado " +
                        "   LEFT JOIN empleados emp ON p.id_empleado = emp.id_empleado " +
                        "   LEFT JOIN usuarios u ON emp.id_usuario = u.id_usuario " +
                        "   WHERE p.id_estado = @estado " +
                        "   ORDER BY id_pedido OFFSET ((" + CurrentPage + " - 1) * 12) ROWS FETCH NEXT 15 ROWS ONLY";
                    command.Parameters.AddWithValue("@estado", estado);
                    tabla.Load(command.ExecuteReader());
                    command.Parameters.Clear();
                    connection.Close();
                    return tabla;
                }
            }
        }

        public void CambiarEstado(int id_pedido, int estado)
        {
            using (SqlConnection connection = new SqlConnection(MoConexionSQL.Instance.Conexion))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    connection.Open();
                    command.CommandText = "UPDATE pedidos SET id_estado = @estado WHERE id_pedido = @id_pedido";
                    command.Parameters.AddWithValue("@estado", estado);
                    command.Parameters.AddWithValue("@id_pedido", id_pedido);
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                    connection.Close();
                }
            }
        }


    }
}
