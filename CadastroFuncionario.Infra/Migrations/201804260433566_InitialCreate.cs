namespace CadastroFuncionario.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Funcionario",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        PrimeiroNome = c.String(nullable: false, maxLength: 40),
                        MeioNome = c.String(maxLength: 40),
                        UltimoNome = c.String(nullable: false, maxLength: 40),
                        Documento = c.String(nullable: false, maxLength: 11),
                        Telefone = c.String(nullable: false, maxLength: 20),
                        EnderecoRua = c.String(nullable: false, maxLength: 40),
                        EnderecoBairro = c.String(nullable: false, maxLength: 40),
                        EnderecoNumero = c.String(maxLength: 10),
                        EnderecoCep = c.String(nullable: false, maxLength: 8),
                        EnderecoCidade = c.String(nullable: false, maxLength: 40),
                        EnderecoUf = c.String(nullable: false, maxLength: 2),
                        Cargo = c.String(maxLength: 40),
                        DescricaoCargo = c.String(nullable: false, maxLength: 40),
                        Salario = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Funcionario");
        }
    }
}
