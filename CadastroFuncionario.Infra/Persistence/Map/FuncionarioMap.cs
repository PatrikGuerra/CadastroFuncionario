using System.Data.Entity.ModelConfiguration;
using CadastroFuncionario.Domain.Entities;

namespace CadastroFuncionario.Infra.Persistence.Map
{
    public class FuncionarioMap : EntityTypeConfiguration<Funcionario>
    {
        public FuncionarioMap()
        {
            ToTable("Funcionario");

            HasKey(x => x.Id);

            //Nome
            Property(x => x.Nome.PrimeiroNome)
                .IsRequired()
                .HasMaxLength(40);

            Property(x => x.Nome.MeioNome)
                .HasMaxLength(40);

            Property(x => x.Nome.UltimoNome)
                .IsRequired()
                .HasMaxLength(40);

            //Documento
            Property(x => x.Documento.Numero)
                .IsRequired()
                .HasMaxLength(11);

            //Telefone
            Property(x => x.Telefone.Numero)
                .IsRequired()
                .HasMaxLength(20);

            //Endereco
            Property(x => x.Endereco.Uf)
                .IsRequired()
                .HasMaxLength(2);

            Property(x => x.Endereco.Rua)
                .IsRequired()
                .HasMaxLength(40);

            Property(x => x.Endereco.Bairro)
                .IsRequired()
                .HasMaxLength(40);

            Property(x => x.Endereco.Numero)
                .HasMaxLength(10);

            Property(x => x.Endereco.Cidade)
                .IsRequired()
                .HasMaxLength(40);

            Property(x => x.Endereco.Cep)
                .IsRequired()
                .HasMaxLength(8);

            //FuncionarioCargo
            Property(x => x.Cargo.Nome)
                .HasMaxLength(40);

            Property(x => x.Cargo.Descricao)
                .IsRequired()
                .HasMaxLength(40);

            Property(x => x.Cargo.Salario)
                .IsRequired();
        }
    }
}
