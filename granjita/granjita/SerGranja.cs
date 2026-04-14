using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace granjita
{
    internal abstract class SerGranja // abstract = no se puede usar directamente
    {
        protected int dias; // accesible en hijos (Cultivo, Animal)

        public bool Listo
        {
            get
            {
                return dias <= 0;
            }
        }

        public abstract void PasarDia();
        // obliga a que cada hijo implemente su forma de pasar el día
    }
}