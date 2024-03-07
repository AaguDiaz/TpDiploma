using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMUN.Cache
{
     public interface IPrestacion
    {
        string  Nombre { get; }
        int MontoSolicitado { get; set; }
        int cuotasSolicitado { get; set; }
        string pdf { get; set; }
    }
    
}
