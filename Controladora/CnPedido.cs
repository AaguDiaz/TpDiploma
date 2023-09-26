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

        MoPedido oPed = new MoPedido();

        public int CrearPedido(int idLista, List<MoPedidoLista> productosSeleccionados,int totalPedido)
        {
            return oPed.CrearPedido(idLista,productosSeleccionados,totalPedido);
        }

        
        public DataTable ListarPedido()
        {
            return oPed.ListarPedido();
        }
        public DataTable ListarPedidoPorEstado()
        {
            return oPed.ListarPedidoPorEstado();
        }

        public void ActualizarEstado(int idPedido, int newestado)
        {
            oPed.ActualizarEstado(idPedido,newestado);
        }

    }
}
