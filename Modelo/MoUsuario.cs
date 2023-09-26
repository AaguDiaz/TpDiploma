using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;

namespace Modelo
{
    public interface IUsuarioService
    {
        int IniciarSesion(string mail, string contrasena);
        bool EnviarCodigoRecuperacion(string correoElectronico);
        bool VerificarCodigo(string correoElectronico, string codigo);
        bool CambiarContrasena(string correoElectronico, string nuevaContrasena);
    }
    public class UsuarioService : IUsuarioService
    {
        private MoConexionSQL Conexion = new MoConexionSQL();
        private SqlCommand command = new SqlCommand();
        private SqlDataReader reader;
        private Dictionary<string, string> codigosRecuperacion = new Dictionary<string, string>();

        public int IniciarSesion(string mail, string contrasena)
        {
            int idPermiso = -1;

            command.Connection = Conexion.AbirConexion();
            try {
                command.CommandText = "SELECT id_permiso FROM usuarios WHERE mail = @mail AND contra = @Contrasena";
                command.Parameters.AddWithValue("@mail", mail);
                command.Parameters.AddWithValue("@Contrasena", contrasena);

                object result = command.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                   idPermiso = Convert.ToInt32(result);
                }
                command.Parameters.Clear();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al crear el pedido: " + ex.Message);
            }
            return idPermiso;
        }

        public bool EnviarCodigoRecuperacion(string correoElectronico)
        {
            try
            {
                Random random = new Random();
                int codigo = random.Next(10000, 99999); // Genera un código aleatorio de 5 dígitos
                codigosRecuperacion[correoElectronico] = codigo.ToString(); // Almacena el código asociado al correo


                string destinatario = correoElectronico;
                string asunto = "Código de recuperación";
                string mensaje = $"Tu código de recuperación es: {codigo}";

                MailMessage correo = new MailMessage();
                correo.From = new MailAddress("acaservicios01@gmail.com");
                correo.To.Add(destinatario);
                correo.Subject = asunto;
                correo.Body = mensaje;

                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.Credentials = new NetworkCredential("acaservicios01@gmail.com", "Agus1234");
                smtp.EnableSsl = true;

                smtp.Send(correo);

                return true; // Indica éxito
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que pueda ocurrir durante el envío del correo
                Console.WriteLine($"Error al enviar el código: {ex.Message}");
                return false; // Indica fallo
            }

        }
        public bool VerificarCodigo(string correoElectronico, string codigo)
        {
            if (codigosRecuperacion.ContainsKey(correoElectronico) && codigosRecuperacion[correoElectronico] == codigo)
            {
                return true; // El código es válido
            }
            else
            {
                return false; // El código no coincide
            }
        }
    }
    public class MoUsuario
    {

    }
}
