using Microsoft.EntityFrameworkCore;
using Salao.Data.Context;
using Salao.Data.Repository.Interface;
using Salao.Domain.Model;
using System.Linq;

namespace Salao.Data.Repository.Implementations
{
    public class FuncionarioRepository : Repository<Funcionario>, IFuncionarioRepository
    {
        public FuncionarioRepository(SalaoContext context) : base(context) { }

        public override Funcionario FindById(int id)
        {
            return _context.Funcionarios
                .Include(f => f.FuncionarioServico)
                .FirstOrDefault(f => f.Id.Equals(id));
        }
        public Funcionario FindByEnderco(int id)
        {
            return _context.Funcionarios                
                .FirstOrDefault(f => f.EnderecoId.Equals(id));
        }
    }
}
