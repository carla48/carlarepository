using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcaiAPI.Model
{
    public class VisualizarPedidoModel
    {
        public long Id { get; set; }
        public string Tamanho { get; set; }

        public string Sabor { get; set; }

        public string Preco { get; set; }

        public IList<PersonalizacaoModel> Personalizacoes { get; set; }

        public string ValorTotal { get; set; }

        public string TempoPreparo { get; set; }

    }
}
