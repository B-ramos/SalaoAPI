using Microsoft.EntityFrameworkCore;
using Salao.Data.Context;
using Salao.Data.Repository.Interface;
using Salao.Domain.Model;
using System.Linq;

namespace Salao.Data.Repository.Implementations
{
    public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(SalaoContext context) : base(context) { }

       
        public Endereco FindByCep(Endereco endereco)
        {
           
            return _context.Enderecos.FirstOrDefault(x => x.Numero == endereco.Numero && x.CEP == endereco.CEP);
                       
        }
    }
}
