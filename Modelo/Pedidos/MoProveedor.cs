using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using COMUN.Cache;

namespace Modelo
{
    public class MoProveedor
    {
        SqlDataReader reader;

        public DataTable Mostrar()
        {
            using (SqlConnection connection = new SqlConnection(MoConexionSQL.Instance.Conexion))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    DataTable table = new DataTable();
                    command.Connection = connection;
                    connection.Open();
                    command.CommandText = "Select id_proveedor AS ID, nombre_proveedor AS Proveedor, direccion_pro AS Direccion, cuil AS CUIL, telefono AS Telefono, estado AS Estado from proveedores";
                    reader = command.ExecuteReader();
                    table.Clear();
                    table.Load(reader);
                    reader.Close();
                    connection.Close();
                    return table;
                }
            }
        }
        public int verificacion(string nombre, string direccion, long cuil, long telefono)
        {
            using (SqlConnection connection = new SqlConnection(MoConexionSQL.Instance.Conexion))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    int id_lista = 0;
                    command.Connection = connection;
                    connection.Open();
                    command.CommandText = "Select id_proveedor from proveedores where nombre_proveedor = '" + nombre + "' AND direccion_pro = '" + direccion + "' AND cuil = '" + cuil + "' AND telefono = '" + telefono + "'";
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        if (reader.HasRows)
                        {
                            id_lista = reader.GetInt32(0);
                            reader.Close();
                            connection.Close();
                            return id_lista;
                        }
                        else
                        {
                            reader.Close();
                            connection.Close();
                            return id_lista;
                        }
                    }
                    return id_lista;
                }
            }
        }
        public void InsertarProveedor(string nombre_proveedor, string direccion_pro, long cuil, long telefono)
        {
            using (SqlConnection connection = new SqlConnection(MoConexionSQL.Instance.Conexion))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    string Estado = "Activo";
                    connection.Open();
                    command.CommandText = "INSERT INTO proveedores VALUES('" + nombre_proveedor + "','" + direccion_pro + "', '" + cuil + "', '" + telefono + "','" + Estado + ")";
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public void ModificarProveedor(int id, string nombre_proveedor, string direccion_pro, long cuil, long telefono)
        {
            using (SqlConnection connection = new SqlConnection(MoConexionSQL.Instance.Conexion))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    string Estado = "Activo";
                    command.Connection = connection;
                    connection.Open();
                    command.CommandText = "UPDATE proveedores " +
                        " SET nombre_proveedor = @nombre, direccion_pro = @dire, cuil = @cuil, telefono =@tel, estado= @estado " +
                        " WHERE id_proveedor = @id ";
                    command.Parameters.AddWithValue("@nombre", nombre_proveedor);
                    command.Parameters.AddWithValue("@dire", direccion_pro);
                    command.Parameters.AddWithValue("@cuil", cuil);
                    command.Parameters.AddWithValue("@tel", telefono);
                    command.Parameters.AddWithValue("@estado", Estado);
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                    connection.Close();

                }
            }
        }

        public void DarAltaProveedor(int id)
        {
            using (SqlConnection connection = new SqlConnection(MoConexionSQL.Instance.Conexion))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    string Estado = "Activo";
                    connection.Open();
                    command.CommandText = "UPDATE proveedores SET estado = @estado WHERE id_proveedor = @id";
                    command.Parameters.AddWithValue("@estado", Estado);
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                    connection.Close();
                }
            }

        }

        public void DarBajaProveedor(int id)
        {
            using (SqlConnection connection = new SqlConnection(MoConexionSQL.Instance.Conexion))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    string Estado = "Inactivo";
                    command.Connection = connection;
                    connection.Open();
                    command.CommandText = "UPDATE proveedores SET estado = @estado WHERE id_proveedor = @id ";
                    command.Parameters.AddWithValue("@estado", Estado);
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                    connection.Close();
                }
            }
        }

        public List<CacheProveedor> MostrarProveedor()
        {
            using (SqlConnection connection = new SqlConnection(MoConexionSQL.Instance.Conexion))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    connection.Open();
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
                    connection.Close();
                    return proveedores;
                }
            }
        }

    }
}
