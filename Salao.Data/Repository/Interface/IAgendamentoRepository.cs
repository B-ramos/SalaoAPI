using Salao.Domain.Model;
using System.Collections.Generic;

namespace Salao.Data.Repository.Interface
{
    public interface IAgendamentoRepository : IRepository<Agendamento>
    {
        public List<Agendamento> FindByIdCliente(int id);
        public List<Agendamento> FindByIdFuncionario(int id);
    }
}
