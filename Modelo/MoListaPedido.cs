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
        public string id_lista { get; set; }
        public string id_proveedor { get; set; }

        public string fecha_nacimiento { get; set; }

        private MoConexionSQL Conexion = new MoConexionSQL();
        private SqlCommand cmd = new SqlCommand();
        
        DataTable tabla = new DataTable();

        public string Mostrar(int id_p)
        {
            SqlDataReader reader;
            cmd.Connection = Conexion.AbirConexion();
            cmd.CommandText = "Select id_lista from listapedidos where id_proveedor = @id_proveedor";
            cmd.Parameters.AddWithValue("@id_proveedor", id_p);
            reader = cmd.ExecuteReader();
            string id_lista = string.Empty;
            if (reader.Read())
            {
                id_lista = reader["id_lista"].ToString();
                
            }
            return id_lista;
            
        }
        public List<MoListaPedido> MostrarLista()
        {
            cmd.Connection = Conexion.AbirConexion();
            SqlDataReader leeeer;
            cmd.CommandText = "Select id_lista, id_proveedor, fecha_vencimiento from listapedidos";
            leeeer = cmd.ExecuteReader();
            List<MoListaPedido> listap = new List<MoListaPedido>();
            while (leeeer.Read())
            {
                listap.Add(new MoListaPedido
                {
                    id_lista = leeeer["id_lista"].ToString(),
                    id_proveedor = leeeer["id_proveedor"].ToString(),
                    fecha_nacimiento = leeeer["fecha_vencimiento"].ToString()
                });
            }
            leeeer.Close();
            return listap;
        }

        public void Insertarlista(int id_proveedor, DateTime fecha_vencimiento)
        {
            cmd.Connection = Conexion.CerrarConexion();
            cmd.Connection = Conexion.AbirConexion();
            cmd.CommandText = "INSERT INTO listapedidos (id_proveedor, fecha_vencimiento) VALUES(@idproveedor, @fecha_v)";
            cmd.Parameters.AddWithValue("@idproveedor", id_proveedor);
            cmd.Parameters.AddWithValue("@fecha_v", fecha_vencimiento);
            cmd.ExecuteNonQuery();
        }
       
        public string ObtenerNombreProveedorPorIdLista(int idLista)
        {
            string nombreProveedor = string.Empty;
            // Realizar la consulta SQL para obtener el nombre del proveedor por la ID de la lista
            cmd.Connection = Conexion.AbirConexion();
            cmd.CommandText = "SELECT proveedores.nombre_proveedor " +
                           "FROM listapedidos " +
                           "INNER JOIN proveedores ON listapedidos.id_proveedor = proveedores.id_proveedor " +
                           "WHERE listapedidos.id_lista = '"+idLista+"'";
             object result = cmd.ExecuteScalar();
             if (result != null)
                {
                 nombreProveedor = result.ToString();
                }
            return nombreProveedor;
        }

        public DateTime ObtenerFechaVencimientoPorIdLista(int idLista)
        {
            DateTime fechaVencimiento = DateTime.MinValue;
            // Realizar la consulta SQL para obtener la fecha de vencimiento de la lista
            cmd.Connection = Conexion.AbirConexion();
            cmd.CommandText = "SELECT fecha_vencimiento " +
                           "FROM listapedidos "+
                           "WHERE listapedidos.id_lista = '" + idLista + "'";
            object result = cmd.ExecuteScalar();
            if (result != null)
            {
                fechaVencimiento = Convert.ToDateTime(result);
            }
            return fechaVencimiento;
        }
    }
}
