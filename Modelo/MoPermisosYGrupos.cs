using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Modelo
{
    public class MoPermisosYGrupos
    {
        private MoConexionSQL Conexion = new MoConexionSQL();
        private SqlCommand command = new SqlCommand();
        private SqlDataReader reader;

        public DataTable MostrarPermisos()
        {
            DataTable table = new DataTable();
            command.Connection = Conexion.AbirConexion();
            command.CommandText = "SELECT nombre_permiso AS Permisos FROM permisos";
            reader = command.ExecuteReader();
            table.Load(reader);
            Conexion.CerrarConexion();
            return table;
        }
        public DataTable MostrarGrupos()
        {
            DataTable table = new DataTable();
            command.Connection = Conexion.AbirConexion();
            command.CommandText = "SELECT nombre_grupo AS Grupos FROM grupos";
            reader = command.ExecuteReader();
            table.Load(reader);
            Conexion.CerrarConexion();
            return table;
        }
    }
}
