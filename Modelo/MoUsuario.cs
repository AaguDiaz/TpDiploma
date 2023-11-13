using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using COMUN;
using COMUN.Cache;

namespace Modelo
{
    public class MoUsuario : MoConexionSQL
    {
        private MoConexionSQL Conexion = new MoConexionSQL();
        private SqlCommand command = new SqlCommand();
        private SqlDataReader reader;
        public bool Login(string mail, string contrasena)
        {
            command.Connection = Conexion.AbirConexion();
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

            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    if (UserLoginCache.nombre_permisos == null)
                        UserLoginCache.nombre_permisos = new List<string>();

                    if (UserLoginCache.nombre_grupos == null)
                        UserLoginCache.nombre_grupos = new List<string>();

                    while (reader.Read())
                    {
                        UserLoginCache.id_usuario = reader.GetInt32(0);
                        UserLoginCache.nombre = reader.GetString(1);
                        UserLoginCache.apellido = reader.GetString(2);
                        UserLoginCache.mail = reader.GetString(3);
                        UserLoginCache.contra = reader.GetString(4);
                        UserLoginCache.dni = reader.GetInt32(5);
                        UserLoginCache.cvu = (long)reader.GetInt64(6);
                        UserLoginCache.direccion = reader.GetString(7);
                        UserLoginCache.telefono = (long)reader.GetInt64(8);
                        // Agregar permisos
                        string permiso = reader["permisos"].ToString();
                        // Agregar grupos
                        string grupo = reader["grupos"].ToString();
                        if (!UserLoginCache.nombre_permisos.Contains(permiso))
                        {
                            UserLoginCache.nombre_permisos.Add(permiso);
                        }
                        if (!UserLoginCache.nombre_grupos.Contains(grupo))
                        {
                            UserLoginCache.nombre_grupos.Add(grupo);
                        }
                        UserLoginCache.estado = reader.GetString(11);
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public bool CargarUsuario(int id)
        {
            command.Connection = Conexion.AbirConexion();
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
                    if (CacheEditarUsuario.permisos == null)
                        CacheEditarUsuario.permisos = new List<string>();

                    if (CacheEditarUsuario.grupos == null)
                        CacheEditarUsuario.grupos = new List<string>();
                    while (reader.Read())
                    {
                        CacheEditarUsuario.nombre = reader.GetString(0);
                        CacheEditarUsuario.apellido = reader.GetString(1);
                        CacheEditarUsuario.mail = reader.GetString(2);
                        CacheEditarUsuario.dni = reader.GetInt32(3);
                        CacheEditarUsuario.cvu = (long)reader.GetInt64(4);
                        CacheEditarUsuario.direccion = reader.GetString(5);
                        CacheEditarUsuario.telefono = (long)reader.GetInt64(6);
                        // Agregar permisos
                        string permisos = reader["permisos"].ToString();
                        // Agregar grupos
                        string grupos = reader["grupos"].ToString();
                        if (!CacheEditarUsuario.permisos.Contains(permisos))
                        {
                            CacheEditarUsuario.permisos.Add(permisos);
                        }
                        if (!CacheEditarUsuario.grupos.Contains(grupos))
                        {
                            CacheEditarUsuario.grupos.Add(grupos);
                        }
                    }
                    command.Parameters.Clear();
                    reader.Close();
                    command.Connection = Conexion.CerrarConexion();
                    return true;
                }
                else
                {
                    command.Parameters.Clear();
                    reader.Close();
                    command.Connection = Conexion.CerrarConexion();
                    return false;
                }
            }

        }
        public string enviarCodigo(string userRequesting, int cod)
        {
            command.Connection = Conexion.AbirConexion();
            command.CommandText = "SELECT u.id_usuario, per.nombre_empleado AS nombre ,per.apellido_empleado AS apellido, u.mail" +
                "            FROM usuarios u" +
                "            LEFT JOIN empleados per ON u.id_usuario = per.id_usuario" +
                "            WHERE u.mail = @mail";
            command.Parameters.AddWithValue("@mail", userRequesting);
            command.CommandType = CommandType.Text;
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
                    recipientMail: new List<string> { userMail }
                    );
                return "Hola, " + userName + "  " + userAperllido + " tu solicitud de recuperacion de contraseña ha sido enviada a" + userMail;
            }
            return "Mail no registrado";

        }
        public bool cambiarContra(string mail, string contra)
        {
            string contraEncriptada = MetodosComunes.Encrypt.GetSHA256(contra);
            command.Connection = Conexion.AbirConexion();
            command.CommandText = "UPDATE usuarios SET contra = @contra WHERE mail = @mail";
            command.Parameters.AddWithValue("@mail", mail);
            command.Parameters.AddWithValue("@contra", contraEncriptada);
            command.CommandType = CommandType.Text;
            int rows = command.ExecuteNonQuery();
            if (rows > 0)
                return true;
            else
                return false;
        }
        public DataTable MostrarUsuarios()
        {
            DataTable tabla = new DataTable();
            command.Connection = Conexion.AbirConexion();
            command.CommandText = "SELECT u.id_usuario AS ID, per.nombre_empleado AS Nombre ,per.apellido_empleado AS Apellido, u.mail AS Mail," +
                "                         per.dni AS DNI, per.cvu AS CVU, per.direccion AS Dirección, per.telefono AS Teléfono, " +
                "                         g.nombre_grupo AS Grupos, p.nombre_permiso AS Permisos, u.estado AS Estado" +
                "            FROM usuarios u" +
                "            LEFT JOIN empleados per ON u.id_usuario = per.id_usuario" +
                "            LEFT JOIN usuarios_grupos ug ON u.id_usuario = ug.id_usuario" +
                "            LEFT JOIN grupos g ON ug.id_grupo = g.id_grupo " +
                "            LEFT JOIN usuarios_permisos up ON u.id_usuario = up.id_usuario" +
                "            LEFT JOIN permisos p ON up.id_permiso = p.id_permiso";
            command.CommandType = CommandType.Text;
            reader = command.ExecuteReader();
            tabla.Load(reader);
            return tabla;
        }
        public bool AltaUsuario(int id)
        {
            command.Connection = Conexion.AbirConexion();
            command.CommandText = "Select estado FROM usuarios WHERE id_usuario = @id";
            command.Parameters.AddWithValue("@id", id);
            string estadoActual = command.ExecuteScalar().ToString();
            if (estadoActual != "Activo                                                      ")
            {
                command.CommandText = "UPDATE usuarios SET estado = @estado WHERE id_usuario = @idusuario";
                command.Parameters.AddWithValue("@estado", "Activo");
                command.Parameters.AddWithValue("@idusuario", id);
                command.CommandType = CommandType.Text;
                int rows = command.ExecuteNonQuery();
                if (rows > 0)
                    return true;
                else
                    return false;
            }
            else return false;

        }
        public bool BajaUsuario(int id)
        {
            command.Connection = Conexion.AbirConexion();
            command.CommandText = "Select estado FROM usuarios WHERE id_usuario = @id";
            command.Parameters.AddWithValue("@id", id);
            string estadoActual = command.ExecuteScalar().ToString();
            if (estadoActual != "Baja                                                        ")
            {
                command.CommandText = "UPDATE usuarios SET estado = @estado WHERE id_usuario = @idusuario";
                command.Parameters.AddWithValue("@estado", "Baja");
                command.Parameters.AddWithValue("@idusuario", id);
                command.CommandType = CommandType.Text;
                int rows = command.ExecuteNonQuery();
                if (rows > 0)
                    return true;
                else
                    return false;
            }
            else return false;

        }
        public bool permisoUsuario(int id_usuario)
        {

            command.Connection = Conexion.AbirConexion();
            command.CommandText = "SELECT p.nombre_permiso AS permisos" +
                "            FROM usuarios u" +
                "            LEFT JOIN usuarios_permisos up ON u.id_usuario = up.id_usuario" +
                "            LEFT JOIN permisos p ON up.id_permiso = p.id_permiso" +
                "            WHERE u.id_usuario = @id";
            command.Parameters.AddWithValue("@id", id_usuario);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    if (CacheEditarUsuario.permisosUsuario == null)
                        CacheEditarUsuario.permisosUsuario = new List<string>();

                    while (reader.Read())
                    {
                        string valor = reader.IsDBNull(0) ? null : reader.GetString(0);
                        if (valor != null)
                        {
                            CacheEditarUsuario.permisosUsuario.Add(reader.GetString(0));
                        }
                    }
                    command.Parameters.Clear();
                    return true;
                }
                else
                {
                    command.Parameters.Clear();
                    return false;
                }
            }

        }
        public bool grupoUsuario(int id_usuario)
        {

            command.Connection = Conexion.AbirConexion();
            command.CommandText = "SELECT g.nombre_grupo" +
                "            FROM usuarios u" +
                "            LEFT JOIN usuarios_grupos ug ON u.id_usuario = ug.id_usuario" +
                "            LEFT JOIN grupos g ON ug.id_grupo = g.id_grupo" +
                "            WHERE u.id_usuario = @id";
            command.Parameters.AddWithValue("@id", id_usuario);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    if (CacheEditarUsuario.gruposUsuario == null)
                        CacheEditarUsuario.gruposUsuario = new List<string>();

                    while (reader.Read())
                    {
                        string valor = reader.IsDBNull(0) ? null : reader.GetString(0);
                        if (valor != null)
                        {
                            CacheEditarUsuario.gruposUsuario.Add(reader.GetString(0));
                        }
                    }
                    command.Parameters.Clear();
                    return true;
                }
                else
                {
                    command.Parameters.Clear();
                    return false;
                }
            }

        }
        public bool EditarUsuario(int id, string nombre, string apellido, string mail, int dni, long cvu,long telefono, string direccion)
        {
            command.Connection = Conexion.AbirConexion();
            command.CommandText = "UPDATE empleados SET nombre_empleado = @nombre, apellido_empleado = @apellido, dni = @dni, cvu = @cvu, direccion = @direccion, telefono = @telefono WHERE id_usuario = @id";
            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@nombre", nombre);
            command.Parameters.AddWithValue("@apellido", apellido);
            command.Parameters.AddWithValue("@dni", dni);
            command.Parameters.AddWithValue("@cvu", cvu);
            command.Parameters.AddWithValue("@direccion", direccion);
            command.Parameters.AddWithValue("@telefono", telefono);
            command.CommandType = CommandType.Text;
            int rows = command.ExecuteNonQuery();
            if (rows > 0)
            {
                command.CommandText = "UPDATE usuarios SET mail = @mail WHERE id_usuario = @id";
                command.Parameters.AddWithValue("@mail", mail);
                command.CommandType = CommandType.Text;
                int rows2 = command.ExecuteNonQuery();
                if (rows2 > 0)
                {
                    if (CacheEditarUsuario.PermisosAgregar == null)
                        CacheEditarUsuario.PermisosAgregar = new List<string>();
                    if (CacheEditarUsuario.PermisosQuitar == null)
                        CacheEditarUsuario.PermisosQuitar = new List<string>();
                    if (CacheEditarUsuario.GruposAgregar == null)
                        CacheEditarUsuario.GruposAgregar = new List<string>();
                    if(CacheEditarUsuario.GruposQuitar == null)
                        CacheEditarUsuario.GruposQuitar = new List<string>();

                    int rows3 = command.ExecuteNonQuery();
                    foreach (string permiso in CacheEditarUsuario.PermisosAgregar)
                    {
                        command.CommandText = "INSERT INTO usuarios_permisos (id_usuario, id_permiso) VALUES (@id, (SELECT id_permiso FROM permisos WHERE nombre_permiso = @permiso))";
                        command.Parameters.AddWithValue("@permiso", permiso);
                        command.CommandType = CommandType.Text;
                        if (rows3 > 0)
                        {
                            command.Parameters.Clear();
                        }
                        else
                        {
                            command.Parameters.Clear();
                            return false;
                        }
                    }
                    foreach(string permiso in CacheEditarUsuario.PermisosQuitar)
                    {
                        command.CommandText = "DELETE FROM usuarios_permisos WHERE id_usuario = @id AND id_permiso = (SELECT id_permiso FROM permisos WHERE nombre_permiso = @permiso)";
                        command.Parameters.AddWithValue("@permiso", permiso);
                        command.CommandType = CommandType.Text;
                        if (rows3 > 0)
                        {
                            command.Parameters.Clear();
                        }
                        else
                        {
                            command.Parameters.Clear();
                            return false;
                        }
                    }
                    foreach(string grupo in CacheEditarUsuario.GruposAgregar)
                    {
                        command.CommandText = "INSERT INTO usuarios_grupos (id_usuario, id_grupo) VALUES (@id, (SELECT id_grupo FROM grupos WHERE nombre_grupo = @grupo))";
                        command.Parameters.AddWithValue("@grupo", grupo);
                        command.CommandType = CommandType.Text;
                        if (rows3 > 0)
                        {
                            command.Parameters.Clear();
                        }
                        else
                        {
                            command.Parameters.Clear();
                            return false;
                        }
                    }
                    foreach(string grupo in CacheEditarUsuario.GruposQuitar)
                    {
                        command.CommandText = "DELETE FROM usuarios_grupos WHERE id_usuario = @id AND id_grupo = (SELECT id_grupo FROM grupos WHERE nombre_grupo = @grupo)";
                        command.Parameters.AddWithValue("@grupo", grupo);
                        command.CommandType = CommandType.Text;
                        if (rows3 > 0)
                        {
                            command.Parameters.Clear();
                        }
                        else
                        {
                            command.Parameters.Clear();
                            return false;
                        }
                    }
                    command.Parameters.Clear();
                    return true;
                }
                else
                {
                    command.Parameters.Clear();
                    return false;
                }
            }
            else
            {
                command.Parameters.Clear();
                return false;
            }
        }
    }
}
