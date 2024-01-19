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
    public class CnProveedor
    {
        private MoProveedor moProv = new MoProveedor();

        public DataTable MostrarProv()
        {
            return moProv.Mostrar(); 
        }
        public int VerificarProv(string nombre, string direccion, string cuil, string telefono)
        {
            return moProv.verificacion(nombre, direccion, Convert.ToInt64(cuil), Convert.ToInt64(telefono));
        }
        public void InsertarProv(string nombre_proveedor, string direccion_pro, string cuil, string telefono)
        {
            moProv.InsertarProveedor(nombre_proveedor, direccion_pro, Convert.ToInt64(cuil), Convert.ToInt64(telefono));
        }
        public void ModificarProv(int id, string nombre_proveedor, string direccion_pro, string cuil, string telefono)
        {
            moProv.ModificarProveedor(id, nombre_proveedor, direccion_pro, Convert.ToInt64(cuil), Convert.ToInt64(telefono));
        }

        public void DarAltaProv(int id)
        {
            moProv.DarAltaProveedor(id);
        }

        public void DarBajaProv(int id)
        {
            moProv.DarBajaProveedor(id);
        }


        public List<CacheProveedor> MostrarProveedor()
        {
            return moProv.MostrarProveedor();
        }
    }
   
}
