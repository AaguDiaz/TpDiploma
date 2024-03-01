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
using System.Runtime.InteropServices.WindowsRuntime;
using System.Net.Http.Headers;
using Modelo.Seguridad;

namespace Modelo
{
    public class MoUsuario
    {
        MoGrupos moGrupos = new MoGrupos();
        MoPermisos moPermisos = new MoPermisos();
        MoGrupoFamiliar moGrupoFamiliar = new MoGrupoFamiliar();
        private SqlDataReader reader;
        int skip = 0;


        public bool Login(string mail, string contrasena)
        {
            using (SqlConnection connection = new SqlConnection(MoConexionSQL.Instance.Conexion))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT u.id_usuario, per.nombre_empleado AS nombre ,per.apellido_empleado AS apellido, u.mail, u.contra," +
                "                         per.dni, per.cvu, per.direccion, per.telefono, " +
                "                         g.nombre_grupo AS grupos, p.nombre_permiso AS permisos, u.estado" +
                "            FROM usuarios u" +
                "            LEFT JOIN empleados per ON u.id_usuario = per.id_usuario" +
                "            LEFT JOIN usuarios_grupos ug ON u.id_usuario = ug.id_usuario" +
                "            LEFT JOIN grupos g ON ug.id_grupo = g.id_grupo " +
                "            LEFT JOIN usuarios_permisos up ON u.id_usuario = up.id_usuario" +
                "            LEFT JOIN permisos p ON up.id_permiso = p.id_permiso" +
                "            WHERE u.mail = @mail AND u.contra = @contra";
                    command.Parameters.AddWithValue("@mail", mail);
                    command.Parameters.AddWithValue("@contra", MetodosComunes.Encrypt.GetSHA256(contrasena));
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader);
                            reader.Close();
                            foreach (DataRow row in dt.Rows)
                            {
                                UserLoginCache.id_usuario = Convert.ToInt32(row[0]);
                                UserLoginCache.nombre = row[1].ToString();
                                UserLoginCache.apellido = row[2].ToString();
                                UserLoginCache.mail = row[3].ToString();
                                UserLoginCache.contra = row[4].ToString();
                                UserLoginCache.dni = Convert.ToInt32(row[5]);
                                UserLoginCache.cvu = (long)(row[6]);
                                UserLoginCache.direccion = row[7].ToString();
                                UserLoginCache.telefono = (long)row[8];
                                UserLoginCache.estado = row[11].ToString();
                                moGrupos.ObtenerGruposDelUsuario();
                                moPermisos.ObtenerPermisosIndividuales();
                                moGrupoFamiliar.ObtenerGrupoFamiliar(Convert.ToInt32(row[0]));
                            }
                            command.Parameters.Clear();
                            connection.Close();
                            return true;
                        }
                        else
                        {
                            command.Parameters.Clear();
                            connection.Close();
                            return false;
                        }
                    }
                }
            }
        }
        public bool EstadoLogin(string mail)
        {
            using (SqlConnection connection = new SqlConnection(MoConexionSQL.Instance.Conexion))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    connection.Open();
                    command.CommandText = "SELECT estado FROM usuarios WHERE mail = @mail";
                    command.Parameters.AddWithValue("@mail", mail);
                    string estado = command.ExecuteScalar().ToString();
                    if (estado == "Activo                                                      ")
                    {
                        command.Parameters.Clear();
                        connection.Close();
                        return true;
                    }
                    else
                    {
                        command.Parameters.Clear();
                        connection.Close();
                        return false;
                    }
                }
            }
        }

        public bool CargarUsuario(int id)
        {
            using (SqlConnection connection = new SqlConnection(MoConexionSQL.Instance.Conexion))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    connection.Open();
                    command.CommandText = "SELECT per.nombre_empleado,per.apellido_empleado, u.mail," +
                "                         per.dni, per.cvu, per.direccion, per.telefono, " +
                "                         g.nombre_grupo AS grupos, p.nombre_permiso AS permisos, u.estado" +
                "            FROM usuarios u" +
                "            LEFT JOIN empleados per ON u.id_usuario = per.id_usuario" +
                "            LEFT JOIN usuarios_grupos ug ON u.id_usuario = ug.id_usuario" +
                "            LEFT JOIN grupos g ON ug.id_grupo = g.id_grupo " +
                "            LEFT JOIN usuarios_permisos up ON u.id_usuario = up.id_usuario" +
                "            LEFT JOIN permisos p ON up.id_permiso = p.id_permiso" +
                "            WHERE u.id_usuario = @id";
                    command.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                CacheEditarUsuario.nombre = reader.GetString(0);
                                CacheEditarUsuario.apellido = reader.GetString(1);
                                CacheEditarUsuario.mail = reader.GetString(2);
                                CacheEditarUsuario.dni = reader.GetInt32(3);
                                CacheEditarUsuario.cvu = (long)reader.GetInt64(4);
                                CacheEditarUsuario.direccion = reader.GetString(5);
                                CacheEditarUsuario.telefono = (long)reader.GetInt64(6);
                            }
                            command.Parameters.Clear();
                            reader.Close();connection.Close();
                            return true;
                        }
                        else
                        {
                            command.Parameters.Clear();
                            reader.Close();
                            connection.Close();
                            return false;
                        }
                    }
                }
            }
        }
        public void ModificarInfoEmpleado(int id, string nombre, string apellido, int dni, long cvu, long telefono, string direccion)
        {
            using (SqlConnection connection = new SqlConnection(MoConexionSQL.Instance.Conexion))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "UPDATE empleados SET nombre_empleado = @nombre, apellido_empleado = @apellido, dni = @dni, cvu = @cvu, direccion = @direccion, telefono = @telefono WHERE id_usuario = @id";
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@nombre", nombre);
                    command.Parameters.AddWithValue("@apellido", apellido);
                    command.Parameters.AddWithValue("@dni", dni);
                    command.Parameters.AddWithValue("@cvu", cvu);
                    command.Parameters.AddWithValue("@direccion", direccion);
                    command.Parameters.AddWithValue("@telefono", telefono);
                    connection.Open();
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                    connection.Close();
                }
            }
        }


        public string enviarCodigo(string userRequesting, int cod)
        {
            using (SqlConnection connection = new SqlConnection(MoConexionSQL.Instance.Conexion))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT u.id_usuario, per.nombre_empleado AS nombre ,per.apellido_empleado AS apellido, u.mail" +
                "            FROM usuarios u" +
                "            LEFT JOIN empleados per ON u.id_usuario = per.id_usuario" +
                "            WHERE u.mail = @mail";
                    command.Parameters.AddWithValue("@mail", userRequesting);
                    connection.Open();
                    reader = command.ExecuteReader();
                    if (reader.Read() == true)
                    {
                        string userName = reader.GetString(1);
                        string userAperllido = reader.GetString(2);
                        string userMail = reader.GetString(3);
                        var mailService = new COMUN.Mail.SystemSupportMail();
                        mailService.sendMail(
                            subjet: "SYSTEM: Solicitud de recuperación de contraseña",
                            body: "Hola, " + userName + "  " + userAperllido + " esta es tu solicitud de recuperacion de contraseña" + "\n" + "tu codigo de recuperacion es: " + cod,
                            recipientMail: new List<string> { userMail },
                            attachmentPaths: new List<string>()
                            );
                        connection.Close();
                        return "Hola, " + userName + "  " + userAperllido + " tu solicitud de recuperacion de contraseña ha sido enviada a" + userMail;
                    }
                    connection.Close();
                    return "Mail no registrado";
                }
            }
        }
        public bool cambiarContra(string mail, string contra)
        {
            string contraEncriptada = MetodosComunes.Encrypt.GetSHA256(contra); 
            using (SqlConnection connection = new SqlConnection(MoConexionSQL.Instance.Conexion))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "UPDATE usuarios SET contra = @contra WHERE mail = @mail";
                    command.Parameters.AddWithValue("@mail", mail);
                    command.Parameters.AddWithValue("@contra", contraEncriptada);
                    connection.Open();
                    int rows = command.ExecuteNonQuery();
                    connection.Close();
                    if (rows > 0)
                        return true;
                    else
                        return false;
                }
            }
        }



        public DataTable MostrarUsuarios(int currentPage)
        {
            skip = (currentPage - 1) * 12;
            DataTable tabla = new DataTable();
            using (SqlConnection connection = new SqlConnection(MoConexionSQL.Instance.Conexion))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT u.id_usuario AS ID, per.nombre_empleado AS Nombre ,per.apellido_empleado AS Apellido, u.mail AS Mail," +
                "                         per.dni AS DNI, per.cvu AS CVU, per.direccion AS Dirección, per.telefono AS Teléfono, u.estado AS Estado " +
                "            FROM usuarios u " +
                "            LEFT JOIN empleados per ON u.id_usuario = per.id_usuario " +
                $"   ORDER BY ID OFFSET {skip} ROWS FETCH NEXT {12} ROWS ONLY";
                    connection.Open();
                    reader = command.ExecuteReader();
                    tabla.Load(reader);
                    connection.Close();
                    return tabla;
                }
            }
        }
        public DataTable MostrarUsuariosSegunNombreYApellido(string NomApe)
        {
            DataTable tabla = new DataTable();
            using (SqlConnection connection = new SqlConnection(MoConexionSQL.Instance.Conexion))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT u.id_usuario AS ID, per.nombre_empleado AS Nombre ,per.apellido_empleado AS Apellido, u.mail AS Mail," +
                "                         per.dni AS DNI, per.cvu AS CVU, per.direccion AS Dirección, per.telefono AS Teléfono, u.estado AS Estado " +
                "            FROM usuarios u " +
                "            LEFT JOIN empleados per ON u.id_usuario = per.id_usuario " +
                "            WHERE CONCAT(per.nombre_empleado, ' ' ,per.apellido_empleado) = @NomApe";
                    command.Parameters.AddWithValue("@NomApe", NomApe);
                    connection.Open();
                    reader = command.ExecuteReader();
                    command.Parameters.Clear();
                    tabla.Load(reader);
                    connection.Close();
                    return tabla;
                }
            }
        }
        public DataTable MostrarUsuariosSegunMail(string mail)
        {
            DataTable tabla = new DataTable();
            using (SqlConnection connection = new SqlConnection(MoConexionSQL.Instance.Conexion))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT u.id_usuario AS ID, per.nombre_empleado AS Nombre ,per.apellido_empleado AS Apellido, u.mail AS Mail," +
                "                         per.dni AS DNI, per.cvu AS CVU, per.direccion AS Dirección, per.telefono AS Teléfono, u.estado AS Estado " +
                "            FROM usuarios u " +
                "            LEFT JOIN empleados per ON u.id_usuario = per.id_usuario " +
                "            WHERE u.mail = @mail";
                    command.Parameters.AddWithValue("@mail", mail);
                    connection.Open();
                    reader = command.ExecuteReader();
                    command.Parameters.Clear();
                    tabla.Load(reader);
                    connection.Close();
                    return tabla;
                }
            }
        }
        public DataTable MostrarUsuariosSegunDNI(int Dni)
        {
            DataTable tabla = new DataTable();
            using (SqlConnection connection = new SqlConnection(MoConexionSQL.Instance.Conexion))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT u.id_usuario AS ID, per.nombre_empleado AS Nombre ,per.apellido_empleado AS Apellido, u.mail AS Mail," +
                "                         per.dni AS DNI, per.cvu AS CVU, per.direccion AS Dirección, per.telefono AS Teléfono, u.estado AS Estado " +
                "            FROM usuarios u " +
                "            LEFT JOIN empleados per ON u.id_usuario = per.id_usuario " +
                "            WHERE per.dni = @dni";
                    command.Parameters.AddWithValue("@dni", Dni);
                    connection.Open();
                    reader = command.ExecuteReader();
                    command.Parameters.Clear();
                    tabla.Load(reader);
                    connection.Close();
                    return tabla;
                }
            }
        }
        public DataTable MostrarUsuariosSegunEstado(string estado, int currentPage)
        {
            skip = (currentPage - 1) * 12;
            DataTable tabla = new DataTable();
            using (SqlConnection connection = new SqlConnection(MoConexionSQL.Instance.Conexion))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT u.id_usuario AS ID, per.nombre_empleado AS Nombre ,per.apellido_empleado AS Apellido, u.mail AS Mail," +
                "                         per.dni AS DNI, per.cvu AS CVU, per.direccion AS Dirección, per.telefono AS Teléfono, u.estado AS Estado " +
                "            FROM usuarios u " +
                "            LEFT JOIN empleados per ON u.id_usuario = per.id_usuario " +
                "            WHERE u.estado = @estado" +
                $"   ORDER BY ID OFFSET {skip} ROWS FETCH NEXT {12} ROWS ONLY";
                    command.Parameters.AddWithValue("@estado", estado);
                    connection.Open();
                    reader = command.ExecuteReader();
                    command.Parameters.Clear();
                    tabla.Load(reader);
                    connection.Close();
                    return tabla;
                }
            }
        }




        public bool AltaUsuario(int id)
        {
            using (SqlConnection connection = new SqlConnection(MoConexionSQL.Instance.Conexion))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "Select estado FROM usuarios WHERE id_usuario = @id";
                    command.Parameters.AddWithValue("@id", id);
                    connection.Open();
                    string estadoActual = command.ExecuteScalar().ToString();
                    if (estadoActual != "Activo                                                      ")
                    {
                        command.CommandText = "UPDATE usuarios SET estado = @estado WHERE id_usuario = @idusuario";
                        command.Parameters.AddWithValue("@estado", "Activo");
                        command.Parameters.AddWithValue("@idusuario", id);
                        command.CommandType = CommandType.Text;
                        int rows = command.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            command.Parameters.Clear();
                            connection.Close();
                            return true;
                        }

                        else
                        {
                            command.Parameters.Clear();
                            connection.Close();
                            return false;
                        }

                    }
                    else return false;
                }
            }
        }
        public bool BajaUsuario(int id)
        {
            using (SqlConnection connection = new SqlConnection(MoConexionSQL.Instance.Conexion))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "Select estado FROM usuarios WHERE id_usuario = @id";
                    command.Parameters.AddWithValue("@id", id);
                    connection.Open();
                    string estadoActual = command.ExecuteScalar().ToString();
                    if (estadoActual != "Baja                                                        ")
                    {
                        command.CommandText = "UPDATE usuarios SET estado = @estado WHERE id_usuario = @idusuario";
                        command.Parameters.AddWithValue("@estado", "Baja");
                        command.Parameters.AddWithValue("@idusuario", id);
                        command.CommandType = CommandType.Text;
                        int rows = command.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            command.Parameters.Clear();
                            connection.Close();
                            return true;
                        }

                        else
                        {
                            command.Parameters.Clear();
                            connection.Close();
                            return false;
                        }
                    }
                    else return false;
                }
            }
        }
        public bool EditarUsuario(int id, string nombre, string apellido, string mail, int dni, long cvu, long telefono, string direccion, List<string> permisos, List<string> grupos)
        {
            using (SqlConnection connection = new SqlConnection(MoConexionSQL.Instance.Conexion))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "UPDATE empleados SET nombre_empleado = @nombre, apellido_empleado = @apellido, dni = @dni, cvu = @cvu, direccion = @direccion, telefono = @telefono WHERE id_usuario = @id";
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@nombre", nombre);
                    command.Parameters.AddWithValue("@apellido", apellido);
                    command.Parameters.AddWithValue("@dni", dni);
                    command.Parameters.AddWithValue("@cvu", cvu);
                    command.Parameters.AddWithValue("@direccion", direccion);
                    command.Parameters.AddWithValue("@telefono", telefono);
                    connection.Open();
                    int rows = command.ExecuteNonQuery();
                    command.Parameters.Clear();
                    if (rows > 0)
                    {
                        command.CommandText = "UPDATE usuarios SET mail = @mail WHERE id_usuario = @id";
                        command.Parameters.AddWithValue("@id", id);
                        command.Parameters.AddWithValue("@mail", mail);
                        command.CommandType = CommandType.Text;
                        int rows2 = command.ExecuteNonQuery();
                        command.Parameters.Clear();
                        if (rows2 > 0)
                        {
                            if (permisos != null)
                            {
                                command.CommandText = "DELETE FROM usuarios_permisos WHERE id_usuario = @id";
                                command.Parameters.AddWithValue("@id", id);
                                command.ExecuteNonQuery();
                                command.Parameters.Clear();
                                foreach (string permiso in permisos)
                                {
                                    command.CommandText = "INSERT INTO usuarios_permisos (id_usuario, id_permiso) VALUES (@id, (SELECT id_permiso FROM permisos WHERE nombre_permiso = @permiso))";
                                    command.Parameters.AddWithValue("@id", id);
                                    command.Parameters.AddWithValue("@permiso", permiso);
                                    command.ExecuteNonQuery();
                                    command.Parameters.Clear();
                                }

                            }
                            if (grupos != null)
                            {
                                command.CommandText = "DELETE FROM usuarios_grupos WHERE id_usuario = @id";
                                command.Parameters.AddWithValue("@id", id);
                                command.ExecuteNonQuery();
                                command.Parameters.Clear();
                                foreach (string grupo in grupos)
                                {
                                    command.CommandText = "INSERT INTO usuarios_grupos (id_usuario, id_grupo) VALUES (@id, (SELECT id_grupo FROM grupos WHERE nombre_grupo = @grupo))";
                                    command.Parameters.AddWithValue("@id", id);
                                    command.Parameters.AddWithValue("@grupo", grupo);
                                    command.ExecuteNonQuery();
                                    command.Parameters.Clear();
                                }
                            }
                            command.Parameters.Clear();
                            connection.Close();
                            return true;
                        }
                        else
                        {
                            command.Parameters.Clear();
                            connection.Close();
                            return false;
                        }
                    }
                    connection.Close();
                    return false;
                }
            }
        }
        public bool RegistrarUsuario(string nombre, string apellido, string mail, string contra, int dni, long cvu, long telefono, string direccion, List<string> permisos, List<string> grupos)
        {
            using (SqlConnection connection = new SqlConnection(MoConexionSQL.Instance.Conexion))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "INSERT INTO usuarios (mail, contra, estado) OUTPUT INSERTED.id_usuario VALUES (@mail, @contra, @estado)";
                    command.Parameters.AddWithValue("@mail", mail);
                    command.Parameters.AddWithValue("@contra", MetodosComunes.Encrypt.GetSHA256(contra));
                    command.Parameters.AddWithValue("@estado", "Activo");
                    connection.Open();
                    int id_usuario = (int)command.ExecuteScalar();
                    command.Parameters.Clear();
                    if (id_usuario > 0)
                    {
                        command.CommandText = "INSERT INTO empleados (nombre_empleado, apellido_empleado, dni, cvu, direccion, telefono, id_usuario) VALUES (@nombre, @apellido, @dni, @cvu, @direccion, @telefono, @id)";
                        command.Parameters.AddWithValue("@nombre", nombre);
                        command.Parameters.AddWithValue("@apellido", apellido);
                        command.Parameters.AddWithValue("@dni", dni);
                        command.Parameters.AddWithValue("@cvu", cvu);
                        command.Parameters.AddWithValue("@direccion", direccion);
                        command.Parameters.AddWithValue("@telefono", telefono);
                        command.Parameters.AddWithValue("@id", id_usuario);
                        int rows = command.ExecuteNonQuery();
                        command.Parameters.Clear();
                        if (rows > 0)
                        {
                            if (permisos != null)
                            {
                                foreach (string permiso in permisos)
                                {
                                    command.CommandText = "INSERT INTO usuarios_permisos (id_usuario, id_permiso) VALUES (@id, (SELECT id_permiso FROM permisos WHERE nombre_permiso = @permiso))";
                                    command.Parameters.AddWithValue("@id", id_usuario);
                                    command.Parameters.AddWithValue("@permiso", permiso);
                                    command.ExecuteNonQuery();
                                    command.Parameters.Clear();
                                }
                            }
                            if (grupos != null)
                            {
                                foreach (string grupo in grupos)
                                {
                                    command.CommandText = "INSERT INTO usuarios_grupos (id_usuario, id_grupo) VALUES (@id, (SELECT id_grupo FROM grupos WHERE nombre_grupo = @grupo))";
                                    command.Parameters.AddWithValue("@id", id_usuario);
                                    command.Parameters.AddWithValue("@grupo", grupo);
                                    command.ExecuteNonQuery();
                                    command.Parameters.Clear();
                                }
                            }
                            command.Parameters.Clear();
                            connection.Close();
                            return true;
                        }
                        else
                        {
                            command.Parameters.Clear();
                            connection.Close();
                            return false;
                        }
                    }
                    else
                    {
                        command.Parameters.Clear();
                        connection.Close();
                        return false;
                    }
                }
            }

        }


        public List<Permisos> permisoUsuario(int id_usuario)
        {
            List<Permisos> permisos = new List<Permisos>();
            using (SqlConnection connection = new SqlConnection(MoConexionSQL.Instance.Conexion))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT p.id_permiso AS ID, p.nombre_permiso AS permisos" +
                "            FROM usuarios u" +
                "            LEFT JOIN usuarios_permisos up ON u.id_usuario = up.id_usuario" +
                "            LEFT JOIN permisos p ON up.id_permiso = p.id_permiso" +
                "            WHERE u.id_usuario = @id";
                    command.Parameters.AddWithValue("@id", id_usuario);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {

                            while (reader.Read())
                            {
                                string valor = reader.IsDBNull(1) ? null : reader.GetString(1);
                                if (valor != null)
                                {
                                    permisos.Add(new Permisos
                                    {
                                        id_permiso = reader.GetInt32(0),
                                        nombre_permiso = reader.GetString(1)
                                    });
                                }
                            }
                            command.Parameters.Clear();
                            connection.Close();
                            return permisos;
                        }
                        else
                        {
                            command.Parameters.Clear();
                            connection.Close();
                            return permisos;
                        }
                    }
                }
            }

        }
        public List<Grupo> grupoUsuario(int id_usuario)
        {
            List<Grupo> grupo = new List<Grupo>();
            using (SqlConnection connection = new SqlConnection(MoConexionSQL.Instance.Conexion))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT g.id_grupo, g.nombre_grupo" +
                "            FROM usuarios u" +
                "            LEFT JOIN usuarios_grupos ug ON u.id_usuario = ug.id_usuario" +
                "            LEFT JOIN grupos g ON ug.id_grupo = g.id_grupo" +
                "            WHERE u.id_usuario = @id";
                    command.Parameters.AddWithValue("@id", id_usuario);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                string valor = reader.IsDBNull(1) ? null : reader.GetString(1);
                                if (valor != null)
                                {
                                    grupo.Add(new Grupo
                                    {
                                        id_grupo = reader.GetInt32(0),
                                        nombre_grupo = reader.GetString(1)
                                    });
                                }
                            }
                            command.Parameters.Clear();
                            connection.Close();
                            return grupo;
                        }
                        else
                        {
                            command.Parameters.Clear();
                            connection.Close();
                            return grupo;
                        }
                    }
                }
            }
        }


        public List<string> MostrarAdmins()
        {
            using (SqlConnection connection = new SqlConnection(MoConexionSQL.Instance.Conexion))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = " SELECT u.mail AS Mail " +
                "            FROM usuarios u" +
                "            LEFT JOIN usuarios_grupos ug ON u.id_usuario = ug.id_usuario " +
                "            LEFT JOIN grupos g ON ug.id_grupo = g.id_grupo " +
                "            WHERE g.nombre_grupo = 'Administrador' ";
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<string> mails = new List<string>();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                mails.Add(reader.GetString(0));
                            }
                            command.Parameters.Clear();
                            connection.Close();
                            return mails;
                        }
                        else
                        {
                            command.Parameters.Clear();
                            connection.Close();
                            return mails;
                        }
                    }
                }
            }
        }

    }
}
