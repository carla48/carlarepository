using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AcaiAPI.Model
{
    public class Pedido
    {
        public Pedido()
        {
            //this.Personalizacoes = new HashSet<Personalizacao>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public Sabor Sabor { get; set; }

        public short SaborId { get; set; }
        public Tamanho Tamanho { get; set; }

        public short TamanhoId { get; set; }

        public List<PedidoPersonalizacao> Personalizacoes { get; set; }

        public decimal ValorTotal { get; set; }

        public long TempoPreparo { get; set; }

        
    }
}
