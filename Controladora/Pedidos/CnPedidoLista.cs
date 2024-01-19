using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;

namespace Controladora
{
    public class CnPedidoLista
    {
        MoPedidoLista pedidoLista = new MoPedidoLista();

        public void CargarPedidoLista(int id_pedido, string id_lista, string producto, string desc, string cat, string cantidad, string precio)
        {
            pedidoLista.CargarPedidoLista(id_pedido, Convert.ToInt32(id_lista), producto, desc, cat,Convert.ToInt32( cantidad),Convert.ToInt32( precio));
        }

        public DataTable MostrarPedidoLista(int id, int currentPage)
        {
            return pedidoLista.MostrarPedidoLista(id, currentPage);
        }
    }
}
