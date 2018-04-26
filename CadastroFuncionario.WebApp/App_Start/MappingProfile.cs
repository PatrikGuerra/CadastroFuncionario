using AutoMapper;

namespace CadastroFuncionario.WebApp
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Domain.Entities.Funcionario, Dtos.FuncionarioDTO>()
                .ForMember(x => x.CargoDescricao, map => map.MapFrom(m => m.Cargo.Descricao))
                .ForMember(x => x.CargoNome, map => map.MapFrom(m => m.Cargo.Nome))
                .ForMember(x => x.CargoSalario, map => map.MapFrom(m => m.Cargo.Salario))

                .ForMember(x => x.EnderecoBairro, map => map.MapFrom(m => m.Endereco.Bairro))
                .ForMember(x => x.EnderecoCep, map => map.MapFrom(m => m.Endereco.Cep))
                .ForMember(x => x.EnderecoCidade, map => map.MapFrom(m => m.Endereco.Cidade))
                .ForMember(x => x.EnderecoNumero, map => map.MapFrom(m => m.Endereco.Numero))
                .ForMember(x => x.EnderecoRua, map => map.MapFrom(m => m.Endereco.Rua))
                .ForMember(x => x.EnderecoUf, map => map.MapFrom(m => m.Endereco.Uf))

                .ForMember(x => x.NomeMeio, map => map.MapFrom(m => m.Nome.MeioNome))
                .ForMember(x => x.NomePrimeiro, map => map.MapFrom(m => m.Nome.PrimeiroNome))
                .ForMember(x => x.NomeUltimo, map => map.MapFrom(m => m.Nome.UltimoNome))

                .ForMember(x => x.NumeroDocumento, map => map.MapFrom(m => m.Documento.Numero))
                .ForMember(x => x.NumeroTelefone, map => map.MapFrom(m => m.Telefone.Numero));
        }
    }
}