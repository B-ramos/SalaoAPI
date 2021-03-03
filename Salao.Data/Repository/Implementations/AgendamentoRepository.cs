using Salao.Data.Context;
using Salao.Data.Repository.Interface;
using Salao.Domain.Model;

namespace Salao.Data.Repository.Implementations
{
    public class AgendamentoRepository : Repository<Agendamento>, IAgendamentoRepository
    {
        public AgendamentoRepository(SalaoContext context) : base(context) { }
    }
}
