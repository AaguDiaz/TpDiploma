using COMUN.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMUN.Interfaces.Strategy
{
    public class SubsidioNacimiento : IPrestacion
    {
        public string Nombre => "Subsidio Nacimiento";
        public static int limite { get; set; }
        public static int cuotas { get; set; }
        public int MontoSolicitado { get; set; }
        public int cuotasSolicitado { get; set; }

        public string pdf { get; set; }
    }
}
