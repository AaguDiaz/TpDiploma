using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Modelo
{
    public class MoListaPedido
    {
        private MoConexionSQL Conexion = new MoConexionSQL();
        private SqlCommand command = new SqlCommand();
        DataTable tabla = new DataTable();
        int skip = 0;


        public DataTable FiltroTodas(int currentPage)
        {
            skip = (currentPage -1 ) * 15;
            command.Connection = Conexion.AbirConexion();
            command.CommandText = "Select lp.id_lista AS IDLista, p.nombre_proveedor AS Proveedor, lp.fecha_vencimiento " +
                "   FROM listapedidos lp " +
                "   LEFT JOIN proveedores p ON lp.id_proveedor = p.id_proveedor " +
               $"   ORDER BY IDLista OFFSET {skip} ROWS FETCH NEXT {15} ROWS ONLY";
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    tabla.Load(reader);
                    command.Parameters.Clear();
                    Conexion.CerrarConexion();
                    return tabla;
                }
                else
                {
                    command.Parameters.Clear();
                    Conexion.CerrarConexion();
                    return tabla;
                }
            }
        }
        public DataTable FiltroActivas(int currentPage)
        {
            skip = (currentPage - 1) * 15;
            command.Connection = Conexion.AbirConexion();
            command.CommandText = "Select lp.id_lista AS IDLista, p.nombre_proveedor AS Proveedor, lp.fecha_vencimiento " +
                "   FROM listapedidos lp " +
                "   LEFT JOIN proveedores p ON lp.id_proveedor = p.id_proveedor" +
                "   WHERE fecha_vencimiento > GETDATE()" +
                $" ORDER BY IDLista OFFSET {skip} ROWS FETCH NEXT {15} ROWS ONLY";
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    tabla.Load(reader);
                    command.Parameters.Clear();
                    Conexion.CerrarConexion();
                    return tabla;
                }
                else
                {
                    command.Parameters.Clear();
                    Conexion.CerrarConexion();
                    return tabla;
                }
            }
        }
        public DataTable FiltroVencidas(int currentPage)
        {
            skip = (currentPage - 1) * 15;
            command.Connection = Conexion.AbirConexion();
            command.CommandText = "Select lp.id_lista AS IDLista, p.nombre_proveedor AS Proveedor, lp.fecha_vencimiento " +
                "   FROM listapedidos lp " +
                "   LEFT JOIN proveedores p ON lp.id_proveedor = p.id_proveedor" +
                "   WHERE fecha_vencimiento < GETDATE()" +
                $" ORDER BY IDLista OFFSET {skip} ROWS FETCH NEXT {15} ROWS ONLY";
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    tabla.Load(reader);
                    command.Parameters.Clear();
                    Conexion.CerrarConexion();
                    return tabla;
                }
                else
                {
                    command.Parameters.Clear();
                    Conexion.CerrarConexion();
                    return tabla;
                }
            }
        }


        public int CargarLista(string Proveedor, DateTime fechaVencimiento)
        {
            command.Connection = Conexion.AbirConexion();
            // Obtener el id_proveedor a partir del nombre_proveedor
            command.CommandText = "SELECT id_proveedor FROM proveedores WHERE nombre_proveedor = @nombre_proveedor";
            command.Parameters.AddWithValue("@nombre_proveedor", Proveedor);
            object reader = command.ExecuteScalar();
            int id_proveedor = Convert.ToInt32(reader);
            // Insertar en la tabla listapedidos
            command.CommandText = "INSERT INTO listapedidos (id_proveedor, fecha_vencimiento) OUTPUT INSERTED.id_lista VALUES (@id_proveedor, @fecha_vencimiento)";
            command.Parameters.AddWithValue("@id_proveedor", id_proveedor);
            command.Parameters.AddWithValue("@fecha_vencimiento", fechaVencimiento); // o la fecha que desees
            object reader2 = command.ExecuteScalar();
            int id_lista = Convert.ToInt32(reader2);
            command.Parameters.Clear();
            Conexion.CerrarConexion();
            return id_lista;
        }

        public int cargarListaPxP(int id_lista, string nombreProducto, string descripcionProducto, int precioProducto)
        {
            command.Connection = Conexion.AbirConexion();
            command.CommandText = "SELECT id_producto FROM productos WHERE nombre_producto = @nombre_prod AND descripcion = @desc";
            command.Parameters.AddWithValue("@nombre_prod", nombreProducto);
            command.Parameters.AddWithValue("@desc", descripcionProducto);
            object reader = command.ExecuteScalar();
            command.CommandText = "INSERT INTO lista_pedidos_productos (id_lista ,id_productos ,precio) " +
                                   "   VALUES (@id_lista, @id_productos, @precio_producto)";
            command.Parameters.AddWithValue("@id_lista", id_lista);
            command.Parameters.AddWithValue("@id_productos", reader);
            command.Parameters.AddWithValue("@precio_producto", precioProducto);
            command.ExecuteNonQuery();
            command.Parameters.Clear();
            Conexion.CerrarConexion();
            return 1;
        }

       


    }
}
