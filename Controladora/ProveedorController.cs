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
    public class ProveedorController
    {
        proveedor Proveedor = new proveedor();

        public List<proveedor> ObtenerProveedores()
        {
            return Proveedor.MostrarProveedor();
        }
    }
}
