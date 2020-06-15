using AcaiAPI.Data;
using AcaiAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcaiAPI.Repository
{
    public class PedidoPersonalizacaoRepository : IPedidoPersonalizacaoRepository
    {
        private readonly ApplicationDbContext _contexto;

        public PedidoPersonalizacaoRepository(ApplicationDbContext ctx)
        {
            _contexto = ctx;

        }
        public void Add(PedidoPersonalizacao pedidoPersonalizacao)
        {
            _contexto.PedidoPersonalizacoes.Add(pedidoPersonalizacao);
        }

        public List<Personalizacao> GetPersonalizacoesPeloPedido(long pedidoId)
        {
            return _contexto.PedidoPersonalizacoes
                .Where(x => x.PedidoId == pedidoId)
                .Select(o => new Personalizacao
                {
                    Description = o.Personalizacao.Description,
                    Id = o.Personalizacao.Id,
                    TempoAdicional = o.Personalizacao.TempoAdicional,
                    ValorAdicional = o.Personalizacao.ValorAdicional

                }).ToList();
                        
        }
    }
}
