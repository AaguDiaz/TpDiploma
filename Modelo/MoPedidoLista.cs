using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Modelo
{
    public class MoPedidoLista
    {
        public int id_pedido { get; set; }
        public int id_producto { get; set; }
        public int id_lista { get; set; }
        public int cantidad { get; set; }

        public MoPedidoLista()
        {

        }

        public MoPedidoLista(int id_listas, int id_productos, int Cantidad)
        {
            id_lista=id_listas;
            id_producto = id_productos;
            cantidad = Cantidad;

        }
    }
}
