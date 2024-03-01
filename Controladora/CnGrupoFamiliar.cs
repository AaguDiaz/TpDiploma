using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COMUN;
using Modelo;

namespace Controladora
{
    public class CnGrupoFamiliar
    {
        MoUsuario moUsu = new MoUsuario();
        public bool MandarMail(string nombre, int dni, DateTime fecha, string parentezco, string filePath)
        {
            foreach (string mail in moUsu.MostrarAdmins())
            {
                var mailService = new COMUN.Mail.SystemSupportMail();
                mailService.sendMail(
                    subjet: "Solicitud nuevo familiar ",
                    body: "El usuario: "+UserLoginCache.nombre+" "+UserLoginCache.apellido+" solicito agregar un nuevo familiar a su grupo familiar " + "\n"+
                    " los datos del nuevo integrante son los siguientes: "+"\n"+
                    "-Nombre completo: " + nombre+"."+ "\n" + 
                    "-DNI: "+dni.ToString()+"."+ "\n"+
                    "-Fecha de nacimiento: "+fecha.ToString()+"."+ "\n"+
                    "-Parentesco: "+parentezco+".",
                    recipientMail: new List<string> { mail },
                    attachmentPaths: new List<string> { filePath }
                    );
            }
            return true;
        }

        public bool BajaFamiliar(string nombre, int dni, string parentezco)
        {
            foreach (string mail in moUsu.MostrarAdmins())
            {
                var mailService = new COMUN.Mail.SystemSupportMail();
                mailService.sendMail(
                    subjet: "Solicitud baja familiar ",
                    body: "El usuario: " + UserLoginCache.nombre + " " + UserLoginCache.apellido + " solicito dar de baja a un familiar de su grupo familiar " + "\n" +
                    " los datos del integrante a dar de baja son los siguientes: " + "\n" +
                    "-Nombre completo: " + nombre + "." + "\n" +
                    "-DNI: " + dni.ToString() + "." + "\n" +
                    "-Parentesco: " + parentezco + ".",
                    recipientMail: new List<string> { mail },
                    attachmentPaths: new List<string> ()
                    );
            }
            return true;
        }

    }
}
