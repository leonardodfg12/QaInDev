using System;
using FluentValidation;

namespace QaInDev.Models.Validators
{
    public class PedidoValidator : AbstractValidator<Pedido>
    {
        public PedidoValidator()
        {
            RuleFor(x => x.ClientId).GreaterThan(0).WithMessage("Cliente não informado");
            RuleFor(x => x.DataPedido).LessThanOrEqualTo(DateTime.Now).WithMessage("Data do pedido deve ser inferior a data atual");
            RuleFor(x => x.ValorTotal).GreaterThan(0).WithMessage("Valor total do pedido não informado");
            RuleFor(x => x.PedidoItens).NotNull().WithMessage("Não foi informado nehum item do pedido");
        }
    }
}