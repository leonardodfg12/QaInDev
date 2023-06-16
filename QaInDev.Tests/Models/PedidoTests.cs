using System;
using System.Linq;
using QaInDev.Models;
using Xunit;

namespace QaInDev.Tests.Models
{
    public class PedidoTests
    {
        [Fact]
        public void Validar_DeveAdicionarErros_QuandoPedidoInvalido()
        {
            var pedido = new Pedido();
            var validacoes = pedido.Validar();

            Assert.True(validacoes.Any());
            Assert.Contains("Cliente não informado", validacoes.Select(x => x));
            Assert.Contains("Valor total do pedido não informado", validacoes.Select(x => x));
            Assert.Contains("Não foi informado nehum item do pedido", validacoes.Select(x => x));
        }

        [Fact]
        public void Validar_DeveAdicionarErros_QuandoPedidoSuperiorDataAtual()
        {
            var pedido = new Pedido()
            {
                DataPedido = DateTime.Now.AddDays(5)
            };
            var validacoes = pedido.Validar();
            Assert.True(validacoes.Any());
            Assert.Contains("Data do pedido deve ser inferior a data atual", validacoes.Select(x => x));
        }

        [Fact]
        public void Validar_NaoDeveAdicionarErro_QuandoPedidoValido()
        {
            var pedido = new Pedido()
            {
                ClientId = 1,
                DataPedido = DateTime.Now.AddDays(-1),
                ValorTotal = 200,
                PedidoItens = new System.Collections.Generic.List<PedidoItem>()
                {
                    new PedidoItem()
                    {
                        ProdutoNome = "Produto teste",
                        Quantidade = 50,
                        ValorUnitario = 150
                    }
                }
            };
            var validacoes = pedido.Validar();
            Assert.Empty(validacoes);
        }
    }
}