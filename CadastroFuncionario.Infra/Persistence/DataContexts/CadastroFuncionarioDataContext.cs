using System.Data.Entity;
using CadastroFuncionario.Domain.Entities;
using CadastroFuncionario.Domain.ValueObjects;
using CadastroFuncionario.Infra.Persistence.Map;

namespace CadastroFuncionario.Infra.Persistence.DataContexts
{
    public class CadastroFuncionarioDataContext : DbContext
    {
        public CadastroFuncionarioDataContext() : base("CadFConnectionString")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CadastroFuncionarioDataContext, Migrations.Configuration>());
        }

        public DbSet<Funcionario> Funcionario { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new FuncionarioMap());

            modelBuilder.ComplexType<Documento>().Property(x => x.Numero).HasColumnName("Documento");

            modelBuilder.ComplexType<Endereco>().Property(x => x.Uf).HasColumnName("EnderecoUf");
            modelBuilder.ComplexType<Endereco>().Property(x => x.Rua).HasColumnName("EnderecoRua");
            modelBuilder.ComplexType<Endereco>().Property(x => x.Numero).HasColumnName("EnderecoNumero");
            modelBuilder.ComplexType<Endereco>().Property(x => x.Cidade).HasColumnName("EnderecoCidade");
            modelBuilder.ComplexType<Endereco>().Property(x => x.Cep).HasColumnName("EnderecoCep");
            modelBuilder.ComplexType<Endereco>().Property(x => x.Bairro).HasColumnName("EnderecoBairro");

            modelBuilder.ComplexType<Cargo>().Property(x => x.Nome).HasColumnName("Cargo");
            modelBuilder.ComplexType<Cargo>().Property(x => x.Descricao).HasColumnName("DescricaoCargo");
            modelBuilder.ComplexType<Cargo>().Property(x => x.Salario).HasColumnName("Salario");

            modelBuilder.ComplexType<Nome>().Property(x => x.MeioNome).HasColumnName("MeioNome");
            modelBuilder.ComplexType<Nome>().Property(x => x.PrimeiroNome).HasColumnName("PrimeiroNome");
            modelBuilder.ComplexType<Nome>().Property(x => x.UltimoNome).HasColumnName("UltimoNome");

            modelBuilder.ComplexType<Telefone>().Property(x => x.Numero).HasColumnName("Telefone");
        }
    }
}
