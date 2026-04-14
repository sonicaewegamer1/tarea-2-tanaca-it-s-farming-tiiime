using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace granjita
{
    internal class Animal : SerGranja, IProducible
    {
        public Animal()
        {
            dias = 3; // tiempo para producir
        }

        public override void PasarDia()
        {
            dias--; // pasa el tiempo
        }

        public void Producir(List<Venta> ventas)
        {
            if (Listo) // si está listo
            {
                ventas.Add(new Venta(3, 40)); // genera venta
                Reset(); // reinicia ciclo
            }
        }

        public void Reset()
        {
            dias = 3; // vuelve a empezar
        }
    }
}