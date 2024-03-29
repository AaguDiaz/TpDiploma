﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMUN.Cache
{

    public struct PedidosByDate
    {
        public string Fecha { get; set; }
        public int Total { get; set; }
    }

    public class CacheReportes
    {
        public static int NumEmpleados { get; set; }
        public static int EmpleadosActivos { get; set; }
        public static int EmpleadosBaja { get; set; }


        public static int NumProveedores { get; set; }
        public static int ProveedoresActivos { get; set; }
        public static int ProveedoresBaja { get; set; }


        public static int NumProductos { get; set; }

        public static int NumPedidos { get; set; }
        public static int PedidosPendientes { get; set; }
        public static int PedidosAceptadas { get; set; }
        public static int PedidosRechazadas { get; set; }



        public static int NumListaPedidos { get; set; }
        public static int ListasActivas { get; set; }
        public static int ListasVencidas { get; set; }



        public static List<PedidosByDate> PedidosLista { get; set; }
        public static List<KeyValuePair<string, int>> TopProductos { get; set; }
        public static List<KeyValuePair<string, int>> TopListas { get; set; }


        //auditoria
        public static List<KeyValuePair<string, int>> TopInicio { get; set; }
        public static List<KeyValuePair<string, int>> TopTrazabilidad { get; set; }



        //prestaciones
        public static int NumSoli { get; set; }
        public static int SoliPendientes { get; set; }
        public static int SoliAceptadas { get; set; }
        public static int SoliRechazadas { get; set; }
        public static int NumPrestaciones { get; set; }
        public static int NumDeudores { get; set; }
        public static int NumDeudaTot { get; set; }



        public static List<PedidosByDate> Solicitudes { get; set; }
        public static List<KeyValuePair<string, int>> Prestaciones { get; set; }
        public static List<KeyValuePair<string, int>> Deudores { get; set; }

    }
}
