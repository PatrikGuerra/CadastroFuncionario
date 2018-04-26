using Flunt.Br.Validation;
using Flunt.Validations;

namespace CadastroFuncionario.Domain.ValueObjects
{
    public class Endereco : Shared.ValueObjects.ValueObjects
    {
        private Endereco() { }

        public Endereco(string rua, string bairro, string numero, string cep, string cidade, string uf)
        {
            Rua = rua;
            Bairro = bairro;
            Numero = numero;
            Cep = cep;
            Cidade = cidade;
            Uf = uf;

            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(Rua, 3, "Endereco.Rua", "Rua deve conter ao menos 3 caracteres.")
                .HasMaxLen(Rua, 40, "Endereco.Rua", "Rua deve conter no máximo 40 caracteres.")
              
                .HasMinLen(Bairro, 3, "Endereco.Bairro", "Bairro deve conter ao menos 3 caracteres.")
                .HasMaxLen(Bairro, 40, "Endereco.Bairro", "Bairro deve conter no máximo 40 caracteres.")
              
                .HasMaxLen(Numero, 10, "Endereco.Numero", "Número deve conter no máximo 10 caracteres.")
                
                .IsCep(Cep, "Endereco.Cep", "CEP inválido.")
                
                .HasMinLen(Cidade, 3, "Endereco.Cidade", "Cidade deve conter ao menos 3 caracteres.")
                .HasMaxLen(Cidade, 40, "Endereco.Cidade", "Cidade deve conter no máximo 40 caracteres.")
               
                .HasLen(Uf, 2, "Endereco.Uf", "UF deve conter 2 caracteres.")
            );
        }

        public string Rua { get; private set; }
        public string Bairro { get; private set; }
        public string Numero { get; private set; }
        public string Cep { get; private set; }
        public string Cidade { get; private set; }
        public string Uf { get; private set; }
    }
}
