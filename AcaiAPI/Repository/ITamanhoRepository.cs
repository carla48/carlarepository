using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcaiAPI.Model;

namespace AcaiAPI.Repository
{
    public interface ITamanhoRepository
    {
        void Add(Tamanho tamanho);
        IEnumerable<Tamanho> GetAll();
        Tamanho Find(short id);

        Tamanho FindById(short id);
    }
}
