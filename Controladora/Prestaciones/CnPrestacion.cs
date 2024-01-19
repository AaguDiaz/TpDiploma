using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;

namespace Controladora
{
    public class CnPrestacion
    {
        MoPrestacion moPrestacion = new MoPrestacion();
        public void Cargarlimites()
        {
            moPrestacion.Cargarlimites();
        }
    }
}
