using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcaiAPI.Model
{
    public class Tamanho : Generico
    {
        public decimal Valor { get; set; }

        public long TempoPreparo { get; set; }

        public virtual Pedido Pedido { get; set; }
    }
}
