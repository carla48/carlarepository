using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcaiAPI.Model
{
    public class PedidoCreateRequestModel
    {
        public short Sabor { get; set; }
        public short Tamanho { get; set; }
        public IList<short> Personalizacoes { get; set; }
    }
}
