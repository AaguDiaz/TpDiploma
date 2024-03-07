using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;

namespace Controladora
{
    public class CnDeudas
    {
        private MoDeuda moDeuda = new MoDeuda();

        public int MostrarMontoDeuda()
        {
            return moDeuda.MostrarMontoDeuda();
        }

        public int MostrarLimiteDeuda()
        {
            return moDeuda.MostrarLimiteDeuda();
        }

        public DataTable MostrarDeudas()
        {
            return moDeuda.MostrarDetalleDeuda();
        }

        public bool VerificarDeuda(int id_soli, int monto,string empleado)
        {
            if( moDeuda.VerificarDeuda(empleado) == false)
            {
                moDeuda.CrearDeuda(empleado);
            }
            int deuda= moDeuda.MostrarMontoDeudaEmpleado(empleado);
            int limite = moDeuda.MostrarLimiteDeuda();
            int montototal = deuda + monto;
            if(montototal < limite)
            {
                moDeuda.CargarSoli_deuda(id_soli, monto,empleado);
                moDeuda.ActualizarDeuda(monto,empleado);
                return true;
            }else
            {
                return false;
            }


        }

    }
}
