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
    public class MoPedidoLista
    {
        private SqlDataReader reader;
        DataTable tabla = new DataTable();

        public void CargarPedidoLista(int id_pedido, int id_lista, string producto,string desc, string cat, int cantidad, int precio)
        {
            using (SqlConnection connection = new SqlConnection(MoConexionSQL.Instance.Conexion))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    connection.Open();
                    command.CommandText = "SELECT id_categoria FROM categorias WHERE nombre = @cat";
                    command.Parameters.AddWithValue("@cat", cat);
                    int id_categoria = Convert.ToInt32(command.ExecuteScalar());
                    command.CommandText = "SELECT id_producto FROM productos WHERE nombre_producto = @producto AND descripcion = @desc AND categoria = @idcat";
                    command.Parameters.AddWithValue("@producto", producto);
                    command.Parameters.AddWithValue("@desc", desc);
                    command.Parameters.AddWithValue("@idcat", id_categoria);
                    int id_producto = Convert.ToInt32(command.ExecuteScalar());
                    command.CommandText = "INSERT INTO pedidos_lista_p (id_pedido, id_lista, id_producto, cantidad, precio_tot) VALUES (@id_pedido, @id_lista, @id_producto, @cantidad, @precio)";
                    command.Parameters.AddWithValue("@id_pedido", id_pedido);
                    command.Parameters.AddWithValue("@id_lista", id_lista);
                    command.Parameters.AddWithValue("@id_producto", id_producto);
                    command.Parameters.AddWithValue("@cantidad", cantidad);
                    command.Parameters.AddWithValue("@precio", precio);
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                    connection.Close();
                }
            }
        }

        public DataTable MostrarPedidoLista(int id, int currentPage)
        {
            using (SqlConnection connection = new SqlConnection(MoConexionSQL.Instance.Conexion))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    int skip = (currentPage - 1) * 12;
                    command.Connection = connection;
                    connection.Open();
                    command.CommandText = "SELECT p.nombre_producto AS Producto, p.descripcion AS Descripcion, pl.cantidad AS Cantidad, pl.precio_tot AS Precio " +
                        "   FROM pedidos_lista_p pl " +
                        "   JOIN productos p ON pl.id_producto = p.id_producto " +
                        "   WHERE pl.id_pedido = @id " +
                        $" ORDER BY Producto OFFSET {skip} ROWS FETCH NEXT {12} ROWS ONLY";
                    command.Parameters.AddWithValue("@id", id);
                    reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        tabla.Clear();
                        tabla.Load(reader);
                        command.Parameters.Clear();
                        connection.Close();
                        return tabla;
                    }
                    command.Parameters.Clear();
                    connection.Close();
                    return tabla;
                }
            }
        }


    }
}
