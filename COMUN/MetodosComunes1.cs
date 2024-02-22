using System;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Net.Mail;
using System.Net;
using COMUN;
using System.Text.RegularExpressions;
using COMUN.Seguridad;
using System.Collections.Generic;
using System.Linq;

namespace COMUN
{
    static public class MetodosComunes
    {


        static public List<Permisos> ObtenerPermisosActivos()
        {
            List<Permisos> permisosActivos = new List<Permisos>();

            foreach (var item in UserLoginCache.grupos)
            {
                foreach (var item2 in item.permisos)
                {
                    permisosActivos.Add(item2);
                }
            }
            if (UserLoginCache.permisos_individuales != null)
            {

                foreach (var item in UserLoginCache.permisos_individuales)
                {
                    permisosActivos.Add(item);
                }
            }
            return permisosActivos;
        }


        static public void CargarModulosFormularios(string nombreFormulario, FlowLayoutPanel flpControles)
        {
            List<Permisos> permisosActivos = ObtenerPermisosActivos();
            List<Modulos> modulos = new List<Modulos>();


            foreach (var item in permisosActivos)
            {
                if (item.formulario.nombre_formulario == nombreFormulario)
                {
                    foreach (var item2 in item.modulos)
                    {
                        modulos.Add(item2);
                    }
                }
            }

            if (modulos != null)
            {
                foreach(Control control in flpControles.Controls)
                {
                    if(control is Button && control.Tag != null)
                    {
                        string nombreAccionBoton = control.Tag.ToString();
                        bool tienePermiso = modulos.Any(x => x.nombre_modulo == nombreAccionBoton);
                        control.Enabled = tienePermiso;
                        control.Visible = tienePermiso;
                    }
                }
            }

        } 
       
        static public void CerrarSesion()
        {
            UserLoginCache.id_usuario = 0;
            UserLoginCache.nombre = "";
            UserLoginCache.apellido = "";
            UserLoginCache.mail = "";
            UserLoginCache.contra = "";
            UserLoginCache.dni = 0;
            UserLoginCache.cvu = 0;
            UserLoginCache.direccion = "";
            UserLoginCache.telefono = 0;
            UserLoginCache.grupos = null;
            UserLoginCache.permisos_individuales = null;
            UserLoginCache.estado = "";

        }

        static public KeyPressEventArgs KeyPressSoloNumeros(KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }

            return e;
        }
        static public KeyPressEventArgs KeyPressSoloLetras(KeyPressEventArgs e)
        {

            if (Char.IsLetter(e.KeyChar))//solo letras
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))//solo backspace, space, delete, etc.
            {
                e.Handled = false;
            }
            else if (Char.IsPunctuation(e.KeyChar))// solo .:;,_- (simbolos de punt
            {
                e.Handled = false;
            }
            else if (Char.IsSymbol(e.KeyChar))//demas caracteres
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))//espacio
            {
                e.Handled = false;
            }
            else//que el resto no lo escriba
            {
                e.Handled = true;
            }
            return e;
        }


        /// Encripta una cadena
        public static string EncriptarPassBD(string cadenaAencriptar)
        {
            string result = string.Empty;
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(cadenaAencriptar);
            result = Convert.ToBase64String(encryted);
            return result;
        }

        /// Esta función desencripta la cadena que le envíamos en el parámentro de entrada.
        public static string DesEncriptarPassBD(string cadenaAdesencriptar)
        {
            string result = string.Empty;
            byte[] decryted = Convert.FromBase64String(cadenaAdesencriptar);
            //result = System.Text.Encoding.Unicode.GetString(decryted, 0, decryted.ToArray().Length);
            result = System.Text.Encoding.Unicode.GetString(decryted);
            return result;
        }

    }

}
