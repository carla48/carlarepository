using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcaiAPI.Model;

namespace AcaiAPI.Repository
{
    public interface IPedidoRepository
    {
        long Add(Pedido pedido);
        IEnumerable<Pedido> GetAll();
        Pedido Find(long id);
    }
}
