﻿using AcaiAPI.Model;
using AcaiAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcaiAPI.Controllers
{
    [ApiController]
    [Route("api/pedido")]
    public class PedidoController : Controller
    {
        private readonly ISaborRepository _saborRepository;
        private readonly ITamanhoRepository _tamanhoRepository;
        private readonly IPersonalizacaoRepository _personalizacaoRepository;
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IPedidoPersonalizacaoRepository _pedidoPersonalizacaoRepository;

        public PedidoController(ISaborRepository saborRepository,
                                ITamanhoRepository tamanhoRepository,
                                IPersonalizacaoRepository personalizacaoRepository,
                                IPedidoRepository pedidoRepository,
                                IPedidoPersonalizacaoRepository pedidoPersonalizacaoRepository)
        {
            _saborRepository = saborRepository;
            _tamanhoRepository = tamanhoRepository;
            _personalizacaoRepository = personalizacaoRepository;
            _pedidoRepository = pedidoRepository;
            _pedidoPersonalizacaoRepository = pedidoPersonalizacaoRepository;

        }

        // POST api/pedido
        [HttpPost]

        public void Post([FromBody] PedidoCreateRequestModel value) // RequestModel 
        {
            Pedido pedido = new Pedido();

            pedido.Sabor = _saborRepository.Find(value.Sabor);
            pedido.SaborId = pedido.Sabor.Id;
            pedido.Tamanho = _tamanhoRepository.Find(value.Tamanho);
            pedido.TamanhoId = pedido.Tamanho.Id;
            
            List<Personalizacao> personalizacoes = _personalizacaoRepository.GetPersonalizacoesPelosIds(value.Personalizacoes).ToList();
            
            if (personalizacoes != null && personalizacoes.Count > 0)
            {
                foreach(Personalizacao item in personalizacoes)
                {
                    PedidoPersonalizacao pedidoPersonalizacao = new PedidoPersonalizacao();
                    pedidoPersonalizacao.Personalizacao = new Personalizacao()
                    {
                        Id = item.Id,
                        Description = item.Description,
                        TempoAdicional = item.TempoAdicional,
                        ValorAdicional = item.ValorAdicional
                    };
                    pedidoPersonalizacao.Pedido = pedido;
                    pedidoPersonalizacao.Personalizacao.Pedidos.Add(pedidoPersonalizacao);
                    pedidoPersonalizacao.Pedido.Personalizacoes.Add(pedidoPersonalizacao);
                    _pedidoPersonalizacaoRepository.Add(pedidoPersonalizacao);
                    pedido.Personalizacoes.Add(pedidoPersonalizacao);
                }
            }
            pedido.TempoPreparo = GetTempoPreparo(pedido, personalizacoes);
            pedido.ValorTotal = GetValorTotal(pedido, personalizacoes);
            _pedidoRepository.Add(pedido); // Insertion
            
        }

        [HttpGet]
        public ActionResult<IEnumerable<VisualizarPedidoModel>> Get()
        {
            IList<Pedido> todosPedidos = _pedidoRepository.GetAll().ToList();
            IList<VisualizarPedidoModel> pedidosVisualizados = new List<VisualizarPedidoModel>();
            if (todosPedidos != null && todosPedidos.Count > 0)
            {
                foreach (Pedido pedidoGravado in todosPedidos)
                {
                    pedidosVisualizados.Add(GetPedidoVisualizado(pedidoGravado));
                }
            }
            
                return pedidosVisualizados.ToList();
            
        }

        [HttpGet("{id}")]

        public ActionResult<VisualizarPedidoModel> Get(long id)
        {

            Pedido result = _pedidoRepository.Find(id);
            if (result == null)
            {
                return NotFound();
            }
            else
            {
                return new ObjectResult(GetPedidoVisualizado(result));
            }
        }

        private long GetTempoPreparo(Pedido pedido, List<Personalizacao> personalizacaos)
        {
            long tempoPreparo = 0;
            if (pedido != null && pedido.Tamanho != null)
            {
                tempoPreparo += pedido.Tamanho.TempoPreparo;
            }
            if (pedido != null && pedido.Sabor != null)
            {
                tempoPreparo += pedido.Sabor.TempoAdicional;
            }
            if (pedido.Personalizacoes != null && pedido.Personalizacoes.Count > 0)
            {
                foreach (Personalizacao p in personalizacaos)
                {
                    tempoPreparo += p.TempoAdicional;
                }
            }
            return tempoPreparo;
        }

        private decimal GetValorTotal(Pedido pedido, List<Personalizacao> personalizacaos)
        {
            decimal valorTotal = 0;
            if (pedido != null && pedido.Tamanho != null)
            {
                valorTotal += pedido.Tamanho.Valor;
            }
            if (pedido.Personalizacoes != null && pedido.Personalizacoes.Count > 0)
            {
                foreach (Personalizacao p in personalizacaos)
                {
                    valorTotal += p.ValorAdicional;
                }
            }
            return valorTotal;
        }

        private VisualizarPedidoModel GetPedidoVisualizado(Pedido pedidoGravado)
        {
            VisualizarPedidoModel result = new VisualizarPedidoModel();
            pedidoGravado.Tamanho = _tamanhoRepository.Find(pedidoGravado.TamanhoId);
            result.Id = pedidoGravado.Id;
            result.Tamanho = pedidoGravado.Tamanho != null ? pedidoGravado.Tamanho.Description : "";
            pedidoGravado.Sabor = _saborRepository.Find(pedidoGravado.SaborId);
            result.Sabor = pedidoGravado.Sabor != null ? pedidoGravado.Sabor.Description : "";
            result.Preco = "00.00";
            if (pedidoGravado.Tamanho != null)
            {
                decimal valorFormatado = Math.Truncate(pedidoGravado.Tamanho.Valor * 100) / 100;
                result.Preco = string.Format("{0:N2}%", valorFormatado);
            }
            result.Personalizacoes = new List<PersonalizacaoModel>();
            IList<Personalizacao> personalizacoes = _pedidoPersonalizacaoRepository.GetPersonalizacoesPeloPedido(pedidoGravado.Id);
            if (personalizacoes != null && personalizacoes.Count > 0)
            {
                foreach (Personalizacao item in personalizacoes)
                {
                    PersonalizacaoModel personalizacaoModel = new PersonalizacaoModel();
                    personalizacaoModel.Descricao = item.Description;
                    decimal valorAdicionalFormatado = Math.Truncate(item.ValorAdicional * 100) / 100;
                    personalizacaoModel.Preco = string.Format("R$ {0:N2}", valorAdicionalFormatado);
                    result.Personalizacoes.Add(personalizacaoModel);
                }
            }

            result.TempoPreparo = string.Format("{0:D2} minutos",
                        pedidoGravado.TempoPreparo);
            decimal valorTotalFormatado = Math.Truncate(pedidoGravado.ValorTotal * 100) / 100;
            result.ValorTotal = string.Format("R${0:N2}", valorTotalFormatado);
            return result;
        }
    }
}
