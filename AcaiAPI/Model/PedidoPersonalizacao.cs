using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcaiAPI.Model
{
    public class PedidoPersonalizacao
    {
        public long PedidoId { get; set; }
        public Pedido Pedido { get; set; }
        public short PersonalizacaoId { get; set; }
        public Personalizacao Personalizacao { get; set; }
    }
}
