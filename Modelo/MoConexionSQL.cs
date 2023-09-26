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
        private SqlConnection Conexion = new SqlConnection("Data Source=W10NTBX-SLOTI;Initial Catalog=pruebaACA;Integrated Security=True");

          public SqlConnection AbirConexion()
          {
            if(Conexion.State== ConnectionState.Closed) { 
                Conexion.Open();
            }
            return Conexion;
          }

            public SqlConnection CerrarConexion()
            {
                if(Conexion.State == ConnectionState.Open)
                {
                    Conexion.Close();
                }
                return Conexion;
            }
        
        

    }
}
