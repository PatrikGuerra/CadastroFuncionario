using System;
using System.Collections.Generic;
using System.Linq;
using CadastroFuncionario.Domain.Entities;
using CadastroFuncionario.Domain.Queries;
using CadastroFuncionario.Domain.Repositories;
using CadastroFuncionario.Infra.Persistence.DataContexts;

namespace CadastroFuncionario.Infra.Repositories
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        CadastroFuncionarioDataContext context;

        public FuncionarioRepository(CadastroFuncionarioDataContext context)
        {
            this.context = context;
        }

        public void Criar(Funcionario funcionario)
        {
            context.Funcionario.Add(funcionario);
            context.SaveChanges();
        }

        public void Atualizar(Funcionario funcionario)
        {
            context.Entry<Funcionario>(funcionario).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }

        public bool DocumentoExiste(string documento)
        {
            return context.Funcionario.Any(FuncionarioQueries.GetFuncionarioPorDocumento(documento));
        }

        public Funcionario Get(Guid id)
        {
            return context.Funcionario.FirstOrDefault(FuncionarioQueries.GetFuncionario(id));
        }

        public List<Funcionario> Get()
        {
            return context.Funcionario.ToList();
        }

        public void Deletar(Funcionario funcionario)
        {
            context.Funcionario.Remove(funcionario);
            context.SaveChanges();
        }

        public Funcionario GetPorDocumento(string documento)
        {
            return context.Funcionario.FirstOrDefault(FuncionarioQueries.GetFuncionarioPorDocumento(documento));
        }
    }
}
