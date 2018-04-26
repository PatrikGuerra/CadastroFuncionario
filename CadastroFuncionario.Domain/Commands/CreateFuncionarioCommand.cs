namespace CadastroFuncionario.Domain.Commands
{
    public class CreateFuncionarioCommand
    {
        public string NomePrimeiro { get; set; }
        public string NomeMeio { get; set; }
        public string NomeUltimo { get; set; }

        public string NumeroDocumento { get; set; }

        public string NumeroTelefone { get; set; }

        public string EnderecoRua { get; set; }
        public string EnderecoBairro { get; set; }
        public string EnderecoNumero { get; set; }
        public string EnderecoCep { get; set; }
        public string EnderecoCidade { get; set; }
        public string EnderecoUf { get; set; }

        public string CargoNome { get; set; }
        public string CargoDescricao { get; set; }
        public decimal CargoSalario { get; set; }
    }
}
