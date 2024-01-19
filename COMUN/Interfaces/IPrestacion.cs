using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMUN.Cache
{
     public interface IPrestacion
    {
        string Nombre {get;} 
        int MontoSolicitado { get; set; }
        int cuotas { get; set; }
    }
    public class AyudaEconomicaOrdinaria : IPrestacion
    {
        public string Nombre => "Ayuda Economica Ordinaria";
        public static int limite { get; set; } // Establece el límite según tus requisitos
        public int MontoSolicitado { get; set; }
        public int cuotas { get; set; }

    }
    public class AyudaEconomicaSalud: IPrestacion
    {
        public string Nombre => "Ayuda Economica Salud";
        public static int limite { get; set; } 
        public int MontoSolicitado { get; set; }
        public int cuotas { get; set; }

       
    }
    public class Odontologia : IPrestacion
    {
        public string Nombre => "Odontologia";
        public static int limite { get; set; }
        public int MontoSolicitado { get; set; }
        public int cuotas { get; set; }

      
    }
    public class Optica : IPrestacion
    {
        public string Nombre => "Optica";
        public static int limite { get; set; }
        public int MontoSolicitado { get; set; }
        public int cuotas { get; set; }

    }
    public class Farmacia: IPrestacion
    {
        public string Nombre => "Farmacia";
        public static int limite { get; set; }
        public int MontoSolicitado { get; set; }
        public int cuotas { get; set; }

    }
    public class SubsidioCasamiento : IPrestacion
    {
        public string Nombre => "Subsidio Casamiento";
        public static int limite { get; set; }
        public int MontoSolicitado { get; set; }
        public int cuotas { get; set; }

    }
    public class SubsidioEscolar : IPrestacion
    {
        public string Nombre => "Subsidio Escolaridad";
        public static int limite { get; set; }
        public int MontoSolicitado { get; set; }
        public int cuotas { get; set; }

    }
    public class SubsidioNacimiento : IPrestacion
    {
        public string Nombre => "Subsidio Nacimiento";
        public static int limite { get; set; }
        public int MontoSolicitado { get; set; }
        public int cuotas { get; set; }

    }
}
