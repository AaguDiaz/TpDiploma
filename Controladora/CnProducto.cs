using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Modelo;

namespace Controladora
{
    public class CnProducto
    {
        MoProducto producto = new MoProducto();

        public List<MoProducto> ObtenerProducto()
        {
            return producto.MostrarProducto();
        }

        public string ObtenerNombreProductoPorId(int idProducto)
        {
            return producto.ObtenerNombreProductoPorId(idProducto);
        }
        public string ObtenerDescripcionPorId(int idProducto)
        {
            return producto.ObtenerDescripcionPorId(idProducto);
        }

        public List<MoProducto> MostrarProductosPorLista(string idLista)
        {
            return producto.MostrarProductosPorLista(Convert.ToInt32(idLista));
        }

    }
}
