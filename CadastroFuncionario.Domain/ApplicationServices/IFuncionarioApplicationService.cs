using System;
using System.Collections.Generic;
using CadastroFuncionario.Domain.Commands;
using CadastroFuncionario.Domain.Entities;
using CadastroFuncionario.Shared.Commands;

namespace CadastroFuncionario.Domain.Services
{
    public interface IFuncionarioApplicationService
    {
        List<Funcionario> Get();
        Funcionario Get(Guid id);
        ICommandResult Create(CreateFuncionarioCommand command);
        ICommandResult Update(EditFuncionarioCommand command);
        ICommandResult Delete(Guid id);
    }
}
