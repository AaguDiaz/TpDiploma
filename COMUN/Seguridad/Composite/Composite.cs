using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMUN.Seguridad.Composite
{
    public class Composite : Component
    {
        private List<Component> hijos = new List<Component>();
        public string descripcion_grupo { get; set; }

        public Composite(string Nombre, string descripcion_grupo) : base(Nombre)
        {
            this.descripcion_grupo = descripcion_grupo;
        }

        public string ObtenerNombre()
        {
            return Nombre;
        }

        public override void Agregar(Component c)
        {
            hijos.Add(c);
        }

        public override void Remover(Component c)
        {
            hijos.Remove(c);
        }

        public override List<Component> ObtenerHijos()
        {
            return hijos;
        }
    }
    
}

