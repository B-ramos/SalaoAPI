using Microsoft.EntityFrameworkCore;
using Salao.Data.Context;
using Salao.Data.Repository.Interface;
using Salao.Domain.Model;
using System.Collections.Generic;
using System.Linq;

namespace Salao.Data.Repository.Implementations
{
    public class FuncionarioServicoRepository : Repository<FuncionarioServico>, IFuncionarioServicoRepository
    {
        public FuncionarioServicoRepository(SalaoContext context) : base(context) { }

        public List<FuncionarioServico> FindByIdServico(int id)
        {
            return _context.FuncionariosServicos
                           .Include(fs => fs.Funcionario)
                           .Where(f => f.ServicoId.Equals(id))
                           .ToList();          
        }
        
        public List<FuncionarioServico> FindByIdFuncionario(int id)
        {
            return _context.FuncionariosServicos                          
                           .Include(fs => fs.Servico)
                           .Where(fs => fs.FuncionarioId.Equals(id))
                           .ToList();
        }

        public FuncionarioServico FindByIdFuncionarioServico(int funcionarioId, int servicoId)
        {
            return _context.FuncionariosServicos
                           .FirstOrDefault(fs => fs.FuncionarioId.Equals(funcionarioId) &&
                                                 fs.ServicoId.Equals(servicoId));
        }

       
    }
}
