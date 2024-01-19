using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Modelo;

namespace Controladora
{
    public class CnListaPedido
    {
        MoListaPedido moListaPedido = new MoListaPedido();

        public DataTable MostrarTodas(int currentPage)
        {
            DataTable tabla = new DataTable();
            tabla = moListaPedido.FiltroTodas(currentPage);
            return tabla;
        }

        public DataTable MostrarActivas(int currentPage)
        {
            DataTable tabla = new DataTable();
            tabla = moListaPedido.FiltroActivas(currentPage);
            return tabla;
        }

        public DataTable MostrarVencidas(int currentPage)
        {
            DataTable tabla = new DataTable();
            tabla = moListaPedido.FiltroVencidas(currentPage);
            return tabla;
        }

        public int CargarLista(string Proveedor, DateTime fechaVencimiento)
        {
           return moListaPedido.CargarLista(Proveedor,fechaVencimiento);
        }

        public int CargarListaPxP(int id_lista,string nombreProducto,string descripcionProducto,int precioProducto)
        {
            return moListaPedido.cargarListaPxP(id_lista, nombreProducto, descripcionProducto, precioProducto);
        }

        


        

    }
}
