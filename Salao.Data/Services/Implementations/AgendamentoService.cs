using Salao.Data.Repository.Interface;
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

        public Agendamento FindbyId(int id)
        {
            return _repo.FindById(id);
        }

        public Agendamento Create(Agendamento agendamento)
        {
            return _repo.Create(agendamento);
        }
        
        public Agendamento Update(Agendamento agendamento)
        {
            return _repo.Update(agendamento);
        }

        public void Delete(int id)
        {
            _repo.Delete(id);
        }
    }
}
