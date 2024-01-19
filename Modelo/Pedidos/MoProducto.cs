﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using COMUN.Cache;

namespace Modelo
{
    public class MoProducto
    {
        private MoConexionSQL conexion = new MoConexionSQL();
        private SqlDataReader reader; 
        SqlCommand command = new SqlCommand();
        DataTable tabla = new DataTable();

        public List<CacheProductos> MostrarCategorias()
        {
            command.Connection = conexion.AbirConexion();
            command.CommandText = "Select nombre from categorias";
            List<CacheProductos> categorias = new List<CacheProductos>();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    categorias.Add(new CacheProductos { 
                        nombre_cat = reader["nombre"].ToString() 
                    });
                }
                reader.Close();
            }
            return categorias;
        }

        public DataTable MostrarProductos(int currentPage)
        {
            int skip = (currentPage - 1) * 12;
            command.Connection = conexion.AbirConexion();
            command.CommandText = "Select p.nombre_producto AS Producto, p.descripcion AS Descripcion, c.nombre AS Categoria" +
                "   FROM productos p " +
                "   LEFT JOIN categorias c ON p.categoria = c.id_categoria " +
                $" ORDER BY Producto OFFSET {skip} ROWS FETCH NEXT {12} ROWS ONLY";
            tabla.Clear();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    tabla.Load(reader);
                    command.Parameters.Clear();
                    conexion.CerrarConexion();
                    return tabla;
                }
                else
                {
                    command.Parameters.Clear();
                    conexion.CerrarConexion();
                    return tabla;
                }
            }
        }
        public DataTable MostrarProductosFil(int currentPage, int valor)
        {
            int skip = (currentPage - 1) * 12;
            command.Connection = conexion.AbirConexion();
            command.CommandText = "Select p.nombre_producto AS Producto, p.descripcion AS Descripcion, c.nombre AS Categoria" +
                "   FROM productos p " +
                "   LEFT JOIN categorias c ON p.categoria = c.id_categoria" +
                "   WHERE p.categoria = @valor " +
                $" ORDER BY Producto OFFSET {skip} ROWS FETCH NEXT {12} ROWS ONLY";
            command.Parameters.AddWithValue("@valor", valor);
            reader = null;
            tabla.Clear();
            using (reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    tabla.Load(reader);
                    command.Parameters.Clear();
                    conexion.CerrarConexion();
                    return tabla;
                }
                else
                {
                    command.Parameters.Clear();
                    conexion.CerrarConexion();
                    return tabla;
                }
            }
        }

        public DataTable MostrarProductosABM()
        {
            command.Connection = conexion.AbirConexion();
            command.CommandText = "Select p.id_producto AS Id, p.nombre_producto AS Producto, p.descripcion AS Descripcion, c.nombre AS Categoria" +
                "   FROM productos p " +
                "   LEFT JOIN categorias c ON p.categoria = c.id_categoria";
            tabla.Clear();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    tabla.Load(reader);
                    command.Parameters.Clear();
                    conexion.CerrarConexion();
                    return tabla;
                }
                else
                {
                    command.Parameters.Clear();
                    conexion.CerrarConexion();
                    return tabla;
                }
            }
        }


        public void AgregarProducto(string nombre, string descripcion, string categoria)
        {
            command.Connection = conexion.AbirConexion();
            command.CommandText ="SELECT id_categoria FROM categorias WHERE nombre = @categoria";
            command.Parameters.AddWithValue("@categoria", categoria);
            int id = Convert.ToInt32(command.ExecuteScalar());
            command.CommandText = "INSERT INTO productos (nombre_producto, descripcion, categoria) VALUES (@nombre, @descripcion, @idcategoria)";
            command.Parameters.AddWithValue("@nombre", nombre);
            command.Parameters.AddWithValue("@descripcion", descripcion);
            command.Parameters.AddWithValue("@idcategoria", id);
            command.ExecuteNonQuery();
            command.Parameters.Clear();
            conexion.CerrarConexion();
        }

        public void ModificarProducto(int id, string nombre, string descripcion, string categoria)
        {
            command.Connection = conexion.AbirConexion();
            command.CommandText = "SELECT id_categoria FROM categorias WHERE nombre = @categoria";
            command.Parameters.AddWithValue("@categoria", categoria);
            int idcat = Convert.ToInt32(command.ExecuteScalar());
            command.CommandText = "UPDATE productos SET nombre_producto = @nombre, descripcion = @descripcion, categoria = @idcategoria WHERE id_producto = @id";
            command.Parameters.AddWithValue("@nombre", nombre);
            command.Parameters.AddWithValue("@descripcion", descripcion);
            command.Parameters.AddWithValue("@idcategoria", idcat);
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
            command.Parameters.Clear();
            conexion.CerrarConexion();
        }

        public int EliminarProducto(int id)
        {
            command.Connection = conexion.AbirConexion();
            command.CommandText = "SELECT id_lista FROM lista_pedidos_productos WHERE id_productos = @idp";
            command.Parameters.AddWithValue("@idp", id);
            int result = Convert.ToInt32(command.ExecuteScalar());
            if (result == 0 )
            {
                command.CommandText = "DELETE FROM productos WHERE id_producto = @id";
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
                command.Parameters.Clear();
                conexion.CerrarConexion();
                return result;
            }
            else
            {
                command.Parameters.Clear();
                conexion.CerrarConexion();
                return result;
            }
        }

        public int ObtenerIdCat()
        {
            command.Connection = conexion.AbirConexion();
            command.CommandText = " SELECT TOP 1 id_categoria " +
                " FROM categorias " +
                " ORDER BY id_categoria DESC ";
            int id = Convert.ToInt32(command.ExecuteScalar());
            command.Parameters.Clear();
            conexion.CerrarConexion();
            return id;
        }

        public void AgregarCategoria(string nombre)
        {
            command.Connection = conexion.AbirConexion();
            command.CommandText = "INSERT INTO categorias (nombre) VALUES (@nombre)";
            command.Parameters.AddWithValue("@nombre", nombre);
            command.ExecuteNonQuery();
            command.Parameters.Clear();
            conexion.CerrarConexion();
        }   

    }
}