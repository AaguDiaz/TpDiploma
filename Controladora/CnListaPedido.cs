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
        private MoListaPedido objetoMo = new MoListaPedido();

        public string MostrarId(string id_proveedor)
        {
            return objetoMo.Mostrar(Convert.ToInt32(id_proveedor));
        }

        public void Insertarlista(int id_proveedor, DateTime fecha_vencimiento)
        {
            objetoMo.Insertarlista(id_proveedor,fecha_vencimiento);
        }

        public List<MoListaPedido> MostrarLista()
        {
            return objetoMo.MostrarLista();
        }

        public string ObtenerNombreProveedorPorIdLista(string idLista)
        {

            return objetoMo.ObtenerNombreProveedorPorIdLista(Convert.ToInt32(idLista));
        }
        
        public DateTime ObtenerFechaVencimientoPorIdLista(string idLista)
        {
            return objetoMo.ObtenerFechaVencimientoPorIdLista(Convert.ToInt32(idLista));
        }

    }
}
