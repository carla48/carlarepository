using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcaiAPI.Model;
using AcaiAPI.Data;

namespace AcaiAPI.Repository
{
    public class PersonalizacaoRepository : IPersonalizacaoRepository
    {
        private readonly ApplicationDbContext _contexto;
        private List<Personalizacao> _personalizacaoList = new List<Personalizacao>();

        public PersonalizacaoRepository(ApplicationDbContext ctx)
        {
            _contexto = ctx;
            PopulatePersonalizacoes();
        }
        public void Add(Personalizacao personalizacao)
        {
            _contexto.Personalizacoes.Add(personalizacao);
            _contexto.SaveChanges();
        }

        public Personalizacao Find(short id)
        {
            return _contexto.Personalizacoes.FirstOrDefault(l => l.Id == id);
        }

        public Personalizacao FindById(short id)
        {
            return _personalizacaoList.FirstOrDefault(s => s.Id == id);
        }

        public IEnumerable<Personalizacao> GetAll()
        {
            return _contexto.Personalizacoes.ToList();
        }

        public async Task<bool> Update(Personalizacao item)
        {
            _contexto.Entry(_contexto.Personalizacoes.FirstOrDefault(x => x.Id == item.Id)).CurrentValues.SetValues(item);
            return (await _contexto.SaveChangesAsync()) > 0;
        }

        
        public IEnumerable<Personalizacao> GetPersonalizacoesPelosIds(IList<short> personalizacoes)
        {
            IList<Personalizacao> personalizacaosSelecionadas = new List<Personalizacao>();
            foreach (short elemento in personalizacoes)
            {
                Personalizacao personalizacaoEncontrada = Find(elemento);
                if (personalizacaoEncontrada != null)
                {
                    personalizacaosSelecionadas.Add(personalizacaoEncontrada);
                }
            }
            return personalizacaosSelecionadas;

        }

        private void PopulatePersonalizacoes()
        {
            Personalizacao personalizacao1 = new Personalizacao()
            {
                Id = 1,
                Description = "granola",
                TempoAdicional = 0,
                ValorAdicional = 0
            };
            _personalizacaoList.Add(personalizacao1);
            Personalizacao personalizacao2 = new Personalizacao()
            {
                Id = 2,
                Description = "paçoca",
                TempoAdicional = 180,
                ValorAdicional = 3
            };
            _personalizacaoList.Add(personalizacao2);
            Personalizacao personalizacao3 = new Personalizacao()
            {
                Id = 3,
                Description = "leite ninho",
                TempoAdicional = 0,
                ValorAdicional = 3
            };
            _personalizacaoList.Add(personalizacao3);
        }
    }
}
