using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace granjita
{
    internal class Cultivo : SerGranja, IProducible // hereda + implementa 
    {
        public Cultivo()
        {
            dias = 2; // tiempo de crecimiento
        }

        public override void PasarDia() // obligatorio por abstract
        {
            dias--; // reduce los días
        }

        public void Producir(List<Venta> ventas) // obligatorio por interfaz
        {
            if (Listo) // si ya creció
            {
                ventas.Add(new Venta(2, 30)); // crea venta
            }
        }
    }
}