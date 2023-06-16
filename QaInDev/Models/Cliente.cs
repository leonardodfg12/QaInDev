using System;
using QaInDev.Models.Validators;

namespace QaInDev.Models
{
    public class Cliente
    {
        public string Nome { get; private set; }
        public string Sobrenome { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public string Email { get; private set; }
        public bool Ativo { get; private set; }

        public Cliente(string nome, string sobrenome, DateTime dataNascimento, DateTime dataCadastro, string email, bool ativo)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            DataNascimento = dataNascimento;
            DataCadastro = dataCadastro;
            Email = email;
            Ativo = ativo;

        }

        public string NomeCompleto()
        {
            return $"{Nome} {Sobrenome}";
        }

        public bool EhEspecial()
        {
            return DataCadastro < DateTime.Now.AddYears(-3)  &&  Ativo;
        }

        public void Inativar()
        {
            Ativo = false;
        }

        public void EhValido()
        {
            var validationResult = new ClienteValidacao().Validate(this);
            if (validationResult.IsValid) return;
            throw new Exception("Dados do Cliente estão invalidos");
        }
    }
}