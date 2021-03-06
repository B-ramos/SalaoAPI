using Salao.Data.Context;
using Salao.Data.Repository.Interface;
using Salao.Domain.Model;
using System.Linq;

namespace Salao.Data.Repository.Implementations
{
    public class FuncionarioRepository : Repository<Funcionario>, IFuncionarioRepository
    {
        public FuncionarioRepository(SalaoContext context) : base(context) { }

        public Funcionario FindByEnderco(int id)
        {
            return _context.Funcionarios.Where(f => f.EnderecoId.Equals(id)).FirstOrDefault();

        }
    }
}
