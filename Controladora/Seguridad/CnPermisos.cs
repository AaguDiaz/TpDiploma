using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COMUN.Seguridad;
using Modelo;

namespace Controladora
{
    public class CnPermisos
    {
        MoPermisos permiso = new MoPermisos();


        public DataTable MostrarPermisos()
        {
            return permiso.MostrarPermisos();
        }

        public List<string> MostrarPermisosSegunSeccion(int seccion)
        {
            List<string> PermisosSeccion = new List<string>();

            switch (seccion)
            {
                case 0:
                    break;
                case 1:
                    PermisosSeccion.Add("AgregarPedidos");
                    PermisosSeccion.Add("BuscarProductos");
                    PermisosSeccion.Add("CargarCat");
                    PermisosSeccion.Add("DetallesLista");
                    PermisosSeccion.Add("NuevaLista");
                    PermisosSeccion.Add("AgregarProductos");
                    PermisosSeccion.Add("SolicitarPedido");
                    break;
                case 2:
                    PermisosSeccion.Add("Prestaciones");
                    break;
                case 3:
                    PermisosSeccion.Add("Reportes");
                    break;
                case 4:
                    PermisosSeccion.Add("ABMProductos");
                    PermisosSeccion.Add("ABMProveedores");
                    PermisosSeccion.Add("ABMUsuarios");
                    PermisosSeccion.Add("CargaDatosUsuarios");
                    PermisosSeccion.Add("Grupos");
                    PermisosSeccion.Add("ABMGrupos");
                    PermisosSeccion.Add("ABMPedidosYPrestaciones");
                    PermisosSeccion.Add("Auditoria");
                    PermisosSeccion.Add("Backup");
                    break;
                default:
                    break;
            }

            permiso.MostrarPermisosSegunSeccion(PermisosSeccion);

            List<string> Permisos = new List<string>();

            if (COMUN.Seguridad.Permisos.PermisosPorFormulario == null)
            {
                return Permisos;
            }
            else { 
            foreach (var item in COMUN.Seguridad.Permisos.PermisosPorFormulario)
            {
                Permisos.Add(item.nombre_permiso);
            }
                return Permisos;
        }
            
        }

        public Permisos MostrarPermisosSegunNombre(string permiso_nombre)
        {
            return permiso.MostrarPermisosPorNombre(permiso_nombre);
        }
    }
}
