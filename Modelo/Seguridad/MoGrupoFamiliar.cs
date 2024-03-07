using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using COMUN;
using COMUN.Cache;
using COMUN.Seguridad;
using COMUN.Seguridad.Composite;

namespace Modelo.Seguridad
{
    public class MoGrupoFamiliar
    {

        public void ObtenerGrupoFamiliar(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(MoConexionSQL.Instance.Conexion))
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "SELECT  gf.id_grupo_familiar AS ID_GRUPO, CONCAT(gf.nombre, ' ', gf.apellido) AS NOMBRECOMPLETO, gf.dni AS DNI, gf.fecha_nacimiento AS FECHA_NACIMIENTO, gf.parentesco AS PARENTESCO " +
                            "   FROM grupo_familiar gf " +
                            "   LEFT JOIN empleados e ON gf.id_empleado = e.id_empleado " +
                            "   LEFT JOIN usuarios u ON e.id_usuario = u.id_usuario " +
                            "   WHERE u.id_usuario = @id ";
                        command.Parameters.AddWithValue("@id", id);
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader);

                            if (dt.Rows != null)
                            {
                                foreach(DataRow row in dt.Rows)
                                {
                                    GrupoFamiliar grupoFamiliar = new GrupoFamiliar();
                                    grupoFamiliar.IdGrupoFamiliar = Convert.ToInt32(row["ID_GRUPO"]);
                                    grupoFamiliar.nombreCompleto = row["NOMBRECOMPLETO"].ToString();
                                    grupoFamiliar.dni = Convert.ToInt32(row["DNI"]);
                                    grupoFamiliar.fecha_nacimiento = Convert.ToDateTime(row["FECHA_NACIMIENTO"]);
                                    grupoFamiliar.parentesco = row["PARENTESCO"].ToString();
                                    if (UserLoginCache.grupoFamiliar == null)
                                    {
                                        UserLoginCache.grupoFamiliar = new List<GrupoFamiliar>();
                                    }
                                    UserLoginCache.grupoFamiliar.Add(grupoFamiliar);
                                }
                            }
                        }
                        command.Parameters.Clear();
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el grupo familiar", ex);
            }
        }

        public DataTable MostrarFamiliares(int id)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(MoConexionSQL.Instance.Conexion))
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "SELECT  gf.id_grupo_familiar AS ID_GRUPO, gf.nombre AS Nombre, gf.apellido AS Apellido, gf.dni AS DNI, gf.fecha_nacimiento AS Fecha_nacimiento, gf.parentesco AS parentesco " +
                            "   FROM grupo_familiar gf " +
                            "   LEFT JOIN empleados e ON gf.id_empleado = e.id_empleado " +
                            "   LEFT JOIN usuarios u ON e.id_usuario = u.id_usuario " +
                            "   WHERE u.id_usuario = @id ";
                        command.Parameters.AddWithValue("@id", id);
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            dt.Load(reader);
                        }
                        command.Parameters.Clear();
                        connection.Close();
                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el grupo familiar", ex);
            }
        }

        public void AgregarFamiliar(int id, string nombre, string apellido, int dni, DateTime fecha, string parentesco)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(MoConexionSQL.Instance.Conexion))
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "INSERT INTO grupo_familiar (id_empleado, nombre, apellido, dni, fecha_nacimiento, parentesco) " +
                            "   VALUES ((SELECT id_empleado FROM empleados WHERE id_usuario = @id), @nombre, @apellido, @dni, @fecha, @parentesco)";
                        command.Parameters.AddWithValue("@id", id);
                        command.Parameters.AddWithValue("@nombre", nombre);
                        command.Parameters.AddWithValue("@apellido", apellido);
                        command.Parameters.AddWithValue("@dni", dni);
                        command.Parameters.AddWithValue("@fecha", fecha);
                        command.Parameters.AddWithValue("@parentesco", parentesco);
                        connection.Open();
                        command.ExecuteNonQuery();
                        command.Parameters.Clear();
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar el familiar", ex);
            }
        }
        public void EliminarFamiliar(int id, int dni)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(MoConexionSQL.Instance.Conexion))
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "DELETE FROM grupo_familiar WHERE id_empleado = (SELECT id_empleado FROM empleados WHERE id_usuario = @id) AND dni = @dni";
                        command.Parameters.AddWithValue("@id", id);
                        command.Parameters.AddWithValue("@dni", dni);
                        connection.Open();
                        command.ExecuteNonQuery();
                        command.Parameters.Clear();
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el familiar", ex);
            }
        }   
    }
}
