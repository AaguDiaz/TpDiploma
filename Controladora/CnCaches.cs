﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COMUN.Cache;

namespace Controladora
{
    public class CnCaches
    {
        //Cache de CargaDatosUsuario
        public string CacheNombre()
        {
            string nombre = CacheEditarUsuario.nombre;
            return nombre;
        }
        public string CacheApellido()
        {
            string apellido = CacheEditarUsuario.apellido;
            return apellido;
        }
        public string CacheMail()
        {
            string mail = CacheEditarUsuario.mail;
            return mail;
        }
        public string CacheDni()
        {
            string dni = CacheEditarUsuario.dni.ToString();
            return dni;
        }
        public string CacheCVU()
        {
            string cvu = CacheEditarUsuario.cvu.ToString();
            return cvu;
        }   
        public string CacheTelefono()
        {
            string telefono = CacheEditarUsuario.telefono.ToString();
            return telefono;
        }
        public string CacheDireccion()
        {
            string direccion = CacheEditarUsuario.direccion;
            return direccion;
        }
      

        
        //Cache de Lista de pedidos

        public DataTable Productos()
        {
            if (CacheProductos.tbProducto == null)
            {
                CacheProductos.tbProducto = new DataTable();
                CacheProductos.tbProducto.Columns.Add("Producto", typeof(string));
                CacheProductos.tbProducto.Columns.Add("Descripcion", typeof(string));
                CacheProductos.tbProducto.Columns.Add("Categoria", typeof(string));
                CacheProductos.tbProducto.Columns.Add("Precio", typeof(int));
            }
            return CacheProductos.tbProducto;
        }

    }
}
