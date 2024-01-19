using Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora
{
    public class CnListaProd
    {
        MoListaProd moListaProd = new MoListaProd();

        public string MostrarFechaDetalleLPP(int id)
        {
            return moListaProd.MostrarFechaDetalleLPP(id);
        }

        public string MostrarProvDetalleLPP(int id)
        {
            return moListaProd.MostrarProvDetalleLPP(id);
        }

        public DataTable MostrarDetalleLista(int Id, int currentPage)
        {
            return moListaProd.MostrarDetalleLista(Id, currentPage);
        }
    }
}
