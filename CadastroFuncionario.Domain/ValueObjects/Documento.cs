using Flunt.Br.Validation;
using Flunt.Validations;

namespace CadastroFuncionario.Domain.ValueObjects
{
    public class Documento : Shared.ValueObjects.ValueObjects
    {
        private Documento() { }

        public Documento(string numero)
        {
            Numero = numero;

            AddNotifications(new Contract()
                .Requires()
                .IsCpf(Numero, "Documento.Numero", "CPF inválido.")
            );
            
        }

        public string Numero { get; private set; }
    }
}
