using Salao.Data.Context;
using Salao.Data.Repository.Interface;
using Salao.Domain.Model;

namespace Salao.Data.Repository.Implementations
{
    public class ServicoRepository : Repository<Servico>, IServicoRepository
    {
        public ServicoRepository(SalaoContext context) : base(context) { }
        
    }
}
