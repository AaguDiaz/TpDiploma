using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using COMUN.Seguridad;
using COMUN;

namespace Modelo
{
    public class MoPermisos
    {
        private SqlDataReader reader;
        private SqlDataReader reader2;



        public void ObtenerPermisosIndividuales()
        {
            List<Permisos> permisos = new List<Permisos>();
            using (SqlConnection connection = new SqlConnection(MoConexionSQL.Instance.Conexion))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT p.nombre_permiso AS Permisos " +
                        " FROM usuarios_permisos up" +
                        " LEFT JOIN permisos p ON up.id_permiso = p.id_permiso" +
                        " WHERE up.id_usuario = @id_usuario ";
                    command.Parameters.AddWithValue("@id_usuario", UserLoginCache.id_usuario);
                    connection.Open();
                    DataTable dt = new DataTable();
                    reader = command.ExecuteReader();
                    dt.Load(reader);
                    command.Parameters.Clear();
                    reader.Close();
                    if (dt.Rows != null)
                    {
                        foreach (DataRow Row in dt.Rows)
                        {
                            permisos.Add(MostrarPermisosPorNombre(Row["Permisos"].ToString()));
                            UserLoginCache.permisos_individuales = permisos;

                        }
                    }
                    connection.Close();
                }
            }
        }
        public Permisos MostrarPermisosPorNombre(string permiso_nombre)
        {
            Permisos permisos = new Permisos();
            using (SqlConnection connection = new SqlConnection(MoConexionSQL.Instance.Conexion))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT p.id_permiso AS IdP, p.nombre_permiso AS Permisos, f.id_formulario AS IdF, f.nombre_formulario AS Formulario " +
                    " FROM permisos p " +
                    " LEFT JOIN formularios f ON p.id_formulario = f.id_formulario " +
                    " WHERE p.nombre_permiso = @Permisos";
                    command.Parameters.AddWithValue("@Permisos", permiso_nombre);
                    connection.Open();
                    reader = command.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    reader.Close();
                    command.Parameters.Clear();
                    if (dt.Rows != null)
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            Formularios formularios = new Formularios();
                            formularios.nombre_formulario = row["Formulario"].ToString(); ;

                            permisos.nombre_permiso = row["Permisos"].ToString();
                            permisos.formulario = formularios;
                            permisos.modulos = new List<Modulos>();

                            command.CommandText = "SELECT m.nombre_modulo AS Modulo " +
                                " FROM modulo m " +
                                " LEFT JOIN permiso_modulo fm ON m.id_modulo = fm.id_modulo" +
                                " WHERE fm.id_permiso = @idpermiso";
                            command.Parameters.AddWithValue("@idpermiso", row["IdP"]);
                            reader2 = command.ExecuteReader();
                            if (reader2 != null)
                            {
                                while (reader2.Read())
                                {
                                    Modulos modulos = new Modulos();
                                    modulos.nombre_modulo = reader2["Modulo"].ToString();

                                    permisos.modulos.Add(modulos);
                                }
                                reader2.Close();
                                command.Parameters.Clear();
                            }
                        }
                    }
                    connection.Close();
                    return permisos;
                }
            }
        }



        public DataTable MostrarPermisos()
        {
            using (SqlConnection connection = new SqlConnection(MoConexionSQL.Instance.Conexion))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    connection.Open();
                    command.CommandText = "SELECT nombre_permiso AS Permisos FROM permisos";
                    reader = command.ExecuteReader();
                    DataTable table = new DataTable();
                    table.Load(reader);
                    reader.Close();
                    connection.Close();
                    return table;
                }
            }
        }


        public void MostrarPermisosSegunSeccion(List<string> PermisosSeccion)
        {
            List<Permisos> Permisos = new List<Permisos>();
            using (SqlConnection connection = new SqlConnection(MoConexionSQL.Instance.Conexion))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    connection.Open();
                    foreach (string permiso in PermisosSeccion)
                    {
                        command.CommandText = "SELECT p.id_permiso AS IdP, p.nombre_permiso AS Permisos, f.id_formulario AS IdF, f.nombre_formulario AS Formulario " +
                           " FROM permisos p " +
                           " LEFT JOIN formularios f ON p.id_formulario = f.id_formulario " +
                           " WHERE f.nombre_formulario = @Permisos";
                        command.Parameters.AddWithValue("@Permisos", permiso);
                        reader = command.ExecuteReader();
                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        if (dt.Rows != null)
                        {
                            foreach (DataRow row in dt.Rows)
                            {
                                Formularios formularios = new Formularios();
                                formularios.nombre_formulario = row["Formulario"].ToString();

                                Permisos permisos = new Permisos
                                {
                                    nombre_permiso = row["Permisos"].ToString(),
                                    formulario = formularios,
                                    modulos = new List<Modulos>()
                                };

                                command.CommandText = "SELECT m.nombre_modulo AS Modulo " +
                                    " FROM modulo m " +
                                    " LEFT JOIN permiso_modulo fm ON m.id_modulo = fm.id_modulo" +
                                    " WHERE fm.id_permiso = @idpermiso ";
                                command.Parameters.AddWithValue("@idpermiso", row["IdP"]);
                                reader2 = command.ExecuteReader();
                                if (reader2 != null)
                                {
                                    while (reader2.Read())
                                    {
                                        Modulos modulos = new Modulos();
                                        modulos.nombre_modulo = reader2["Modulo"].ToString();

                                        permisos.modulos.Add(modulos);
                                    }
                                    reader2.Close();
                                    command.Parameters.Clear();
                                }

                                Permisos.Add(permisos);
                            }
                        }
                        COMUN.Seguridad.Permisos.PermisosPorFormulario = Permisos;
                        reader.Close();
                        command.Parameters.Clear();
                    }
                    connection.Close();
                }

            }
        }
    }
}
