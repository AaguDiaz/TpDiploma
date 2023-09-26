using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Modelo
{
    public class MoPedido
    {

        private MoConexionSQL Conexion = new MoConexionSQL();
        private SqlCommand cmd = new SqlCommand();
        private SqlDataReader reader;
        int id_usuario = 1;
        int id_estado= 1;
        
        int idPedido { get; set; }
        string nombreUsuario { get;  set; } 
        int total { get; set; } 
        string estado { get; set; }
        public MoPedido()
        {

        }

        public MoPedido(int idPedidos,string nombreUsuarios, int Total, string estados)
        {
            idPedido = idPedidos;
            nombreUsuario = nombreUsuarios;
            total = Total;
            estado = estados;

        }
        public int CrearPedido(int idLista, List<MoPedidoLista> productosSeleccionados, int totalPedido)
        {
            int idPedido = 0;

            cmd.Connection = Conexion.AbirConexion();
            

            try
            {
                    // Insertar el pedido en la tabla "pedidos"
                cmd.CommandText = "INSERT INTO pedidos VALUES ('"+id_usuario+"','"+totalPedido+"','"+id_estado+"'); SELECT SCOPE_IDENTITY() as id_pedido;";
                idPedido = Convert.ToInt32(cmd.ExecuteScalar());
                
                    // Insertar los productos del pedido en la tabla "pedido_lista"
                 cmd.CommandText = "INSERT INTO pedidos_lista_p (id_pedido, id_lista, id_producto, cantidad) VALUES (@IdPedidoLista, @IdLista , @IdProducto, @Cantidad)";
                 foreach (MoPedidoLista producto in productosSeleccionados)
                 {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@IdPedidoLista", idPedido);
                    cmd.Parameters.AddWithValue("@IdLista", idLista);
                    cmd.Parameters.AddWithValue("@IdProducto", producto.id_producto);
                    cmd.Parameters.AddWithValue("@Cantidad", producto.cantidad);

                    cmd.ExecuteNonQuery();
                 }
                Console.WriteLine("Pedido Cargado con exito");
            }
            catch (Exception ex)
            {
              idPedido = 0; // Indicar que ocurrió un error
              Console.WriteLine("Error al crear el pedido: " + ex.Message);
            }
            return idPedido;
        }

        
        public DataTable ListarPedido()
        {
            DataTable table = new DataTable();
            cmd.Connection = Conexion.AbirConexion();
            cmd.CommandText= "SELECT pedidos.id_pedido, usuarios.mail, pedidos.total, estado.Estado FROM pedidos JOIN usuarios ON pedidos.id_usuario = usuarios.id_usuario JOIN estado ON pedidos.id_estado = estado.id_estado WHERE pedidos.id_usuario = "+id_usuario;
            reader = cmd.ExecuteReader();
            table.Load(reader);
            reader.Close();
            Conexion.CerrarConexion();
            return table;
        }

        public DataTable ListarPedidoPorEstado()
        {
            DataTable table = new DataTable();
            cmd.Connection = Conexion.AbirConexion();
            cmd.CommandText = "SELECT pedidos.id_pedido, usuarios.mail, pedidos.total, estado.Estado FROM pedidos JOIN usuarios ON pedidos.id_usuario = usuarios.id_usuario JOIN estado ON pedidos.id_estado = estado.id_estado ";
            reader = cmd.ExecuteReader();
            table.Load(reader);
            reader.Close();
            Conexion.CerrarConexion();
            return table;
        }

        public void ActualizarEstado(int idPedido, int newestado)
        {
            cmd.Connection = Conexion.AbirConexion();
            cmd.CommandText = "UPDATE pedidos SET id_estado = @newestado WHERE id_pedido= @IdPedido";
            cmd.Parameters.AddWithValue("@newestado", newestado);
            cmd.Parameters.AddWithValue("@IdPedido", idPedido);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            Conexion.CerrarConexion();
        }
    }
}
