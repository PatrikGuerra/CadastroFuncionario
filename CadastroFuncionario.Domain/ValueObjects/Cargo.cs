using Flunt.Validations;

namespace CadastroFuncionario.Domain.ValueObjects
{
    public class Cargo : Shared.ValueObjects.ValueObjects
    {
        private Cargo() { }

        public Cargo(string nome, string descricao, decimal salario)
        {
            Nome = nome;
            Descricao = descricao;
            Salario = salario;

            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(Nome, "FuncionarioCargo.Nome", "O Cargo deve ser informado.")
                .HasMaxLen(Nome, 40, "FuncionarioCargo.Nome", "O Cargo deve conter no máximo 40 caracteres.")

                .IsNotNullOrEmpty(Descricao, "FuncionarioCargo.Descricao", "A Descrição do Cargo deve ser informado.")
                .HasMaxLen(Descricao, 40, "FuncionarioCargo.Descricao", "A Descrição do Cargo deve conter no máximo 40 caracteres.")
                
                .IsGreaterThan(Salario, 0, "FuncionarioCargo.Salario", "O Salário deve ser informado.")
            );
        }

        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public decimal Salario { get; private set; }
    }
}
