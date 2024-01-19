using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using COMUN.Cache;

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
            command.CommandText = "Select id_proveedor AS ID, nombre_proveedor AS Proveedor, direccion_pro AS Direccion, cuil AS CUIL, telefono AS Telefono, estado AS Estado from proveedores";
            reader = command.ExecuteReader();
            table.Clear();
            table.Load(reader);
            reader.Close();
            conexion.CerrarConexion();
            return table;
        }
        public int verificacion(string nombre, string direccion, long cuil, long telefono)
        {
            int id_lista= 0;
            command.Connection = conexion.AbirConexion();
            command.CommandText = "Select id_proveedor from proveedores where nombre_proveedor = '"+nombre+"' AND direccion_pro = '"+direccion+"' AND cuil = '"+cuil+"' AND telefono = '"+telefono+"'";
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                if (reader.HasRows)
                {
                    id_lista = reader.GetInt32(0);
                    reader.Close();
                    conexion.CerrarConexion();
                    return id_lista;
                }
                else
                {
                    reader.Close();
                    conexion.CerrarConexion();
                    return id_lista;
                }
            }
            return id_lista;
        }
        public void InsertarProveedor(string nombre_proveedor, string direccion_pro, long cuil, long telefono)
        {
            string Estado = "Activo";
            command.Connection = conexion.AbirConexion();
            command.CommandText = "INSERT INTO proveedores VALUES('"+nombre_proveedor+"','" +direccion_pro+"', '"+cuil+"', '"+telefono+ "','"+Estado+")";
            command.ExecuteNonQuery();
        }

        public void ModificarProveedor(int id, string nombre_proveedor, string direccion_pro, long cuil, long telefono)
        {
            string Estado = "Activo";
            command.Connection = conexion.AbirConexion();
            command.CommandText = "UPDATE";
        }

        public void DarAltaProveedor(int id)
        {
            string Estado = "Activo";
            command.Connection = conexion.AbirConexion();
            command.CommandText = "UPDATE proveedores SET estado = '"+Estado+"' WHERE id_proveedor = '"+id+"'";
            command.ExecuteNonQuery();
        }

        public void DarBajaProveedor(int id)
        {
            string Estado = "Inactivo";
            command.Connection = conexion.AbirConexion();
            command.CommandText = "UPDATE proveedores SET estado = '" + Estado + "' WHERE id_proveedor = '" + id + "'";
            command.ExecuteNonQuery();
        }

        public List<CacheProveedor> MostrarProveedor()
        {
            command.Connection = conexion.AbirConexion();
            command.CommandText = "Select nombre_proveedor from proveedores WHERE estado = 'Activo'";
            List<CacheProveedor> proveedores = new List<CacheProveedor>();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    proveedores.Add(new CacheProveedor { nombre_proveedor = reader["nombre_proveedor"].ToString() });
                }
                reader.Close();
            }
            return proveedores;
        }

    }
}
