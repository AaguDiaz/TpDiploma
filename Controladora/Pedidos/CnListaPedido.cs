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

        public DataTable MostrarTodas(int currentPage, DateTime desde, DateTime hasta)
        {
            DataTable tabla = new DataTable();
            tabla = moListaPedido.FiltroTodas(currentPage, desde, hasta);
            return tabla;
        }

        public DataTable MostrarActivas(int currentPage)
        {
            DataTable tabla = new DataTable();
            tabla = moListaPedido.FiltroActivas(currentPage);
            return tabla;
        }

        public DataTable MostrarVencidas(int currentPage, DateTime desde, DateTime hasta)
        {
            DataTable tabla = new DataTable();
            tabla = moListaPedido.FiltroVencidas(currentPage, desde, hasta);
            return tabla;
        }

        public int CargarLista(string Proveedor, string desc,DateTime fechaVencimiento)
        {
           return moListaPedido.CargarLista(Proveedor, desc, fechaVencimiento);
        }

        public int CargarListaPxP(int id_lista,string nombreProducto,string descripcionProducto,int precioProducto)
        {
            return moListaPedido.cargarListaPxP(id_lista, nombreProducto, descripcionProducto, precioProducto);
        }

        


        

    }
}
