using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Modelo;
using COMUN.Cache;

namespace Controladora
{
    public class CnProducto
    {
        MoProducto producto = new MoProducto();

        public List<CacheProductos> MostrarCategorias()
        {
            return producto.MostrarCategorias();
        }

        public DataTable MostrarProductos(int currentPage)
        {
            return producto.MostrarProductos(currentPage);
        }

        public DataTable MostrarProductosFil(int currentPage, int valor)
        {
            return producto.MostrarProductosFil(currentPage, valor);
        }

        public DataTable MostrarProductosABM()
        {
            return producto.MostrarProductosABM();
        }

        public void AgregarProducto(string nombre, string descripcion, string categoria)
        {
            producto.AgregarProducto(nombre, descripcion, categoria);
        }

        public void ModificarProducto(int id, string nombre, string descripcion, string categoria)
        {
            producto.ModificarProducto(id, nombre, descripcion, categoria);
        }

        public int EliminarProducto(int id)
        {
            return producto.EliminarProducto(id);
        }

        public int ObtenerIdCat()
        {
            return producto.ObtenerIdCat();
        }

        public void AgregarCategoria(string nombre)
        {
            producto.AgregarCategoria(nombre);
        }

    }
}
