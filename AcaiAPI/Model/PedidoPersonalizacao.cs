using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AcaiAPI.Model
{
    public class PedidoPersonalizacao
    {
        [Key]
        public long PedidoId { get; set; }
        public Pedido Pedido { get; set; }

        [Key]
        public short PersonalizacaoId { get; set; }
        public Personalizacao Personalizacao { get; set; }
    }
}
