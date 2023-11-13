using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMUN.Cache
{
    public class CacheEditarUsuario
    {
        public static string nombre { get; set; }
        public static string apellido { get; set; }
        public static string mail { get; set; }
        public static int dni { get; set; }
        public static long cvu { get; set; }
        public static long telefono { get; set; }
        public static string direccion { get; set; }
        public static List<string> grupos { get; set; }
        public static List<string> permisos { get; set; }
        public static List<string> permisosUsuario { get; set; }
        public static List<string> gruposUsuario { get; set; }
        public static List<string> PermisosAgregar { get; set; }
        public static List<string> PermisosQuitar { get; set; }
        public static List<string> GruposAgregar { get; set; }
        public static List<string> GruposQuitar { get; set; }
    }
}
