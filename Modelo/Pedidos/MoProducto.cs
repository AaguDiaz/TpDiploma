using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using COMUN.Cache;
using COMUN;

namespace Modelo
{
    public class MoProducto
    {
        private SqlDataReader reader; 
        DataTable tabla = new DataTable();

        public DataTable MostrarCategorias()
        {
            using (SqlConnection connection = new SqlConnection(MoConexionSQL.Instance.Conexion))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    connection.Open();
                    command.CommandText = "Select id_categoria, nombre from categorias";
                    DataTable categorias = new DataTable();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        categorias.Load(reader);
                        reader.Close();
                    }
                    connection.Close();
                    return categorias;
                }
            }
        }

        public DataTable MostrarProductos(int currentPage)
        {
            using (SqlConnection connection = new SqlConnection(MoConexionSQL.Instance.Conexion))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    int skip = (currentPage - 1) * 12;
                    connection.Open();
                    command.CommandText = "Select p.nombre_producto AS Producto, p.descripcion AS Descripcion, c.nombre AS Categoria" +
                        "   FROM productos p " +
                        "   LEFT JOIN categorias c ON p.categoria = c.id_categoria " +
                        $" ORDER BY Producto OFFSET {skip} ROWS FETCH NEXT {12} ROWS ONLY";
                    tabla.Clear();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            tabla.Load(reader);
                            command.Parameters.Clear();
                            connection.Close();
                            return tabla;
                        }
                        else
                        {
                            command.Parameters.Clear();
                            connection.Close();
                            return tabla;
                        }
                    }
                }
            }
        }
        public DataTable MostrarProductosFil(int currentPage, int valor)
        {
            using (SqlConnection connection = new SqlConnection(MoConexionSQL.Instance.Conexion))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    int skip = (currentPage - 1) * 12;
                    command.Connection = connection;
                    connection.Open();
                    command.CommandText = "Select p.nombre_producto AS Producto, p.descripcion AS Descripcion, c.nombre AS Categoria" +
                        "   FROM productos p " +
                        "   LEFT JOIN categorias c ON p.categoria = c.id_categoria" +
                        "   WHERE p.categoria = @valor " +
                        $" ORDER BY Producto OFFSET {skip} ROWS FETCH NEXT {12} ROWS ONLY";
                    command.Parameters.AddWithValue("@valor", valor);
                    reader = null;
                    tabla.Clear();
                    using (reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            tabla.Load(reader);
                            command.Parameters.Clear();
                            connection.Close();
                            return tabla;
                        }
                        else
                        {
                            command.Parameters.Clear();
                            connection.Close();
                            return tabla;
                        }
                    }
                }
            }
        }

        public DataTable MostrarProductosABM()
        {
            using (SqlConnection connection = new SqlConnection(MoConexionSQL.Instance.Conexion))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    connection.Open();
                    command.CommandText = "Select p.id_producto AS Id, p.nombre_producto AS Producto, p.descripcion AS Descripcion, c.nombre AS Categoria" +
                        "   FROM productos p " +
                        "   LEFT JOIN categorias c ON p.categoria = c.id_categoria";
                    tabla.Clear();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            tabla.Load(reader);
                            command.Parameters.Clear();
                            connection.Close();
                            return tabla;
                        }
                        else
                        {
                            command.Parameters.Clear();
                            connection.Close();
                            return tabla;
                        }
                    }
                }
            }
        }


        public void AgregarProducto(string nombre, string descripcion, string categoria)
        {
            using (SqlConnection connection = new SqlConnection(MoConexionSQL.Instance.Conexion))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    connection.Open();
                    command.CommandText = "SELECT id_categoria FROM categorias WHERE nombre = @categoria";
                    command.Parameters.AddWithValue("@categoria", categoria);
                    int id = Convert.ToInt32(command.ExecuteScalar());
                    command.CommandText = "INSERT INTO productos (nombre_producto, descripcion, categoria) OUTPUT INSERTED.id_producto VALUES (@nombre, @descripcion, @idcategoria)";
                    command.Parameters.AddWithValue("@nombre", nombre);
                    command.Parameters.AddWithValue("@descripcion", descripcion);
                    command.Parameters.AddWithValue("@idcategoria", id);
                    int idp = Convert.ToInt32(command.ExecuteScalar());
                    if (idp != 0)
                    {
                        command.Parameters.Clear();
                        command.CommandText = "SELECT id_empleado FROM empleados WHERE id_usuario = @Usuario";
                        command.Parameters.AddWithValue("@Usuario", UserLoginCache.id_usuario);
                        int idemp = Convert.ToInt32(command.ExecuteScalar());

                        command.CommandText = "INSERT INTO productos_auditoria (id_producto, nombre_producto, descripcion, categoria, id_empleado, registro, fecha) VALUES (@idp, @nombre, @desc, @cat, @idemp, @regis, @fecha)";
                        command.Parameters.AddWithValue("@idp", idp);
                        command.Parameters.AddWithValue("@nombre", nombre);
                        command.Parameters.AddWithValue("@desc", descripcion);
                        command.Parameters.AddWithValue("@cat", id);
                        command.Parameters.AddWithValue("@idemp", idemp);
                        command.Parameters.AddWithValue("@regis", "Registro Producto");
                        command.Parameters.AddWithValue("@fecha", DateTime.Now);

                        command.ExecuteNonQuery();
                    }
                    command.Parameters.Clear();
                    connection.Close();
                }
            }
        }

        public void ModificarProducto(int id, string nombre, string descripcion, string categoria)
        {
            using (SqlConnection connection = new SqlConnection(MoConexionSQL.Instance.Conexion))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    connection.Open();
                    command.CommandText = "SELECT id_categoria FROM categorias WHERE nombre = @categoria";
                    command.Parameters.AddWithValue("@categoria", categoria);
                    int idcat = Convert.ToInt32(command.ExecuteScalar());
                    command.CommandText = "UPDATE productos SET nombre_producto = @nombre, descripcion = @descripcion, categoria = @idcategoria WHERE id_producto = @id";
                    command.Parameters.AddWithValue("@nombre", nombre);
                    command.Parameters.AddWithValue("@descripcion", descripcion);
                    command.Parameters.AddWithValue("@idcategoria", idcat);
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();

                    command.CommandText = "SELECT id_empleado FROM empleados WHERE id_usuario = @Usuario";
                    command.Parameters.AddWithValue("@Usuario", UserLoginCache.id_usuario);
                    int idemp = Convert.ToInt32(command.ExecuteScalar());

                    command.CommandText = "INSERT INTO productos_auditoria (id_producto, nombre_producto, descripcion, categoria, id_empleado, registro, fecha) VALUES (@idp, @nombre, @desc, @cat, @idemp, @regis, @fecha)";
                    command.Parameters.AddWithValue("@idp", id);
                    command.Parameters.AddWithValue("@nombre", nombre);
                    command.Parameters.AddWithValue("@desc", descripcion);
                    command.Parameters.AddWithValue("@cat", idcat);
                    command.Parameters.AddWithValue("@idemp", idemp);
                    command.Parameters.AddWithValue("@regis", "Modificacion Producto");
                    command.Parameters.AddWithValue("@fecha", DateTime.Now);
                    command.ExecuteNonQuery();


                    command.Parameters.Clear();
                    connection.Close();
                }
            }
        }

        public int EliminarProducto(int id)
        {
            using (SqlConnection connection = new SqlConnection(MoConexionSQL.Instance.Conexion))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    connection.Open();
                    command.CommandText = "SELECT id_empleado FROM empleados WHERE id_usuario = @Usuario";
                    command.Parameters.AddWithValue("@Usuario", UserLoginCache.id_usuario);
                    int idemp = Convert.ToInt32(command.ExecuteScalar());
                    command.CommandText = "SELECT id_lista FROM lista_pedidos_productos WHERE id_productos = @idp";
                    command.Parameters.AddWithValue("@idp", id);
                    int result = Convert.ToInt32(command.ExecuteScalar());
                    if (result == 0)
                    {
                        command.CommandText = "SELECT nombre_producto, descripcion, categoria FROM productos WHERE id_producto = @id";
                        command.Parameters.AddWithValue("@id", id);
                        SqlDataReader reader = command.ExecuteReader();
                        if(reader.HasRows)
                        {
                            DataTable tabla = new DataTable();
                            tabla.Load(reader);
                            reader.Close();
                            string nombre = tabla.Rows[0][0].ToString();
                            string descripcion = tabla.Rows[0][1].ToString();
                            int idcat = Convert.ToInt32(tabla.Rows[0][2].ToString());
                            command.Parameters.Clear();

                            command.CommandText = "INSERT INTO productos_auditoria (id_producto, nombre_producto, descripcion, categoria, id_empleado, registro, fecha) VALUES (@idp, @nombre, @desc, @cat, @idemp, @regis, @fecha)";
                            command.Parameters.AddWithValue("@idp", id);
                            command.Parameters.AddWithValue("@nombre", nombre);
                            command.Parameters.AddWithValue("@desc", descripcion);
                            command.Parameters.AddWithValue("@cat", idcat);
                            command.Parameters.AddWithValue("@idemp", idemp);
                            command.Parameters.AddWithValue("@regis", "eliminacion Producto");
                            command.Parameters.AddWithValue("@fecha", DateTime.Now);
                            command.ExecuteNonQuery();
                            
                        }
                        command.Parameters.Clear();
                        reader.Close();
                        command.CommandText = "DELETE FROM productos WHERE id_producto = @id";
                        command.Parameters.AddWithValue("@id", id);
                        command.ExecuteNonQuery();
                        command.Parameters.Clear();
                        connection.Close();
                        return result;
                    }
                    else
                    {
                        command.Parameters.Clear();
                        connection.Close();
                        return result;
                    }
                }
            }
        }

        public int ObtenerIdCat()
        {
            using (SqlConnection connection = new SqlConnection(MoConexionSQL.Instance.Conexion))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    connection.Open();
                    command.CommandText = " SELECT TOP 1 id_categoria " +
                        " FROM categorias " +
                        " ORDER BY id_categoria DESC ";
                    int id = Convert.ToInt32(command.ExecuteScalar());
                    command.Parameters.Clear();
                    connection.Close();
                    return id;
                }
            }
        }

        public void AgregarCategoria(string nombre)
        {
            using (SqlConnection connection = new SqlConnection(MoConexionSQL.Instance.Conexion))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    connection.Open();
                    command.CommandText = "INSERT INTO categorias (nombre) VALUES (@nombre)";
                    command.Parameters.AddWithValue("@nombre", nombre);
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                    connection.Close();
                }
            }
        }   

    }
}
