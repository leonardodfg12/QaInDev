using System;
using Bogus;
using Bogus.DataSets;
using FluentAssertions;
using QaInDev.Models;
using Xunit;

namespace QaInDev.Tests.Models
{
    public class ClienteTestsBogus
    {
        [Fact]
        public void EHValid_DeveGerarException_QuandoDadosClientesInvalido()
        {
            var genero = new Faker().PickRandom<Name.Gender>();
            var cliente = new Faker<Cliente>("pt_BR")
            .CustomInstantiator(f => new Cliente(
                f.Name.FirstName(genero).Substring(1, 1),
                f.Name.LastName(genero),
                f.Date.Past(1, DateTime.Now),
                DateTime.Now.AddYears(-4),
                "",
                true))
            .RuleFor(c => c.Email, (f, c) => f.Internet.Email(c.Nome.ToLower(), c.Sobrenome.ToLower()))
            .Generate();

            var ex = Assert.Throws<Exception>(() => cliente.EhValido());

            // Assert.Equal("Dados do Cliente estão invalidos", ex.Message);
            ex.Message.Should().Be("Dados do Cliente estão invalidos");
        }

        [Fact]
        public void NomeCompleto_DeveRetornarNomeConcatenado()
        {

            var faker = new Faker();
            var genero = faker.PickRandom<Name.Gender>();
            var nome = faker.Name.FirstName(genero);
            var sobrenome = faker.Name.LastName(genero);

            var cliente = new Faker<Cliente>("pt_BR")
            .CustomInstantiator(f => new Cliente(
                nome,
                sobrenome,
                f.Date.Past(1, DateTime.Now),
                DateTime.Now.AddYears(-4),
                "",
                true))
            .RuleFor(c => c.Email, (f, c) => f.Internet.Email(c.Nome.ToLower(), c.Sobrenome.ToLower()))
            .Generate();

            // const string nome = "Leonardo";
            // const string sobrenome = "Rodrigues";
            // var cliente = new Cliente("Leonardo", "Rodrigues", DateTime.Now.AddYears(-34), DateTime.Now, "email@email.com", true);
            var nomeCompleto = cliente.NomeCompleto();
            // Assert.Equal($"{nome} {sobrenome}", nomeCompleto);
            nomeCompleto.Should().Be($"{nome} {sobrenome}", nomeCompleto);
        }

        [Fact]
        public void EhEspecial_DeveRetornarFalse_QuandoDataCadastroInferiorA3AnosEAtivo_Bogus()
        {
            var genero = new Faker().PickRandom<Name.Gender>();
            var cliente = new Faker<Cliente>("pt_BR")
            .CustomInstantiator(f => new Cliente(
                f.Name.FirstName(genero).Substring(1, 1),
                f.Name.LastName(genero),
                f.Date.Past(1, DateTime.Now),
                DateTime.Now.AddYears(-5),
                "",
                true))
            .RuleFor(c => c.Email, (f, c) => f.Internet.Email(c.Nome.ToLower(), c.Sobrenome.ToLower()))
            .Generate();
            var especial = cliente.EhEspecial();

            // Assert.True(especial);
            especial.Should().BeTrue();
        }
    }
}