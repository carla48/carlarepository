using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcaiAPI.Model;
using AcaiAPI.Data;

namespace AcaiAPI.Repository
{
    public class TamanhoRepository : ITamanhoRepository
    {
        private readonly ApplicationDbContext _contexto;
        private List<Tamanho> _tamanhoList = new List<Tamanho>();

        public TamanhoRepository(ApplicationDbContext ctx)
        {
            _contexto = ctx;
            PopulateTamanhos();
        }
        public void Add(Tamanho tamanho)
        {
            _contexto.Tamanhos.Add(tamanho);
            _contexto.SaveChanges();
        }

        public Tamanho Find(short id)
        {
            return _contexto.Tamanhos.FirstOrDefault(l => l.Id == id);
        }

        public Tamanho FindById(short id)
        {
            return _tamanhoList.FirstOrDefault(s => s.Id == id);
        }

        public IEnumerable<Tamanho> GetAll()
        {
            return _contexto.Tamanhos.ToList();
        }

        private void PopulateTamanhos()
        {
            Tamanho tamanho1 = new Tamanho()
            {
                Id = 1,
                Description = "pequeno (300ml)",
                TempoPreparo = 300,
                Valor = 10
            };
            _tamanhoList.Add(tamanho1);
            Tamanho tamanho2 = new Tamanho()
            {
                Id = 2,
                Description = "médio (500ml)",
                TempoPreparo = 420,
                Valor = 13
            };
            _tamanhoList.Add(tamanho2);
            Tamanho tamanho3 = new Tamanho()
            {
                Id = 3,
                Description = "grande (700ml)",
                TempoPreparo = 600,
                Valor = 15
            };
            _tamanhoList.Add(tamanho3);
        }
    }
}
