using Salao.Data.Context;
using Salao.Data.Repository.Interface;
using Salao.Domain.Model;
using System.Linq;

namespace Salao.Data.Repository.Implementations
{
    public class ServicoRepository : Repository<Servico>, IServicoRepository
    {
        public ServicoRepository(SalaoContext context) : base(context) { }

        public Servico FindByName(string nome)
        {
            return _context.Servicos.FirstOrDefault(s => s.Nome.ToUpper() == nome.ToUpper());
                      
        }
    }
}
