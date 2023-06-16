using System.Collections.Generic;
using System.Linq;
using QaInDev.Data.Configs;
using QaInDev.Models;

namespace QaInDev.Data
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly QAInDevContext _context;
        public PedidoRepository(QAInDevContext context)
        {
            _context = context;
        }
        public void Atualizar(Pedido pedido)
        {
            _context.Pedidos.Update(pedido);
            _context.SaveChanges();
        }

        public void Deletar(Pedido pedido)
        {
            _context.Pedidos.Remove(pedido);
            _context.SaveChanges();
        }

        public void Inserir(Pedido pedido)
        {
            _context.Pedidos.Add(pedido);
            _context.SaveChanges();
        }

        public Pedido ObterPorId(int id)
        {
            return _context.Pedidos.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Pedido> ObterTodos()
        {
            return _context.Pedidos.ToList();
        }
       
 
        public IEnumerable<Pedido> ObterPorCliente(int clienteId)
        {
            return _context.Pedidos.Where(x => x.ClientId == clienteId).ToList();
        }
    }
}