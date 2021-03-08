using Microsoft.EntityFrameworkCore;
using Salao.Data.Context;
using Salao.Data.Repository.Interface;
using Salao.Domain.Model;
using System.Collections.Generic;
using System.Linq;

namespace Salao.Data.Repository.Implementations
{
    public class AgendamentoRepository : Repository<Agendamento>, IAgendamentoRepository
    {
        public AgendamentoRepository(SalaoContext context) : base(context) { }

        public override List<Agendamento> FindAll()
        {

            return _context.Agendamentos
                           .Include(a => a.Cliente)
                           .Include(a => a.Servico)
                           .Include(a => a.Funcionario)                           
                           .ToList();
        }

        public List<Agendamento> FindByIdCliente(int id)
        {
            return _context.Agendamentos
                           .Where(a => a.ClienteId.Equals(id))
                           .Include(a => a.Cliente)
                           .Include(a => a.Servico)
                           .Include(a => a.Funcionario)                           
                           .ToList();
        }

        public List<Agendamento> FindByIdFuncionario(int id)
        {
            return _context.Agendamentos
                           .Where(a => a.FuncionarioId.Equals(id))
                           .Include(a => a.Cliente)
                           .Include(a => a.Servico)
                           .Include(a => a.Funcionario)
                           .ToList();
        }

        
    }
}
