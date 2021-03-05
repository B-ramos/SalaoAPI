using Salao.Data.Repository.Interface;
using Salao.Data.Services.Interface;
using Salao.Domain.Model;
using System.Collections.Generic;

namespace Salao.Data.Services.Implementations
{
    public class AgendamentoService : IAgendamentoService
    {
        private readonly IAgendamentoRepository _repo;
        
        public AgendamentoService(IAgendamentoRepository repo)
        {
            _repo = repo;            
        }

        public List<Agendamento> FindAll()
        {
            return _repo.FindAll();
        }

        public Agendamento FindById(int id)
        {
            return _repo.FindById(id);
        }

        public Agendamento Create(Agendamento agendamento)
        {
            return _repo.Create(agendamento);
        }
        
        public Agendamento Update(Agendamento novoAgendamento)
        {
            var agendamento = _repo.FindById(novoAgendamento.Id);

            if (agendamento == null)
                return null;

            return _repo.Update(agendamento, novoAgendamento);
        }

        public bool Delete(int id)
        {
            var agendamento = _repo.FindById(id);

            if (agendamento == null)
                return false;

            _repo.Delete(agendamento);
            return true;
        }
    }
}
