using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using CadastroFuncionario.Domain.Commands;
using CadastroFuncionario.Domain.Entities;
using CadastroFuncionario.Domain.Services;
using CadastroFuncionario.Shared.Commands;
using CadastroFuncionario.WebApp.Dtos;

namespace CadastroFuncionario.WebApp.Controllers
{
    public class FuncionarioController : ApiController
    {
        IFuncionarioApplicationService applicationService;

        public FuncionarioController(IFuncionarioApplicationService applicationService)
        {
            this.applicationService = applicationService;
        }

        [HttpGet]
        [Route("api/funcionarios")]

        public Task<HttpResponseMessage> Get()
        {
            List<Funcionario> funcionarios = this.applicationService.Get();

            List<FuncionarioDTO> dto = AutoMapper.Mapper.Map<List<Funcionario>, List<FuncionarioDTO>>(funcionarios);

            return Task.FromResult<HttpResponseMessage>(Request.CreateResponse(HttpStatusCode.OK, dto));
        }

        [HttpGet]
        [Route("api/funcionarios/{id}")]
        public Task<HttpResponseMessage> Get(string id)
        {
            Funcionario funcionario = this.applicationService.Get(Guid.Parse(id));
            FuncionarioDTO dto = AutoMapper.Mapper.Map<Funcionario, FuncionarioDTO>(funcionario);

            return Task.FromResult<HttpResponseMessage>(Request.CreateResponse(HttpStatusCode.OK, dto));
        }

        [HttpPost]
        [Route("api/funcionarios")]
        public Task<HttpResponseMessage> Post([FromBody]dynamic value)
        {
            var command = new CreateFuncionarioCommand()
            {
                CargoDescricao = (string)value.CargoDescricao,
                CargoNome = (string)value.CargoNome,
                CargoSalario = (decimal)value.CargoSalario,
                EnderecoBairro = (string)value.EnderecoBairro,
                EnderecoCep = (string)value.EnderecoCep,
                EnderecoCidade = (string)value.EnderecoCidade,
                EnderecoNumero = (string)value.EnderecoNumero,
                EnderecoRua = (string)value.EnderecoRua,
                EnderecoUf = (string)value.EnderecoUf,
                NomeMeio = (string)value.NomeMeio,
                NomePrimeiro = (string)value.NomePrimeiro,
                NomeUltimo = (string)value.NomeUltimo,
                NumeroDocumento = (string)value.NumeroDocumento,
                NumeroTelefone = (string)value.NumeroTelefone
            };

            ICommandResult retorno = applicationService.Create(command);
            return Task.FromResult<HttpResponseMessage>(Request.CreateResponse(HttpStatusCode.OK, retorno));
        }

        [HttpPut]
        [Route("api/funcionarios/{id}")]
        public Task<HttpResponseMessage> Put(string id, [FromBody]dynamic value)
        {
            var command = new EditFuncionarioCommand()
            {
                Id = Guid.Parse(id),
                CargoDescricao = (string)value.CargoDescricao,
                CargoNome = (string)value.CargoNome,
                CargoSalario = (decimal)value.CargoSalario,
                EnderecoBairro = (string)value.EnderecoBairro,
                EnderecoCep = (string)value.EnderecoCep,
                EnderecoCidade = (string)value.EnderecoCidade,
                EnderecoNumero = (string)value.EnderecoNumero,
                EnderecoRua = (string)value.EnderecoRua,
                EnderecoUf = (string)value.EnderecoUf,
                NomeMeio = (string)value.NomeMeio,
                NomePrimeiro = (string)value.NomePrimeiro,
                NomeUltimo = (string)value.NomeUltimo,
                NumeroDocumento = (string)value.NumeroDocumento,
                NumeroTelefone = (string)value.NumeroTelefone
            };

            ICommandResult retorno = applicationService.Update(command);
            return Task.FromResult<HttpResponseMessage>(Request.CreateResponse(HttpStatusCode.OK, retorno));
        }

        [HttpDelete]
        [Route("api/funcionarios/{id}")]
        public Task<HttpResponseMessage> Delete(string id)
        {
            ICommandResult retorno = applicationService.Delete(Guid.Parse(id));
            return Task.FromResult<HttpResponseMessage>(Request.CreateResponse(HttpStatusCode.OK, retorno));
        }
    }
}