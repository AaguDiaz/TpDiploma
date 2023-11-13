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
        int limite { get; set; }
        int MontoSolicitado { get; set; }
        int cuotas { get; set; }
        bool ValidarSolicitud();
    }
    public class AyudaEconomicaOrdinaria : IPrestacion
    {
        public string Nombre => "Ayuda Economica Ordinaria";
        public int limite { get; set; } // Establece el límite según tus requisitos
        public int MontoSolicitado { get; set; }
        public int cuotas { get; set; }

        public bool ValidarSolicitud()
        {
            if (MontoSolicitado > limite)
            {
                Console.WriteLine("El monto solicitado supera el límite permitido.");
                return false;
            }
            if(cuotas > 18)
            {
                Console.WriteLine("El número de cuotas supera el límite permitido.");
                return false;
            }
            return true;
        }
    }
    public class AyudaEconomicaSalud: IPrestacion
    {
        public string Nombre => "Ayuda Economica Salud";
        public int limite { get; set; } 
        public int MontoSolicitado { get; set; }
        public int cuotas { get; set; }

        public bool ValidarSolicitud()
        {
            if (MontoSolicitado > limite)
            {
                Console.WriteLine("El monto solicitado supera el límite permitido.");
                return false;
            }
            if(cuotas > 18)
            {
                Console.WriteLine("El número de cuotas supera el límite permitido.");
                return false;
            }

            return true;
        }
    }
    public class Odontologia : IPrestacion
    {
        public string Nombre => "Odontologia";
        public int limite { get; set; }
        public int MontoSolicitado { get; set; }
        public int cuotas { get; set; }

        public bool ValidarSolicitud()
        {
            if (MontoSolicitado > limite)
            {
                Console.WriteLine("El monto solicitado supera el límite permitido.");
                return false;
            }
            if(cuotas > 18)
            {
                Console.WriteLine("El número de cuotas supera el límite permitido.");
                return false;
            }

            return true;
        }
    }
    public class Optica : IPrestacion
    {
        public string Nombre => "Optica";
        public int limite { get; set; }
        public int MontoSolicitado { get; set; }
        public int cuotas { get; set; }

        public bool ValidarSolicitud()
        {
            if (MontoSolicitado > limite)
            {
                Console.WriteLine("El monto solicitado supera el límite permitido.");
                return false;
            }
            if(cuotas > 18)
            {
                Console.WriteLine("El número de cuotas supera el límite permitido.");
                return false;
            }
            return true;
        }
    }
    public class Farmacia: IPrestacion
    {
        public string Nombre => "Farmacia";
        public int limite { get; set; }
        public int MontoSolicitado { get; set; }
        public int cuotas { get; set; }

        public bool ValidarSolicitud()
        {
            if (MontoSolicitado > limite)
            {
                Console.WriteLine("El monto solicitado supera el límite permitido.");
                return false;
            }
            if(cuotas > 6)
            {
                Console.WriteLine("El número de cuotas supera el límite permitido.");
                return false;
            }

            return true;
        }
    }
    public class SubsidioCasamiento : IPrestacion
    {
        public string Nombre => "Subsidio Casamiento";
        public int limite { get; set; }
        public int MontoSolicitado { get; set; }
        public int cuotas { get; set; }

        public bool ValidarSolicitud()
        {
            if (MontoSolicitado > limite)
            {
                Console.WriteLine("El monto solicitado supera el límite permitido.");
                return false;
            }

            return true;
        }
    }
    public class SubsidioEscolar : IPrestacion
    {
        public string Nombre => "Subsidio Escolaridad";
        public int limite { get; set; }
        public int MontoSolicitado { get; set; }
        public int cuotas { get; set; }

        public bool ValidarSolicitud()
        {
            if (MontoSolicitado > limite)
            {
                Console.WriteLine("El monto solicitado supera el límite permitido.");
                return false;
            }

            return true;
        }
    }
    public class SubsidioNacimiento : IPrestacion
    {
        public string Nombre => "Subsidio Nacimiento";
        public int limite { get; set; }
        public int MontoSolicitado { get; set; }
        public int cuotas { get; set; }

        public bool ValidarSolicitud()
        {
            if (MontoSolicitado > limite)
            {
                Console.WriteLine("El monto solicitado supera el límite permitido.");
                return false;
            }

            return true;
        }
    }
}
