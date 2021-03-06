using Salao.Domain.Model;

namespace Salao.Data.Repository.Interface
{
    public interface IServicoRepository : IRepository<Servico>
    {
        public Servico FindByName(string nome);
    }
}
