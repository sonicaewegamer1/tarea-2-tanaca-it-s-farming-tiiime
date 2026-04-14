using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace granjita
{
    internal class Venta
    {
        public int Dias { get; set; }
        public int Ganancia { get; set; }

        public bool Listo => Dias <= 0;

        public Venta(int dias, int ganancia)
        {
            Dias = dias;
            Ganancia = ganancia;
        }

        public void PasarDia()
        {
            Dias--;
        }
    }
}