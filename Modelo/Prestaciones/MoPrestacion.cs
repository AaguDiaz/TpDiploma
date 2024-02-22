using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using COMUN.Cache;

namespace Modelo
{
    public class MoPrestacion
    {
    
        public void Cargarlimites()
        {
            using (SqlConnection connection = new SqlConnection(MoConexionSQL.Instance.Conexion))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    connection.Open();
                    command.CommandText = "SELECT p.nombre_prestacion, p.limite FROM prestaciones p";

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                if (reader.GetString(0) == "Ayuda Economica Ordinaria ")
                                {
                                    AyudaEconomicaOrdinaria.limite = reader.GetInt32(1);
                                }
                                else if (reader.GetString(0) == "Ayuda Economica Salud")
                                {
                                    AyudaEconomicaSalud.limite = reader.GetInt32(1);
                                }
                                else if (reader.GetString(0) == "Odontologia")
                                {
                                    Odontologia.limite = reader.GetInt32(1);
                                }
                                else if (reader.GetString(0) == "Optica")
                                {
                                    Optica.limite = reader.GetInt32(1);
                                }
                                else if (reader.GetString(0) == "Farmacia")
                                {
                                    Farmacia.limite = reader.GetInt32(1);
                                }
                                else if (reader.GetString(0) == "Subsidio Escolaridad")
                                {
                                    SubsidioEscolar.limite = reader.GetInt32(1);
                                }
                                else if (reader.GetString(0) == "Subsidio Casamiento")
                                {
                                    SubsidioCasamiento.limite = reader.GetInt32(1);
                                }
                                else if (reader.GetString(0) == "Subsidio Nacimiento")
                                {
                                    SubsidioNacimiento.limite = reader.GetInt32(1);
                                }
                            }
                        }
                    }
                    connection.Close();
                }
            }

        }


    }
}
