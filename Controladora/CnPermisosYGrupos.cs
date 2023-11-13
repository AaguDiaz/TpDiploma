using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using COMUN.Cache;

namespace Controladora
{
    public class CnPermisosYGrupos
    {
        MoPermisosYGrupos moPermisosYGrupos = new MoPermisosYGrupos();
        public DataTable MostrarPermisos()
        {
            return moPermisosYGrupos.MostrarPermisos();
        }
        public DataTable MostrarGrupos()
        {
            return moPermisosYGrupos.MostrarGrupos();
        }   
    }
}
