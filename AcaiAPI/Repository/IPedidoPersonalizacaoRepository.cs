using AcaiAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcaiAPI.Repository
{
    public interface IPedidoPersonalizacaoRepository
    {
        void Add(PedidoPersonalizacao pedidoPersonalizacao);

        List<Personalizacao> GetPersonalizacoesPeloPedido(long pedidoId);
    }
}
