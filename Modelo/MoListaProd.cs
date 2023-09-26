using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Modelo
{
     public class MoListaProd
    {
        public int id_list_prod { get; set; }
        public int id_productos { get; set; }
        public int id_lista { get; set; }
        public int precio { get; set; }

        public MoListaProd()
        {

        }

        public MoListaProd (int id_producto,int Precio)
        {
            id_productos = id_producto;
            precio = Precio;

        }

        private MoConexionSQL Conexion = new MoConexionSQL();
        private SqlCommand cmd = new SqlCommand();
        private SqlDataReader reader;
        DataTable tabla = new DataTable();

        public void Insertarlista_Prod(int id_lista, int id_producto, int precio)
        {
            cmd.Connection = Conexion.CerrarConexion();
            cmd.Connection = Conexion.AbirConexion();
            cmd.CommandText = "INSERT INTO lista_pedidos_productos (id_lista, id_productos, precio) VALUES('" + id_lista + "','"+ id_producto +"','"+ precio+"')";
            cmd.ExecuteNonQuery();
        }

        public DataTable Mostrar()
        {
            cmd.Connection = Conexion.AbirConexion();
            cmd.CommandText = "select id_lista as Numero_Lista, nombre_producto as Producto, precio as Precio from lista_pedidos_productos inner join productos on lista_pedidos_productos.id_productos = productos.id_producto";
            reader = cmd.ExecuteReader();
            tabla.Load(reader);
            Conexion.CerrarConexion();
            return tabla;
        }

        public DataTable MostrarNuevaLista(int IdLista)
        {
            cmd.Connection = Conexion.AbirConexion();
            cmd.CommandText = "select id_lista as Numero_Lista, nombre_producto as Producto, precio as Precio from lista_pedidos_productos inner join productos on lista_pedidos_productos.id_productos = productos.id_producto Where id_lista ="+IdLista;
            reader = cmd.ExecuteReader();
            tabla.Load(reader);
            reader.Close();
            Conexion.CerrarConexion();
            return tabla;
        }


        public List<MoListaProd> ObtenerProductosPorLista(int idLista)
        {
            List<MoListaProd> productos = new List<MoListaProd>();

            cmd.Connection = Conexion.AbirConexion();
            cmd.CommandText = "SELECT id_productos, precio FROM lista_pedidos_productos WHERE id_lista = '"+ idLista+"'";
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int id_productos = Convert.ToInt32(reader["id_productos"]);
                int precio = Convert.ToInt32(reader["precio"]);

                MoListaProd prod = new MoListaProd(id_productos, precio);
                productos.Add(prod);
            }
            reader.Close();
            return productos;
        }


        public int ObtenerPrecioProducto(int idProducto)
        {
            cmd.Connection = Conexion.AbirConexion();
            cmd.CommandText = "SELECT precio FROM lista_pedidos_productos WHERE id_productos = '" + idProducto + "'";
  
            object result = cmd.ExecuteScalar();
            if (result != null && result != DBNull.Value)
            {
                precio = Convert.ToInt32(result);
            }
            return precio;
        }
    }
}
