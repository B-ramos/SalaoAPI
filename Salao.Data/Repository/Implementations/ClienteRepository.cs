using Salao.Data.Context;
using Salao.Data.Repository.Interface;
using Salao.Domain.Model;

namespace Salao.Data.Repository.Implementations
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(SalaoContext context) : base(context) { }
    }
}
