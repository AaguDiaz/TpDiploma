using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Modelo
{
    public class MoProducto
    {
        public string id_producto { get; set; }
        public string nombre_producto { get; set; }
        public string descripcion { get; set; }

        private MoConexionSQL conexion = new MoConexionSQL();
        SqlCommand command = new SqlCommand();
        SqlDataReader leer;
        public List<MoProducto> MostrarProducto()
        {
            command.Connection = conexion.AbirConexion();
            command.CommandText = "Select id_producto, nombre_producto from productos";
            leer = command.ExecuteReader();
            List<MoProducto> producto = new List<MoProducto>();
            while (leer.Read())
            {
                producto.Add(new MoProducto
                {
                    id_producto= leer["id_producto"].ToString(),
                    nombre_producto = leer["nombre_producto"].ToString()
                });
            }
            return producto;
        }
        public string ObtenerNombreProductoPorId(int idProducto)
        {
            string nombreProducto = string.Empty;
            // Realizar la consulta SQL para obtener el nombre del proveedor por la ID de la lista
            command.Connection = conexion.AbirConexion();
            command.CommandText = "SELECT nombre_producto FROM productos WHERE id_producto = '"+ idProducto + "'";
            object result = command.ExecuteScalar();
            if (result != null)
            {
                nombreProducto = result.ToString();
            }
            return nombreProducto;
        }
        public string ObtenerDescripcionPorId(int idProducto)
        {
            string des = string.Empty;
            // Realizar la consulta SQL para obtener el nombre del proveedor por la ID de la lista
            command.Connection = conexion.AbirConexion();
            command.CommandText = "SELECT descripcion FROM productos WHERE id_producto = '" + idProducto + "'";
            object result = command.ExecuteScalar();
            if (result != null)
            {
                des = result.ToString();
            }
            return des;
        }
        public List<MoProducto> MostrarProductosPorLista(int idLista)
        {
            string nombreProducto = string.Empty;
            // Realizar la consulta SQL para obtener el nombre del proveedor por la ID de la lista
            command.Connection = conexion.AbirConexion();
            command.CommandText = "SELECT productos.id_producto, productos.nombre_producto FROM lista_pedidos_productos INNER JOIN productos ON lista_pedidos_productos.id_productos = productos.id_producto WHERE lista_pedidos_productos.id_lista = '" + idLista + "'";
            SqlDataReader result;
            result = command.ExecuteReader();
            List<MoProducto> producto = new List<MoProducto>();
            while (result.Read())
            {
                producto.Add(new MoProducto
                {
                    id_producto = result["id_producto"].ToString(),
                    nombre_producto = result["nombre_producto"].ToString()
                });
            }
            result.Close();
            return producto;
        }
    }
}
