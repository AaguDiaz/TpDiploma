using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Modelo;
using System.Runtime.Remoting.Messaging;
using COMUN;

namespace Controladora
{
    public class CnPedido
    {
        MoPedido moPed = new MoPedido();
        MoUsuario moUsu = new MoUsuario();
        DataTable table = new DataTable();
        public int CargarPedido(string total)
        {
            return moPed.CargarPedido(Convert.ToInt32(total));
        }

        public DataTable MostrarPedidos(int CurrentPage, string filtro, DateTime desde, DateTime hasta)
        {
            if(filtro == "Todas")
            {
                return moPed.MostarPedidosTodas(CurrentPage, desde, hasta);
            }
            else if(filtro == "Pendientes")
            {
                return moPed.MostarPedidosFiltro(CurrentPage, 1, desde, hasta);
            }
            else if(filtro == "Aceptadas")
            {
                return moPed.MostarPedidosFiltro(CurrentPage, 2, desde, hasta);
            }
            else if(filtro == "Rechazadas")
            {
                return moPed.MostarPedidosFiltro(CurrentPage, 3, desde, hasta);
            }
            return table;
        }

        public DataTable MostrarPedidosABM(int CurrentPage, string filtro)
        {
            if (filtro == "Todas")
            {
                return moPed.MostrarPedidosABM(CurrentPage);
            }
            else if (filtro == "Pendientes")
            {
                return moPed.MostrarPedidosABMFiltro(CurrentPage, 1);
            }
            else if (filtro == "Aceptadas")
            {
                return moPed.MostrarPedidosABMFiltro(CurrentPage, 2);
            }
            else if (filtro == "Rechazadas")
            {
                return moPed.MostrarPedidosABMFiltro(CurrentPage, 3);
            }
            return table;
        }


        public void CambiarEstadoPedido(int id_pedido, string estado)
        { 
            if(estado == "Aceptado")
            {
                moPed.CambiarEstado(id_pedido, 2);
            }else if(estado == "Rechazado")
            {
                moPed.CambiarEstado(id_pedido, 3);
            }
        }


        public void MandarMailUsuario(int id_pedido, string nombreyapellido, string mail, string estado)
        {

            var mailService = new COMUN.Mail.SystemSupportMail();
            if(estado == "Aceptado")
            {
                mailService.sendMail(
                                       subjet: "ACA: Estado de su pedido",
                                       body: "Hola " + nombreyapellido + " su pedido con el ID: " + id_pedido + " fue: " + estado + " el dia: " + DateTime.Now,
                                       recipientMail: new List<string> { mail } );
            }
            else if (estado == "Rechazado")
            {
                mailService.sendMail(
                                       subjet: "ACA: Estado de su pedido",
                                       body: "Hola: " + nombreyapellido + " su pedido con el ID: "+ id_pedido +  "fue: " + estado + " el dia: " + DateTime.Now + "\n" +
                                       "Si quiere saber el motivo consulte con: " + UserLoginCache.nombre + " " + UserLoginCache.apellido + " o con cualquier otro administrador, desde ya muchas gracias!.",
                                       recipientMail: new List<string> { mail } );
            }
        }



        public void MandarMailAdmins()
        {
            string userName = UserLoginCache.nombre;
            string userAperllido = UserLoginCache.apellido;
            var mailService = new COMUN.Mail.SystemSupportMail();
            foreach (string mail in moUsu.MostrarAdmins())
            {
                mailService.sendMail(
                    subjet: "SYSTEM: Nueva solicitud de pedido",
                    body: "El usuario: " + userName + "  " + userAperllido + " registró un nuevo pedido el dia: " + DateTime.Now + "\n" + "El pedido espera confirmacion.",
                    recipientMail: new List<string> { mail }
                    );
            }
        }

    }
}
