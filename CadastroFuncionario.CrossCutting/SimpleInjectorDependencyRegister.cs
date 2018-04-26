using CadastroFuncionario.ApplicationService;
using CadastroFuncionario.Domain.Repositories;
using CadastroFuncionario.Domain.Services;
using CadastroFuncionario.Infra.Persistence.DataContexts;
using CadastroFuncionario.Infra.Repositories;
using SimpleInjector;

namespace CadastroFuncionario.CrossCutting
{
    public class SimpleInjectorDependencyRegister
    {
        public static void Configure(Container container)
        {
            container.Register<CadastroFuncionarioDataContext, CadastroFuncionarioDataContext>();
            container.Register<IFuncionarioRepository, FuncionarioRepository>();
            container.Register<IFuncionarioApplicationService, FuncionarioApplicationService>();
        }
    }
}
