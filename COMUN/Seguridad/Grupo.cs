using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMUN.Seguridad
{
    public class Grupo
    {
        public int id_grupo { get; set; }
        public string nombre_grupo { get; set; }
        public string descripcion_grupo { get; set; }
        public List<Permisos> permisos { get; set; }


    }
}
