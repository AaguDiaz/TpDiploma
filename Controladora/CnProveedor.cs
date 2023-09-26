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
    public class CnProveedor
    {
        private MoProveedor objetoMo = new MoProveedor();

        public DataTable MostrarProv()
        {
            return objetoMo.Mostrar(); 
        }
        public void InsertarProv(string nombre_proveedor, string direccion_pro, string cuil, string telefono)
        {
            objetoMo.InsertarProveedor(nombre_proveedor, direccion_pro, Convert.ToInt64(cuil), Convert.ToInt64(telefono));
        }
    }
   
}
