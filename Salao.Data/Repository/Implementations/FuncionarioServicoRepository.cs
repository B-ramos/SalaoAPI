using Salao.Data.Context;
using Salao.Data.Repository.Interface;
using Salao.Domain.Model;

namespace Salao.Data.Repository.Implementations
{
    public class FuncionarioServicoRepository : Repository<FuncionarioServico>, IFuncionarioServicoRepository
    {
        public FuncionarioServicoRepository(SalaoContext context) : base(context) { }
        
    }
}
