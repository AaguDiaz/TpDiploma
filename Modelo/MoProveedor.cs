using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Modelo
{
    public class MoProveedor
    {
        
        private MoConexionSQL conexion = new MoConexionSQL();
        SqlCommand command = new SqlCommand();
        SqlDataReader reader;

        public DataTable Mostrar()
        {
            DataTable table = new DataTable();
            command.Connection = conexion.AbirConexion();
            command.CommandText = "Select * from proveedores";
            reader = command.ExecuteReader();
            table.Load(reader);
            reader.Close();
            conexion.CerrarConexion();
            return table;
        }
        public void InsertarProveedor(string nombre_proveedor, string direccion_pro, long cuil, long telefono)
        {
            command.Connection = conexion.AbirConexion();
            command.CommandText = "INSERT INTO proveedores VALUES('"+nombre_proveedor+"','" +direccion_pro+"', '"+cuil+"', '"+telefono+"')";
            command.ExecuteNonQuery();
        }

    }
    public class proveedor
    {
         public string id_proveedor { get; set; }
         public string nombre_proveedor { get; set; } 

         private MoConexionSQL conexion = new MoConexionSQL();
         SqlCommand command = new SqlCommand();
         SqlDataReader reader;
         SqlDataReader leer;
        public List<proveedor> MostrarProveedor()
        {
            command.Connection = conexion.AbirConexion();
            command.CommandText = "Select id_proveedor, nombre_proveedor from proveedores";
            reader = command.ExecuteReader();
            List<proveedor> proveedores = new List<proveedor>();
            while (reader.Read())
            {
                proveedores.Add(new proveedor
                {
                    id_proveedor = reader["id_proveedor"].ToString(),
                    nombre_proveedor = reader["nombre_proveedor"].ToString()
                });
            }
            reader.Close();
            return proveedores;
        }
        public string MostrarNombre(int id_p)
        {
            command.Connection = conexion.AbirConexion();
            command.CommandText = "Select id_proveedor from proveedores where id_proveedor = @id_proveedor";
            command.Parameters.AddWithValue("@id_proveedor", id_p);
            reader = command.ExecuteReader();
            command.Parameters.Clear();
            string id_lista = string.Empty;
            if (reader.Read())
            {
                id_lista = reader["id_lista"].ToString();

            }
            return id_lista;

        }
    }
}
