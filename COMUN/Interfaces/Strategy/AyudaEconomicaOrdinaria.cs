using COMUN.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMUN.Interfaces.Strategy
{
    public class AyudaEconomicaOrdinaria : IPrestacion
    {
        public string Nombre => "Ayuda Economica Ordinaria";
        public static int limite { get; set; } // Establece el límite según tus requisitos
        public static int cuotas { get; set; }

        public int MontoSolicitado { get; set; }
        public int cuotasSolicitado { get; set; }
        public string pdf { get; set; }

    }
}
