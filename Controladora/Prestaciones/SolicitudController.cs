using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using COMUN.Cache;
using System.Data;

namespace Controladora
{
    public class SolicitudController
    {
        MoDeuda moDeuda = new MoDeuda();
        MoSolicitud moSoli = new MoSolicitud();
        DataTable table = new DataTable();

        public bool ProcesarSolicitud(List<IPrestacion> prestaciones)
        {

            int montoTotal = prestaciones.Sum(p => p.MontoSolicitado);

            if(montoTotal > moDeuda.MostrarLimiteDeuda())
            {
                return false;
            }
            
            int deudaotal = montoTotal + moDeuda.MostrarMontoDeuda();

            moSoli.Solicitud(prestaciones, montoTotal);
            moDeuda.ActualizarDeuda(deudaotal);
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


    }
}

