using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcaiAPI.Model;
using AcaiAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace AcaiAPI.Repository
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly ApplicationDbContext _contexto;

        public PedidoRepository(ApplicationDbContext ctx)
        {
            _contexto = ctx;

        }
        public long Add(Pedido pedido)
        {
            //_contexto.Sabores.Add(pedido.Sabor);
            //_contexto.Tamanhos.Add(pedido.Tamanho);
            
            _contexto.Pedidos.Add(pedido);
            
            _contexto.SaveChanges();

            return pedido.Id;

        }

        public void AddPersonalizacao(Pedido pedido)
        {
            /*if (pedido.Personalizacoes != null && pedido.Personalizacoes.Count > 0)
            {
                foreach (PedidoPersonalizacao personalizacao in pedido.Personalizacoes)
                {
                    _contexto.PedidoPersonalizacoes.Add(personalizacao);
                    //_contexto.Personalizacoes.Add(personalizacao);
                    //_contexto.SaveChanges();
                }
            }*/
            //_contexto.Update(pedido);
            _contexto.Entry(pedido).State = EntityState.Modified;
            _contexto.SaveChanges();
        }

        public void AddPersonalizacoesPedido(Pedido pedido)
        {
            if (pedido.Personalizacoes != null && pedido.Personalizacoes.Count > 0)
            {
                foreach (PedidoPersonalizacao personalizacao in pedido.Personalizacoes)
                {
                    _contexto.PedidoPersonalizacoes.Add(personalizacao);
                    //_contexto.Personalizacoes.Add(personalizacao);
                }
            }
            _contexto.SaveChanges();
        }

        public Pedido Find(long id)
        {
            return _contexto.Pedidos.FirstOrDefault(l => l.Id == id);
        }

        public IEnumerable<Pedido> GetAll()
        {
            return _contexto.Pedidos.ToList();
        }


    }
}
