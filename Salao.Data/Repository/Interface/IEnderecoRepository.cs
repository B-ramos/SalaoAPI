using Salao.Domain.Model;

namespace Salao.Data.Repository.Interface
{
    public interface IEnderecoRepository : IRepository<Endereco>
    {
        public Endereco FindByCep(Endereco enderco);
    }
}
