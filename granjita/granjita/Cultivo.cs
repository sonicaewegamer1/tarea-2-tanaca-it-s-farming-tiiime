using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace granjita
{
    internal class Cultivo
    {
        int dias;

        public bool Listo => dias <= 0;

        public Cultivo()
        {
            dias = 2;
        }

        public void PasarDia()
        {
            dias--;
        }
    }
}