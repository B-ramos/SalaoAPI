using Salao.Data.Context;
using Salao.Data.Repository.Interface;
using Salao.Domain.Model;

namespace Salao.Data.Repository.Implementations
{
    public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(SalaoContext context) : base(context) { }
        
    }
}
