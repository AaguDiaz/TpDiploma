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

        private MoConexionSQL Conexion = new MoConexionSQL();
        private SqlCommand command = new SqlCommand();
        private SqlDataReader reader;

        public int CargarPedido(int total)
        {
            command.Connection = Conexion.AbirConexion(); 
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
            Conexion.CerrarConexion();
            return id_pedido;
        }

        public DataTable MostarPedidosTodas(int CurrentPage, DateTime desde, DateTime hasta)
        {
            DataTable tabla = new DataTable();
            command.Connection = Conexion.AbirConexion();
            command.CommandText = "SELECT p.id_pedido AS ID, p.total AS Precio_total, e.Estado AS Estado, p.fecha_pedido AS Fecha_del_pedido" +
                "   FROM pedidos p " +
                "   LEFT JOIN estado e ON p.id_estado = e.id_estado " +
                "   WHERE p.fecha_pedido BETWEEN @FechaDesde AND @FechaHasta " +
                "   ORDER BY id_pedido OFFSET ((" + CurrentPage + " - 1) * 15) ROWS FETCH NEXT 15 ROWS ONLY";
            command.Parameters.AddWithValue("@FechaDesde", desde);
            command.Parameters.AddWithValue("@FechaHasta", hasta);
            tabla.Load(command.ExecuteReader());
            command.Parameters.Clear();
            Conexion.CerrarConexion();
            return tabla;
        }

        public DataTable MostarPedidosFiltro(int CurrentPage,int estado, DateTime desde, DateTime hasta)
        {
            DataTable tabla = new DataTable();
            command.Connection = Conexion.AbirConexion();
            command.CommandText = "SELECT p.id_pedido AS ID, p.total AS Precio_total, e.Estado AS Estado, p.fecha_pedido AS Fecha_del_pedido" +
                "   FROM pedidos p " +
                "   LEFT JOIN estado e ON p.id_estado = e.id_estado " +
                "   WHERE p.id_estado = @estado AND p.fecha_pedido BETWEEN @FechaDesde AND @FechaHasta " +
                "   ORDER BY id_pedido OFFSET ((" + CurrentPage + " - 1) * 15) ROWS FETCH NEXT 15 ROWS ONLY";
            command.Parameters.AddWithValue("@estado", estado);
            command.Parameters.AddWithValue("@FechaDesde", desde);
            command.Parameters.AddWithValue("@FechaHasta", hasta);
            tabla.Load(command.ExecuteReader());
            command.Parameters.Clear();
            Conexion.CerrarConexion();
            return tabla;
        }

    }
}
