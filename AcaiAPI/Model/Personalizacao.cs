using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcaiAPI.Model
{
    public class Personalizacao : Generico
    {
        public Personalizacao()
        {
           
        }
        public decimal ValorAdicional { get; set; }

        public long TempoAdicional { get; set; }

        public IList<PedidoPersonalizacao> Pedidos { get; set; }

        
    }
}
