using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using COMUN.Cache;
using System.Runtime.Remoting.Messaging;
using System.Globalization;


namespace Modelo
{
    public class MoReportes
    {
        private SqlDataReader reader;
        public DateTime startDate;
        public DateTime endDate;
        public int numberDays;


        public void CargarPedidos()
        {
            using (SqlConnection connection = new SqlConnection(MoConexionSQL.Instance.Conexion))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    CacheReportes.PedidosLista = new List<PedidosByDate>();
                    command.Connection = connection;
                    connection.Open();
                    command.CommandText = @"SELECT fecha_pedido AS Fecha, COUNT(id_pedido) AS Total
                                    FROM pedidos
                                    WHERE fecha_pedido BETWEEN @fromDate AND @toDate
                                    GROUP BY fecha_pedido
                                    ORDER BY fecha_pedido ASC";
                    command.Parameters.Add("@fromDate", System.Data.SqlDbType.DateTime).Value = startDate;
                    command.Parameters.Add("@toDate", System.Data.SqlDbType.DateTime).Value = endDate;
                    var reader = command.ExecuteReader();
                    var resultTable = new List<KeyValuePair<DateTime, int>>();
                    while (reader.Read())
                    {
                        resultTable.Add(
                                    new KeyValuePair<DateTime, int>((DateTime)reader[0], (int)reader[1])
                                    );
                    }
                    reader.Close();
                    if (numberDays <= 1)
                    {
                        CacheReportes.PedidosLista = (from orderList in resultTable
                                                      group orderList by orderList.Key.ToString("hh tt")
                                           into order
                                                      select new PedidosByDate
                                                      {
                                                          Fecha = order.Key,
                                                          Total = order.Sum(amount => amount.Value)
                                                      }).ToList();

                    }
                    else if (numberDays <= 30)
                    {
                        CacheReportes.PedidosLista = (from orderList in resultTable
                                                      group orderList by orderList.Key.ToString("dd MMM")
                                                       into order
                                                      select new PedidosByDate
                                                      {
                                                          Fecha = order.Key,
                                                          Total = order.Sum(amount => amount.Value)
                                                      }).ToList();
                        command.Parameters.Clear();
                    }
                    //Group by Weeks
                    else if (numberDays <= 92)
                    {
                        CacheReportes.PedidosLista = (from orderList in resultTable
                                                      group orderList by CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(
                                                          orderList.Key, CalendarWeekRule.FirstDay, DayOfWeek.Monday)
                                           into order
                                                      select new PedidosByDate
                                                      {
                                                          Fecha = "Week " + order.Key.ToString(),
                                                          Total = order.Sum(amount => amount.Value)
                                                      }).ToList();
                        command.Parameters.Clear();
                    }
                    //Group by Months
                    else if (numberDays <= (365 * 2))
                    {
                        bool isYear = numberDays <= 365 ? true : false;
                        CacheReportes.PedidosLista = (from orderList in resultTable
                                                      group orderList by orderList.Key.ToString("MMM yyyy")
                                           into order
                                                      select new PedidosByDate
                                                      {
                                                          Fecha = isYear ? order.Key.Substring(0, order.Key.IndexOf(" ")) : order.Key,
                                                          Total = order.Sum(amount => amount.Value)
                                                      }).ToList();
                        command.Parameters.Clear();
                    }
                    //Group by Years
                    else
                    {
                        CacheReportes.PedidosLista = (from orderList in resultTable
                                                      group orderList by orderList.Key.ToString("yyyy")
                                           into order
                                                      select new PedidosByDate
                                                      {
                                                          Fecha = order.Key,
                                                          Total = order.Sum(amount => amount.Value)
                                                      }).ToList();
                        command.Parameters.Clear();
                    }
                    command.Parameters.Clear();
                    connection.Close();
                }
            }
        }

        public void CargarTotales()
        {
            using (SqlConnection connection = new SqlConnection(MoConexionSQL.Instance.Conexion))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    connection.Open();

                    //Cargar total de socios
                    command.CommandText = "select count(id_empleado) from empleados";
                    CacheReportes.NumEmpleados = (int)command.ExecuteScalar();
                    //Cargar total de socios activos
                    command.CommandText = "select count(id_usuario) from usuarios where estado = 'Activo'";
                    CacheReportes.EmpleadosActivos = (int)command.ExecuteScalar();
                    //Cargar total de socios de baja
                    command.CommandText = "select count(id_usuario) from usuarios where estado = 'Baja'";
                    CacheReportes.EmpleadosBaja = (int)command.ExecuteScalar();


                    //Cargar total de proveedores
                    command.CommandText = "select count(id_proveedor) from proveedores";
                    CacheReportes.NumProveedores = (int)command.ExecuteScalar();
                    //Cargar total de proveedores activos
                    command.CommandText = "select count(id_proveedor) from proveedores where estado = 'Activo'";
                    CacheReportes.ProveedoresActivos = (int)command.ExecuteScalar();
                    //Cargar total de proveedores de baja
                    command.CommandText = "select count(id_proveedor) from proveedores where estado = 'Baja'";
                    CacheReportes.ProveedoresBaja = (int)command.ExecuteScalar();

                    //Cargar total de productos
                    command.CommandText = "select count(id_producto) from productos";
                    CacheReportes.NumProductos = (int)command.ExecuteScalar();

                    //Cargar total de listas
                    command.CommandText = "select count(id_lista) from listapedidos";
                    CacheReportes.NumListaPedidos = (int)command.ExecuteScalar();
                    //Cargar total de listas activas
                    command.CommandText = "select count(id_lista) from listapedidos where fecha_vencimiento > GETDATE()";
                    CacheReportes.ListasActivas = (int)command.ExecuteScalar();
                    //Cargar total de listas vencidas
                    command.CommandText = "select count(id_lista) from listapedidos where fecha_vencimiento < GETDATE()";
                    CacheReportes.ListasVencidas = (int)command.ExecuteScalar();

                    //Get Total Number of Orders
                    command.CommandText = @"select count(id_pedido) from [pedidos]" +
                                            "where fecha_pedido between  @fromDate and @toDate";
                    command.Parameters.Add("@fromDate", System.Data.SqlDbType.DateTime).Value = startDate;
                    command.Parameters.Add("@toDate", System.Data.SqlDbType.DateTime).Value = endDate;
                    CacheReportes.NumPedidos = (int)command.ExecuteScalar();
                    command.Parameters.Clear();

                    //Cargar total de pedidos pendientes
                    command.CommandText = "select count(id_pedido) from pedidos " +
                        " where id_estado = '1' AND fecha_pedido between @fromDate and @toDate ";
                    command.Parameters.Add("@fromDate", System.Data.SqlDbType.DateTime).Value = startDate;
                    command.Parameters.Add("@toDate", System.Data.SqlDbType.DateTime).Value = endDate;
                    CacheReportes.PedidosPendientes = (int)command.ExecuteScalar();
                    command.Parameters.Clear(); ;
                    //Cargar total de pedidos aceptados
                    command.CommandText = " select count(id_pedido) from pedidos " +
                        " where id_estado = '2' AND fecha_pedido between @fromDate and @toDate ";
                    command.Parameters.Add("@fromDate", System.Data.SqlDbType.DateTime).Value = startDate;
                    command.Parameters.Add("@toDate", System.Data.SqlDbType.DateTime).Value = endDate;
                    CacheReportes.PedidosAceptadas = (int)command.ExecuteScalar();
                    command.Parameters.Clear();
                    //Cargar total de pedidos rechazados
                    command.CommandText = "select count(id_pedido) from pedidos " +
                        " where id_estado = '3' AND fecha_pedido between @fromDate and @toDate ";
                    command.Parameters.Add("@fromDate", System.Data.SqlDbType.DateTime).Value = startDate;
                    command.Parameters.Add("@toDate", System.Data.SqlDbType.DateTime).Value = endDate;
                    CacheReportes.PedidosRechazadas = (int)command.ExecuteScalar();
                    command.Parameters.Clear();
                    connection.Close();
                }
            }
        }

        public void CargarTopPedidos()
        {
            using (SqlConnection connection = new SqlConnection(MoConexionSQL.Instance.Conexion))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    CacheReportes.TopProductos = new List<KeyValuePair<string, int>>();
                    command.Connection = connection;
                    connection.Open();
                    command.CommandText = @"SELECT TOP 5 P.nombre_producto, sum(pl.cantidad) as C
                                            from pedidos_lista_p pl
                                            inner join productos P on P.id_producto = pl.id_producto
                                            inner join [pedidos] O on O.id_pedido = pl.id_pedido
                                            where O.fecha_pedido between @fromDate and @toDate
                                            group by P.nombre_producto
                                            order by C desc ";
                    command.Parameters.Add("@fromDate", System.Data.SqlDbType.DateTime).Value = startDate;
                    command.Parameters.Add("@toDate", System.Data.SqlDbType.DateTime).Value = endDate;
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        CacheReportes.TopProductos.Add(
                            new KeyValuePair<string, int>(reader[0].ToString(), (int)reader[1]));
                    }
                    reader.Close();
                    command.Parameters.Clear();
                    connection.Close();
                }
            }
        }

        public void CargarTopListas()
        {
            using (SqlConnection connection = new SqlConnection(MoConexionSQL.Instance.Conexion))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    CacheReportes.TopListas = new List<KeyValuePair<string, int>>();
                    command.Connection = connection;
                    connection.Open();
                    command.CommandText = @"SELECT CONCAT(p.nombre_proveedor, ' ', l.descripcion) AS Lista, COUNT(lp.id_lista) AS CantidadUsos
                                    FROM pedidos_lista_p lp
                                    LEFT JOIN listapedidos l ON lp.id_lista = l.id_lista
                                    LEFT JOIN proveedores p ON l.id_proveedor = p.id_proveedor
                                    LEFT JOIN pedidos ped ON lp.id_pedido = ped.id_pedido
                                    where ped.fecha_pedido between @fromDate and @toDate
                                    group by CONCAT(p.nombre_proveedor, ' ', l.descripcion)
                                    order by CantidadUsos desc ";
                    command.Parameters.Add("@fromDate", System.Data.SqlDbType.DateTime).Value = startDate;
                    command.Parameters.Add("@toDate", System.Data.SqlDbType.DateTime).Value = endDate;
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        CacheReportes.TopListas.Add(
                            new KeyValuePair<string, int>(reader[0].ToString(), (int)reader[1]));
                    }
                    reader.Close();
                    command.Parameters.Clear();
                    connection.Close();
                }
            }
        }




    }
}
