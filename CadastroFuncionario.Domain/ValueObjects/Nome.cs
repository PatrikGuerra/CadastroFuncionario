using Flunt.Validations;

namespace CadastroFuncionario.Domain.ValueObjects
{
    public class Nome : Shared.ValueObjects.ValueObjects
    {
        private Nome() { }

        public Nome(string primeiroNome, string meioNome, string ultimoNome)
        {
            PrimeiroNome = primeiroNome;
            MeioNome = meioNome;
            UltimoNome = ultimoNome;

            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(PrimeiroNome, 3, "Nome.PrimeiroNome", "Nome deve conter ao menos 3 caracteres.")
                .HasMaxLen(PrimeiroNome, 40, "Nome.PrimeiroNome", "Nome deve conter no máximo 40 caracteres.")

                .HasMaxLen(MeioNome, 40, "Nome.MeioNome", "Nome do Meio deve conter no máximo 40 caracteres.")

                .HasMinLen(UltimoNome, 3, "Nome.UltimoNome", "Sobrenome deve conter ao menos 3 caracteres.")
                .HasMaxLen(UltimoNome, 40, "Nome.UltimoNome", "Sobrenome deve conter no máximo 40 caracteres.")
            );
        }

        public string PrimeiroNome { get; private set; }
        public string MeioNome { get; private set; }
        public string UltimoNome { get; private set; }

        public override string ToString()
        {
            string nomecompleto = PrimeiroNome;

            if (!string.IsNullOrEmpty(MeioNome))
            {
                nomecompleto += " " + MeioNome;
            }

            nomecompleto += " " + UltimoNome;

            return nomecompleto;
        }
    }
}
