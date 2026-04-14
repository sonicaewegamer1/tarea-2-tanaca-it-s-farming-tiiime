using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace granjita
{
    internal interface IProducible
    {
        void Producir(List<Venta> ventas);
        // método sin cuerpo (sin { })
        // obliga a que quien implemente esto cree ventas
    }
}