using CadastroFuncionario.ApplicationService;
using CadastroFuncionario.Domain.Repositories;
using CadastroFuncionario.Domain.Services;
using CadastroFuncionario.Infra.Persistence.DataContexts;
using CadastroFuncionario.Infra.Repositories;
using Autofac;

namespace CadastroFuncionario.CrossCutting
{
    public static class AutoFacDependencyRegister
    {
        public static void Configure(ContainerBuilder builder)
        {
            builder.RegisterType<FuncionarioApplicationService>().As<IFuncionarioApplicationService>();
            builder.RegisterType<CadastroFuncionarioDataContext>().As<CadastroFuncionarioDataContext>();
            builder.RegisterType<FuncionarioRepository>().As<IFuncionarioRepository>();
        }
    }
}
