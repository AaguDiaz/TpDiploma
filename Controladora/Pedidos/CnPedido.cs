using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Modelo;

namespace Controladora
{
    public class CnPedido
    {
        MoPedido moPed = new MoPedido();
        DataTable table = new DataTable();
        public int CargarPedido(string total)
        {
            return moPed.CargarPedido(Convert.ToInt32(total));
        }

        public DataTable MostrarPedidos(int CurrentPage, string filtro, DateTime desde, DateTime hasta)
        {
            if(filtro == "Todas")
            {
                return moPed.MostarPedidosTodas(CurrentPage, desde, hasta);
            }
            else if(filtro == "Pendientes")
            {
                return moPed.MostarPedidosFiltro(CurrentPage, 1, desde, hasta);
            }
            else if(filtro == "Aceptadas")
            {
                return moPed.MostarPedidosFiltro(CurrentPage, 2, desde, hasta);
            }
            else if(filtro == "Rechazadas")
            {
                return moPed.MostarPedidosFiltro(CurrentPage, 3, desde, hasta);
            }
            return table;
        }

    }
}
