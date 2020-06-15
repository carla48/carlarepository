using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcaiAPI.Model;

namespace AcaiAPI.Repository
{
    public interface IPersonalizacaoRepository
    {
        void Add(Personalizacao personalizacao);
        IEnumerable<Personalizacao> GetAll();
        Personalizacao Find(short id);

        Personalizacao FindById(short id);
        IEnumerable<Personalizacao> GetPersonalizacoesPelosIds(IList<short> personalizacoes);

        Task<bool> Update(Personalizacao item);
    }
}
