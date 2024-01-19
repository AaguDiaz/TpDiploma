using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using COMUN.Cache;

namespace Controladora
{
    public class SolicitudController
    {
        MoDeuda moDeuda = new MoDeuda();
        MoSolicitud moSoli = new MoSolicitud();

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

        
    }
}

