using Flunt.Validations;
using Flunt.Br.Validation;

namespace CadastroFuncionario.Domain.ValueObjects
{
    public  class Telefone : Shared.ValueObjects.ValueObjects
    {
        private Telefone() { }

        public Telefone(string numero)
        {
            Numero = numero;

            AddNotifications(new Contract()
                .Requires()
                .IsCellPhone(Numero, "Telefone.Numero", "O Telefone deve ser válido")
            );
        }

        public string Numero { get; private set; }
    }
}
