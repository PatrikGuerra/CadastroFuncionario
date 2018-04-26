using CadastroFuncionario.Domain.ValueObjects;
using CadastroFuncionario.Shared.Entities;

namespace CadastroFuncionario.Domain.Entities
{
    public class Funcionario : Entity
    {
        private Funcionario() { }

        public Funcionario(Nome nome, Documento documento, Telefone telefone, Endereco endereco, Cargo cargo)
        {
            Nome = nome;
            Documento = documento;
            Telefone = telefone;
            Endereco = endereco;
            Cargo = cargo;

            AddNotifications(Nome, Documento, Telefone, Endereco, Cargo);
        }

        public void Update(Nome nome, Documento documento, Telefone telefone, Endereco endereco, Cargo cargo)
        {
            Nome = nome;
            Documento = documento;
            Telefone = telefone;
            Endereco = endereco;
            Cargo = cargo;

            AddNotifications(Nome, Documento, Telefone, Endereco, Cargo);
        }

        public Nome Nome { get; private set; }
        public Documento Documento { get; private set; }
        public Telefone Telefone { get; private set; }
        public Endereco Endereco { get; private set; }
        public Cargo Cargo { get; private set; }
    }
}
