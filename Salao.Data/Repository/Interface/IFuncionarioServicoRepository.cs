using Salao.Domain.Model;
using System.Collections.Generic;

namespace Salao.Data.Repository.Interface
{
    public interface IFuncionarioServicoRepository : IRepository<FuncionarioServico>
    {
        public FuncionarioServico FindByIdFuncionarioServico(int funcionarioId, int servicoId);

        public List<FuncionarioServico> FindByIdServico(int id);

        public List<FuncionarioServico> FindByIdFuncionario(int id);
    }
}
