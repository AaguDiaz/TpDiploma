using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using COMUN.Seguridad.Composite;
using COMUN.Seguridad;

namespace Controladora
{
    public class CnGrupos
    {
        MoGrupos moGrupos = new MoGrupos();
        
        public DataTable MostrarGrupos()
        {
            return moGrupos.MostrarGrupos();
        }   

        public bool AgregarGrupo(Composite grupo)
        {
            if(moGrupos.AgregarGrupo(grupo)==true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool EditarGrupo(Composite grupo, int id_grupo)
        {
            if (moGrupos.EditarGrupo(grupo, id_grupo) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public Grupo MostrarGrupoSegunNombre(string nombre)
        {
            return moGrupos.MostrarGrupoSegunNombre(nombre);
        }

        public DataTable MostrarGruposFiltro(int filtro, int currentPage)

        {
            if (filtro == 1)
            {
                return moGrupos.MostrarTodosGrupos(currentPage);
            }
            else if (filtro == 2)
            {
                return moGrupos.MostrarGruposAlta(currentPage);
            }
            else if (filtro == 3)
            {
                return moGrupos.MostrarGruposBaja(currentPage);
            }
            else
            {
                return null;
            }
        }

        public bool CambiarEstadoGrupo(string nombre, int estado)
        {
            if (estado == 4)
            {
                moGrupos.DardeAltaGrupo(nombre);
                return true;
            }
            else if (estado == 5)
            {
                moGrupos.DardeBajaGrupo(nombre);
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
