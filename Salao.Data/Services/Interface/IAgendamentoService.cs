using Salao.Domain.Model;
using System.Collections.Generic;

namespace Salao.Data.Services.Interface
{
    public interface IAgendamentoService
    {
        List<Agendamento> FindAll();
        Agendamento FindById(int id);
        Agendamento Create(Agendamento agendamento);
        Agendamento Update(Agendamento agendamento);
        bool Delete(int id);        
    }
}
