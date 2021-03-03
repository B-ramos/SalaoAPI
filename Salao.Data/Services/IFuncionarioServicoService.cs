using Salao.Domain.Model;
using System.Collections.Generic;

namespace Salao.Data.Services
{
    public interface IFuncionarioServicoService
    {
        List<FuncionarioServico> FindAll();
        FuncionarioServico FindbyId(int id);
        FuncionarioServico Create(FuncionarioServico funcionarioServico);
        FuncionarioServico Update(FuncionarioServico funcionarioServico);
        void Delete(int id);        
    }
}
