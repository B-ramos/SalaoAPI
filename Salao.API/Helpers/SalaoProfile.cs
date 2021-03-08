using AutoMapper;
using Salao.API.Dto;
using Salao.Domain.Model;

namespace Salao.API.Helpers
{
    public class SalaoProfile : Profile
    {
        public SalaoProfile()
        {
            CreateMap<Cliente, ClienteDto>();
            CreateMap<Funcionario, FuncionarioDto>();
            CreateMap<Servico, ServicoDto>();
            CreateMap<FuncionarioServico, FuncionarioServicoDto>();

            CreateMap<Agendamento, AgendamentosDto>()
            .ForPath(dest => dest.Agendamento.Id, opt => opt.MapFrom(src => src.Id))
            .ForPath(dest => dest.Agendamento.Status, opt => opt.MapFrom(src => src.Status))
            .ForPath(dest => dest.Agendamento.Data, opt => opt.MapFrom(src => src.Data))
            .ForPath(dest => dest.Agendamento.DataTermino, opt => opt.MapFrom(src => src.DataTermino))
            .ForPath(dest => dest.Agendamento.Anotacao, opt => opt.MapFrom(src => src.Anotacao));

            //.ForPath(dest => dest.Cliente.Id, opt => opt.MapFrom(src => src.Cliente.Id))
            //.ForPath(dest => dest.Cliente.Nome, opt => opt.MapFrom(src => src.Cliente.Nome))
            //.ForPath(dest => dest.Cliente.Telefone, opt => opt.MapFrom(src => src.Cliente.Telefone))
            //.ForPath(dest => dest.Funcionario.Id, opt => opt.MapFrom(src => src.Funcionario.Id))
            //.ForPath(dest => dest.Funcionario.Nome, opt => opt.MapFrom(src => src.Funcionario.Nome))
            //.ForPath(dest => dest.Funcionario.Telefone, opt => opt.MapFrom(src => src.Funcionario.Telefone))
            //.ForPath(dest => dest.Servico.Id, opt => opt.MapFrom(src => src.Servico.Id))
            //.ForPath(dest => dest.Servico.Nome, opt => opt.MapFrom(src => src.Servico.Nome))
            //.ForPath(dest => dest.Servico.MinutosParaExecucao, opt => opt.MapFrom(src => src.Servico.MinutosParaExecucao))
            //.ForPath(dest => dest.Servico.Preco, opt => opt.MapFrom(src => src.Servico.Preco))



        }
    }
}
