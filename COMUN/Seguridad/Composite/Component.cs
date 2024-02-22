using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMUN.Seguridad.Composite
{
    public abstract class Component
    {
        protected string Nombre { get; set; }

        public Component(string Nombre)
        {
            this.Nombre = Nombre;
        }

        public virtual void Agregar(Component c)
        {
            throw new NotImplementedException();
        }

        public virtual void Remover(Component c)
        {
            throw new NotImplementedException();
        }

        public abstract List<Component> ObtenerHijos();
        
    }
}

