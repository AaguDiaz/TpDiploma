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
        public void ProcesarSolicitud(List<IPrestacion> prestaciones)
        {
            if(moDeuda.MostrarDeudas() == 130000)
            {
                return;
            }
            foreach (var prestacion in prestaciones) { 

                if (prestacion.ValidarSolicitud())
                {
                    Console.WriteLine("Solicitud procesada con éxito.");
                }
                else
                {
                    Console.WriteLine("Solicitud rechazada.");
                }
            }
        }

        
    }
}

