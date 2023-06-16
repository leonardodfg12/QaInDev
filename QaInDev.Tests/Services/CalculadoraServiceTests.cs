using QaInDev.Services;
using Xunit;

namespace QaInDev.Tests.Services
{
    public class CalculadoraServiceTests
    {
        [Theory]
        [InlineData(2, 2, 4)]
        [InlineData(1, 1, 2)]
        [InlineData(4, 4, 8)]
        [InlineData(4, 6, 10)]
        [InlineData(4, 1, 5)]
        [InlineData(3, 3, 6)]
        public void Somar_DeveRetornarValorValido(decimal numero1, decimal numero2, decimal resultado)
        {
            var soma = CalculadoraService.Somar(numero1, numero2);
            Assert.Equal(resultado, soma);
        }
    }
}