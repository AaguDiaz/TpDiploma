using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Modelo
{
    public class MoConexionSQL
    {
        private static MoConexionSQL _instance;
        private static readonly object _lock = new object();
        public string Conexion { get; private set; }
        
        private MoConexionSQL() {
            Conexion = "Data Source=W10NTBX-SLOTI;Initial Catalog=pruebaACA;Integrated Security=True";
        }

        public static MoConexionSQL Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new MoConexionSQL();
                    }
                    return _instance;
                }
            }
        }
    }
}
