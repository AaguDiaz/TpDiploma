using COMUN;
using COMUN.Cache;
using Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Controladora
{
    public class SolicitudController
    {
        MoDeuda moDeuda = new MoDeuda();
        MoSolicitud moSoli = new MoSolicitud();
        DataTable table = new DataTable();

        public bool ProcesarSolicitud(List<IPrestacion> prestaciones)
        {

            int montoTotal = 0;

            foreach (var item in prestaciones)
            {
                montoTotal += item.MontoSolicitado;
            }

            if (montoTotal > moDeuda.MostrarLimiteDeuda())
            {
                return false;
            }

            int deudaotal = montoTotal + moDeuda.MostrarMontoDeuda();
            if (deudaotal > moDeuda.MostrarLimiteDeuda())
            {
                return false;
            }

            moSoli.Solicitud(prestaciones, montoTotal);
            
            return true;
        }


        public DataTable MostrarSoliciudesUsuario(int CurrentPage, string filtro, DateTime desde, DateTime hasta)
        {
            if (filtro == "Todas")
            {
                return moSoli.MostrarSoliciudesUsuario(CurrentPage, desde, hasta);
            }
            else if (filtro == "Pendientes")
            {
                return moSoli.MostarSoliFiltro(CurrentPage, 1, desde, hasta);
            }
            else if (filtro == "Aceptadas")
            {
                return moSoli.MostarSoliFiltro(CurrentPage, 2, desde, hasta);
            }
            else if (filtro == "Rechazadas")
            {
                return moSoli.MostarSoliFiltro(CurrentPage, 3, desde, hasta);
            }
            return table;
        }

        public DataTable MostrarSolicitudXID(int id, int currentPage)
        {
            return moSoli.MostrarSoliXID(id, currentPage);
        }

        public byte[] MostrarArchivo(int id)
        {
            return moSoli.BuscarPDF(id);
        }

        public DataTable MostrarPrestacionesFiltro(int currentPage, string filtro)
        {
            if (filtro == "Todas")
            {
                return moSoli.MostrarTodasPrestaciones(currentPage);
            }
            else if (filtro == "Pendientes")
            {
                return moSoli.MostrarSolicitudABMFiltro(currentPage, 1);
            }
            else if (filtro == "Aceptadas")
            {
                return moSoli.MostrarSolicitudABMFiltro(currentPage, 2);
            }
            else if (filtro == "Rechazadas")
            {
                return moSoli.MostrarSolicitudABMFiltro(currentPage, 3);
            }
            return table;
        }

        public void cambiarEstado(int id, int estado)
        {
            moSoli.CambiarEstado(id, estado);
        }

        public void MandarMailUsuario(int id_pedido, string nombreyapellido, string mail, string estado)
        {
            var mailService = new COMUN.Mail.SystemSupportMail();
            if (estado == "Aceptado")
            {
                mailService.sendMail(
                                       subjet: "ACA: Estado de su solicitud de prestaciones ",
                                       body: "Hola " + nombreyapellido + " su solicitud de prestaciones con el ID: " + id_pedido + " fue: " + estado + " el dia: " + DateTime.Now,
                                       recipientMail: new List<string> { mail },
                                       attachmentPaths: new List<string>());
            }
            else if (estado == "Rechazado")
            {
                mailService.sendMail(
                                       subjet: "ACA: Estado de su solicitud de prestaciones ",
                                       body: "Hola: " + nombreyapellido + " su pedido con el ID: " + id_pedido + "fue: " + estado + " el dia: " + DateTime.Now + "\n" +
                                       "Si quiere saber el motivo consulte con: " + UserLoginCache.nombre + " " + UserLoginCache.apellido + " o con cualquier otro administrador, desde ya muchas gracias!.",
                                       recipientMail: new List<string> { mail },
                                       attachmentPaths: new List<string>());
            }
        }

    }
}
