using System;
using System.Collections.Generic;
using CadastroFuncionario.Domain.Commands;
using CadastroFuncionario.Domain.Entities;
using CadastroFuncionario.Domain.Repositories;
using CadastroFuncionario.Domain.Services;
using CadastroFuncionario.Domain.ValueObjects;
using CadastroFuncionario.Shared.Commands;

namespace CadastroFuncionario.ApplicationService
{
    public class FuncionarioApplicationService : IFuncionarioApplicationService
    {
        IFuncionarioRepository repository;

        public FuncionarioApplicationService(IFuncionarioRepository repository)
        {
            this.repository = repository;
        }

        public ICommandResult Create(CreateFuncionarioCommand command)
        {
            Nome nome = new Nome(command.NomePrimeiro, command.NomeMeio, command.NomeUltimo);
            Documento documento = new Documento(command.NumeroDocumento);
            Telefone telefone = new Telefone(command.NumeroTelefone);
            Endereco endereco = new Endereco(command.EnderecoRua, command.EnderecoBairro, command.EnderecoNumero, command.EnderecoCep, command.EnderecoCidade, command.EnderecoUf);
            Cargo cargo = new Cargo(command.CargoNome, command.CargoDescricao, command.CargoSalario);

            Funcionario funcionario = new Funcionario(nome, documento, telefone, endereco, cargo);

            if (funcionario.Invalid)
            {
                return new CommandResult(funcionario, false, "Não foi possível inserir o funcionário.");
            }

            if (this.repository.DocumentoExiste(funcionario.Documento.Numero))
            {
                return new CommandResult(funcionario, false, "Não foi possível inserir o funcionário. Documento já vinculado.");
            }

            this.repository.Criar(funcionario);

            return new CommandResult(true, "Funcionário cadastrado com sucesso.");
        }

        public ICommandResult Delete(Guid id)
        {
            Funcionario funcionario = this.repository.Get(id);

            if (funcionario == null)
            {
                return new CommandResult(true, "O funcionário não foi localizado.");
            }

            this.repository.Deletar(funcionario);

            return new CommandResult(true, "O funcionário foi removido.");
        }

        public List<Funcionario> Get()
        {
            return this.repository.Get();
        }

        public Funcionario Get(Guid id)
        {
            return this.repository.Get(id);
        }

        public ICommandResult Update(EditFuncionarioCommand command)
        {
            Funcionario funcionario = repository.Get(command.Id);

            if (funcionario == null)
            {
                return new CommandResult(funcionario, false, "Não foi possivel atualizar. Funcionario não localizado.");
            }

            Funcionario funcionarioDocumento = repository.GetPorDocumento(command.NumeroDocumento);

            if (funcionarioDocumento != null && !funcionarioDocumento.Id.Equals(funcionario.Id))
            {
                return new CommandResult(funcionario, false, "O documento informado já está em uso por outro funcionário.");
            }

            Nome nome = new Nome(command.NomePrimeiro, command.NomeMeio, command.NomeUltimo);
            Documento documento = new Documento(command.NumeroDocumento);
            Telefone telefone = new Telefone(command.NumeroTelefone);
            Endereco endereco = new Endereco(command.EnderecoRua, command.EnderecoBairro, command.EnderecoNumero, command.EnderecoCep, command.EnderecoCidade, command.EnderecoUf);
            Cargo cargo = new Cargo(command.CargoNome, command.CargoDescricao, command.CargoSalario);

            funcionario.Update(nome, documento, telefone, endereco, cargo);

            if (funcionario.Invalid)
            {
                return new CommandResult(funcionario, false, "Não foi possível atualizar o funcionário.");
            }

            this.repository.Atualizar(funcionario);

            return new CommandResult(true, "Funcionário atualizado com sucesso.");
        }
    }
}
