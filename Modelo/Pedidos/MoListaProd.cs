using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using static System.Net.Mime.MediaTypeNames;

namespace Modelo
{
     public class MoListaProd
    {
        private SqlDataReader reader;
        DataTable tabla = new DataTable();

        public string MostrarProvDetalleLPP(int id)
        {
            using (SqlConnection connection = new SqlConnection(MoConexionSQL.Instance.Conexion))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    connection.Open();
                    command.CommandText = "SELECT p.nombre_proveedor " +
                        "   FROM listapedidos lpp " +
                        "   JOIN proveedores p ON lpp.id_proveedor = p.id_proveedor" +
                        "   WHERE id_lista = @id";
                    command.Parameters.AddWithValue("@id", id);
                    string proveedor = command.ExecuteScalar().ToString();
                    command.Parameters.Clear();
                    connection.Close();
                    return proveedor;
                }
            }
        }
        public string MostrarFechaDetalleLPP(int id)
        {
            using (SqlConnection connection = new SqlConnection(MoConexionSQL.Instance.Conexion))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    connection.Open();
                    command.CommandText = "SELECT fecha_vencimiento " +
                        "   FROM listapedidos " +
                        "   WHERE id_lista = @id";
                    command.Parameters.AddWithValue("@id", id);
                    string fecha = command.ExecuteScalar().ToString();
                    command.Parameters.Clear();
                    connection.Close();
                    return fecha;
                }
            }
        }

        public DataTable MostrarDetalleLista(int Id, int currentPage)
        {
            using (SqlConnection connection = new SqlConnection(MoConexionSQL.Instance.Conexion))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    int skip = (currentPage - 1) * 12;
                    connection.Open();
                    command.CommandText = "SELECT p.nombre_producto AS Producto, p.descripcion AS Descripcion, c.nombre AS Categoria, lpp.precio AS Precio " +
                        "   FROM lista_pedidos_productos lpp " +
                        "   JOIN productos p ON lpp.id_productos = p.id_producto " +
                        "   JOIN categorias c ON p.categoria = c.id_categoria" +
                        "   WHERE lpp.id_lista = @id " +
                        $" ORDER BY Producto OFFSET {skip} ROWS FETCH NEXT {12} ROWS ONLY";
                    command.Parameters.AddWithValue("@id", Id);
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
