using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using COMUN.Seguridad;
using COMUN.Seguridad.Composite;
using COMUN;

namespace Modelo
{
    public class MoGrupos
    {
        private MoPermisos permisos = new MoPermisos();
        private SqlDataReader reader;
        int skip = 0;


        public void ObtenerGruposDelUsuario()
        {
            using (SqlConnection connection = new SqlConnection(MoConexionSQL.Instance.Conexion))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT g.id_grupo, g.nombre_grupo " +
                        " FROM usuarios_grupos ug" +
                        " LEFT JOIN grupos g ON ug.id_grupo = g.id_grupo" +
                        " WHERE g.id_estado = '4' AND ug.id_usuario = @id_usuario  ";
                    command.Parameters.AddWithValue("@id_usuario", UserLoginCache.id_usuario);
                    connection.Open();
                    DataTable dt = new DataTable();
                    using (SqlDataReader leer = command.ExecuteReader())
                    {
                        dt.Load(leer);
                        leer.Close();
                        if (dt.Rows != null)
                        {
                            foreach (DataRow Row in dt.Rows)
                            {
                                Grupo grupo = new Grupo();
                                grupo.permisos = new List<Permisos>();
                                grupo.id_grupo = Convert.ToInt32(Row["id_grupo"]);
                                grupo.nombre_grupo = Row["nombre_grupo"].ToString();

                                command.CommandText = "SELECT p.nombre_permiso AS permiso " +
                                    " from grupos g " +
                                    " left join permisos_grupos pg ON g.id_grupo = pg.id_grupo " +
                                    " left join permisos p ON pg.id_permiso = p.id_permiso " +
                                    " where g.nombre_grupo = @grupo ";
                                command.Parameters.AddWithValue("@grupo", grupo.nombre_grupo);
                                DataTable dt2 = new DataTable();
                                using (SqlDataReader reader2 = command.ExecuteReader())
                                {
                                    dt2.Load(reader2);
                                    reader2.Close();
                                    if (dt2.Rows != null)
                                    {
                                        foreach (DataRow row in dt2.Rows)
                                        {
                                            grupo.permisos.Add(permisos.MostrarPermisosPorNombre(row["permiso"].ToString()));

                                        }

                                    }
                                }
                                if (UserLoginCache.grupos == null)
                                {
                                    UserLoginCache.grupos = new List<Grupo>();
                                }
                                UserLoginCache.grupos.Add(grupo);
                                command.Parameters.Clear();

                            }
                        }
                    }

                    command.Parameters.Clear();
                    connection.Close();
                }
            }
         }


        public DataTable MostrarGrupos()
        {
            using (SqlConnection connection = new SqlConnection(MoConexionSQL.Instance.Conexion))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    DataTable table = new DataTable();
                    command.CommandText = "SELECT nombre_grupo AS Grupos FROM grupos WHERE id_estado = '4' ";
                    connection.Open();
                    reader = command.ExecuteReader();
                    table.Load(reader);
                    reader.Close();
                    connection.Close();
                    return table;
                }
            }
        }

        public DataTable MostrarTodosGrupos(int currentPage)
        {
            using (SqlConnection connection = new SqlConnection(MoConexionSQL.Instance.Conexion))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    skip = (currentPage - 1) * 12;
                    DataTable table = new DataTable();
                    connection.Open();
                    command.CommandText = "SELECT g.id_grupo AS ID, g.nombre_grupo AS Grupos, g.descripcion AS Descripcion, e.Estado AS Estado " +
                        " FROM grupos g " +
                        " LEFT JOIN estado e ON g.id_estado = e.id_estado " +
                        $"   ORDER BY ID OFFSET {skip} ROWS FETCH NEXT {12} ROWS ONLY";
                    reader = command.ExecuteReader();
                    table.Load(reader);
                    reader.Close();
                    connection.Close();
                    return table;
                }
            }
        }
        public DataTable MostrarGruposAlta(int curentPage)
        {
            using (SqlConnection connection = new SqlConnection(MoConexionSQL.Instance.Conexion))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    skip = (curentPage - 1) * 12;
                    DataTable table = new DataTable();
                    connection.Open();
                    command.CommandText = "SELECT g.id_grupo AS ID, g.nombre_grupo AS Grupos, g.descripcion AS Descripcion, e.Estado AS Estado " +
                        " FROM grupos g " +
                        " LEFT JOIN estado e ON g.id_estado = e.id_estado " +
                        " WHERE g.id_estado = '4' " +
                         $"   ORDER BY ID OFFSET {skip} ROWS FETCH NEXT {12} ROWS ONLY";
                    reader = command.ExecuteReader();
                    table.Load(reader);
                    reader.Close();
                    connection.Close();
                    return table;
                }
            }
        }
        public DataTable MostrarGruposBaja(int currentPage)
        {
            using (SqlConnection connection = new SqlConnection(MoConexionSQL.Instance.Conexion))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    skip = (currentPage - 1) * 12;
                    DataTable table = new DataTable();
                    connection.Open();
                    command.CommandText = "SELECT g.id_grupo AS ID, g.nombre_grupo AS Grupos, g.descripcion AS Descripcion, e.Estado AS Estado " +
                        " FROM grupos g " +
                        " LEFT JOIN estado e ON g.id_estado = e.id_estado " +
                        " WHERE g.id_estado = '5' " +
                         $"   ORDER BY ID OFFSET {skip} ROWS FETCH NEXT {12} ROWS ONLY";
                    reader = command.ExecuteReader();
                    table.Load(reader);
                    reader.Close();
                    connection.Close();
                    return table;
                }
            }
        }

        public void DardeAltaGrupo(string nombreGrupo)
        {

            using (SqlConnection connection = new SqlConnection(MoConexionSQL.Instance.Conexion))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    connection.Open();
                    command.CommandText = "UPDATE grupos SET id_estado = @estado WHERE nombre_grupo = @nombreGrupo";
                    command.Parameters.AddWithValue("@estado", 4);
                    command.Parameters.AddWithValue("@nombreGrupo", nombreGrupo);
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                    connection.Close();
                }
            }
        }
        public void DardeBajaGrupo(string nombreGrupo)
        {
            using (SqlConnection connection = new SqlConnection(MoConexionSQL.Instance.Conexion))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    connection.Open();
                    command.CommandText = "UPDATE grupos SET id_estado = @estado WHERE nombre_grupo = @nombreGrupo";
                    command.Parameters.AddWithValue("@estado", 5);
                    command.Parameters.AddWithValue("@nombreGrupo", nombreGrupo);
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                    connection.Close();
                }
            }
        }

        public bool AgregarGrupo(Composite grupo)
        {
            using (SqlConnection connection = new SqlConnection(MoConexionSQL.Instance.Conexion))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    //verificamos si el grupo ya existe
                    command.Connection = connection;
                    connection.Open();
                    command.CommandText = "SELECT COUNT(*) FROM grupos WHERE nombre_grupo = @nombreGrupo";
                    command.Parameters.AddWithValue("@nombreGrupo", grupo.ObtenerNombre());
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    command.Parameters.Clear();

                    if (count > 0)
                    {
                        connection.Close();
                        return false;
                    }
                    else
                    {
                        //creamos el grupo
                        command.CommandText = "INSERT INTO grupos (nombre_grupo, descripcion, id_estado) OUTPUT INSERTED.id_grupo VALUES (@nombreGrupo, @descripcionGrupo, '4' )";
                        command.Parameters.AddWithValue("@nombreGrupo", grupo.ObtenerNombre());
                        command.Parameters.AddWithValue("@descripcionGrupo", grupo.descripcion_grupo);
                        int idGrupo = (int)(command.ExecuteScalar());

                        //recorremos los permisos del grupo y los agregamos a la tabla permisos_grupo
                        foreach (Leaf permiso in grupo.ObtenerHijos())
                        {
                            //buscamos el id del permiso
                            command.CommandText = "SELECT id_permiso FROM permisos WHERE nombre_permiso = @nombrePermiso";
                            command.Parameters.AddWithValue("@nombrePermiso", permiso.ObtenerNombre());
                            int idPermiso = Convert.ToInt32(command.ExecuteScalar());

                            command.CommandText = "INSERT INTO permisos_grupos (id_permiso, id_grupo) VALUES (@idPermiso, @idGrupo)";
                            command.Parameters.AddWithValue("@idPermiso", idPermiso);
                            command.Parameters.AddWithValue("@idGrupo", idGrupo);
                            command.ExecuteNonQuery();
                            command.Parameters.Clear();
                        }
                        command.Parameters.Clear();
                        connection.Close();
                        return true;
                    }
                }
            }
        }

        public bool EditarGrupo(Composite grupo, int id_grupo)
        {
            using (SqlConnection connection = new SqlConnection(MoConexionSQL.Instance.Conexion))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    connection.Open();
                    command.CommandText = "UPDATE grupos SET nombre_grupo = @nombreGrupo, descripcion = @descripcionGrupo WHERE id_grupo = @idGrupo";
                    command.Parameters.AddWithValue("@nombreGrupo", grupo.ObtenerNombre());
                    command.Parameters.AddWithValue("@descripcionGrupo", grupo.descripcion_grupo);
                    command.Parameters.AddWithValue("@idGrupo", id_grupo);
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                    foreach (Leaf permiso in grupo.ObtenerHijos())
                    {
                        command.CommandText = "SELECT id_permiso FROM permisos WHERE nombre_permiso = @nombrePermiso";
                        command.Parameters.AddWithValue("@nombrePermiso", permiso.ObtenerNombre());
                        int idPermiso = Convert.ToInt32(command.ExecuteScalar());
                        command.Parameters.Clear();

                        command.CommandText = "SELECT COUNT(*) FROM permisos_grupos WHERE id_permiso = @idPermiso AND id_grupo = @idGrupo";
                        command.Parameters.AddWithValue("@idPermiso", idPermiso);
                        command.Parameters.AddWithValue("@idGrupo", id_grupo);
                        int count = Convert.ToInt32(command.ExecuteScalar());
                        command.Parameters.Clear();

                        if (count == 0)
                        {
                            command.CommandText = "INSERT INTO permisos_grupos (id_permiso, id_grupo) VALUES (@idPermiso, @idGrupo)";
                            command.Parameters.AddWithValue("@idPermiso", idPermiso);
                            command.Parameters.AddWithValue("@idGrupo", id_grupo);
                            command.ExecuteNonQuery();
                            command.Parameters.Clear();
                        }
                    }
                    // si el permiso no esta en el grupo, se elimina de la tabla permisos_grupo
                    command.CommandText = "SELECT id_permiso FROM permisos_grupos WHERE id_grupo = @idGrupo";
                    command.Parameters.AddWithValue("@idGrupo", id_grupo);
                    reader = command.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    command.Parameters.Clear();
                    if (dt.Rows != null)
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            bool existe = false;
                            foreach (Leaf permiso in grupo.ObtenerHijos())
                            {
                                command.CommandText = "SELECT id_permiso FROM permisos WHERE nombre_permiso = @nombrePermiso";
                                command.Parameters.AddWithValue("@nombrePermiso", permiso.ObtenerNombre());
                                int idPermiso = Convert.ToInt32(command.ExecuteScalar());
                                command.Parameters.Clear();
                                if (idPermiso == Convert.ToInt32(row["id_permiso"]))
                                {
                                    existe = true;
                                    break;
                                }
                            }
                            if (existe == false)
                            {
                                command.CommandText = "DELETE FROM permisos_grupos WHERE id_permiso = @idPermiso AND id_grupo = @idGrupo";
                                command.Parameters.AddWithValue("@idPermiso", Convert.ToInt32(row["id_permiso"]));
                                command.Parameters.AddWithValue("@idGrupo", id_grupo);
                                command.ExecuteNonQuery();
                                command.Parameters.Clear();
                            }
                        }
                    }
                    connection.Close();
                    return true;

                }
            }
        }



        public Grupo MostrarGrupoSegunNombre(string nombre)
        {
            using (SqlConnection connection = new SqlConnection(MoConexionSQL.Instance.Conexion))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    Grupo grupo = new Grupo();
                    grupo.permisos = new List<Permisos>();
                    command.Connection = connection;
                    connection.Open();
                    command.CommandText = "SELECT id_grupo, nombre_grupo, descripcion FROM grupos WHERE nombre_grupo = @nombreGrupo ";
                    command.Parameters.AddWithValue("@nombreGrupo", nombre);
                    reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        grupo.id_grupo = Convert.ToInt32(reader["id_grupo"]);
                        grupo.nombre_grupo = reader["nombre_grupo"].ToString();
                        grupo.descripcion_grupo = reader["descripcion"].ToString();

                        command.CommandText = "SELECT p.nombre_permiso AS permiso " +
                            " from grupos g " +
                            " left join permisos_grupos pg ON g.id_grupo = pg.id_grupo " +
                            " left join permisos p ON pg.id_permiso = p.id_permiso " +
                            " where g.nombre_grupo = @grupo ";
                        command.Parameters.AddWithValue("@grupo", grupo.nombre_grupo);
                        reader.Close();
                        DataTable dt = new DataTable();
                        dt.Load(reader = command.ExecuteReader());
                        if (dt.Rows != null)
                        {
                            foreach (DataRow row in dt.Rows)
                            {
                                grupo.permisos.Add(permisos.MostrarPermisosPorNombre(row["permiso"].ToString()));
                            }
                        }

                    }
                    command.Parameters.Clear();
                    connection.Close();
                    return grupo;
                }
            }
        }

    }
}
