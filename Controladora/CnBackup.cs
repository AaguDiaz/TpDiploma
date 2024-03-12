using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;

namespace Controladora
{
    public class CnBackup
    {
        MoBackup backup = new MoBackup();

        public string GenerarBackup()
        {
            return backup.GenerarBackup();
        }


        public string RestaurarBackup(string ruta)
        {
            return backup.RestaurarBackup(ruta);
        }

    }
}
