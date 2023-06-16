using System.Linq;
using System;
using System.Collections.Generic;
using QaInDev.Models.Validators;

namespace QaInDev.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public double ValorTotal { get; set; }
        public DateTime DataPedido { get; set; }
        public virtual List<PedidoItem> PedidoItens { get; set; }

        public IEnumerable<string> Validar()
        {
            var validator = new PedidoValidator().Validate(this);
            return validator.Errors.Select(x => x.ErrorMessage);
        }
    }
}