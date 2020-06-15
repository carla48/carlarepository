using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcaiAPI.Model
{
    public class Sabor : Generico
    {
        public long TempoAdicional { get; set; }
        public Pedido Pedido { get; set; }
    }
}
