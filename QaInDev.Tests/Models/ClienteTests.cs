using System;
using FluentAssertions;
using QaInDev.Models;
using Xunit;

namespace QaInDev.Tests.Models
{
    public class ClienteTests
    {
        [Fact]
        public void EHValid_DeveGerarException_QuandoDadosClientesInvalido()
        {
            var cliente = new Cliente("L", "Rodrigues", DateTime.Now, DateTime.Now, "email@email.com", true);
            var ex = Assert.Throws<Exception>(() => cliente.EhValido());

            // Assert.Equal("Dados do Cliente estão invalidos", ex.Message);
            ex.Message.Should().Be("Dados do Cliente estão invalidos");
        }

        [Fact]
        public void NomeCompleto_DeveRetornarNomeConcatenado()
        {
            const string nome = "Leonardo";
            const string sobrenome = "Rodrigues";
            var cliente = new Cliente("Leonardo", "Rodrigues", DateTime.Now.AddYears(-34), DateTime.Now, "email@email.com", true);
            var nomeCompleto = cliente.NomeCompleto();

            // Assert.Equal($"{nome} {sobrenome}", nomeCompleto);
            nomeCompleto.Should().Be($"{nome} {sobrenome}", nomeCompleto);
        }

        [Fact]
        public void EhEspecial_DeveRetornarFalse_QuandoDataCadastroInferiorA3AnosEAtivo()
        {
            var cliente = new Cliente("Leonardo", "Rodrigues", DateTime.Now.AddYears(-34), DateTime.Now.AddYears(-5), "email@email.com", true);
            var especial = cliente.EhEspecial();

            // Assert.True(especial);
            especial.Should().BeTrue();
        }
    }
}