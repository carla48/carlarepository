using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcaiAPI.Model;

namespace AcaiAPI.Repository
{
    public interface ISaborRepository
    {
        void Add(Sabor sabor);
        IEnumerable<Sabor> GetAll();
        Sabor Find(short id);

        //Sabor FindById(short id);
    }
}
