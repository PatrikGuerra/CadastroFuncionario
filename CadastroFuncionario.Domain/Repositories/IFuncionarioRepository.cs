using System;
using System.Collections.Generic;
using CadastroFuncionario.Domain.Entities;

namespace CadastroFuncionario.Domain.Repositories
{
    public interface IFuncionarioRepository
    {
        List<Funcionario> Get();
        Funcionario Get(Guid id);
        Funcionario GetPorDocumento(string documento);
        bool DocumentoExiste(string documento);
        void Criar(Funcionario funcionario);
        void Atualizar(Funcionario funcionario);
        void Deletar(Funcionario funcionario);
    }
}
