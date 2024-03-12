using System;
using System.Data.SqlClient;

namespace Modelo
{
    public class MoBackup
    {

        public string GenerarBackup()
        {
            using (SqlConnection connection = new SqlConnection(MoConexionSQL.Instance.Conexion))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    
                    string mensaje = "";
                    string NombreArchivo = "SistemaACA" + DateTime.Now.ToString("yyyy-MM-dd") + ".bak";
                    try
                    {
                        command.Connection = connection;
                        connection.Open();
                        command.CommandText = $"BACKUP DATABASE [pruebaACA] TO DISK = N'"+
                            "C:\\Program Files\\Microsoft SQL Server\\MSSQL15.MSSQLSERVER\\MSSQL\\Backup\\"+NombreArchivo+ 
                            "' WITH NOFORMAT, NOINIT, NAME = N'pruebaACA-Full Database Backup', SKIP, NOREWIND, NOUNLOAD,  STATS = 10";
                        command.ExecuteNonQuery();
                        connection.Close();
                        mensaje = "Backup generado correctamente";
                    }
                    catch (Exception ex)
                    {
                        mensaje = "Error al generar el backup: " + ex.Message;
                    }
                    return mensaje;
                }
            }
        }

        public string RestaurarBackup(string ruta)
        {
            using (SqlConnection connection = new SqlConnection(MoConexionSQL.Instance.Conexion))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    string mensaje = "";
                    try
                    {
                        command.Connection = connection;
                        connection.Open();
                        command.CommandText = "USE [master] ALTER DATABASE [pruebaACA] SET SINGLE_USER WITH ROLLBACK IMMEDIATE \n " +
                            " RESTORE DATABASE [pruebaACA] FROM DISK = N'" + ruta + "' WITH FILE = 1, REPLACE, NOUNLOAD, STATS = 5 \n " +
                            " ALTER DATABASE [pruebaACA] SET MULTI_USER";
                        command.ExecuteNonQuery();
                        connection.Close();
                        mensaje = "Backup restaurado correctamente";
                    }
                    catch (Exception ex)
                    {
                        mensaje = "Error al restaurar el backup: " + ex.Message;
                    }
                    return mensaje;
                }
            }
        }   


    }
}
