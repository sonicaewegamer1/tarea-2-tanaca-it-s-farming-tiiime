using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace granjita
{
    internal class Animal
    {
        int dias;

        public bool Listo => dias <= 0;

        public Animal()
        {
            dias = 3;
        }

        public void PasarDia()
        {
            dias--;
        }

        public void Reset()
        {
            dias = 3;
        }
    }
}