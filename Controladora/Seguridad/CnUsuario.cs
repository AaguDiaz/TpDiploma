using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using COMUN;
using COMUN.Seguridad;
using Modelo;

namespace Controladora
{
    public class CnUsuario
    {
        MoUsuario moUsuario = new MoUsuario();

        public bool Login(string mail, string contra)
        {
            return moUsuario.Login(mail, contra);
        }
        public bool EstadoUsuario(string mail)
        {
            return moUsuario.EstadoLogin(mail);
        }
       
        public string enviarCodigo(string mail, int cod)
        {
            return moUsuario.enviarCodigo(mail, cod);
        }
        public bool cambiarContra(string mail, string contra)
        {
            return moUsuario.cambiarContra(mail, contra);
        }


        public DataTable MostrarUsuarios(int currentPage)
        {
            DataTable tabla = new DataTable();
            tabla = moUsuario.MostrarUsuarios(currentPage);
            return tabla;
        }
        public DataTable MostrarUsuariosFiltrados(string filtro,string parametro, int currentPage)
        {   
            DataTable tabla = new DataTable();
            if(filtro == "Nombre y apellido")
            {
                tabla = moUsuario.MostrarUsuariosSegunNombreYApellido(parametro);
            }else if(filtro == "Mail")
            {
                tabla = moUsuario.MostrarUsuariosSegunMail(parametro);
            }else if(filtro == "DNI")
            {
                tabla = moUsuario.MostrarUsuariosSegunDNI(Convert.ToInt32(parametro));
            }else if(filtro == "Estado")
            {
                tabla = moUsuario.MostrarUsuariosSegunEstado(parametro, currentPage);
            }
            return tabla;
        }


        public bool AltaUsuario(int id)
        {
            return moUsuario.AltaUsuario(id);
        }
        public bool BajaUsuario(int id)
        {
            return moUsuario.BajaUsuario(id);
        }
        public bool CagarUsuario(int id)
        {
            return moUsuario.CargarUsuario(id);
        }



        public List<Permisos> permisosUsuario(int id)
        {
            return moUsuario.permisoUsuario(id);
        }
        public List<Grupo> grupoUsuario(int id)
        {
            return moUsuario.grupoUsuario(id);
        }



        public bool EditarUsuario(int id, string nombre, string apellido, string mail, string dni, string cvu, string telefono, string direccion, List<string> permisos, List<string> grupos)
        {
            int Dni = int.Parse(dni);
            long Cvu= long.Parse(cvu);
            long Telefono = long.Parse(telefono);
            return moUsuario.EditarUsuario(id, nombre, apellido, mail, Dni, Cvu, Telefono, direccion, permisos, grupos);
        }
        public bool RegistrarUsuario(string nombre, string apellido, string mail, string dni, string cvu, string telefono, string direccion, List<string> permisos, List<string> grupos)
        {
            int Dni = int.Parse(dni);
            long Cvu = long.Parse(cvu);
            long Telefono = long.Parse(telefono);
            string contra = nombre + "1234";
            
            if(moUsuario.RegistrarUsuario(nombre, apellido, mail, contra, Dni, Cvu, Telefono, direccion, permisos, grupos)== true)
            {
                var mailService = new COMUN.Mail.SystemSupportMail();
                mailService.sendMail(
                    subjet: "SYSTEM: Registro de usuario",
                    body: "Hola, " + nombre + "  " + apellido + "\n" + "Tu cuenta ya ha sido registrada, para ingresar la aplicacion debera ingresar su mail y su contraseña generada automaticamente la siguiente es su nombre más 1234 en tu caso seria:  " +
                    nombre + "1234" + "\n" + "Te recomendamos que apenas incie sesion vaya a Estado de cuenta y modifique su contraseña para no tener problemas en un futuro." + "\n" + "Desde ya muchas gracias.",
                    recipientMail: new List<string> { mail },
                    attachmentPaths: new List<string>()
                    ) ;

                return true;
            }
            else { return false; }
            
        }


        public void ModificarInfoEmpleado(string nombre, string apellido, string dni, string cvu, string telefono, string direccion)
        {
            int Dni = int.Parse(dni);
            long Cvu = long.Parse(cvu);
            long Telefono = long.Parse(telefono);
            int id = COMUN.UserLoginCache.id_usuario;
            moUsuario.ModificarInfoEmpleado(id, nombre, apellido, Dni, Cvu, Telefono, direccion);
            COMUN.UserLoginCache.nombre = nombre;
            COMUN.UserLoginCache.apellido = apellido;
            COMUN.UserLoginCache.dni = Dni;
            COMUN.UserLoginCache.cvu = Cvu;
            COMUN.UserLoginCache.telefono = Telefono;
            COMUN.UserLoginCache.direccion = direccion;
        }
    }
}
