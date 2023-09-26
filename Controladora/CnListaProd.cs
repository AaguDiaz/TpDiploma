using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Modelo;

namespace Controladora
{
    public class CnListaProd
    {
        private MoListaProd objMo = new MoListaProd();

        public void Insertarlista_Prod(string id_lista, string id_producto, string precio)
        {
            objMo.Insertarlista_Prod(Convert.ToInt32(id_lista), Convert.ToInt32(id_producto), Convert.ToInt32(precio));
        }

       
        public DataTable MostrarNuevaLista(string IdLista)
        {
            return objMo.MostrarNuevaLista(Convert.ToInt32(IdLista));
        }

        public List<MoListaProd> ObtenerProductosPorLista(string idLista)
        {
            return objMo.ObtenerProductosPorLista(Convert.ToInt32(idLista));
        }

        public int ObtenerPrecioProducto(int idProducto)
        {
            return objMo.ObtenerPrecioProducto(idProducto);
        }
    }
}
