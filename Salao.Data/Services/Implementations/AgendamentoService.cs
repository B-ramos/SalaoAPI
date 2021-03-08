using Salao.Data.Repository.Interface;
using Salao.Data.Services.Interface;
using Salao.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Salao.Data.Services.Implementations
{
    public class AgendamentoService : IAgendamentoService
    {
        private readonly IAgendamentoRepository _repoAgendamento;
        private readonly IClienteRepository _repoCliente;
        private readonly IServicoRepository _repoServico;
        private readonly IFuncionarioRepository _repoFuncionario;
        private readonly IFuncionarioServicoRepository _repoFuncionarioServico;

        public AgendamentoService(IAgendamentoRepository repoAgendamento,
                                  IClienteRepository repoCliente,
                                  IServicoRepository repoServico,
                                  IFuncionarioRepository repoFuncionario,
                                  IFuncionarioServicoRepository repoFuncionarioServico)
        {
            _repoAgendamento = repoAgendamento;            
            _repoCliente = repoCliente;            
            _repoServico = repoServico;            
            _repoFuncionario = repoFuncionario;
            _repoFuncionarioServico = repoFuncionarioServico;
        }

        public List<Agendamento> FindAll()
        {
            return _repoAgendamento.FindAll();
        }

        public List<Agendamento> FindByIdCliente(int id)
        {
            var cliente = _repoCliente.FindById(id);
            if (cliente == null)
                return null;

            return _repoAgendamento.FindByIdCliente(id);
        }

        public List<Agendamento> FindByIdFuncionario(int id)
        {
            var funcionario = _repoFuncionario.FindById(id);
            if (funcionario == null)
                return null;

            return _repoAgendamento.FindByIdFuncionario(id);
        }


        public Agendamento Create(Agendamento agendamento)
        {            
            var cliente = _repoCliente.FindById(agendamento.ClienteId);
            var servico = _repoServico.FindById(agendamento.ServicoId);
            if (cliente == null || servico == null)
                return null;
           
            // Adiciona o funcionário que realiza o serviço solicitado.
            var funcionarioServico = _repoFuncionarioServico.FindByIdServico(servico.Id).FirstOrDefault();
            if (funcionarioServico == null)
                return null;

            agendamento.Funcionario = funcionarioServico.Funcionario;
            agendamento.DataTermino = agendamento.Data.Value.AddMinutes(servico.MinutosParaExecucao);

            var agenda = _repoAgendamento.FindAll();
            
            if(agenda.Count < 1)
                return _repoAgendamento.Create(agendamento);

            DateTime dataTerminoParaAgendar = agendamento.Data.Value.AddMinutes(servico.MinutosParaExecucao);

            if (agenda.Any(a => a.DataTermino >= agendamento.Data && a.Data <= dataTerminoParaAgendar 
            && a.Funcionario == funcionarioServico.Funcionario))
            {
                return null;
            }

            return _repoAgendamento.Create(agendamento);
        }
        
        public Agendamento Update(Agendamento novoAgendamento)
        {
            var agendamento = _repoAgendamento.FindById(novoAgendamento.Id);

            if (agendamento == null)
                return null;

            return _repoAgendamento.Update(agendamento, novoAgendamento);
        }

        public bool Delete(int id)
        {
            var agendamento = _repoAgendamento.FindById(id);

            if (agendamento == null)
                return false;

            _repoAgendamento.Delete(agendamento);
            return true;
        }

        
    }
}
