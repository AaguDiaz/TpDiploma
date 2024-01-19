using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;

namespace Controladora
{
    public class CnDeudas
    {
        private MoDeuda objetoMo = new MoDeuda();

        public int MostrarMontoDeuda()
        {
            return objetoMo.MostrarMontoDeuda();
        }

        public int MostrarLimiteDeuda()
        {
            return objetoMo.MostrarLimiteDeuda();
        }
    }
}
