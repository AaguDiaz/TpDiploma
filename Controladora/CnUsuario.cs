using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public string enviarCodigo(string mail, int cod)
        {
            return moUsuario.enviarCodigo(mail, cod);
        }
        public bool cambiarContra(string mail, string contra)
        {
            return moUsuario.cambiarContra(mail, contra);
        }
        public DataTable MostrarUsuarios()
        {
            DataTable tabla = new DataTable();
            tabla = moUsuario.MostrarUsuarios();
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
        public bool permisosUsuario(int id)
        {
            return moUsuario.permisoUsuario(id);
        }
        public bool grupoUsuario(int id)
        {
            return moUsuario.grupoUsuario(id);
        }
        public bool EditarUsuario(int id, string nombre, string apellido, string mail, string dni, string cvu, string telefono, string direccion)
        {
            int Dni = int.Parse(dni);
            long Cvu= long.Parse(cvu);
            long Telefono = long.Parse(telefono);
            return moUsuario.EditarUsuario(id, nombre, apellido, mail, Dni, Cvu, Telefono, direccion);
        }
    }
}
