using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMUN.Cache
{
    public class GrupoFamiliar
    {
        public int IdGrupoFamiliar { get; set; }
        public string nombreCompleto { get; set; }
        public int dni { get; set; }
        public DateTime fecha_nacimiento { get; set; }
        public string parentesco { get; set; }
    }
}
