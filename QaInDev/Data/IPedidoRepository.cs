using System.Collections.Generic;
using QaInDev.Models;

namespace QaInDev.Data
{
    public interface IPedidoRepository
    {
        void Inserir(Pedido pedido);
        IEnumerable<Pedido> ObterTodos();
        Pedido ObterPorId(int id);
        void Atualizar(Pedido pedido);
        void Deletar(Pedido pedido);
        IEnumerable<Pedido> ObterPorCliente(int clienteId);
    }
}