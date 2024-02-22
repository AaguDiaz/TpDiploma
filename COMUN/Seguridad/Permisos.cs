using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMUN.Seguridad
{
    public class Permisos
    {
        public int id_permiso { get; set; }
        public string nombre_permiso { get; set; }
        public Formularios formulario { get; set; }
        public List<Modulos> modulos { get; set; }

        public static List<Permisos> PermisosPorFormulario{ get; set; }


    }
}
