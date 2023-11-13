using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMUN
{
    public static class UserLoginCache
    {
        public static int id_usuario { get; set; }
        public static string nombre { get; set; }
        public static  string apellido { get; set; }
        public static string mail { get; set; }
        public static string contra { get; set; }
        public static int dni { get; set; }
        public static long cvu { get; set; }
        public static string direccion { get; set; }
        public static long telefono { get; set; }
        public static List<string> nombre_permisos { get; set; }
        public static List<string> nombre_grupos { get; set; }
        public static string estado { get; set; }
    }
}
