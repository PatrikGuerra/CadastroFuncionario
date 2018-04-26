using System;
using System.Linq.Expressions;
using CadastroFuncionario.Domain.Entities;

namespace CadastroFuncionario.Domain.Queries
{
    public static class FuncionarioQueries
    {
        public static Expression<Func<Funcionario, bool>> GetFuncionarioPorDocumento(string documento)
        {
            return x => x.Documento.Numero.Equals(documento);
        }

        public static Expression<Func<Funcionario, bool>> GetFuncionario(Guid id)
        {
            return x => x.Id.Equals(id);
        }
    }
}
