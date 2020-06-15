using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcaiAPI.Model;
using AcaiAPI.Data;

namespace AcaiAPI.Repository
{
    public class SaborRepository : ISaborRepository
    {
        private readonly ApplicationDbContext _contexto;
        private List<Sabor> _saborList = new List<Sabor>();

        public SaborRepository(ApplicationDbContext ctx)
        {
            _contexto = ctx;

        }
        public void Add(Sabor sabor)
        {
            _contexto.SaveChanges();
        }

        public Sabor Find(short id)
        {
            return _contexto.Sabores.FirstOrDefault(l => l.Id == id);
        }

        public IEnumerable<Sabor> GetAll()
        {
            return _contexto.Sabores.ToList();
        }

        private void PopulateSabores()
        {
            Sabor sabor1 = new Sabor()
            {
                Id = 1,
                Description = "morango",
                TempoAdicional = 0
            };
            _saborList.Add(sabor1);
            Sabor sabor2 = new Sabor()
            {
                Id = 2,
                Description = "banana",
                TempoAdicional = 0
            };
            _saborList.Add(sabor2);
            Sabor sabor3 = new Sabor()
            {
                Id = 3,
                Description = "kiwi",
                TempoAdicional = 300
            };
            _saborList.Add(sabor3);
        }
    }
}
