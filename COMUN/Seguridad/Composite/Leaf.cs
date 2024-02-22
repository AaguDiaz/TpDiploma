using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMUN.Seguridad.Composite
{
    public class Leaf : Component
    {
        public Leaf(string Nombre) : base(Nombre)
        {
        }

        public string ObtenerNombre()
        {
            return Nombre;
        }

        public override List<Component> ObtenerHijos()
        {
            throw new Exception("No se puede obtener hijos de una leaf");
        }
    }
}
